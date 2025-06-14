using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsInitializerScene7 : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    [SerializeField] ShowTipBtnAds _showtip_ads_button;
    [SerializeField] ShowSolutionAd _showsolution_ads_button;
    [SerializeField] RefillHeartsAd _refillHearts_ads_button;

    [SerializeField] BannerAddExample _banner_ads_button;
    [SerializeField] InterstitialAdExample interstitialAdExample;
    void Awake()
    {
        InitializeAds();
    }

    void OnEnable()
    {
        //if (Advertisement.isInitialized)
        //{
        //    Debug.Log("Reloading ads on scene re-entry...");
        //    _showtip_ads_button.LoadAd();
        //    _showsolution_ads_button.LoadAd();
        //    _refillHearts_ads_button.LoadAd();
        //}
        try
        {
            _showtip_ads_button.LoadAd();
            _showsolution_ads_button.LoadAd();
            _refillHearts_ads_button.LoadAd();
            interstitialAdExample.LoadAd();
            _banner_ads_button.LoadBanner();
        } 
        catch(Exception e)
        {
            Debug.LogWarning("In AdsInitializerScene7 on " + SceneManager.GetActiveScene().name + " some ads are not used");
        }
    }

    public void InitializeAds()
    {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }


    public void OnInitializationComplete()
    {
        try
        {
            _showtip_ads_button.LoadAd();
            _showsolution_ads_button.LoadAd();
            _refillHearts_ads_button.LoadAd();
            interstitialAdExample.LoadAd();
            _banner_ads_button.LoadBanner();
            Debug.Log("Unity Ads initialization complete.");
        } catch(Exception e)
        {
            Debug.LogWarning("In AdsInitializerScene7 on " + SceneManager.GetActiveScene().name + " some ads are not used");
        }

    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}