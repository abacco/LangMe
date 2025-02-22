using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseDifficulty : MonoBehaviour
{

    [SerializeField] GameObject areYouSurePanel;
    [SerializeField] GameObject proficiencyPanel;

    [SerializeField] TMP_Text selectedDifficulty_txt;
    private string buttonName;

    public void ChooseDDifficulty(string buttonName)
    {
        this.buttonName = buttonName;
        GameManager.Instance.selectedDifficulty = buttonName;
        AmISure();
    }

    public void AmISure()
    {
        areYouSurePanel.SetActive(true);
        selectedDifficulty_txt.text = this.buttonName;
    }

    public void YES()
    {
        GameManager.Instance.selectedDifficulty = this.buttonName;
        GameManager.Instance.SaveData();
        GameManager.Instance.GameManagerDebugLogData();
        GameObject.FindObjectOfType<Navigation>().MoveToScene("6 - Difficulty Rules");
    }

    public void NO()
    {
        areYouSurePanel.SetActive(false);
    }

    public void ShowProficiencyPanel()
    {
        proficiencyPanel.SetActive(true);
    }

    public void HideProficiencyPanel()
    {
        proficiencyPanel.SetActive(false);
    }
}
