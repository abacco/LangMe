using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image image1; // Assegna la prima immagine
    public Image image2; // Assegna la seconda immagine
    public Text textElement; // Assegna il testo
    public float fadeDuration = 1f; // Durata del fade (in secondi)
    public float visibleDuration = 3f; // Tempo visibile senza fade

    private void Start()
    {
        // Avvia l'animazione di fade per tutte e tre gli elementi
        StartCoroutine(FadeSequence());
    }

    private IEnumerator FadeSequence()
    {
        // Effetto fadeIn e fadeOut per image1
        yield return StartCoroutine(FadeIn(image1, image2, textElement));
        yield return new WaitForSeconds(visibleDuration);
        yield return StartCoroutine(FadeOut(image1, image2, textElement));

        yield return StartCoroutine(FadeIn(image1, image2, textElement));
        yield return new WaitForSeconds(visibleDuration);
        yield return StartCoroutine(FadeOut(image1, image2, textElement));

        yield return StartCoroutine(FadeIn(image1, image2, textElement));
        yield return new WaitForSeconds(visibleDuration);
        yield return StartCoroutine(FadeOut(image1, image2, textElement));

        yield return StartCoroutine(FadeIn(image1, image2, textElement));
    }

    private IEnumerator FadeIn(Graphic uiElement, Graphic uiElement2, Graphic uiElement3)
    {
        Color originalColor = uiElement.color;
        Color originalColor2 = uiElement2.color;
        Color originalColor3 = uiElement3.color;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            uiElement.color = new Color(originalColor.r, originalColor.g, originalColor.b, normalizedTime);
            uiElement2.color = new Color(originalColor2.r, originalColor2.g, originalColor2.b, normalizedTime);
            uiElement3.color = new Color(originalColor3.r, originalColor3.g, originalColor3.b, normalizedTime);
            yield return null;
        }
        uiElement.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // Fine fadeIn
        uiElement2.color = new Color(originalColor2.r, originalColor2.g, originalColor2.b, 1f); // Fine fadeIn
        uiElement3.color = new Color(originalColor3.r, originalColor3.g, originalColor3.b, 1f); // Fine fadeIn
    }

    private IEnumerator FadeOut(Graphic uiElement, Graphic uiElement2, Graphic uiElement3)
    {
        Color originalColor = uiElement.color;
        Color originalColor2 = uiElement2.color;
        Color originalColor3 = uiElement3.color;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            uiElement.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f - normalizedTime);
            uiElement2.color = new Color(originalColor2.r, originalColor2.g, originalColor2.b, 1f - normalizedTime);
            uiElement3.color = new Color(originalColor3.r, originalColor3.g, originalColor3.b, 1f - normalizedTime);
            yield return null;
        }
        uiElement.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Fine fadeOut
        uiElement2.color = new Color(originalColor2.r, originalColor2.g, originalColor2.b, 0f); // Fine fadeOut
        uiElement3.color = new Color(originalColor3.r, originalColor3.g, originalColor3.b, 0f); // Fine fadeOut
    }
}
