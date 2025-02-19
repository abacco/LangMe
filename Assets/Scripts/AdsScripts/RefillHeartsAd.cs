using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RefillHeartsAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _refillHeartsAdButton;
    [SerializeField] TMP_Text userLifesTxt;

    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
        // fai refactor magari
        if (GameManager.Instance.userLifes >= 10)
        {
            GameManager.Instance.userLifes = 10;
            GameManager.Instance.SaveData();
            userLifesTxt.text = 10.ToString();
        }
        if (GameManager.Instance.userLifes < 0)
        {
            GameManager.Instance.userLifes = 0;
            GameManager.Instance.SaveData();
            userLifesTxt.text = 0.ToString();
        }
        // Disable the button until the ad is ready to show:
        _refillHeartsAdButton.interactable = false;
    }

    // Call this public method when you want to get an ad ready to show.
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
#if UNITY_EDITOR             
        _adUnitId = "Rewarded_Android"; //Only for testing the functionality in the Editor
#endif
        //if (_adUnitId == null) { _adUnitId = "Rewarded_Android";  }
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            _refillHeartsAdButton.onClick.AddListener(ShowAd);
            // Enable the button for users to click:
            _refillHeartsAdButton.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAd()
    {
        // Disable the button:
        _refillHeartsAdButton.interactable = false;
        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("REFILL HEARTS --------------- Unity Ads Rewarded Ad Completed");
            // Grant a reward.

            // la reward � + 3 cuori!! Fai l'animazione che fa capire che te pigliat 3 cuori
            if (GameManager.Instance.userLifes >= 10) {
                
                GameManager.Instance.userLifes = 10;
                userLifesTxt.text = 10.ToString();
                GameManager.Instance.SaveData();
            }
            if (GameManager.Instance.userLifes < 0) { 
                GameManager.Instance.userLifes = 0;
                userLifesTxt.text = 0.ToString();
                GameManager.Instance.SaveData();
            }
            if (GameManager.Instance.userLifes >= 0 && GameManager.Instance.userLifes < 10)
            {
                GameManager.Instance.userLifes += 3;
                if (GameManager.Instance.userLifes >= 10)
                {

                    GameManager.Instance.userLifes = 10;
                    userLifesTxt.text = 10.ToString();
                    GameManager.Instance.SaveData();
                }
                else {
                    userLifesTxt.text = GameManager.Instance.userLifes.ToString();
                    GameManager.Instance.SaveData();
                }
                Advertisement.Load(_adUnitId, this);
            }
            else
            {
                Debug.Log("Life at max!!!!!!!");
                Advertisement.Load(_adUnitId, this);
            }
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        _refillHeartsAdButton.onClick.RemoveAllListeners();
    }
}
