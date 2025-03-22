using System;
using Unity.VisualScripting;

[System.Serializable]
public class GameData
{
    public string imageSaved; // profileImage
    public string selectedLanguage;
    public int userLifes;
    public int decine; // for the star system
    public string selectedDifficulty;
    public string username;
    public string userNationality;
    public int totalStarsEarned;
    public int proficiencyTrackerIndex;
    public int languagesTrackerIndex;
    public int nodeTrackerIndex;

    public int solutionCounter;
    public LanguageData[] LanguageCompleted;

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
    public class LanguageData
    {
        public bool isCompleted;
        public string LanguageName;
        public int starsGained;

        public LanguageData(string LanguageName, bool isCompleted, int starsGained)
        {
            this.LanguageName = LanguageName;
            this.isCompleted = isCompleted;
            this.starsGained = starsGained;
        }

        public override string ToString()
        {
            return "TOSTRING LanguageData " + this.LanguageName + " isCompleted:" + this.isCompleted + " starsGained: " + this.starsGained + "\n";
        }
    }

    [System.Serializable]
    public class ProficiencyTracker
    {
        public string key;
        public bool isCompleted;
        public int starsGained;

        public ProficiencyTracker(string key, bool isCompleted, int starsGained)
        {
            this.key = key;
            this.isCompleted = isCompleted;
            this.starsGained = starsGained;
        }

        public override string ToString()
        {
            return "TOSTRING ProficiencyTracker " + this.key + "\n" + this.isCompleted.ToString() + " starsGained: " + this.starsGained + "\n";
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
