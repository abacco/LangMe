using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrollRect : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public List<RectTransform> items;  // Lista degli elementi UI da snappare
    public float snapSpeed = 10f;      // Velocità di scorrimento

    private bool isSnapping = false;
    private float targetPos;

    private void Start()
    {
        // Trova automaticamente gli elementi se non assegnati
        if (items.Count == 0)
        {
            foreach (Transform child in content)
            {
                items.Add(child.GetComponent<RectTransform>());
            }
        }
    }

    private void Update()
    {
        if (!isSnapping && Input.GetMouseButtonUp(0))  // Quando il mouse viene rilasciato
        {
            StartCoroutine(SnapToClosest());
        }
    }

    private IEnumerator SnapToClosest()
    {
        isSnapping = true;

        // Trova l'elemento più vicino
        float closestDist = float.MaxValue;
        RectTransform closestItem = null;
        foreach (RectTransform item in items)
        {
            float dist = Mathf.Abs(item.anchoredPosition.x - content.anchoredPosition.x);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestItem = item;
            }
        }

        // Calcola la posizione target
        targetPos = -closestItem.anchoredPosition.x;

        // Smooth scrolling verso il target
        while (Mathf.Abs(content.anchoredPosition.x - targetPos) > 0.1f)
        {
            float newX = Mathf.Lerp(content.anchoredPosition.x, targetPos, snapSpeed * Time.deltaTime);
            content.anchoredPosition = new Vector2(newX, content.anchoredPosition.y);
            yield return null;
        }

        content.anchoredPosition = new Vector2(targetPos, content.anchoredPosition.y);
        isSnapping = false;
    }
}