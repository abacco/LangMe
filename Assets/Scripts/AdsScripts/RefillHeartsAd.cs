using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RefillHeartsAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] ExerciseLogicScript exLogicScript; // to handle userLifes;
    [SerializeField] Button _refillHeartsAdButton;
    [SerializeField] Text userLifesTxt;

    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms

    void Awake()
    {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
        GameManager.Instance.LoadData();
        GameManager.Instance.GameManagerDebugLogData();
        if (GameManager.Instance.userLifes >= 10)
        {
            GameManager.Instance.userLifes = 10;
            if(exLogicScript != null)
            {
                exLogicScript.userLifes = 10;
            }
            GameManager.Instance.SaveData();
            userLifesTxt.text = 10.ToString();
        }
        if (GameManager.Instance.userLifes < 0)
        {
            GameManager.Instance.userLifes = 0;
            if (exLogicScript != null)
            {
                exLogicScript.userLifes = 0;
            }
            GameManager.Instance.SaveData();
            userLifesTxt.text = 0.ToString();
        } 
        //_refillHeartsAdButton.interactable = false;
        userLifesTxt.text = GameManager.Instance.userLifes.ToString();
        if (SceneManager.GetActiveScene().name.Equals("7 - Home"))
        {
            _refillHeartsAdButton.interactable = true;
            exLogicScript = new ExerciseLogicScript();
            exLogicScript.userLifes = GameManager.Instance.userLifes;
        }
    }
    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + _adUnitId);
#if UNITY_EDITOR             
        _adUnitId = "Rewarded_Android"; //Only for testing the functionality in the Editor
#endif
        Advertisement.Load(_adUnitId, this);
    }
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        if (adUnitId.Equals(_adUnitId))
        {
            _refillHeartsAdButton.onClick.RemoveAllListeners(); // Rimuovi eventuali listener esistenti
            _refillHeartsAdButton.onClick.AddListener(ShowAd);
            _refillHeartsAdButton.interactable = true;
        }
    }
    public void ShowAd()
    {
        //_refillHeartsAdButton.interactable = false;
        Advertisement.Show(_adUnitId, this);
    }
    private bool isRewardProcessed = false;
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (isRewardProcessed) return; // Evita esecuzioni duplicate
        isRewardProcessed = true;

        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Ad completato, gestisco la ricompensa.");
            HandleReward();
            UpdateUIAndSave();
            if (!SceneManager.GetActiveScene().name.Equals("7 - Home"))
            {
                ReloadAdIfNeeded();
            }
        }

        isRewardProcessed = false; // Resetta il flag se necessario
    }
    private void HandleReward()
    {
        const int maxLifes = 10;
        const int reward = 3;

        if (exLogicScript.userLifes >= maxLifes)
        {
            SetUserLifes(maxLifes);
        }
        else
        {
            int newLifes = exLogicScript.userLifes + reward;
            SetUserLifes(newLifes > maxLifes ? maxLifes : newLifes);
        }
    }
    private void SetUserLifes(int lifes)
    {
        GameManager.Instance.userLifes = lifes;
        exLogicScript.userLifes = lifes;
        userLifesTxt.text = lifes.ToString();
        Debug.Log($"Updated user lifes: {lifes}");
    }
    private void UpdateUIAndSave()
    {
        GameManager.Instance.SaveData();
        if (SceneManager.GetActiveScene().name.Equals("7 - Home"))
        {
            SetUserLifes(GameManager.Instance.userLifes);
        }
    }
    private void ReloadAdIfNeeded()
    {
        _refillHeartsAdButton.onClick.RemoveAllListeners();
        LoadAd();
    }
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        _refillHeartsAdButton.onClick.RemoveAllListeners();
    }
}
