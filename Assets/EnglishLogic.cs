using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnglishLogic : MonoBehaviour
{
    public TMP_InputField userInputField;
    public Button checkButton;
    public TMP_Text feedbackText;
    public string selectedTense = "PresentSimple"; // Cambia a seconda dell'esercizio

    bool withAdverb;

    private Dictionary<string, List<string>> questionTemplates = new Dictionary<string, List<string>>()
    {
        { "PresentSimple", new List<string> { "Do {subject} {verb} {object}?", "Does {subject} {verb} {object}?" } },
        { "PastSimple", new List<string> { "Did {subject} {verb} {object}?" } }
    };
    // piuttosto che creare un dizionario infinito, mostra la lista di parole disponibili magari

    private HashSet<string> singularPersons = new HashSet<string>() { "he", "she", "it" };
    private HashSet<string> pluralPersons = new HashSet<string>() { "i","you", "we", "they" };

    private HashSet<string> singleVerbsforQuestion = new HashSet<string>() { "eat", "like", "play" };
    private HashSet<string> singleVerbsforAffirmationsAndNegations = new HashSet<string>() { "eats", "likes", "plays" };
    private HashSet<string> continuousVerbs = new HashSet<string>() { "eating", "liking", "playing" };
    
    private HashSet<string> nouns = new HashSet<string>() { "apples", "football" };

    void Start()
    {
        checkButton.onClick.AddListener(() => CheckUserInput(userInputField.text, selectedTense));
    }

    public void CheckUserInput(string userInput, string tense)
    {
        if (!questionTemplates.ContainsKey(tense))
        {
            feedbackText.text = "Tense not recognized.";
            return;
        }

        List<string> validStructures = questionTemplates[tense];
        bool isValid = validStructures.Any(template => MatchesPresentSimpleQuestionsStructure(userInput, template));

        feedbackText.text = isValid ? "Correct!" : "Incorrect structure.";
    }

    // present simple questions struct STRUCT STRUCT STRUCT STRUCT STRUCT STRUCT STRUCT STRUCT STRUCT STRUCT STRUCT STRUCT STRUCT STRUCT STRUCT STRUCT
    private bool MatchesPresentSimpleQuestionsStructure(string input, string template)
    {
        string[] inputWords = input.Split(' '); // Does he play football?
        string[] templateParts = template.Split(' '); // Does {subject} {verb} {object}?

        if (inputWords.Length != templateParts.Length)
            return false;

        for (int i = 0; i < inputWords.Length; i++)
        {
            if (inputWords[0].ToLower().Equals("do"))
            {
                if (pluralPersons.Contains(inputWords[1]))
                {
                    if (singleVerbsforQuestion.Contains(inputWords[2]))
                    {
                        if (nouns.Contains(inputWords[3]))
                        {
                            Debug.Log("The phrase is grammatically correct.");
                            return true;
                        }
                    }
                }
            }
            if (inputWords[0].ToLower().Equals("does"))
            {
                if (singularPersons.Contains(inputWords[1]))
                {
                    if (singleVerbsforQuestion.Contains(inputWords[2]))
                    {
                        if (nouns.Contains(inputWords[3]))
                        {
                            Debug.Log("The phrase is grammatically correct.");
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
