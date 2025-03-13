using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Text on_off_text;
    
    public bool sound = true; // sposta nel game manager per il fatto che se clicchi audio off dall'inizio non devi disattivare l'audio ogni volta in scena!! 

    // fruscio d'erba quando apri pannelli 
    // rumore di click coi pulsanti

    private void Start()
    {
        EnableDisableSound(); // allo start serve il check altrimenti quando clicchi tieni la scritta a on e l'audio off ed è un casino sincronizzare
    }
    public void EnableDisableSound()
    {
        if (sound)
        {
            on_off_text.text = "on";
            sound = !sound;
        } else
        {
            on_off_text.text = "off";
            sound = !sound;
        }
    }
}
