using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnglishLogic : MonoBehaviour
{
    public TMP_Dropdown tenseDropdown; 
    public TMP_Dropdown phraseTypeDropdown; 

    public TMP_InputField userInputField;
    public Button checkButton;
    public TMP_Text feedbackText;
    public TMP_Text rule_dynamic_text;
    public string selectedTense = "Present Simple"; // Cambia a seconda dell'esercizio

    private Dictionary<string, List<string>> questionTemplates = new Dictionary<string, List<string>>()
    {
        { "Present Simple", new List<string> { "Do {subject} {verb} {object}?", "Does {subject} {verb} {object}?" } },
        { "Past Simple", new List<string> { "Did {subject} {verb} {object}?" } },
        { "Present Continuous", new List<string> { "Is {subject} {verb-ing} {object}?", "Are {subject} {verb-ing} {object}?" } },
        { "Past Continuous", new List<string> { "Was {subject} {verb-ing} {object}?", "Were {subject} {verb-ing} {object}?" } },
        { "Future Simple", new List<string> { "Will {subject} {verb} {object}?" } },
        { "Present Perfect", new List<string> { "Have {subject} {verb-past} {object}?", "Has {subject} {verb-past} {object}?" } }
    };
    private Dictionary<string, string> affirmativeTenseRules = new Dictionary<string, string>()
    {
        { "Present Simple", "{subject} {verb} {object}." },
        { "Past Simple", "{subject} {verb-past} {object}." },
        { "Present Continuous", "{subject} is/are {verb-ing} {object}." },
        { "Past Continuous", "{subject} was/were {verb-ing} {object}." },
        { "Future Simple", "{subject} will {verb} {object}." },
        { "Present Perfect", "{subject} have/has {verb-past} {object}." }
    };
    private Dictionary<string, string> negativeTenseRules = new Dictionary<string, string>()
    {
        { "Present Simple", "{subject} do/does not {verb} {object}." },
        { "Past Simple", "{subject} did not {verb} {object}." },
        { "Present Continuous", "{subject} is/are not {verb-ing} {object}." },
        { "Past Continuous", "{subject} was/were not {verb-ing} {object}." },
        { "Future Simple", "{subject} will not {verb} {object}." },
        { "Present Perfect", "{subject} have/has not {verb-past} {object}." }
    };

    // piuttosto che creare un dizionario infinito, mostra la lista di parole disponibili magari
    private HashSet<string> singularPersons = new HashSet<string>() { "he", "she", "it" };
    private HashSet<string> pluralPersons = new HashSet<string>() { "i","you", "we", "they" };

    private HashSet<string> singleVerbsforQuestion = new HashSet<string>() { "eat", "like", "play", "read", "write", "run", "speak", "swim" };
    private HashSet<string> singleVerbsforAffirmationsAndNegations = new HashSet<string>() { "eats", "likes", "plays", "reads", "writes", "runs", "speaks", "swims" };
    private HashSet<string> continuousVerbs = new HashSet<string>() { "eating", "liking", "playing", "reading", "writing", "running", "speaking", "swimming" };
    private HashSet<string> pastVerbs = new HashSet<string>() { "ate", "liked", "played", "read", "wrote", "ran", "spoke", "swam" };
    private HashSet<string> futureVerbs = new HashSet<string>() { "eat", "like", "play", "read", "write", "run", "speak", "swim" };

    private HashSet<string> nouns = new HashSet<string>() { "apples", "football", "books", "letters", "games", "music", "movies", "languages" };

    void Start()
    {
        // in base al primo dropdown fai gli update

        //UpdateQuestionRule();
        HandlePhraseType();
        checkButton.onClick.AddListener(() => CheckUserInput(userInputField.text, selectedTense));
    }
    public void UpdateSelectedTense()
    {
        checkButton.onClick.RemoveAllListeners();
        checkButton.onClick.AddListener(() => CheckUserInput(userInputField.text, tenseDropdown.options[tenseDropdown.value].text));
        UpdateQuestionRule();
        Debug.Log("Selected Tense: " + tenseDropdown.options[tenseDropdown.value].text);
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
        string[] inputWords = input.ToLower().Split(' '); // Does he play football?
        string[] templateParts = template.Split(' '); // Does {subject} {verb} {object}?

        if (inputWords.Length != templateParts.Length)
            return false;

        if (inputWords.Length != 4)
            return false; // Deve avere esattamente 4 parole: (Do/Does) (subject) (verb) (object)?

        // question logic
        if (inputWords[0] == "do")
        {
            if (pluralPersons.Contains(inputWords[1]) && singleVerbsforQuestion.Contains(inputWords[2]) && nouns.Contains(inputWords[3]))
            {
                Debug.Log("The phrase is grammatically correct.");
                return true;
            }
        }
        else if (inputWords[0] == "does")
        {
            if (singularPersons.Contains(inputWords[1]) && singleVerbsforQuestion.Contains(inputWords[2]) && nouns.Contains(inputWords[3]))
            {
                Debug.Log("The phrase is grammatically correct.");
                return true;
            }
        }

        Debug.Log("The phrase is incorrect.");
        return false;
    }

    public void UpdateQuestionRule()
    {
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": rule_dynamic_text.text = "Do {subject} {verb} {object}?" +"\n" + "Does {subject} {verb} {object}?"; break;
            case "Past Simple": rule_dynamic_text.text = "Did {subject} {verb} {object}?";  break;
            case "Present Continuous": rule_dynamic_text.text = "Is {subject} {verb-ing} {object}?" + "\n" + "Are {subject} {verb-ing} {object}?"; break;
            case "Past Continuous": rule_dynamic_text.text = "Was {subject} {verb-ing} {object}?" + "\n" + "Were {subject} {verb-ing} {object}?"; break;
            case "Future Simple": rule_dynamic_text.text = "Will {subject} {verb} {object}?"; break;
            case "Present Perfect": rule_dynamic_text.text = "Have {subject} {verb-past} {object}?" + "\n" + "Has {subject} {verb-past} {object}?"; break;
            default: Debug.Log("error on UpdateQuestionRule"); break;
        }
        Debug.Log("Selected Tense: " + tenseDropdown.options[tenseDropdown.value].text);
    }

    public void UpdateAffirmationRule()
    {
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": rule_dynamic_text.text = "{subject} {verb} {object}."; break;
            case "Past Simple": rule_dynamic_text.text = "{subject} {verb-past} {object}."; break;
            case "Present Continuous": rule_dynamic_text.text = "{subject} is/are {verb-ing} {object}."; break;
            case "Past Continuous": rule_dynamic_text.text = "{subject} was/were {verb-ing} {object}."; break;
            case "Future Simple": rule_dynamic_text.text = "{subject} will {verb} {object}."; break;
            case "Present Perfect": rule_dynamic_text.text = "{subject} have/has {verb-past} {object}."; break;
            default: Debug.Log("error on UpdateAffirmationRule"); break;
        }
        Debug.Log("Selected Tense: " + tenseDropdown.options[tenseDropdown.value].text);
    }
    public void UpdateNegationRule()
    {
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": rule_dynamic_text.text = "{subject} do/does not {verb} {object}."; break;
            case "Past Simple": rule_dynamic_text.text = "{subject} did not {verb} {object}."; break;
            case "Present Continuous": rule_dynamic_text.text = "{subject} is/are not {verb-ing} {object}."; break;
            case "Past Continuous": rule_dynamic_text.text = "{subject} was/were not {verb-ing} {object}."; break;
            case "Future Simple": rule_dynamic_text.text = "{subject} will not {verb} {object}."; break;
            case "Present Perfect": rule_dynamic_text.text = "{subject} have/has not {verb-past} {object}."; break;
            default: Debug.Log("error on UpdateNegationRule"); break;
        }
        Debug.Log("Selected Tense: " + tenseDropdown.options[tenseDropdown.value].text);
    }

    public void HandlePhraseType()
    {
        switch (phraseTypeDropdown.options[phraseTypeDropdown.value].text)
        {
            case "Questions":
                UpdateQuestionRule(); break;
            case "Affirmations":
                UpdateAffirmationRule(); break;
            case "Negations":
                UpdateNegationRule(); break;
                default : Debug.Log("error on HandlePhraseType"); break;
        }
        Debug.Log("Selected Phrase Type: " + phraseTypeDropdown.options[phraseTypeDropdown.value].text);
    }
}