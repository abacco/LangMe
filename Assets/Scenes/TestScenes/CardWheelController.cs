using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardWheelController : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public List<Image> cardSlots;
    public List<Sprite> cardSprites;

    public float animationSpeed = 10f;
    public float scaleFactor = 1.2f;

    private int currentIndex = 0;
    private bool isAnimating = false;
    private Vector2 dragStartPos;
    private float minSwipeDistance = 10f;

    public float dragThreshold = 200f; // Distanza minima per considerare un drag
    private Vector2 pointerDownPosition;
    private bool isDragging = false;

    public GameObject panel; // Il pannello da mostrare al click - areyousurepanel
    public GameObject alternativeViewPanel;

    private void Start()
    {
        if (panel == null)
        {
            Debug.LogWarning("current scene does not need this panel or it is handled by another script");
            panel = new GameObject();
        }

        // ORDINA LE CARTE NELL'ORDINE CORRETTO (da A1 a C2) parte da B2 per il drag
        //cardSlots = cardSlots.OrderBy(slot => slot.name).ToList();
        //cardSprites = cardSprites.OrderBy(slot => slot.name).ToList();
        // Aggiorna la grafica iniziale delle carte
        UpdateCardDisplay(instant: true);

        int count = cardSlots.Count;
        for (int i = 0; i < count; i++)
        {
            cardSlots[i].transform.position += new Vector3(0, -160, 0);
        }
    }
    
    public void ScrollRight()
    {
        if (isAnimating) return;
        //currentIndex = (currentIndex + 1) % cardSprites.Count;
        currentIndex = (currentIndex - 1 + cardSprites.Count) % cardSprites.Count;
        Debug.Log("Now Displayin: " + cardSlots[currentIndex].name);
        //Debug.Log("Scroll Right currentIndex:" + currentIndex);
        StartCoroutine(AnimateTransition(true));
    }

    public void ScrollLeft()
    {
        if (isAnimating) return;
        currentIndex = (currentIndex - 1 + cardSprites.Count) % cardSprites.Count;
        Debug.Log("Scroll Left currentIndex:" + currentIndex);
        //StartCoroutine(AnimateTransition(true));
    }

    private IEnumerator AnimateTransition(bool scrollRight)
    {
        isAnimating = true;

        int count = cardSlots.Count;
        List<Vector3> startPositions = new List<Vector3>();
        List<Vector3> targetPositions = new List<Vector3>();
        List<Vector3> startScales = new List<Vector3>();
        List<Vector3> targetScales = new List<Vector3>();

        // Memorizziamo posizioni e scale iniziali
        for (int i = 0; i < count; i++)
        {
            startPositions.Add(cardSlots[i].transform.position);
            targetPositions.Add(cardSlots[(i + (scrollRight ? 1 : -1) + count) % count].transform.position);

            Debug.Log("startPositions of " + cardSlots[i].name + "is " + cardSlots[i].transform.position); // parte dal riferimento del canvas

            startScales.Add(cardSlots[i].transform.localScale);
            targetScales.Add(cardSlots[(i + (scrollRight ? 1 : -1) + count) % count].transform.localScale);
        }

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * animationSpeed;

            for (int i = 0; i < count; i++)
            {
                cardSlots[i].transform.position = Vector3.Lerp(startPositions[i], targetPositions[i], t);
                cardSlots[i].transform.localScale = Vector3.Lerp(startScales[i], targetScales[i], t);
            }

            yield return null;
        }

        // Aggiorna l'indice corrente in base alla direzione dello swipe
        currentIndex = (currentIndex + (scrollRight ? 1 : -1) + count) % count;
        UpdateCardDisplay(false);
        if(isAnimating) { panel.SetActive(false); }
        isAnimating = false;
    }
    private IEnumerator AnimateTransition()
    {
        isAnimating = true;

        // Salviamo le posizioni e le scale iniziali delle carte
        List<Vector3> startPositions = new List<Vector3>();
        List<Vector3> targetPositions = new List<Vector3>();
        List<Vector3> startScales = new List<Vector3>();
        List<Vector3> targetScales = new List<Vector3>();

        int count = cardSlots.Count;

        // Determiniamo le posizioni di partenza e di destinazione
        for (int i = 0; i < count; i++)
        {
            startPositions.Add(cardSlots[i].transform.position);
            targetPositions.Add(cardSlots[(i + 1) % count].transform.position);

            startScales.Add(cardSlots[i].transform.localScale);
            targetScales.Add(cardSlots[(i + 1) % count].transform.localScale);

        }

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * animationSpeed;

            for (int i = 0; i < count; i++)
            {
                cardSlots[i].transform.position = Vector3.Lerp(startPositions[i], targetPositions[i], t);
                cardSlots[i].transform.localScale = Vector3.Lerp(startScales[i], targetScales[i], t);
            }

            yield return null;
        }

        UpdateCardDisplay(instant: false);
        if (isAnimating) { panel.SetActive(false); }
        isAnimating = false;
    }

    private void UpdateCardDisplay(bool instant)
    {
        int halfSize = cardSlots.Count / 2; // Trova il centro della lista

        for (int i = 0; i < cardSlots.Count; i++)
        {
            // Assicura che la prima carta sia A1 e segua l'ordine giusto
            int spriteIndex = (currentIndex + i) % cardSprites.Count;
            cardSlots[i].sprite = cardSprites[spriteIndex];

            if (instant)
            {
                if (i == halfSize)
                {
                    cardSlots[i].transform.localScale = Vector3.one * scaleFactor;
                }
                else
                {
                    cardSlots[i].transform.localScale = Vector3.zero; // Nasconde le carte dietro
                }
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPos = eventData.position; // Memorizza il punto di inizio del drag
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isAnimating) return;

        float dragDistance = eventData.position.x - pointerDownPosition.x;

        if (Mathf.Abs(dragDistance) > dragThreshold)
        {
            isDragging = true; // Segnala che è uno swipe
            if (dragDistance > 0)
                ScrollRight();
            else
                ;//ScrollLeft();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isAnimating) return;

        float dragDistance = eventData.position.x - dragStartPos.x; // Calcola la differenza

        if (dragDistance > minSwipeDistance)
            ;//ScrollLeft(); // Spostamento a destra → Mostra carta a sinistra
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

            if (dragDistance > minSwipeDistance)
                ScrollRight();
            else if (dragDistance < -minSwipeDistance)
                ;//ScrollLeft();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDownPosition = eventData.position;
        isDragging = false; // Reset del flag
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isDragging) // Se non è stato uno swipe, allora è un click
        {
            panel.SetActive(true); // Mostra il pannello solo se è un vero click
        }
    }

    public void ShowAlternativeView()
    {
        if(alternativeViewPanel.activeInHierarchy)
        {
            alternativeViewPanel.SetActive(false);
        } else
        {
            alternativeViewPanel.SetActive(true);
        }
    }

    private void InitializeCardPositions()
    {
        int count = cardSlots.Count;
        float spacing = 300f; // Distanza tra le carte, regolala secondo le esigenze

        for (int i = 0; i < count; i++)
        {
            float offset = (i - count / 2) * spacing; // Posiziona le carte rispetto al centro
            cardSlots[i].transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
        }
    }
}
