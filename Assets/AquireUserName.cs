using TMPro;
using UnityEngine;

public class AquireUserName : MonoBehaviour
{
    [SerializeField] TMP_InputField inputfield;

    public void AquireUsername()
    {
        GameManager.Instance.username = inputfield.text;
        Debug.Log("UserName Aquired: " + GameManager.Instance.username);
        GameManager.Instance.SaveData();
        Debug.Log("UserName Saved in " + GameManager.Instance.FilePath);
        GameManager.Instance.GameManagerDebugLogData();
    }

}
