using System.Collections;
using System.Collections.Generic;
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

    Dictionary<string, string> levelAndRules = new Dictionary<string, string>(); 
    Dictionary<string, Sprite> iconsAndLanguages = new Dictionary<string, Sprite>(); 
    private void InitializeLevelAndRulesDictionary()
    {
        levelAndRules.Add("A1", "A1 Rules");
        levelAndRules.Add("A2", "A2 Rules");
        levelAndRules.Add("B1", "B1 Rules");
        levelAndRules.Add("B2", "B2 Rules");
        levelAndRules.Add("C1", "C1 Rules");
        levelAndRules.Add("C2", "C2 Rules");

        Debug.Log("Levels And Rules dict initialized");
    }
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
        if("6 - Difficulty Rules".Equals(SceneManager.GetActiveScene().name)) {
            InitializeLevelAndRulesDictionary();
            InitializeIconsAndLanguagesDictionary();
            
            StartCoroutine(UpdateDifficultyRules());
        }
        StartCoroutine(UpdateLanguageIcon());
    }
    public IEnumerator UpdateDifficultyRules()
    {
        yield return new WaitForEndOfFrame();
        difficultyLevel.text = GameManager.Instance.selectedDifficulty;
        if (textRules != null) {
            switch (difficultyLevel.text)
            {
                case "A1": textRules.text = levelAndRules["A1"]; break;
                case "A2": textRules.text = levelAndRules["A2"]; break;
                case "B1": textRules.text = levelAndRules["B1"]; break;
                case "B2": textRules.text = levelAndRules["B2"]; break;
                case "C1": textRules.text = levelAndRules["C1"]; break;
                case "C2": textRules.text = levelAndRules["C2"]; break;
                default: Debug.Log("Error"); break;
            }
        }
    }

    public IEnumerator UpdateLanguageIcon()
    {
        yield return new WaitForEndOfFrame();
        string language = GameManager.Instance.selectedLanguage;
        switch (language.ToLower())
        {
            case "france": selectedLanguageRawImage.sprite = languageIcons[0]; break;
            case "italy": selectedLanguageRawImage.sprite = languageIcons[1]; break;
            case "holland": selectedLanguageRawImage.sprite = languageIcons[2]; break;
            case "russia": selectedLanguageRawImage.sprite = languageIcons[3]; break;
            case "spain": selectedLanguageRawImage.sprite = languageIcons[4]; break;
            case "sweden": selectedLanguageRawImage.sprite = languageIcons[5]; break;
            case "uk": selectedLanguageRawImage.sprite = languageIcons[6]; break;
            case "usa": selectedLanguageRawImage.sprite = languageIcons[7]; break;
            default: Debug.Log("Error"); break;
        }
    }
}
