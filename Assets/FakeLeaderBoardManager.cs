using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeLeaderBoardManager : MonoBehaviour
{
    [System.Serializable]
    public class LeaderboardEntry
    {
        public string playerName;
        public int score;
        //public Image randomProfileImage; - WIP
    }

    public Transform leaderboardContainer; // Il contenitore degli elementi della leaderboard
    public GameObject leaderboardEntryPrefab; // Il prefab per ogni entry

    public List<Sprite> imageList;
    public Image targetImage; // Immagine UI dove verrà mostrata l'immagine selezionata

    private List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();

    void Start()
    {
        GameManager.Instance.LoadData();
        GenerateFakeLeaderboard();
        PopulateLeaderboardUI();
    }


    void GenerateFakeLeaderboard()
    {
        Sprite randomSprite = imageList[Random.Range(0, imageList.Count)];
        targetImage.sprite = randomSprite;
        // the master
        LeaderboardEntry AlexTheFounder = new LeaderboardEntry
        {
            playerName = "AlexTheFounder",
            score = 1079,
            //randomProfileImage = targetImage
        };


        // 30 stelle per Proficiency (a1,a2,b1,b2,c1,c2) per Linguaggio (5 iniziali + 1 inglese) => 30 x 6 x 6 = 1080 stars max
        leaderboardEntries.Clear();
        for (int i = 1; i <= 100; i++)
        {
            LeaderboardEntry entry = new LeaderboardEntry
            {
                playerName = GenerateLofiNickname(),
                score = Random.Range(0, 1080),
                //randomProfileImage = targetImage // wip
            };

            // Controlla i duplicati basandoti su playerName
            bool exists = leaderboardEntries.Exists(e => e.playerName == entry.playerName);

            if (!exists)
            {
                leaderboardEntries.Add(entry);
            }
        }
        leaderboardEntries.Add(AlexTheFounder);
        leaderboardEntries.Sort((a, b) => b.score.CompareTo(a.score)); // Ordina la classifica - per forza, sennò non hai l'ultimo per fare il confronto

        // se l'utente ha almeno più punti dell'ultimo, deve entrare in classifica e appunto si deve riordinare
        if (GameManager.Instance.totalStarsEarned > leaderboardEntries[leaderboardEntries.Count-1].score)  
        {
            leaderboardEntries.Add(new LeaderboardEntry { playerName = GameManager.Instance.username.ToLower(), score = GameManager.Instance.totalStarsEarned });
            leaderboardEntries.Sort((a, b) => b.score.CompareTo(a.score)); // Ordina la classifica
        }
    }

    void PopulateLeaderboardUI()
    {
        foreach (Transform child in leaderboardContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var entry in leaderboardEntries)
        {
            GameObject newEntry = Instantiate(leaderboardEntryPrefab, leaderboardContainer);
            if (entry.playerName.Equals("AlexTheFounder"))
            {
                Color customColor;
                if (ColorUtility.TryParseHtmlString("#FFB500", out customColor))
                {
                    newEntry.transform.Find("PlayerName").GetComponent<Text>().color = customColor;
                    newEntry.transform.Find("PlayerStars").GetComponent<Text>().color = customColor;
                }
            }
            if (entry.playerName.Equals(GameManager.Instance.username.ToLower()))
            {
                newEntry.transform.Find("PlayerName").GetComponent<Text>().text = GameManager.Instance.username;
                newEntry.transform.Find("PlayerStars").GetComponent<Text>().text = GameManager.Instance.totalStarsEarned.ToString();
                //newEntry.transform.Find("RandomProfileImage").GetComponent<Image>().sprite = imageList[Random.Range(0, imageList.Count)];

                Color customColor;
                if (ColorUtility.TryParseHtmlString("#FFFF4A", out customColor))
                {
                    newEntry.transform.Find("PlayerName").GetComponent<Text>().color = customColor;
                    newEntry.transform.Find("PlayerStars").GetComponent<Text>().color = customColor;
                    //newEntry.transform.Find("RandomProfileImage").GetComponent<Image>().sprite = imageList[Random.Range(0, imageList.Count)];
                }
            }
            else
            {
                newEntry.transform.Find("PlayerName").GetComponent<Text>().text = newEntry.GetComponent<PlayerEntryUI>().ChopUsername(entry.playerName);
                newEntry.transform.Find("PlayerStars").GetComponent<Text>().text = entry.score.ToString();
            }
        }
    }

    private static List<string> names = new List<string>()
    {
        "Alex", "James", "John", "Michael", "David", "Robert", "Daniel", "Thomas",
        "William", "Charles", "George", "Henry", "Edward", "Anthony", "Paul",
        "Andrew", "Peter", "Samuel", "Joseph", "Mark", "Benjamin", "Christopher",
        "Patrick", "Richard", "Arthur", "Matthew", "Ethan", "Liam", "Jack",
        "Ryan", "Luke", "Nathan", "Oliver", "Oscar",
        "Marta", "Sophia", "Emma", "Olivia", "Isabella", "Ava", "Mia", "Emily",
        "Charlotte", "Amelia", "Ella", "Grace", "Luna", "Chloe", "Victoria",
        "Zoe", "Hannah", "Sarah", "Alice", "Evelyn", "Lucy", "Lily", "Madeline",
        "Claire", "Eva", "Nora", "Caroline", "Leah", "Natalie", "Elena",
        "Ruby", "Isla", "Audrey", "Savannah",
        "Taylor", "Jordan", "Alex", "Sam", "Chris", "Jules", "Max", "Jamie",
        "Casey", "Morgan", "Robin", "Drew", "Rowan", "Sky", "Cameron", "Kai",
        "Reese", "Elliot", "Sasha", "Avery", "Charlie", "Quinn", "Riley", "Adrian",
        "Peyton", "Logan", "Hayden", "Dakota", "Alexis", "Shay", "Emery"
    };
    private static List<string> nationalities = new List<string>()
    {
        "Dutch", "British", "Italian", "French", "German", "Spanish", "Portuguese",
        "Greek", "Turkish", "Swedish", "Norwegian", "Finnish", "Danish", "Polish",
        "Russian", "Ukrainian", "Czech", "Hungarian", "Romanian", "Bulgarian", "Swiss",
        "Austrian", "Irish", "Scottish", "Welsh", "Canadian", "American", "Mexican",
        "Brazilian", "Argentinian", "Chilean", "Peruvian", "Colombian", "Venezuelan",
        "Australian", "NewZealander", "Japanese", "Chinese", "Korean", "Indian",
        "Pakistani", "Bangladeshi", "SriLankan", "Thai", "Vietnamese", "Filipino",
        "Indonesian", "SouthAfrican", "Egyptian", "Nigerian", "Kenyan", "Moroccan",
        "Tunisian"
    };

    private static List<string> adjectives = new List<string>
    {
        "Chill", "Cozy", "Dreamy", "Soft", "Lazy", "Mellow", "Vintage",
        "Funky", "Groovy", "Smooth", "Calm", "Cool", "Retro", "Silent",
        "Shady", "Hidden", "Wavy", "Lo-Fi", "Quiet", "Gentle", "Tranquil",
        "Ethereal", "Ambient", "Peaceful", "Vivid", "Breezy", "Shimmering",
        "Silent", "Golden", "Flowing", "Lush", "Pastel", "Velvet", "Cloudy",
        "Rainy", "Starry", "Warm", "Luminous", "Harmonic", "Balanced",
        "Flowy", "Serene", "Bright", "Radiant", "Sublime", "Minimal", "Infinite",
        "Majestic", "Muted", "Abstract", "Tender", "Frosty", "Glossy",
        "Relaxed", "Ambient", "Earthy", "Melodic", "Soothing", "Weightless"
    };

    private static List<string> topics = new List<string>
    {
        "Dreamer", "Vibes", "Wanderer", "Soul", "Artist", "Player",
        "Producer", "Listener", "Guru", "Guy", "Gal", "Master",
        "Maker", "Creator", "Mixer", "Traveler", "Nomad", "Rider",
        "Explorer", "Adventurer", "Seeker", "Visionary", "Thinker",
        "Sage", "Scholar", "Speaker", "Doer", "Innovator", "Writer",
        "Observer", "Storyteller", "Champion", "Designer", "Builder",
        "Pathfinder", "Leader", "Strategist", "Inventor", "Planner",
        "Composer", "Musician", "Friend", "Helper", "Craftsman",
        "Tinkerer", "Curator", "Navigator", "Guardian", "Supporter",
        "Dreamcatcher", "Challenger", "Pioneer", "Philosopher"
    };

    private static List<string> extras = new List<string>
    {
        "TheLofi", "InTheBasement", "OnTheMove", "FromTheClouds",
        "OfTheNight", "FromTheWaves", "OnFire", "InTheStudio",
        "UnderTheStars", "FromTheVoid", "WithCaffeine", "WithVinyl",
        "TheDutch", "OnRepeat", "FromTheSunset", "ByTheFireplace",
        "OnTheEdge", "ThroughTime", "OfTheHorizon", "InTheShadows",
        "BeyondTheSky", "InTheRain", "ThroughTheMist", "OfTheStorm",
        "UnderTheMoon", "FromTheMeadow", "WithHarmony", "OverTheSea",
        "FromTheRoots", "ThroughTheGalaxy", "OnTheWaves", "UnderTheAurora",
        "WithTheStars", "AcrossThePlains", "OnTheTrail", "ThroughTheWoods",
        "BeyondTheStars", "OverTheHill", "InTheGlow", "ByTheWindow",
        "UnderTheCanopy", "InTheSilence", "OfTheFields"
    };

    public static string GenerateLofiNickname()
    {
        System.Random random = new System.Random();

        // Combinazioni casuali
        string name = names[random.Next(names.Count)];
        string nationality = nationalities[random.Next(nationalities.Count)];
        string adjective = adjectives[random.Next(adjectives.Count)];
        string topic = topics[random.Next(topics.Count)];
        string extra = extras[random.Next(extras.Count)];

        int randomNumber = random.Next(10, 999);

        // Formato del nickname
        return $"{name}{nationality}{adjective}{topic}";
    }
}
