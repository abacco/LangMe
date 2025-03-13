using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject myThanksImagePanel;
    [SerializeField] GameObject creditsImagePanel;

    public void OpenCloseMyThanksImagePanelImagePanel()
    {
        if (myThanksImagePanel != null)
        {
            myThanksImagePanel.SetActive(!myThanksImagePanel.activeSelf);
        }
    }
    public void OpenCloseCreditsImagePanelImagePanel()
    {
        if (creditsImagePanel != null)
        {
            creditsImagePanel.SetActive(!creditsImagePanel.activeSelf);
        }
    }
}
