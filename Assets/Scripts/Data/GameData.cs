using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public string selectedLanguage;
    public int userLifes;
    public int decine; // for the star system
    public string selectedDifficulty;
    public string username;
    public string userNationality;

    public int solutionCounter;
    public LanguageData LanguageDataStars;
    // star system
    // Dizionario di dizionari annidati per tenere traccia dei punteggi
    //public Dictionary<string, Dictionary<string, Dictionary<string, int>>> LanguageDataStars;
    //public Dictionary<string, Dictionary<string, int>> DifficultyDataStars;
    //public Dictionary<string, int> NodeDataStars;

    [System.Serializable]
    public class NodeData
    {
        public int Stars; 
        public string NodeName;

        public NodeData(string NodeName, int Stars)
        {
            this.NodeName = NodeName;
            this.Stars = Stars;
        }
    }

    [System.Serializable]
    public class DifficultyData
    {
        public NodeData node;
        public string DifficultyName;

        public DifficultyData(string DifficultyName, NodeData node)
        {
            this.DifficultyName = DifficultyName;
            this.node = node; 
        }
    }

    [System.Serializable]
    public class LanguageData
    {
        public DifficultyData Difficulty;
        public string LanguageName;

        public LanguageData(string LanguageName, DifficultyData Difficulty)
        {
            this.LanguageName = LanguageName;
            this.Difficulty = Difficulty;  
        }
    }
}
