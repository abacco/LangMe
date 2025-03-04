using System;
using UnityEngine;
using UnityEngine.UI;

public class LanguageProgression : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.LoadData();
        Debug.Log("In LanguageProgression: ---------");
        GameManager.Instance.GameManagerDebugLogData();
        int decine = GameManager.Instance.solutionCounter / 10;
        GameManager.Instance.decine = decine;

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
                        while (decine > 0)
                        {
                            int stars = GameManager.Instance.LanguageDataStars?.Difficulty.node.Stars ?? 0;
                            ApplyStars(decine, stars);
                            decine--;
                        }
                        break;
                    case "B1":
                        while (decine > 0)
                        {
                            int stars = GameManager.Instance.LanguageDataStars?.Difficulty.node.Stars ?? 0;
                            ApplyStars(decine, stars);
                            decine--;
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
