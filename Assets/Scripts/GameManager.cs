using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameData;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string selectedLanguage;
    public int userLifes;
    public int solutionCounter;
    public int decine; // per lo star system
    public string selectedDifficulty;
    public string username;
    public string userNationality;
    public int totalStarsEarned;
    public int proficiencyTrackerIndex;
    public int languagesTrackerIndex;
    public int nodeTrackerIndex;

    public string imageSaved;


    public GameData.LanguageData[] LanguageCompleted;

    public GameData.NodeData[] ListOfNodes;
    public GameData.ProficiencyTracker[] proficiencyTracker;
    public GameData.ProficiencyTracker singleProficiencyTracker;

    public bool ready_for_test = false;

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
            userNationality = userNationality,
            decine = decine,
            totalStarsEarned = totalStarsEarned,
            proficiencyTrackerIndex = proficiencyTrackerIndex,
            languagesTrackerIndex = languagesTrackerIndex,

            singleProficiencyTracker = singleProficiencyTracker,
            proficiencyTracker = proficiencyTracker,

            LanguageCompleted = LanguageCompleted,
            ListOfNodes = ListOfNodes,
            nodeTrackerIndex = nodeTrackerIndex,

            imageSaved = imageSaved,
        };


        string json = JsonUtility.ToJson(gameData, true); // `true` per formattare bene il JSON

        //string json = Unity.Plastic.Newtonsoft.Json.JsonConvert.SerializeObject(gameData, Unity.Plastic.Newtonsoft.Json.Formatting.Indented);
        Debug.Log("JSON da salvare: -----------" + json);

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
            solutionCounter = (solutionCounter / 10)*10;

            proficiencyTrackerIndex = gameData.proficiencyTrackerIndex;
            languagesTrackerIndex = gameData.languagesTrackerIndex;

            userNationality = gameData.userNationality;
            decine = gameData.decine;
            totalStarsEarned = gameData.totalStarsEarned;


            proficiencyTracker = gameData.proficiencyTracker;
            singleProficiencyTracker = gameData.singleProficiencyTracker;

            LanguageCompleted = gameData.LanguageCompleted;
            ListOfNodes = gameData.ListOfNodes;
            nodeTrackerIndex = gameData.nodeTrackerIndex;

            imageSaved = gameData.imageSaved;

        }
        else
        {
            Debug.LogWarning("Nessun file di salvataggio trovato, usando i valori di default.");
            selectedLanguage = "Dutch";
            userLifes = 10;
            selectedDifficulty = "A1";  
            username = "default username";
            solutionCounter = 0;
            userNationality = "English";
            decine = 0;
            totalStarsEarned = 0;

            ListOfNodes = new GameData.NodeData[10];
            
            nodeTrackerIndex = 0;
            proficiencyTrackerIndex = 0;
            languagesTrackerIndex = 0;

            LanguageCompleted = new GameData.LanguageData[5]; // tutti i linguaggi

            proficiencyTracker = new GameData.ProficiencyTracker[6];
            imageSaved = "DefaultImageSaved";
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
        Debug.Log("GAME MANAGER: I AM IN THE -> " + SceneManager.GetActiveScene().name + "<-------------------------");
        Debug.Log("Data Loaded from Encrypted JSon ----------------");
        Debug.Log("selectedLanguage: " + this.selectedLanguage);
        Debug.Log("userLifes: " + this.userLifes);
        Debug.Log("selectedDifficulty: " + this.selectedDifficulty);
        Debug.Log("username: " + this.username);
        Debug.Log("userNationality: " + this.userNationality);
        Debug.Log("decine: " + this.decine); // per lo star system
        Debug.Log("Total Stars Earned: " + this.totalStarsEarned); // per lo star system
        Debug.Log("LanguageCompleted: " + this.LanguageCompleted.Length.ToString());
        Debug.Log("proficiencyTrackerIndex: " + this.proficiencyTrackerIndex.ToString()); // per il proficiency tracker index
        Debug.Log("proficiencyTracker: " + this.proficiencyTracker.ToString()); // per il proficiency tracker index
        Debug.Log("ListOfNodes Count: " + this.ListOfNodes.Length.ToString()); // per il proficiency tracker index
        Debug.Log("nodeTrackerIndex: " + this.nodeTrackerIndex.ToString()); // per il proficiency tracker index
        Debug.Log("-----------------------------------------------");
    }
}    