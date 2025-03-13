using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // fruscio d'erba quando apri pannelli (magari più in là)
    private static SoundManager instance;

    public AudioClip clickSound; // Suono da assegnare nell'Inspector
    public AudioClip backgroundMusic; // Musica di background da assegnare nell'Inspector
    private AudioSource audioSource; // Per gli effetti sonori
    private AudioSource musicSource; // Per la musica di background

    [SerializeField] Text on_off_text;

    [SerializeField] GameObject startButton;
    [SerializeField] GameObject creditsButton;
    [SerializeField] GameObject soundButton;
    [SerializeField] GameObject on_off_textGo;
    public bool sound = true; // sposta nel game manager per il fatto che se clicchi audio off dall'inizio non devi disattivare l'audio ogni volta in scena!! 

    void Awake()
    {
        // Controlla se c'è già un'istanza esistente
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantieni il GameObject quando cambia scena
        }
        else
        {
            Destroy(gameObject); // Evita duplicati del GameObject
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Riaquisisci il riferimento al pulsante della nuova scena
        soundButton = GameObject.FindGameObjectWithTag("SoundBtn");
        on_off_textGo = GameObject.FindGameObjectWithTag("SoundBtnText");
        if (soundButton != null)
        {
            soundButton.GetComponent<Button>().onClick.RemoveAllListeners();
            soundButton.GetComponent<Button>().onClick.AddListener(() => EnableDisableSound());
        }
    }
    private void OnDestroy()
    {
        // Deregistra il callback per evitare errori
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals("1 - Startup"))
        {
            Debug.Log("SoundManager ok");
            soundButton = GameObject.FindGameObjectWithTag("SoundBtn");
            soundButton.GetComponent<Button>().onClick.AddListener(() => EnableDisableSound());
        }
        Debug.Log("SoundManager ok");
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
            if (on_off_text != null)
            {
                on_off_text.text = "on";
            }
            else { 
                on_off_textGo.GetComponent<Text>().text = "on";
            }
            sound = !sound;
        }
        else
        {
            MuteAudio();
            if (on_off_text != null)
            {
                on_off_text.text = "off";
            }
            else
            {
                on_off_textGo.GetComponent<Text>().text = "off";
            }
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
