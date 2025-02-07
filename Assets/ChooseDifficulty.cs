using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDifficulty : MonoBehaviour
{
    public void ChooseDDifficulty(string buttonName)
    {
        GameManager.Instance.selectedDifficulty = buttonName;

        GameManager.Instance.SaveData();
        GameManager.Instance.GameManagerDebugLogData();
    }
}
