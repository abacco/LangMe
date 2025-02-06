using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public string sceneName = "5 - Difficulty Rules";
    public void MoveToScene5()
    {
        SceneManager.LoadScene(sceneName);
    }
}
