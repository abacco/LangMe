[System.Serializable]
public class GameData
{
    public string selectedLanguage;
    public int userLifes;
    public int decine; // for the star system
    public string selectedDifficulty;
    public string username;
    public string userNationality;
    public int totalStarsEarned;
    public int proficiencyTrackerIndex;
    public int nodeTrackerIndex;

    public int solutionCounter;
    public LanguageData LanguageDataStars;
    public ProficiencyTracker[] proficiencyTracker;

    public NodeData[] ListOfNodes;

    public ProficiencyTracker singleProficiencyTracker;

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

        public override string ToString()
        {
            return "TOSTRING NodeData " + this.NodeName + "\n" + this.Stars.ToString();
        }
    }

    [System.Serializable]
    public class DifficultyData
    {
        public NodeData[] nodeList;
        public string DifficultyName;

        public DifficultyData(string DifficultyName, NodeData[] nodeList)
        {
            this.DifficultyName = DifficultyName;
            this.nodeList = nodeList; 
        }

        public override string ToString()
        {
            return "TOSTRING DifficultyData " + this.DifficultyName + "\n" + this.nodeList.ToString();
        }
    }

    [System.Serializable]
    public class LanguageData
    {
        public DifficultyData Difficulty;
        public string LanguageName;

        public NodeData[] Nodes;

        public LanguageData(string LanguageName, DifficultyData Difficulty)
        {
            this.LanguageName = LanguageName;
            this.Difficulty = Difficulty;
        }

        public override string ToString()
        {
            return "TOSTRING LanguageData " + this.LanguageName + "\n" + this.Difficulty.ToString();
        }
    }

    [System.Serializable]
    public class ProficiencyTracker
    {
        public string key;
        public bool isCompleted;

        public ProficiencyTracker(string key, bool isCompleted)
        {
            this.key = key;
            this.isCompleted = isCompleted;
        }

        public override string ToString()
        {
            return "TOSTRING ProficiencyTracker " + this.key + "\n" + this.isCompleted.ToString();
        }
    }


    public override string ToString()
    {
        return $"GameData: [\n" +
               $"  Selected Language: {selectedLanguage}\n" +
               $"  User Lifes: {userLifes}\n" +
               $"  Decine (Stars System): {decine}\n" +
               $"  Selected Difficulty: {selectedDifficulty}\n" +
               $"  Username: {username}\n" +
               $"  User Nationality: {userNationality}\n" +
               $"  Solution Counter: {solutionCounter}\n" +
               $"  Total Stars Earned: {proficiencyTracker.Length}\n" +
               $"  Proficiency Tracker: {singleProficiencyTracker}\n" +
               "]";
    }
}
