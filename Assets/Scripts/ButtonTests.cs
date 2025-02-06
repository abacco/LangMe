using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonTests : MonoBehaviour
{
    public void ClickTest()
    {
        Debug.Log("Test On Click");
    }
    public void LoseLife() {
        GameManager.Instance.userLifes--;
        GameManager.Instance.SaveData();
    }

    // ok 
    public void ChooseDifficulty(string buttonName)
    {
        GameManager.Instance.selectedDifficulty = buttonName;

        GameManager.Instance.SaveData();
        GameManager.Instance.GameManagerDebugLogData();
    }
}
