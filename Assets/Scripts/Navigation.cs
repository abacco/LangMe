using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    // forse è inutile
    public string[] scenesName = {
        "1 - Startup",
        "2 -AlertScene",
        "3 - Select Username",
        "4 - ChooseALang",
        "5 - Choose Difficulty",
        "6 - Difficulty Rules",
        "7 - Exercise Scene"
    }; 

    public void MoveToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
