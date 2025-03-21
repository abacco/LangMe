using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpdateIcons : MonoBehaviour
{
    [SerializeField] Image selectedLanguageRawImage;
    [SerializeField] Image selectedLanguageRawImage2;

    [SerializeField] Sprite[] languageIcons;

    [SerializeField] Text difficulty_selected;
    private void Start()
    {
        if (difficulty_selected != null)
        {
            difficulty_selected.text = GameManager.Instance.selectedDifficulty.ToUpper();
        }
        StartCoroutine(UpdateLanguageIcon());
    }

    public IEnumerator UpdateLanguageIcon()
    {
        yield return new WaitForEndOfFrame();
        string language = GameManager.Instance.selectedLanguage;

        switch (language.ToLower())
        {
            case "dutch": selectedLanguageRawImage.sprite = languageIcons[0]; selectedLanguageRawImage2.sprite = languageIcons[0]; break;
            default: Debug.Log("Error on language " + language); break;
        }
    }
}
