using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonTests : MonoBehaviour
{
    public string sceneName = "5 - Difficulty Rules";
    public void MoveToScene5()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ClickTest()
    {
        Debug.Log("Test On Click");
    }

    public void ResetSavedData() { 
        PlayerPrefs.DeleteAll();
    }

    public void LoseLife() {
        GameManager.Instance.userLifes--;
        GameManager.Instance.SaveData();
    }
}
