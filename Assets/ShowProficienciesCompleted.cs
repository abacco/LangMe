using UnityEngine;

public class ShowProficienciesCompleted : MonoBehaviour
{
    public void ShowProficiencies()
    {
        GameManager.Instance.LoadData();
        for(int i = 0; i < GameManager.Instance.LanguageCompleted.Length; i++)
        {
            Debug.Log(GameManager.Instance.LanguageCompleted[i] + "\n");
        }
    }
}
