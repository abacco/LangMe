using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageProficiencyCompleted : MonoBehaviour
{
    [SerializeField] Image languageIcon;
    [SerializeField] Sprite[] languageIcons;

    [SerializeField] Image a1_img;
    [SerializeField] Image a2_img;
    [SerializeField] Image b1_img;
    [SerializeField] Image b2_img;
    [SerializeField] Image c1_img;
    [SerializeField] Image c2_img;

    // devi salvare questa info nel gameManager
    Dictionary<string, bool> proficiencyCompletedDictionary = new Dictionary<string, bool>();
    void Start()
    {
        StartCoroutine(UpdateLanguageIcon());
        proficiencyCompletedDictionary.Add("Dutch_B2", true);
        string key = GameManager.Instance.selectedLanguage + "_" + GameManager.Instance.selectedDifficulty;
        if (GameManager.Instance.solutionCounter == 100)
        {
            if (!proficiencyCompletedDictionary.ContainsKey(key))
            {
                proficiencyCompletedDictionary.Add(key, true);
                ChangeColor();
            } else
            {
                Debug.Log("Proficency Completed for: " + GameManager.Instance.selectedLanguage + GameManager.Instance.selectedDifficulty);
                ChangeColor();
            }
        }
        else {
            Debug.Log(GameManager.Instance.selectedLanguage + "_" + GameManager.Instance.selectedDifficulty + " Not yet completed");
        }
    }

    void ChangeColor()
    {
        switch (GameManager.Instance.selectedDifficulty)
        {
            case "A1":
                a1_img.color = Color.yellow; break;
            case "A2":
                a2_img.color = Color.yellow; break;
            case "B1":
                b1_img.color = Color.yellow; break;
            case "B2":
                b2_img.color = Color.yellow; break;
            case "C1":
                c1_img.color = Color.yellow; break;
            case "C2":
                c2_img.color = Color.yellow; break;
                default: throw new Exception("Error on LanguageProficiencyCompleted");
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
