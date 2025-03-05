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

    public int solutionCounter;
    public LanguageData LanguageDataStars;

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
        public NodeData node;
        public string DifficultyName;

        public DifficultyData(string DifficultyName, NodeData node)
        {
            this.DifficultyName = DifficultyName;
            this.node = node; 
        }


        public override string ToString()
        {
            return "TOSTRING DifficultyData " + this.DifficultyName + "\n" + this.node.ToString();
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

        public override string ToString()
        {
            return "TOSTRING LanguageData " + this.LanguageName + "\n" +this.Difficulty.ToString();
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
               $"  Total Stars Earned: {totalStarsEarned}\n" +
               "]";
    }



}
