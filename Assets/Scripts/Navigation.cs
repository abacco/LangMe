using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    [SerializeField] GameObject openScenePanel;
    [SerializeField] TMP_Text scene_selected_text;

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
        "10 - Progress"
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
    public void YesSelected()
    {
        string s = scene_selected_text.text;
        
        foreach (string s2 in scenesName)
        {
            if (s2.ToLower().Contains(s.ToLower()))
            {
                MoveToScene(s2);
                //SceneManager.LoadScene(s2);
            }
        }
        //MoveToScene(scene_selected_text.text);
    }

    
}
