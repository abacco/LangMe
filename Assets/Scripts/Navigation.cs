using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    [SerializeField] GameObject openScenePanel;
    [SerializeField] GameObject warningOfLostProgressPanel;
    [SerializeField] TMP_Text scene_selected_text;
    bool warningPanelYesClick = false;
    // forse è inutile
    public string[] scenesName = {
        "1 - Startup",
        "2 - AlertScene",
        "3 - Select Username",
        "4 - Choose A Language",
        "5 - Choose Difficulty",
        "6 - Difficulty Rules",
        "7 - Home",
        "8 - Exercise Scene", 
        "9 - Dictionary",
        "10 - Progress",
        "14 - Exam Scene"
    }; 

    public void MoveToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenMoveToScenePanel(string chosenBtnName) // used in Home Scene
    {
        openScenePanel.SetActive(true);
        scene_selected_text.text = chosenBtnName;
    }
    public void NoSelected()
    {
        openScenePanel.SetActive(false);
    }

    public void CloseWarningProgressLostPanel()
    {
        warningOfLostProgressPanel.SetActive(false);
    }
    public void OpenWarningProgressLostPanel()
    {
        warningOfLostProgressPanel.SetActive(true);
    }

    public void YesSelected()
    {
        string s = scene_selected_text.text;
        foreach (string s2 in scenesName)
        {
            if (s2.ToLower().Contains(s.ToLower()))
            {
                if ((s.Contains("Difficulty") || s.Contains("Language")) && "7 - Home".Equals(SceneManager.GetActiveScene().name))
                {
                    GameManager.Instance.solutionCounter = 0;
                    GameManager.Instance.SaveData();
                    warningOfLostProgressPanel.SetActive(true);
                    if (warningPanelYesClick)
                    {
                        MoveToScene(s2);
                    } else
                    {
                        warningPanelYesClick = true;
                    }
                }
                else if (s.Contains("Exam"))
                {
                    GameManager.Instance.ready_for_test = true;
                    MoveToScene(s2);
                }
                else
                {
                    MoveToScene(s2);
                }
            }
        }
    }

    
}
