using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AquireUserName : MonoBehaviour
{
    [SerializeField] TMP_InputField inputfield;
    [SerializeField] GameObject areYouSurePanel;

    [SerializeField] TMP_Text selectedUserName_txt;
    public void AquireUsername()
    {
        GameManager.Instance.username = inputfield.text;
        Debug.Log("UserName Aquired: " + GameManager.Instance.username);
        //GameManager.Instance.SaveData();
        Debug.Log("UserName Saved in " + GameManager.Instance.FilePath);
        AmISure();

        GameManager.Instance.GameManagerDebugLogData();
    }

    public void AmISure()
    {
        areYouSurePanel.SetActive(true);
        selectedUserName_txt.text = inputfield.text;
    }

    public void YES()
    {
        GameManager.Instance.username = inputfield.text;
        GameManager.Instance.SaveData();
        SceneManager.LoadScene("4 - ChooseALang");
    }

    public void NO()
    {
        areYouSurePanel.SetActive(false);
    }
}
