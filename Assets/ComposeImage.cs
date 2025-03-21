using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;
using UnityEngine.UI;

public class ComposeImage : MonoBehaviour
{
    //public ScrollRect scrollRect_head; // Lo ScrollRect con gli elementi
    //public Scrollbar scrollBar_head; // Lo ScrollRect con gli elementi

    //public ScrollRect scrollRect_body; // Lo ScrollRect con gli elementi
    //public Scrollbar scrollBar_body; // Lo ScrollRect con gli elementi

    //public List<RectTransform> elements_head; // Lista degli elementi nello ScrollRect
    //public List<RectTransform> elements_body; // Lista degli elementi nello ScrollRect

    //RawImage chosenHead;
    //RawImage chosenBody;

    //public GameObject confirmPanel;
    //public RawImage chosenHead_to_show;
    //public RawImage chosenBody_to_show;
    //private void Update()
    //{
    //    if(scrollBar_head != null) // aggiungere il controllo anche sul dizionario etc...
    //    {
    //        if(scrollBar_head.value >= 0.85f)
    //        {
    //            scrollBar_head.value = 0.85f;
    //        }
    //    }
    //}

    //public RawImage GetCentralHead()
    //{
    //    float viewportCenter = scrollRect_head.viewport.position.x + (scrollRect_head.viewport.rect.width / 2);
    //    RectTransform centralElement = null;
    //    float smallestDistance = float.MaxValue;

    //    foreach (RectTransform element in elements_head)
    //    {
    //        float distance = Mathf.Abs(element.position.x - viewportCenter);
    //        if (distance < smallestDistance)
    //        {
    //            smallestDistance = distance;
    //            centralElement = element;
    //        }
    //    }

    //    return centralElement.gameObject.GetComponent<RawImage>();
    //}
    //public RawImage GetCentralBody()
    //{
    //    float viewportCenter = scrollRect_body.viewport.position.x + (scrollRect_body.viewport.rect.width / 2);
    //    RectTransform centralElement = null;
    //    float smallestDistance = float.MaxValue;

    //    foreach (RectTransform element in elements_body)
    //    {
    //        float distance = Mathf.Abs(element.position.x - viewportCenter);
    //        if (distance < smallestDistance)
    //        {
    //            smallestDistance = distance;
    //            centralElement = element;
    //        }
    //    }

    //    return centralElement.gameObject.GetComponent<RawImage>();
    //}
    //public void AquireHead()
    //{
    //    chosenHead = GetCentralHead();
    //    chosenBody = GetCentralBody();
    //    Debug.Log(chosenHead.gameObject.name);
    //    Debug.Log(chosenBody.gameObject.name);

    //    chosenHead_to_show.texture = chosenHead.texture;
    //    chosenBody_to_show.texture = chosenBody.texture;
    //    confirmPanel.SetActive(true);
    //}


    public ScrollRect scrollRect_head; // Lo ScrollRect con gli elementi
    public Scrollbar scrollBar_head; // Lo ScrollRect con gli elementi

    public List<RectTransform> elements_into_content; // Lista degli elementi nello ScrollRect


    Image chosenHead;

    public GameObject confirmPanel;
    public Image chosenHead_to_show;

    private void Start()
    {
        GameManager.Instance.LoadData();
        // Carica tutte le Texture2D dalla cartella
        Sprite[] textures = Resources.LoadAll<Sprite>("ProfileImages");

        Debug.Log($"{textures.Length} immagini caricate dalla cartella ProfileImages.");
        switch (GameManager.Instance.imageSaved)
        {
            case "1":
                GameObject.Find("profileImage").GetComponent<Image>().sprite = textures[0];
                //    Sprite.Create(
                //        textures[0],
                //        new Rect(0, 0, textures[0].width, textures[0].height),
                //        new Vector2(0.5f, 0.5f)
                //);
                break; 
            case "2": break; 
            case "3": break; 
            case "4": break; 
            case "5": break;
            case "6": break; 
            case "7": break; 
            case "8": break; 
            case "9": break; 
            case "10": break; 
        }
    }

    public Image GetCentralHead()
    {
        float viewportCenter = scrollRect_head.viewport.position.x + (scrollRect_head.viewport.rect.width / 2);
        RectTransform centralElement = null;
        float smallestDistance = float.MaxValue;

        foreach (RectTransform element in elements_into_content)
        {
            float distance = Mathf.Abs(element.position.x - viewportCenter);
            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                centralElement = element;
            }
        }

        GameManager.Instance.imageSaved = centralElement.gameObject.name;

        return centralElement.GetComponent<Image>();
    }
    
    public void AquirePhoto()
    {
        chosenHead = GetCentralHead();
        chosenHead_to_show.sprite = chosenHead.sprite;
        Debug.Log(chosenHead.gameObject.name);
        confirmPanel.SetActive(true);
    }

    public void CloseConfirmPanel()
    {
        confirmPanel.SetActive(false);
    }

    public void ConfirmImage()
    {
        // settare l'immagine di profilo nel GameManager

        GameManager.Instance.SaveData();
        GameObject.Find("profileImage").GetComponent<Image>().sprite = chosenHead.sprite;
    }
}