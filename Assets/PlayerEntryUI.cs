using TMPro;
using UnityEngine;

public class PlayerEntryUI : MonoBehaviour
{
    public TextMeshProUGUI usernameText;
    public GameObject tooltip;
    public TextMeshProUGUI tooltipText;
    private string fullUsername;
    private int maxChars = 10; // Numero massimo di caratteri visibili

    public void SetUsername(string username)
    {
        fullUsername = username;

        // Troncamento con "..."
        if (username.Length > maxChars)
            usernameText.text = username.Substring(0, maxChars) + "...";
        else
            usernameText.text = username;

        // Setta il tooltip con il nome completo
        tooltipText.text = fullUsername;
    }

    // Mostra il tooltip quando passi sopra il nome
    public void ShowTooltip() => tooltip.SetActive(true);

    // Nasconde il tooltip quando esci
    public void HideTooltip() => tooltip.SetActive(false);
}
