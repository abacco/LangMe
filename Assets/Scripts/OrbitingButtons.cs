using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingButtons : MonoBehaviour
{
    public RectTransform centerButton; // Il pulsante centrale
    public RectTransform[] orbitingButtons; // I pulsanti che orbitano
    public float orbitRadius = 400f; // Raggio dell'orbita
    public float orbitSpeed = 30f; // Velocità di rotazione

    private float[] angles; // Per tenere traccia degli angoli dei pulsanti

    void Start()
    {
        angles = new float[orbitingButtons.Length];

        // Distribuisce equamente i pulsanti attorno al centro
        for (int i = 0; i < orbitingButtons.Length; i++)
        {
            angles[i] = i * (360f / orbitingButtons.Length);
        }
    }

    void Update()
    {
        for (int i = 0; i < orbitingButtons.Length; i++)
        {
            // Aggiorna l'angolo con il tempo per creare il movimento orbitale
            angles[i] += orbitSpeed * Time.deltaTime;

            // Converte l'angolo in radianti
            float radians = angles[i] * Mathf.Deg2Rad;

            // Calcola la nuova posizione
            float x = centerButton.anchoredPosition.x + Mathf.Cos(radians) * orbitRadius;
            float y = centerButton.anchoredPosition.y + Mathf.Sin(radians) * orbitRadius;

            // Applica la nuova posizione al pulsante
            orbitingButtons[i].anchoredPosition = new Vector2(x, y);
        }
    }
}
