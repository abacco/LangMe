using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBtns : MonoBehaviour
{
    public RectTransform[] buttons; // Array dei pulsanti UI
    public float moveSpeed = 2.0f;
    public float scaleSpeed = 2.0f;
    public float scaleAmount = 0.2f;
    public Vector2 minBounds = new Vector2(-100, -100);
    public Vector2 maxBounds = new Vector2(100, 100);

    private Vector2[] targetPositions;
    private float[] timeOffsets;

    void Start()
    {
        // Inizializza le posizioni target e gli offset temporali per ogni bottone
        targetPositions = new Vector2[buttons.Length];
        timeOffsets = new float[buttons.Length];

        for (int i = 0; i < buttons.Length; i++)
        {
            targetPositions[i] = GetRandomPosition();
            timeOffsets[i] = Random.Range(0f, 2f); // Offset per evitare sincronia perfetta
        }
    }

    void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            MoveButton(i);
            AnimateScale(i);
        }
    }

    void MoveButton(int index)
    {
        // Muove il pulsante verso la sua destinazione
        buttons[index].anchoredPosition = Vector2.Lerp(buttons[index].anchoredPosition, targetPositions[index], moveSpeed * Time.deltaTime);

        // Cambia destinazione quando il pulsante è abbastanza vicino
        if (Vector2.Distance(buttons[index].anchoredPosition, targetPositions[index]) < 5f)
        {
            targetPositions[index] = GetRandomPosition();
        }
    }

    void AnimateScale(int index)
    {
        // Effetto di gonfiaggio/sgonfiaggio indipendente usando un offset temporale
        float scaleFactor = 1 + Mathf.PingPong((Time.time + timeOffsets[index]) * scaleSpeed, scaleAmount);
        buttons[index].localScale = new Vector3(scaleFactor, scaleFactor, 1);
    }

    Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(minBounds.x, maxBounds.x), Random.Range(minBounds.y, maxBounds.y));
    }
}
