using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardWheelController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Image centerCard;
    public Image leftCard;
    public Image rightCard;
    public List<Sprite> cardSprites;

    public float animationSpeed = 10f;
    public float scaleFactor = 1.2f;

    private int currentIndex = 0;
    private bool isAnimating = false;
    private Vector2 dragStartPos;
    private float minSwipeDistance = 10f;

    private void Start()
    {
        UpdateCardDisplay(instant: true);
    }

    public void ScrollRight()
    {
        if (isAnimating) return;
        currentIndex = (currentIndex + 1) % cardSprites.Count;
        StartCoroutine(AnimateTransition(true));
    }

    public void ScrollLeft()
    {
        if (isAnimating) return;
        currentIndex = (currentIndex - 1 + cardSprites.Count) % cardSprites.Count;
        StartCoroutine(AnimateTransition(false));
    }
    private IEnumerator AnimateTransition(bool scrollRight)
    {
        isAnimating = true;

        // Salva la posizione iniziale delle carte
        Vector3 centerStartPos = centerCard.transform.position;
        Vector3 leftStartPos = leftCard.transform.position;
        Vector3 rightStartPos = rightCard.transform.position;

        // Se lo swipe è verso destra, spostiamo la carta centrale a destra
        Vector3 centerTargetPos = scrollRight ? leftStartPos : rightStartPos;
        Vector3 leftTargetPos = scrollRight ? rightStartPos : centerStartPos;
        Vector3 rightTargetPos = scrollRight ? centerStartPos : leftStartPos;

        // Gestiamo la scala delle carte (stessa logica)
        Vector3 centerStartScale = centerCard.transform.localScale;
        Vector3 leftStartScale = leftCard.transform.localScale;
        Vector3 rightStartScale = rightCard.transform.localScale;

        Vector3 centerTargetScale = scrollRight ? leftStartScale : rightStartScale;
        Vector3 leftTargetScale = scrollRight ? rightStartScale : centerStartScale;
        Vector3 rightTargetScale = scrollRight ? centerStartScale : leftStartScale;

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * animationSpeed;
            centerCard.transform.position = Vector3.Lerp(centerStartPos, centerTargetPos, t);
            leftCard.transform.position = Vector3.Lerp(leftStartPos, leftTargetPos, t);
            rightCard.transform.position = Vector3.Lerp(rightStartPos, rightTargetPos, t);

            centerCard.transform.localScale = Vector3.Lerp(centerStartScale, centerTargetScale, t);
            leftCard.transform.localScale = Vector3.Lerp(leftStartScale, leftTargetScale, t);
            rightCard.transform.localScale = Vector3.Lerp(rightStartScale, rightTargetScale, t);

            yield return null;
        }

        UpdateCardDisplay(instant: false);
        isAnimating = false;
    }
    private IEnumerator AnimateTransition()
    {
        isAnimating = true;

        Vector3 centerStartPos = centerCard.transform.position;
        Vector3 leftStartPos = leftCard.transform.position;
        Vector3 rightStartPos = rightCard.transform.position;

        Vector3 centerTargetPos = leftStartPos;
        Vector3 leftTargetPos = rightStartPos;
        Vector3 rightTargetPos = centerStartPos;

        Vector3 centerStartScale = centerCard.transform.localScale;
        Vector3 leftStartScale = leftCard.transform.localScale;
        Vector3 rightStartScale = rightCard.transform.localScale;

        Vector3 centerTargetScale = leftStartScale;
        Vector3 leftTargetScale = rightStartScale;
        Vector3 rightTargetScale = centerStartScale;

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * animationSpeed;
            centerCard.transform.position = Vector3.Lerp(centerStartPos, centerTargetPos, t);
            leftCard.transform.position = Vector3.Lerp(leftStartPos, leftTargetPos, t);
            rightCard.transform.position = Vector3.Lerp(rightStartPos, rightTargetPos, t);

            centerCard.transform.localScale = Vector3.Lerp(centerStartScale, centerTargetScale, t);
            leftCard.transform.localScale = Vector3.Lerp(leftStartScale, leftTargetScale, t);
            rightCard.transform.localScale = Vector3.Lerp(rightStartScale, rightTargetScale, t);

            yield return null;
        }

        UpdateCardDisplay(instant: false);
        isAnimating = false;
    }

    private void UpdateCardDisplay(bool instant)
    {
        centerCard.sprite = cardSprites[currentIndex];
        leftCard.sprite = cardSprites[(currentIndex - 1 + cardSprites.Count) % cardSprites.Count];
        rightCard.sprite = cardSprites[(currentIndex + 1) % cardSprites.Count];

        if (instant)
        {
            centerCard.transform.localScale = Vector3.one * scaleFactor;
            leftCard.transform.localScale = Vector3.one;
            rightCard.transform.localScale = Vector3.one;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPos = eventData.position; // Memorizza il punto di inizio del drag
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isAnimating) return;

        float dragDistance = eventData.delta.x; // Controlla quanto ci siamo mossi
        Debug.Log("dragDistance " + dragDistance);

        if (dragDistance > 0)
            ScrollLeft(); // Se ci spostiamo a destra, vediamo la carta a sinistra
        else if (dragDistance < 0)
            ScrollRight(); // Se ci spostiamo a sinistra, vediamo la carta a destra
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (isAnimating) return;

        float dragDistance = eventData.position.x - dragStartPos.x; // Calcola la differenza

        if (dragDistance > minSwipeDistance)
            ScrollLeft(); // Spostamento a destra → Mostra carta a sinistra
        else if (dragDistance < -minSwipeDistance)
            ScrollRight(); // Spostamento a sinistra → Mostra carta a destra
        else
            StartCoroutine(AnimateTransition()); // Se lo swipe è troppo piccolo, torna alla posizione iniziale
    }

    private void Update()
    {
        // Backup per il mouse (se OnDrag non funziona)
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            float dragDistance = dragStartPos.x - Input.mousePosition.x;
            Debug.Log("dragDistance " + dragDistance);
            if (dragDistance > minSwipeDistance)
                ScrollRight();
            else if (dragDistance < -minSwipeDistance)
                ScrollLeft();
        }
    }
}
