using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RulesManager : MonoBehaviour
{
    // this script is shared between the Rules Scene and the Exercise Scene (to handle the header but not LIFES!)
    [SerializeField] TMP_Text difficultyLevel;
    [SerializeField] TMP_Text textRules;

    [SerializeField] Image selectedLanguageRawImage;

    [SerializeField] Sprite[] languageIcons;

    Dictionary<string, Sprite> iconsAndLanguages = new Dictionary<string, Sprite>();

    public TMP_Text rules_title_txt;
    public TMP_Text rules_body_txt;
    public int page_counter = 0; // 10 pagine in totale, quindi da 0 a 9
    
    private void InitializeIconsAndLanguagesDictionary()
    {
        iconsAndLanguages.Add("france", languageIcons[0]);
        iconsAndLanguages.Add("italy", languageIcons[1]);
        iconsAndLanguages.Add("holland", languageIcons[2]);
        iconsAndLanguages.Add("russia", languageIcons[3]);
        iconsAndLanguages.Add("spain", languageIcons[4]);
        iconsAndLanguages.Add("sweden", languageIcons[5]);
        iconsAndLanguages.Add("uk", languageIcons[6]);
        iconsAndLanguages.Add("usa", languageIcons[7]);

        Debug.Log("Icons And Languages dict initialized");
    }

    private void Start()
    {
        if ("6 - Difficulty Rules".Equals(SceneManager.GetActiveScene().name) ) { 
            InitializeIconsAndLanguagesDictionary();

            switch (GameManager.Instance.selectedLanguage)
            {
                case "Dutch":
                    switch (GameManager.Instance.selectedDifficulty)
                    {
                        case "A1": UpdateTextWithPagesGeneric(page_counter, DutchDicts.Dutch_a1_rules_titles_and_bodies); break;
                        case "A2": UpdateTextWithPagesGeneric(page_counter, DutchDicts.Dutch_a2_rules_titles_and_bodies); break;
                        default: throw new Exception("Error On selectedDifficulty: ");
                    }
                    break;
                default: throw new Exception("Error On selectedLanguage: ");
            }
        }
        StartCoroutine(UpdateDifficultyRules());
        StartCoroutine(UpdateLanguageIcon());
    }
    public IEnumerator UpdateDifficultyRules()
    {
        yield return new WaitForEndOfFrame();
        difficultyLevel.text = GameManager.Instance.selectedDifficulty;
    }

    public IEnumerator UpdateLanguageIcon()
    {
        yield return new WaitForEndOfFrame();
        string language = GameManager.Instance.selectedLanguage;

        switch (language.ToLower())
        {
            case "france": selectedLanguageRawImage.sprite = languageIcons[0]; break;
            case "italy": selectedLanguageRawImage.sprite = languageIcons[1]; break;
            case "dutch": selectedLanguageRawImage.sprite = languageIcons[2]; break;
            case "russia": selectedLanguageRawImage.sprite = languageIcons[3]; break;
            case "spain": selectedLanguageRawImage.sprite = languageIcons[4]; break;
            case "sweden": selectedLanguageRawImage.sprite = languageIcons[5]; break;
            case "uk": selectedLanguageRawImage.sprite = languageIcons[6]; break;
            case "usa": selectedLanguageRawImage.sprite = languageIcons[7]; break;
            default: Debug.Log("Error on language " + language); break;
        }
    }

    #region InitDutchRules

    #endregion

    public void UpdateTextWithPagesGeneric(int counter, Dictionary<string, string> genericDict)
    {
        // Supponiamo che `counter` sia già definito e rappresenti l'indice attuale
        if (counter >= 0 && counter < genericDict.Count)
        {
            var elemento = genericDict.ElementAt(counter); // Prende l'elemento alla posizione 'counter'

            rules_title_txt.text = elemento.Key;
            rules_body_txt.text = elemento.Value;
        }
    }

    public void SwitchPageForward()
    {
        page_counter++;
        if(page_counter <= 9)
        {
            switch (GameManager.Instance.selectedLanguage)
            {
                case "Dutch":
                    switch (GameManager.Instance.selectedDifficulty)
                    {
                        case "A1": UpdateTextWithPagesGeneric(page_counter, DutchDicts.Dutch_a1_rules_titles_and_bodies); break;
                        case "A2": UpdateTextWithPagesGeneric(page_counter, DutchDicts.Dutch_a2_rules_titles_and_bodies); break;
                        default: throw new Exception("Error On selectedDifficulty: ");
                    }
                    break;
                default: throw new Exception("Error On selectedLanguage: ");
            }
        }
    }
    public void SwitchPageBackward()
    {
        page_counter--;
        if (page_counter >= 0)
        {
            switch (GameManager.Instance.selectedLanguage)
            {
                case "Dutch":
                    switch (GameManager.Instance.selectedDifficulty)
                    {
                        case "A1": UpdateTextWithPagesGeneric(page_counter, DutchDicts.Dutch_a1_rules_titles_and_bodies); break;
                        case "A2": UpdateTextWithPagesGeneric(page_counter, DutchDicts.Dutch_a2_rules_titles_and_bodies); break;
                        default: throw new Exception("Error On selectedDifficulty: ");
                    }
                    break;
                default: throw new Exception("Error On selectedLanguage: ");
            }
        }
    }
}
