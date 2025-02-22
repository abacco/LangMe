using System.Collections;
using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    public float bounceHeight = 50f;  // Quanto si sposta in alto
    public float bounceTime = 0.5f;   // Tempo per rimbalzare su e giù
    public int bounces = 3;           // Numero di rimbalzi

    private Vector3 initialPosition;

    private void OnEnable()
    {
        initialPosition = transform.position; // Memorizza la posizione iniziale
        StartCoroutine(Bounce());
    }

    private IEnumerator Bounce()
    {
        for (int i = 0; i < bounces; i++)
        {
            yield return MoveTo(initialPosition + Vector3.up * bounceHeight, bounceTime / 2);
            yield return MoveTo(initialPosition, bounceTime / 2);
            bounceHeight *= 0.5f; // Ogni rimbalzo diventa più piccolo
        }
    }

    private IEnumerator MoveTo(Vector3 target, float duration)
    {
        float elapsed = 0;
        Vector3 start = transform.position;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
}
