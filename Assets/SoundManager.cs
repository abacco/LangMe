using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // fruscio d'erba quando apri pannelli (magari più in là)

    //public AudioClip clickSound; // Suono da assegnare nell'Inspector
    //private AudioSource audioSource;

    //[SerializeField] Text on_off_text;

    //[SerializeField] GameObject startButton;
    //[SerializeField] GameObject creditsButton;
    //[SerializeField] GameObject soundButton;
    //public bool sound = true; // sposta nel game manager per il fatto che se clicchi audio off dall'inizio non devi disattivare l'audio ogni volta in scena!! 


    //// rumore di click coi pulsanti

    //private void Start()
    //{
    //    EnableDisableSound(); // allo start serve il check altrimenti quando clicchi tieni la scritta a on e l'audio off ed è un casino sincronizzare
    //    audioSource = GetComponent<AudioSource>();
    //    if (audioSource == null)
    //    {
    //        audioSource = gameObject.AddComponent<AudioSource>();
    //    }
    //    audioSource.playOnAwake = false;

    //    // Trova tutti i pulsanti presenti nella scena
    //    Button[] buttons = FindObjectsOfType<Button>();
    //    foreach (Button button in buttons)
    //    {
    //        button.onClick.AddListener(() => PlayClickSound());
    //    }
    //}
    //public void PlayClickSound()
    //{
    //    if (clickSound != null)
    //    {
    //        audioSource.PlayOneShot(clickSound);
    //    }
    //}
    //public void EnableDisableSound()
    //{
    //    if (sound)
    //    {
    //        UnmuteButtonsAudio();

    //        on_off_text.text = "on";
    //        sound = !sound;
    //    } else
    //    {
    //        MuteButtonsAudio();

    //        on_off_text.text = "off";
    //        sound = !sound;
    //    }
    //}

    //private void MuteButtonsAudio()
    //{
    //    audioSource.mute = true;
    //}
    //private void UnmuteButtonsAudio()
    //{
    //    audioSource.mute = false;
    //}
    public AudioClip clickSound; // Suono da assegnare nell'Inspector
    public AudioClip backgroundMusic; // Musica di background da assegnare nell'Inspector
    private AudioSource audioSource; // Per gli effetti sonori
    private AudioSource musicSource; // Per la musica di background

    [SerializeField] Text on_off_text;

    [SerializeField] GameObject startButton;
    [SerializeField] GameObject creditsButton;
    [SerializeField] GameObject soundButton;
    public bool sound = true; // sposta nel game manager per il fatto che se clicchi audio off dall'inizio non devi disattivare l'audio ogni volta in scena!! 

    private void Start()
    {
        // Configura l'AudioSource per gli effetti sonori
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;

        // Configura un AudioSource separato per la musica di background
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = backgroundMusic;
        musicSource.loop = true; // Ripete la musica in loop
        musicSource.playOnAwake = false; // Non avvia subito la musica
        musicSource.volume = 0.5f; // Volume regolabile
        PlayBackgroundMusic();

        // Trova tutti i pulsanti nella scena
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PlayClickSound());
        }

        // Sincronizza stato audio all'inizio
        EnableDisableSound();
    }

    public void PlayClickSound()
    {
        if (clickSound != null && !audioSource.mute) // Controlla se l'audio non è silenziato
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    public void PlayBackgroundMusic()
    {
        if (!musicSource.isPlaying) // Assicura che la musica non venga avviata più volte
        {
            musicSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
        }
    }

    public void EnableDisableSound()
    {
        if (sound)
        {
            UnmuteAudio();
            on_off_text.text = "on";
            sound = !sound;
        }
        else
        {
            MuteAudio();
            on_off_text.text = "off";
            sound = !sound;
        }
    }

    private void MuteAudio()
    {
        audioSource.mute = true; // Silenzia effetti sonori
        musicSource.mute = true; // Silenzia musica di background
    }

    private void UnmuteAudio()
    {
        audioSource.mute = false; // Riattiva effetti sonori
        musicSource.mute = false; // Riattiva musica di background
    }
}
