using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageProficiencyCompleted : MonoBehaviour
{
    // devi salvare questa info nel gameManager
    Dictionary<string, bool> proficiencyCompletedDictionary = new Dictionary<string, bool>();
    void Start()
    {
        proficiencyCompletedDictionary.Add("Dutch_B2", true);
        string key = GameManager.Instance.selectedLanguage + "_" + GameManager.Instance.selectedDifficulty;
        if (GameManager.Instance.solutionCounter == 100)
        {
            if (!proficiencyCompletedDictionary.ContainsKey(key))
            {
                proficiencyCompletedDictionary.Add(key, true);
            } else
            {
                Debug.Log("Proficency Completed for: " + GameManager.Instance.selectedLanguage + GameManager.Instance.selectedDifficulty);
            }
        }
        else {
            Debug.Log(GameManager.Instance.selectedLanguage + "_" + GameManager.Instance.selectedDifficulty + " Not yet completed");
        }
    }

    void Update()
    {
        
    }
}
