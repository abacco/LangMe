using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoseLanguageManager : MonoBehaviour
{
    [SerializeField] GameObject dynamicLanguagePanel;
    [SerializeField] TMP_Text language_selected_text;
    [SerializeField] Button proceedBtn; // are you sure? Yes
    [SerializeField] Button noBtn; // are you sure? No

    public string buttonName;


    public void SayMyName(string name)
    {
        buttonName = name;
        SelectLanguage();
    }

    public void SelectLanguage()
    {
        Debug.Log("I'am " + gameObject.name);
        dynamicLanguagePanel.SetActive(true);
        language_selected_text.text = buttonName;
        GameManager.Instance.GameManagerDebugLogData();
    }

    public void NoSelected() 
    {
        dynamicLanguagePanel.SetActive(false);

        GameManager.Instance.GameManagerDebugLogData();
    }

    public void LanguageChosen() 
    {
        GameManager.Instance.selectedLanguage = buttonName;
        GameManager.Instance.SaveData();
        GameManager.Instance.GameManagerDebugLogData();

        GameObject.FindObjectOfType<Navigation>().MoveToScene("5 - Choose Difficulty");
        dynamicLanguagePanel.SetActive(false);

    }
}
