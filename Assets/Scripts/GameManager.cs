using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string selectedLanguage;
    public int userLifes;
    public int solutionCounter;
    public string selectedDifficulty;
    public string username;

    // Percorso del file JSON
    private string filePath;
    public string FilePath { get; set; }

    private void Awake()
    {
        // Se esiste già un'istanza, distrugge la nuova per mantenere la persistenza
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        filePath = Path.Combine(Application.persistentDataPath, "saveData.json");
        this.FilePath = filePath;
    }

    private void Start()
    {
        LoadData();
    }

    // Quando vuoi salvare i progressi, chiama GameManager.Instance.SaveData();
    public void SaveData()
    {
        GameData gameData = new GameData()
        {
            selectedLanguage = selectedLanguage,
            userLifes = userLifes,
            selectedDifficulty = selectedDifficulty,
            username = username,
            solutionCounter = solutionCounter,
        };

        string json = JsonUtility.ToJson(gameData, true); // `true` per formattare bene il JSON
        string encryptedJson = EncryptionHelper.Encrypt(json); // Cripta il JSON
        File.WriteAllText(filePath, encryptedJson);
     
        Debug.Log("Dati salvati in JSON criptato." + filePath);
    }

    public void LoadData()
    {
        Debug.Log("IN LOAD DATA" + filePath);
        if (File.Exists(filePath)) {
            Debug.Log("IN LOAD DATA" + filePath);
            string encryptedJson = File.ReadAllText(filePath);
            string json = EncryptionHelper.Decrypt(encryptedJson); // Decripta il JSON
            GameData gameData = JsonUtility.FromJson<GameData>(json);
            
            selectedLanguage = gameData.selectedLanguage;
            userLifes = gameData.userLifes;
            selectedDifficulty = gameData.selectedDifficulty;
            username = gameData.username;
            solutionCounter = gameData.solutionCounter;
            GameManagerDebugLogData();
        }
        else
        {
            Debug.LogWarning("Nessun file di salvataggio trovato, usando i valori di default.");
            selectedLanguage = "English";
            userLifes = 10;
            selectedDifficulty = "A1";  
            username = "default username";
            solutionCounter = 0;
            //SaveData();  // Salva subito i dati di default, così il file verrà creato
        }
    }

    void OnApplicationQuit()
    {
        SaveData();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) // Se l'app va in background o si chiude
        {
            SaveData();
        }
    }
    public void ResetSavedData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void GameManagerDebugLogData() 
    {
        Debug.Log("Data Loaded from Encrypted JSon ----------------");
        Debug.Log("selectedLanguage: " + this.selectedLanguage);
        Debug.Log("userLifes: " + this.userLifes);
        Debug.Log("selectedDifficulty: " + this.selectedDifficulty);
        Debug.Log("username: " + this.username);
        Debug.Log("-----------------------------------------------");
    }
}
