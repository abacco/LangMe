using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FakeLeaderBoardManager : MonoBehaviour
{
    [System.Serializable]
    public class LeaderboardEntry
    {
        public string playerName;
        public int score;
    }

    public Transform leaderboardContainer; // Il contenitore degli elementi della leaderboard
    public GameObject leaderboardEntryPrefab; // Il prefab per ogni entry

    private List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();

    void Start()
    {
        GenerateFakeLeaderboard();
        PopulateLeaderboardUI();
    }

    void GenerateFakeLeaderboard()
    {
        // 30 stelle per Proficiency (a1,a2,b1,b2,c1,c2) per Linguaggio (5 iniziali + 1 inglese) => 30 x 6 x 6 = 1080 stars max
        leaderboardEntries.Clear();
        for (int i = 1; i <= 100; i++)
        {
            leaderboardEntries.Add(new LeaderboardEntry { playerName = "Player " + i, score = Random.Range(0, 1080) });   
        }
        leaderboardEntries.Sort((a, b) => b.score.CompareTo(a.score)); // Ordina la classifica - per forza, sennò non hai l'ultimo per fare il confronto

        // se l'utente ha almeno più punti dell'ultimo, deve entrare in classifica e appunto si deve riordinare
        if (GameManager.Instance.totalStarsEarned > leaderboardEntries[leaderboardEntries.Count-1].score)  
        {
            leaderboardEntries.Add(new LeaderboardEntry { playerName = GameManager.Instance.username, score = GameManager.Instance.totalStarsEarned });
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
            
            newEntry.GetComponent<PlayerEntryUI>().SetUsername(entry.playerName);
            if (newEntry.transform.Find("PlayerName").GetComponent<TMP_Text>().text.ToLower().Equals(GameManager.Instance.username))
            {
                newEntry.transform.Find("PlayerName").GetComponent<TMP_Text>().text = GameManager.Instance.username;
                newEntry.transform.Find("PlayerStars").GetComponent<TMP_Text>().text = GameManager.Instance.totalStarsEarned.ToString();

                newEntry.transform.Find("PlayerName").GetComponent<TMP_Text>().color = Color.yellow;
                newEntry.transform.Find("PlayerStars").GetComponent<TMP_Text>().color = Color.yellow;
            }
            else
            {
                newEntry.transform.Find("PlayerName").GetComponent<TMP_Text>().text = entry.playerName;
                newEntry.transform.Find("PlayerStars").GetComponent<TMP_Text>().text = entry.score.ToString();
            }
        }
    }
}
