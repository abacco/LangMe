using System.Collections;
using UnityEngine;

public class ShowAdOnStart : MonoBehaviour
{
    [SerializeField]
    InterstitialAdExample interstitialAdExample;
    void Start()
    {
        // funziona
        StartCoroutine(ShowAdOnStartCoroutine());
    }

    IEnumerator ShowAdOnStartCoroutine()
    {
        yield return new WaitForEndOfFrame();
        interstitialAdExample.ShowAd();
    }
}
