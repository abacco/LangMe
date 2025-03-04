using UnityEngine;

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
}
