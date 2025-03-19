using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageProgression : MonoBehaviour
{
    [SerializeField] GameObject congratsPanel;
    [SerializeField] TMP_Text congrats_text;
    private void OnEnable()
    {
        GameObject[] colorizedStarTOReset = GameObject.FindGameObjectsWithTag("colorized_star");
        for(int i = 0; i < colorizedStarTOReset.Length; i++)
        {
            colorizedStarTOReset[i].GetComponent<Image>().color = Color.black;
        }
        StartCoroutine(InitializeStarsWhenReady());
    }

    private IEnumerator InitializeStarsWhenReady()
    {
        while (SceneManager.GetActiveScene().name != "10 - Progress")
        {
            yield return null;
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
                foreach (GameData.NodeData node in GameManager.Instance.ListOfNodes)
                {
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
}
