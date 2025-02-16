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
        if ("6 - Difficulty Rules".Equals(SceneManager.GetActiveScene().name)) {
            // InitDutchA1Rule();
            InitializeIconsAndLanguagesDictionary();

            switch (GameManager.Instance.selectedLanguage)
            {
                case "Dutch":
                    switch (GameManager.Instance.selectedDifficulty)
                    {
                        case "A1": InitDutchA1Rule(); UpdateTextA1_withPages(page_counter); break;
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
            case "Dutch": selectedLanguageRawImage.sprite = languageIcons[2]; break;
            case "russia": selectedLanguageRawImage.sprite = languageIcons[3]; break;
            case "spain": selectedLanguageRawImage.sprite = languageIcons[4]; break;
            case "sweden": selectedLanguageRawImage.sprite = languageIcons[5]; break;
            case "uk": selectedLanguageRawImage.sprite = languageIcons[6]; break;
            case "usa": selectedLanguageRawImage.sprite = languageIcons[7]; break;
            default: Debug.Log("Error on language " + language); break;
        }
    }

    public TMP_Text rules_title_txt;
    public TMP_Text rules_body_txt;
    Dictionary<string, string> dutch_a1_rules_titles_and_bodies = new Dictionary<string, string>();
    Dictionary<string, string> dutch_a2_rules_titles_and_bodies = new Dictionary<string, string>(); // non usato ancora atm
    Dictionary<string, Dictionary<string, string>> dutch_levels_and_rules = new Dictionary<string, Dictionary<string, string>>();
    public int page_counter = 0; // 10 pagine in totale, quindi da 0 a 9
    public void InitDutchA1Rule() { // sia all'inizio che quando cambi pagina (?) forse quando cambi pagina puoi ottimizzare oppure metti i tag sulle pagine e li filli cosi

        dutch_a1_rules_titles_and_bodies.Add("Pronunciation and Special Sounds", "The \"g\" sounds like a guttural \"h\" (e.g., goed → /ɣut/).\r\n\nThe \"ui\" sounds similar to the French \"œy\" (e.g., huis → /hœys/).\r\n\nThe \"ij\" and \"ei\" are pronounced like a mix between \"ai\" and \"ei\".\r\n\nThe \"sch\" sounds like an \"s\" followed by a guttural \"ch\" (e.g., school → /sxoːl/).");
        dutch_a1_rules_titles_and_bodies.Add("Definite and Indefinite Articles", "De → Used for most common nouns (de man = the man, de vrouw = the woman).\r\nHet → Used for neutral words and diminutives (het huis = the house, het kind = the child).\r\nEen → Indefinite article, meaning \"a\" or \"an\" (een boek = a book).");
        dutch_a1_rules_titles_and_bodies.Add("A1 Rules 3", "A1 Body 3");
        dutch_a1_rules_titles_and_bodies.Add("A1 Rules 4", "A1 Body 4");
        dutch_a1_rules_titles_and_bodies.Add("A1 Rules 5", "A1 Body 5");
        dutch_a1_rules_titles_and_bodies.Add("A1 Rules 6", "A1 Body 6");
        dutch_a1_rules_titles_and_bodies.Add("A1 Rules 7", "A1 Body 7");
        dutch_a1_rules_titles_and_bodies.Add("A1 Rules 8", "A1 Body 8");
        dutch_a1_rules_titles_and_bodies.Add("A1 Rules 9", "A1 Body 9");
        dutch_a1_rules_titles_and_bodies.Add("A1 Rules 10", "A1 Body 10");
    }
    public void UpdateTextA1_withPages(int counter)
    {
        // Supponiamo che `counter` sia già definito e rappresenti l'indice attuale
        if (counter >= 0 && counter < dutch_a1_rules_titles_and_bodies.Count)
        {
            var elemento = dutch_a1_rules_titles_and_bodies.ElementAt(counter); // Prende l'elemento alla posizione 'counter'

            rules_title_txt.text = elemento.Key;   // Chiave
            rules_body_txt.text = elemento.Value;  // Valore
        }

    }
    public void SwitchPageForward()
    {
        page_counter++;
        if(page_counter <= 9)
        {
            UpdateTextA1_withPages(page_counter);
        }
    }
    public void SwitchPageBackward()
    {
        page_counter--;
        if (page_counter >= 0)
        {
            UpdateTextA1_withPages(page_counter);
        }
    }
}
