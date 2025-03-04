using System;
using System.Collections.Generic;
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
        //GameManager.Instance.SaveData();

        switch (GameManager.Instance.selectedLanguage)
        {
            case "Dutch":
                switch (GameManager.Instance.selectedDifficulty)
                {
                    case "A1":
                        switch (decine)
                        {
                            case 0:
                                break;
                            case 1:
                                switch (GameManager.Instance.LanguageDataStars.Difficulty.node.Stars) 
                                {
                                    case 0:
                                        for (int i = 1; i <= 3; i++)
                                        {
                                            GameObject.Find("Node_" + decine + "_star_" + i).GetComponent<Image>().color = Color.white;
                                        }
                                        //GameObject.Find("Node_1_star_1").GetComponent<Image>().color = Color.white;
                                        //GameObject.Find("Node_1_star_2").GetComponent<Image>().color = Color.white;
                                        //GameObject.Find("Node_1_star_3").GetComponent<Image>().color = Color.white;
                                        break;
                                    case 1:
                                        for (int i = 1; i <= 3; i++)
                                        {
                                            if (i == 1)
                                            {
                                                GameObject.Find("Node_" + decine + "_star_" + i).GetComponent<Image>().color = Color.yellow;
                                            }
                                            GameObject.Find("Node_" + decine + "_star_" + i).GetComponent<Image>().color = Color.white;
                                        }
                                        //GameObject.Find("Node_1_star_1").GetComponent<Image>().color = Color.yellow;
                                        //GameObject.Find("Node_1_star_2").GetComponent<Image>().color = Color.white;
                                        //GameObject.Find("Node_1_star_3").GetComponent<Image>().color = Color.white;
                                        break;
                                    case 2:
                                        for (int i = 1; i <= 3; i++)
                                        {
                                            if(i == 1 || i == 2)
                                            {
                                                GameObject.Find("Node_" + decine + "_star_" + i).GetComponent<Image>().color = Color.yellow;
                                            }
                                            GameObject.Find("Node_" + decine + "_star_" + i).GetComponent<Image>().color = Color.white;
                                        }
                                        //GameObject.Find("Node_1_star_1").GetComponent<Image>().color = Color.yellow;
                                        //GameObject.Find("Node_1_star_2").GetComponent<Image>().color = Color.yellow;
                                        //GameObject.Find("Node_1_star_3").GetComponent<Image>().color = Color.white;
                                        break;
                                    case 3:
                                        for (int i = 1; i <= 3; i++)
                                        {
                                            GameObject.Find("Node_" + decine + "_star_" + i).GetComponent<Image>().color = Color.yellow;
                                        }
                                        //GameObject.Find("Node_1_star_1").GetComponent<Image>().color = Color.yellow;
                                        //GameObject.Find("Node_1_star_2").GetComponent<Image>().color = Color.yellow;
                                        //GameObject.Find("Node_1_star_3").GetComponent<Image>().color = Color.yellow;
                                        break;
                                }
                                break;
                            default:
                                throw new Exception("error on LanguageProgression dictionary!!!");
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
}
