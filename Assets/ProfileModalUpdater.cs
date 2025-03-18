using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileModalUpdater : MonoBehaviour
{
    [SerializeField] Image languageIcon;
    [SerializeField] Text hearts_txt;
    [SerializeField] Text difficulty_txt;

    [SerializeField] Sprite[] languageIcons;
    private void Start()
    {
        StartCoroutine(UpdateLanguageIcon());
        try
        {
            difficulty_txt.text = GameManager.Instance.selectedDifficulty;
        } catch (Exception e){
            Debug.Log("difficulty_txt not used here");
        }

        if(hearts_txt != null)
        {
            hearts_txt.text = GameManager.Instance.userLifes.ToString();
        }
    }

    public IEnumerator UpdateLanguageIcon()
    {
        yield return new WaitForEndOfFrame();
        string language = GameManager.Instance.selectedLanguage;

        switch (language.ToLower())
        {
            case "dutch": languageIcon.sprite = languageIcons[0]; break;
            default: Debug.Log("Error on language " + language); break;
        }
    }
}
