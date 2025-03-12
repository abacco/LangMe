using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class ShowAdOnStart : MonoBehaviour
{
    [SerializeField]
    InterstitialAdExample interstitialAdExample;
    void Start()
    {
        // funziona
        interstitialAdExample.LoadAd();
        StartCoroutine(ShowAdOnStartCoroutine());
    }

    public IEnumerator ShowAdOnStartCoroutine()
    {
        yield return new WaitForEndOfFrame();
        interstitialAdExample.LoadAd();
        interstitialAdExample.ShowAd();
    }
}
