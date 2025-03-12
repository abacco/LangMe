using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameData.LanguageData LanguageDataStars;
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

            singleProficiencyTracker = singleProficiencyTracker,
            proficiencyTracker = proficiencyTracker,

            LanguageDataStars = LanguageDataStars,
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
            userNationality = gameData.userNationality;
            decine = gameData.decine;
            totalStarsEarned = gameData.totalStarsEarned;


            proficiencyTracker = gameData.proficiencyTracker;
            singleProficiencyTracker = gameData.singleProficiencyTracker;
            
            LanguageDataStars = gameData.LanguageDataStars;
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
            userNationality = "English";
            decine = 0;
            totalStarsEarned = 0;
            proficiencyTrackerIndex = 0;
            LanguageDataStars = new GameData.LanguageData(
                    "ProvaLinguaggio", new GameData.DifficultyData("ProvaDifficoltà", new GameData.NodeData("ProvaNodo", 1)));

            proficiencyTracker = new GameData.ProficiencyTracker[6];
            // only for test purpose
            //proficiencyTracker[0] = new GameData.ProficiencyTracker("Dutch_A1", true);
            //proficiencyTracker[1] = new GameData.ProficiencyTracker("Dutch_A2", true);
            //proficiencyTracker[2] = new GameData.ProficiencyTracker("Dutch_B1", true);
            //proficiencyTracker[3] = new GameData.ProficiencyTracker("Dutch_B2", true); // per fa prima coi click
            //proficiencyTracker[4] = new GameData.ProficiencyTracker("Dutch_C1", true);
            //proficiencyTracker[5] = new GameData.ProficiencyTracker("Dutch_C2", true);
            GameManagerDebugLogData();
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
        Debug.Log("LanguageDataStars: " + this.LanguageDataStars.ToString()); // per lo star system
        Debug.Log("proficiencyTrackerIndex: " + this.proficiencyTrackerIndex.ToString()); // per il proficiency tracker index
        Debug.Log("proficiencyTracker: " + this.proficiencyTracker.ToString()); // per il proficiency tracker index
        Debug.Log("-----------------------------------------------");
    }

    // prova logica -> LanguageProgressionScript
    // dutch, a1
    // a1, node_1
    // a1, node_2
    // a1, node_3
    // a1, .....
    // a1, node_10
    // dutch, a2
    // a1, node_1
    // a1, node_2
    // a1, node_3
    // a1, .....
    // a1, node_10
    /*
        {
            "dutch", 
                    {"A1", 
                        {
                        "Node1", 1    
                        },
                        {
                        "Node2", 3    
                        },
                    },
                    {
                    "A2",
                        {
                        "Node1", 1    
                        },
                        {
                        "Node2", 3    
                        },
                    },
                    {....},
                    {
                    "C2",
                        {
                        "Node1", 1    
                        },
                        {
                        "Node2", 3    
                        },
                    },   
        }  
    */

    // node1, earnedStar
}
