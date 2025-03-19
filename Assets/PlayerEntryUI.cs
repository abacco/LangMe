using UnityEngine;
using UnityEngine.UI;

public class PlayerEntryUI : MonoBehaviour
{
    public Text usernameText;
    public GameObject tooltip;
    public Text tooltipText;
    private string fullUsername;
    private int maxChars = 10; // Numero massimo di caratteri visibili

    public string ChopUsername(string username)
    {
        fullUsername = username;

        // Verifica se il nome utente supera maxChars
        if (username.Length > maxChars)
        {
            Debug.Log("PlayerEntryUI I'm here");
            usernameText.text = username.Substring(0, maxChars) + "..."; // Troncamento con "..."
        }
        else
        {
            usernameText.text = username; // Nessun troncamento necessario
        }

        // Setta il tooltip con il nome completo
        tooltipText.text = fullUsername;

        // Verifica preventiva per evitare eccezioni
        if (username.Length > maxChars)
        {
            return username.Substring(0, maxChars) + "...";
        }
        else
        {
            return username; // Restituisci il nome completo se non serve troncamento
        }
    }

    // Mostra il tooltip quando passi sopra il nome
    public void ShowTooltip() => tooltip.SetActive(true);

    // Nasconde il tooltip quando esci
    public void HideTooltip() => tooltip.SetActive(false);
}
