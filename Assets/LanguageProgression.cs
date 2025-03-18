using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageProgression : MonoBehaviour
{
    //private void Start()
    //{
    //    GameManager.Instance.LoadData();
    //    Debug.Log("In LanguageProgression: ---------");
    //    GameManager.Instance.GameManagerDebugLogData();
    //    int decine = GameManager.Instance.solutionCounter / 10;
    //    GameManager.Instance.decine = decine;

    //    switch (GameManager.Instance.selectedLanguage)
    //    {
    //        case "Dutch":
    //            switch (GameManager.Instance.selectedDifficulty)
    //            {
    //                case "A1":
    //                    while (decine > 0)
    //                    {
    //                        int stars = GameManager.Instance.LanguageDataStars?.Difficulty.node.Stars ?? 0;
    //                        ApplyStars(decine, stars);
    //                        decine--;
    //                    }
    //                    break;
    //                case "A2":
    //                    while (decine > 0)
    //                    {
    //                        int stars = GameManager.Instance.LanguageDataStars?.Difficulty.node.Stars ?? 0;
    //                        ApplyStars(decine, stars);
    //                        decine--;
    //                    }
    //                    break;
    //                case "B1":
    //                    while (decine > 0)
    //                    {
    //                        int stars = GameManager.Instance.LanguageDataStars?.Difficulty.node.Stars ?? 0;
    //                        ApplyStars(decine, stars);
    //                        decine--;
    //                    }
    //                    break;
    //                case "B2":
    //                    while (decine > 0)
    //                    {
    //                        int stars = GameManager.Instance.LanguageDataStars?.Difficulty.node.Stars ?? 0;
    //                        ApplyStars(decine, stars);
    //                        decine--;
    //                    }
    //                    break;
    //                case "C1":
    //                    while (decine > 0)
    //                    {
    //                        int stars = GameManager.Instance.LanguageDataStars?.Difficulty.node.Stars ?? 0;
    //                        ApplyStars(decine, stars);
    //                        decine--;
    //                    }
    //                    break;
    //                case "C2":
    //                    while (decine > 0)
    //                    {
    //                        int stars = GameManager.Instance.LanguageDataStars?.Difficulty.node.Stars ?? 0;
    //                        ApplyStars(decine, stars);
    //                        decine--;
    //                    }
    //                    break;
    //                default: throw new Exception("Error On selectedDifficulty: ");
    //            }
    //            break;
    //        default: throw new Exception("Error On selectedLanguage: ");
    //    }
    //}

    [SerializeField] GameObject congratsPanel;
    [SerializeField] TMP_Text congrats_text;
    private void Start()
    {
        GameManager.Instance.LoadData();
        //GameManager.Instance.GameManagerDebugLogData();

        int decine = GameManager.Instance.solutionCounter / 10;
        GameManager.Instance.decine = decine;

        if (!IsValidLanguage(GameManager.Instance.selectedLanguage))
        {
            throw new Exception("Error On selectedLanguage: " + GameManager.Instance.selectedLanguage);
        }

        if (!IsValidDifficulty(GameManager.Instance.selectedDifficulty))
        {
            throw new Exception("Error On selectedDifficulty: " + GameManager.Instance.selectedDifficulty);
        }

        while (decine > 0)
        {
            int stars = GetStarsForLanguage(GameManager.Instance.selectedLanguage);
            ApplyStars(decine, stars);
            decine--;
        }
    }

    private bool IsValidLanguage(string language)
    {
        return language == "Dutch"; // || language == "English" || language == "French" || language == "German";
    }

    private bool IsValidDifficulty(string difficulty)
    {
        return difficulty == "A1" || difficulty == "A2" || difficulty == "B1" ||
               difficulty == "B2" || difficulty == "C1" || difficulty == "C2";
    }

    private int GetStarsForLanguage(string language)
    {
        switch (language)
        {
            case "Dutch": return GameManager.Instance.LanguageDataStars?.Difficulty.node.Stars ?? 0;
            //case "English": return GameManager.Instance.LanguageDataStarsEnglish?.Difficulty.node.Stars ?? 0;
            //case "French": return GameManager.Instance.LanguageDataStarsFrench?.Difficulty.node.Stars ?? 0;
            //case "German": return GameManager.Instance.LanguageDataStarsGerman?.Difficulty.node.Stars ?? 0;
            default: throw new Exception("Error On retrieving stars for language: " + language);
        }
    }

    private void ApplyStars(int decine, int starCount)
    {
        for (int i = 1; i <= 3; i++)
        {
            Image img = GameObject.Find($"Node_{decine}_star_{i}")?.GetComponent<Image>();
            if (img == null) continue;

            img.color = (i <= starCount) ? Color.white : Color.black;
        }
    }
}
