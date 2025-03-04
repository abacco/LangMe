using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using UnityEngine.UI;

public class BannerManager : MonoBehaviour
{
    public static BannerManager Instance;

    [SerializeField] private string _androidAdUnitId = "Banner_Android";
    [SerializeField] private string _iOSAdUnitId = "Banner_iOS";
    private string _adUnitId = null;

    [SerializeField] private Canvas _hideBannerButton;

    private bool _isBannerVisible = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Rende questo oggetto persistente tra le scene
            _hideBannerButton.transform.SetParent(transform);
            DontDestroyOnLoad(_hideBannerButton);
            Canvas canvas = GetComponentInChildren<Canvas>();
            if (canvas != null)
            {
                canvas.sortingOrder = 1000; // Garantisce che stia sopra gli altri
            }
        }
        else
        {
            Destroy(gameObject);
            return;
        }

#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
        StartCoroutine(ShowAdOnStartCoroutine());
        LoadBanner();
    }
    IEnumerator ShowAdOnStartCoroutine()
    {
        yield return new WaitForEndOfFrame();
        ShowBannerAd();
    }
    public void LoadBanner()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Load(_adUnitId, new BannerLoadOptions
            {
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerError
            });
        }
    }

    private void OnBannerLoaded()
    {
        Debug.Log("Banner Loaded");
        ShowBanner();
    }
    void ShowBannerAd()
    {
        // Set up options to notify the SDK of show events:
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        // Show the loaded Banner Ad Unit:
        Advertisement.Banner.Show(_adUnitId, options);

    }
    private void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }

    public void ShowBanner()
    {
        if (!_isBannerVisible) return;
        Advertisement.Banner.Show(_adUnitId);
        _hideBannerButton.gameObject.SetActive(true);
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
        _isBannerVisible = false;
        _hideBannerButton.gameObject.SetActive(false);
        StartCoroutine(ReShowAd()); // ok
    }

    public void ToggleBanner()
    {
        if (_isBannerVisible)
            HideBanner();
        else
        {
            _isBannerVisible = true;
            ShowBanner();
        }
    }
    IEnumerator ReShowAd()
    {
        yield return new WaitForSeconds(5f);
        _hideBannerButton.gameObject.SetActive(true);
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };
        Advertisement.Banner.Show(_adUnitId, options);
        //_hideBannerButton.gameObject.SetActive(true);
    }
    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }


}
