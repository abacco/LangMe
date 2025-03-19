using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private void OnEnable()
    {
        //GameManager.Instance.LoadData();
        ////GameManager.Instance.GameManagerDebugLogData();

        //int decine = GameManager.Instance.solutionCounter / 10;
        //GameManager.Instance.decine = decine;

        //if (!IsValidLanguage(GameManager.Instance.selectedLanguage))
        //{
        //    throw new Exception("Error On selectedLanguage: " + GameManager.Instance.selectedLanguage);
        //}

        //if (!IsValidDifficulty(GameManager.Instance.selectedDifficulty))
        //{
        //    throw new Exception("Error On selectedDifficulty: " + GameManager.Instance.selectedDifficulty);
        //}

        //while (decine > 0)
        //{
        //    GetStarsForLanguage(decine, GameManager.Instance.selectedLanguage);
        //    decine--;
        //}
        StartCoroutine(InitializeStarsWhenReady());
    }

    private IEnumerator InitializeStarsWhenReady()
    {
        // Attendi finché la scena attuale non è completamente caricata
        while (SceneManager.GetActiveScene().name != "10 - Progress") // Sostituisci "X" con il nome della tua scena target
        {
            yield return null; // Attende un frame
        }

        GameManager.Instance.LoadData();
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
            GetStarsForLanguage(decine, GameManager.Instance.selectedLanguage);
            decine--;
        }
    }
    private void GetStarsForLanguage(int decine, string language)
    {
        switch (language)
        {
            case "Dutch":
                //Image img1 = GameObject.Find("Node_" + decine + "_star_1").GetComponent<Image>();
                //Image img2 = GameObject.Find("Node_" + decine + "_star_2").GetComponent<Image>();
                //Image img3 = GameObject.Find("Node_" + decine + "_star_3").GetComponent<Image>();
                foreach (GameData.NodeData node in GameManager.Instance.ListOfNodes)
                {
                    // Node_1_star_3
                    Image img1 = GameObject.Find(node.NodeName + "_star_1").GetComponent<Image>();
                    Image img2 = GameObject.Find(node.NodeName + "_star_2").GetComponent<Image>();
                    Image img3 = GameObject.Find(node.NodeName + "_star_3").GetComponent<Image>();
                    switch (node.Stars)
                        {
                            case 0:
                                img1.color = Color.black;
                                img2.color = Color.black;
                                img3.color = Color.black;
                                break;
                            case 1:
                                img1.color = Color.white;
                                img2.color = Color.black;
                                img3.color = Color.black;
                                break;
                            case 2:
                                img1.color = Color.white;
                                img2.color = Color.white;
                                img3.color = Color.black;
                                break;
                            case 3:
                                img1.color = Color.white;
                                img2.color = Color.white;
                                img3.color = Color.white;
                                break;
                        }
                }
                break;
            default: throw new Exception("Error On retrieving stars for language: " + language);
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
    private void ApplyStars(string nodeName, int decine, int starCount)
    {
        GameObject parentObject = GameObject.Find("Node_" + decine); // Sostituisci con il nome del GameObject padre

        string input = nodeName; // Node_1_star_1
        int lastUnderscore = input.LastIndexOf('_'); // Trova la posizione dell'ultimo '_'
        string lastPart = input.Substring(lastUnderscore + 1);
        
        // Node_1_star_1
        for (int i = 1; i <= 3; i++)
        {
            Image img = GameObject.Find("Node_" + decine + "_star_" + i).GetComponent<Image>();
            //img.color = (i <= starCount) ? Color.white : Color.black;
            for (int j = 0; j < starCount; j++)
            {
                img.color = (j <= starCount) ? Color.white : Color.black;
            }
        }
    }
}
