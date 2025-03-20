using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LanguageProficiencyCompleted : MonoBehaviour
{
    [SerializeField] GameObject congratsPanel;
    [SerializeField] Text congrats_text;
    [SerializeField] Image languageIcon;
    [SerializeField] Sprite[] languageIcons;

    [SerializeField] Image a1_img;
    [SerializeField] Image a2_img;
    [SerializeField] Image b1_img;
    [SerializeField] Image b2_img;
    [SerializeField] Image c1_img;
    [SerializeField] Image c2_img;

    void Start()
    {
        GameManager.Instance.LoadData();
        StartCoroutine(UpdateLanguageIcon());


        GameData.ProficiencyTracker[] pr = GameManager.Instance.proficiencyTracker;
        if (pr == null || pr.Length == 0)
        {
            throw new Exception("Proficiency tracker array is null or empty.");
        }

        //ResetColors();

        string key = GameManager.Instance.selectedLanguage + "_" + GameManager.Instance.selectedDifficulty;
        bool needsSave = false;

        // Controlla se il nodo esiste già nell'array
        GameData.ProficiencyTracker existingNode = pr.FirstOrDefault(p => p.key == key);

        if (GameManager.Instance.solutionCounter >= 100)
        {
            if (existingNode != null)
            {
                // Se il nodo esiste già, aggiorna solo lo stato
                existingNode.isCompleted = true;
                needsSave = true;
                Debug.Log("this node " + existingNode.key + existingNode.isCompleted + "exists");
            }
            else
            {
                // Se non esiste, lo aggiunge all'array senza sovrascrivere vecchi dati
                List<GameData.ProficiencyTracker> proficiencyList = pr.ToList();
                proficiencyList.Add(new GameData.ProficiencyTracker(key, true));
                Debug.Log("Added Node" + key);
                GameManager.Instance.proficiencyTracker = proficiencyList.ToArray();
                //GameManager.Instance.singleProficiencyTracker.isCompleted = false;
                //GameManager.Instance.singleProficiencyTracker.key = "SingleProfTrackerReset";
                needsSave = true;
                GameManager.Instance.SaveData();
            }
        }

        int how_many_completed = 0;
        // Colora tutti i nodi completati
        foreach (var proficiency in GameManager.Instance.proficiencyTracker)
        {
            if (proficiency.isCompleted)
            {
                how_many_completed++;
                ChangeColor(proficiency.key);
                if(how_many_completed == 6)
                {
                    Debug.Log("you won!"); // ok - inserisci il pannello di win
                    congrats_text.text = "Congratulations On Completing " + GameManager.Instance.selectedLanguage;
                    congratsPanel.SetActive(true);
                }
            }
        }

        if (needsSave)
        {
            GameManager.Instance.SaveData();
        }
    }

    void ResetColors(string key)
    {
        if (key.Contains("A1")) a1_img.color = Color.black;
        if (key.Contains("A2")) a2_img.color = Color.black;
        if (key.Contains("B1")) b1_img.color = Color.black;
        if (key.Contains("B2")) b2_img.color = Color.black;
        if (key.Contains("C1")) c1_img.color = Color.black;
        if (key.Contains("C2")) c2_img.color = Color.black;
    }

    void ChangeColor(string key)
    {
        if (key.Contains("A1")) a1_img.color = Color.white;
        if (key.Contains("A2")) a2_img.color = Color.white;
        if (key.Contains("B1")) b1_img.color = Color.white;
        if (key.Contains("B2")) b2_img.color = Color.white;
        if (key.Contains("C1")) c1_img.color = Color.white;
        if (key.Contains("C2")) c2_img.color = Color.white;
    }

    public IEnumerator UpdateLanguageIcon()
    {
        yield return new WaitForEndOfFrame();
        string language = GameManager.Instance.selectedLanguage;

        switch (language.ToLower())
        {
            case "dutch": languageIcon.sprite = languageIcons[0]; break;
            default: Debug.LogError("Error on language: " + language); break;
        }
    }

    public void CloseCongratsPanel()
    {
        congratsPanel.SetActive(false);
    }


    /*JSON da salvare: -----------{
  
    "decine": 0,
    "selectedDifficulty": "A1",
    "proficiencyTrackerIndex": 0,
    "nodeTrackerIndex": 10,
    "solutionCounter": 100,
    
    "proficiencyTracker": [
        {
            "key": "",
            "isCompleted": false
        },
        {
            "key": "",
            "isCompleted": false
        },
        {
            "key": "",
            "isCompleted": false
        },
        {
            "key": "",
            "isCompleted": false
        },
        {
            "key": "",
            "isCompleted": false
        },
        {
            "key": "",
            "isCompleted": false
        },
        {
            "key": "Dutch_A1",
            "isCompleted": true
        }
    ],
    "ListOfNodes": [
        {
            "Stars": 3,
            "NodeName": "Node_1"
        },
        {
            "Stars": 3,
            "NodeName": "Node_2"
        },
        {
            "Stars": 3,
            "NodeName": "Node_3"
        },
        {
            "Stars": 3,
            "NodeName": "Node_4"
        },
        {
            "Stars": 3,
            "NodeName": "Node_5"
        },
        {
            "Stars": 3,
            "NodeName": "Node_6"
        },
        {
            "Stars": 3,
            "NodeName": "Node_7"
        },
        {
            "Stars": 3,
            "NodeName": "Node_8"
        },
        {
            "Stars": 3,
            "NodeName": "Node_9"
        },
        {
            "Stars": 3,
            "NodeName": "Node_10"
        }
    ],
    "singleProficiencyTracker": {
        "key": "Dutch_A1",
        "isCompleted": true
    }
}*/
}
