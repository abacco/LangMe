using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
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

    //    string language = GameManager.Instance.selectedLanguage;
    //    string difficulty = GameManager.Instance.selectedDifficulty;

    //    // Chiave composta per gestire le combinazioni di lingua e difficoltà
    //    string key = $"{language}_{difficulty}";

    //    // Dizionario delle combinazioni supportate
    //    HashSet<string> validCombinations = new HashSet<string>
    //    {
    //    "Dutch_A1", "Dutch_A2"
    //    };

    //    // Controlla se la combinazione è valida
    //    if (!validCombinations.Contains(key))
    //    {
    //        throw new Exception($"Error: Unsupported language or difficulty -> {key}");
    //    }

    //    // Ottieni il numero di stelle
    //    int stars = GameManager.Instance.LanguageDataStars?.Difficulty.node.Stars ?? 0;

    //    // Applica le stelle
    //    ApplyStars(decine, stars);
    //}

    //// Metodo generico per impostare i colori delle stelle
    //private void ApplyStars(int decine, int starCount)
    //{
    //    for (int i = 1; i <= 3; i++)
    //    {
    //        Image img = GameObject.Find($"Node_{decine}_star_{i}")?.GetComponent<Image>();
    //        if (img == null) continue;

    //        img.color = (i <= starCount) ? Color.yellow : Color.white;
    //    }
    //}

    // end refactor

    private void Start()
    {
        GameManager.Instance.LoadData();
        Debug.Log("In LanguageProgression: ---------");
        GameManager.Instance.GameManagerDebugLogData();
        int decine = GameManager.Instance.solutionCounter / 10;
        GameManager.Instance.decine = decine;
        //GameManager.Instance.SaveData();

        switch (GameManager.Instance.selectedLanguage)
        {
            case "Dutch":
                switch (GameManager.Instance.selectedDifficulty)
                {
                    case "A1":
                        while (decine > 0)
                        {
                            int stars = GameManager.Instance.LanguageDataStars?.Difficulty.node.Stars ?? 0;
                            ApplyStars(decine, stars);
                            decine--;
                        }
                        break;
                    case "A2":
                        switch (decine)
                        {
                            case 0:
                                // sono nel primo nodo dell'A2
                                // devo fare la get delle earned star del primo nodo del dutch a1
                                break;
                        }
                        break;
                    default: throw new Exception("Error On selectedDifficulty: ");
                }
                break;
            default: throw new Exception("Error On selectedLanguage: ");
        }
    }

    private void ApplyStars(int decine, int starCount)
    {
        for (int i = 1; i <= 3; i++)
        {
            Image img = GameObject.Find($"Node_{decine}_star_{i}")?.GetComponent<Image>();
            if (img == null) continue;

            img.color = (i <= starCount) ? Color.yellow : Color.white;
        }
    }
}
