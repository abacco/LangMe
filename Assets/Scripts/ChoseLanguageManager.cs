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
    public void SelectLanguage()
    {
        Debug.Log("I'am " + gameObject.name);
        dynamicLanguagePanel.SetActive(true);
        language_selected_text.text = buttonName;
    }

    public void SayMyName(string name)
    {
        buttonName = name;
        SelectLanguage();
    }
}
