using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AquireUserName : MonoBehaviour
{
    [SerializeField] InputField inputfield;
    [SerializeField] GameObject areYouSurePanel;
    [SerializeField] GameObject insertNamePanel;

    [SerializeField] Text selectedUserName_txt;
    public void AquireUsername()
    {
        if (inputfield != null && !"".Equals(inputfield.text)) {
            GameManager.Instance.username = inputfield.text;
            Debug.Log("UserName Aquired: " + GameManager.Instance.username);
            //GameManager.Instance.SaveData();
            Debug.Log("UserName Saved in " + GameManager.Instance.FilePath);
            AmISure();

            //GameManager.Instance.GameManagerDebugLogData();
        } else
        {
            Debug.LogWarning("Input Field ''");
            insertNamePanel.SetActive(true);
        }
        
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
        SceneManager.LoadScene("4 - Choose A Language");
    }

    public void NO()
    {
        areYouSurePanel.SetActive(false);
        if(insertNamePanel.activeInHierarchy)
        {
            insertNamePanel.SetActive(false);
        }
    }
}
