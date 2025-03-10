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

    [SerializeField] GameObject rememberPanel;

    public TMP_InputField userInputField;
    public Button checkButton;
    public TMP_Text feedbackText;
    public TMP_Text rule_dynamic_text;
    public string selectedTense = ""; // Cambia a seconda dell'esercizio

    List<string> possibleSimpleQuestions = new List<string>
    {
        "does she drink coffee?",
        "do they visit their grandparents?",
        "does he drive a car?",
        "do you enjoy music?",
        "does it rain often?",
        "do we arrive on time?",
        "does john play the piano?",
        "do the students listen to the teacher?",
        "does her brother work in an office?",
        "do my parents call me every day?",
        "does sarah write emails?",
        "do they like ice cream?",
        "does he walk to work?",
        "do you cook dinner?",
        "does it cost a lot?",
        "do we watch movies?",
        "does david travel often?",
        "do the kids do their homework?",
        "does your cat sleep a lot?",
        "do my neighbors have a car?",
        "does she clean the house?",
        "do they visit the museum?",
        "does he buy new clothes?",
        "do you sell books?",
        "does it work correctly?",
        "do we exercise daily?",
        "does emma dance well?",
        "do the birds sing in the morning?",
        "does his father fix cars?",
        "do my friends like sushi?",
        "does alice bake cakes?",
        "do they enjoy swimming?",
        "does he watch youtube?",
        "do you play chess?",
        "does it smell bad?",
        "do we take the bus?",
        "does tom paint pictures?",
        "do the workers arrive early?",
        "does her mother call her every day?",
        "do my cousins live in france?",
        "does she eat vegetables?",
        "do they study hard?",
        "does he read newspapers?",
        "do you prefer tea?",
        "does it sound good?",
        "do we sleep well?",
        "does jack help his brother?",
        "do the dogs bark at night?",
        "does his uncle work in a shop?",
        "do my classmates like math?",
        "does lily go to the gym?",
        "do they ride bicycles?",
        "does he repair computers?",
        "do you send emails?",
        "does it taste sweet?",
        "do we finish work at six?",
        "does sam play soccer?",
        "do the tourists visit london?",
        "does her boyfriend buy gifts?",
        "do my teachers give homework?",
        "does she open the windows?",
        "do they order food online?",
        "does he watch the news?",
        "do you wear a hat?",
        "does it rain in winter?",
        "do we dance at parties?",
        "does mike play video games?",
        "do the engineers build bridges?",
        "does his cousin study medicine?",
        "do my parents wake up early?",
        "does she brush her teeth?",
        "do they visit the zoo?",
        "does he love pizza?",
        "do you drink water?",
        "does it shine in summer?",
        "do we work together?",
        "does lisa wear glasses?",
        "do the children play outside?",
        "does her sister drive fast?",
        "do my grandparents travel a lot?",
        "does she listen to the radio?",
        "do they cook breakfast?",
        "does he teach english?",
        "do you like rock music?",
        "does it freeze in winter?",
        "do we meet on fridays?",
        "does james fix bikes?",
        "do the nurses take care of patients?",
        "does his boss arrive late?"
    };
    List<string> possibleComplexQuestions = new List<string>
    {
        "Why does she always drink coffee in the morning?",
        "When do they usually visit their grandparents on weekends?",
        "Where does he drive his car every evening?",
        "How often do you enjoy live music at the concert hall?",
        "Why does it rain so much in this city?",
        "What time do we normally arrive at the office?",
        "Which instrument does John play at the music academy?",
        "How do the students listen carefully to the teacher's explanations?",
        "Where does her brother work as an accountant in the city?",
        "Why do my parents always call me before dinner?",
        "When does Sarah write emails to her colleagues?",
        "Why do they love eating ice cream in winter?",
        "How far does he walk to work every morning?",
        "What dish do you usually cook for dinner?",
        "How much does it cost to park here for an hour?",
        "Why do we always watch horror movies at night?",
        "How frequently does David travel abroad for business?",
        "When do the kids do their homework after school?",
        "Where does your cat sleep during the day?",
        "Why do my neighbors always complain about the noise?",
        "How does she clean the house so quickly?",
        "Why do they visit the museum every Sunday?",
        "How often does he buy new clothes for special occasions?",
        "What kind of books do you usually sell at the store?",
        "Why does it work better with a new battery?",
        "How many hours do we exercise every week?",
        "Why does Emma dance so well at competitions?",
        "When do the birds start singing in the morning?",
        "How does his father fix cars so efficiently?",
        "Why do my friends love eating sushi at that restaurant?",
        "What type of cakes does Alice bake for birthdays?",
        "How much do they enjoy swimming in the lake?",
        "When does he watch YouTube after work?",
        "Why do you always play chess with your grandfather?",
        "How bad does it smell in the garbage room?",
        "What bus do we take to get to the museum?",
        "How does Tom paint such realistic pictures?",
        "When do the workers usually arrive at the factory?",
        "Why does her mother call her three times a day?",
        "How often do my cousins visit France for vacations?",
        "What vegetables does she eat for lunch?",
        "How long do they study for their exams?",
        "When does he read newspapers in the morning?",
        "Why do you prefer tea over coffee?",
        "How well does it sound with the new speakers?",
        "What time do we usually sleep on weekends?",
        "How often does Jack help his brother with homework?",
        "Why do the dogs bark at night so loudly?",
        "Where does his uncle work as a shop assistant?",
        "How much do my classmates like studying math?",
        "Why does Lily go to the gym so early?",
        "When do they ride bicycles in the park?",
        "How does he repair computers so quickly?",
        "Why do you send emails instead of calling?",
        "How sweet does it taste with honey?",
        "What time do we finish work on Fridays?",
        "How well does Sam play soccer?",
        "When do the tourists visit London the most?",
        "Why does her boyfriend buy expensive gifts?",
        "How much homework do my teachers give every day?",
        "How many windows does she open in the house?",
        "Why do they order food online instead of cooking?",
        "When does he watch the news on TV?",
        "Why do you wear a hat in summer?",
        "How much does it rain in winter?",
        "What kind of music do we dance to at parties?",
        "How often does Mike play video games?",
        "When do the engineers build new bridges?",
        "Why does his cousin study medicine abroad?",
        "How early do my parents wake up in the morning?"
    };
    private Dictionary<string, List<string>> wordCategories = new Dictionary<string, List<string>>()
    {
        { "wh-word", new List<string> { "why", "when", "where", "how", "what", "which" } },
        { "auxiliary", new List<string> { "does", "do" } },
        { "subject", new List<string> { "she", "he", "it", "we", "they", "you", "john", "sarah", "david", "emma", "jack" } },
        { "verb", new List<string> { "drink", "visit", "drive", "enjoy", "rain", "arrive", "play", "listen", "work", "call", "write", "like", "walk", "cook", "cost", "watch", "travel", "sleep", "have", "clean", "buy", "sell", "exercise", "dance", "sing", "fix", "bake", "swim", "teach", "eat", "study", "read", "prefer", "sound", "help", "bark", "go", "ride", "repair", "send", "taste", "finish", "build", "wake" } },
        { "object", new List<string> { "coffee", "car", "music", "emails", "ice cream", "movies", "homework", "office", "cat", "sushi", "cakes", "pictures", "glasses", "water", "bicycles", "computers", "tourists", "windows", "news", "bridges", "medicine" } },
        { "preposition", new List<string> { "in", "on", "at", "to", "with", "for", "before", "after", "during", "as" } },
        { "time", new List<string> { "morning", "weekends", "evening", "night", "winter", "Fridays" } }
    };

    void Start()
    {
        // in base al primo dropdown fai gli update
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
        switch (phraseTypeDropdown.options[phraseTypeDropdown.value].text)
        {
            case "Questions":
                bool isValid = MatchesPresentSimpleQuestionsStructure(userInput);
                feedbackText.text = isValid ? "Correct!" : "Incorrect structure. See the rules";
                break;
            case "Affirmations":
                break;
            case "Negations":
                break;
            default: Debug.Log("error on HandlePhraseType"); break;
        }
    }
    public void UpdateQuestionRule()
    {
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": rule_dynamic_text.text = Return_PresentSimple_Question_Rules(); break; // spostare nel panel
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



    private string Return_PresentSimple_Question_Rules()
    {
        return "{auxiliary} {subject} {verb} {object}?" + "\nEx.Does she like pizza?"; // aggiungere quello delle complex
    }


    static bool IsAValidSimpleQuestion(string input, List<string> possibleSimpleQuestions)
    {
        return possibleSimpleQuestions.Contains(input) ? true : false;
    }
    static bool IsAValidComplexQuestion(string input, List<string> possibleSimpleQuestions)
    {
        return possibleSimpleQuestions.Contains(input) ? true : false;
    }

    private bool MatchesPresentSimpleQuestionsStructure(string input)
    {
        if ("Questions".Equals(phraseTypeDropdown.options[phraseTypeDropdown.value].text))
        {
            return IsAValidSimpleQuestion(input, possibleSimpleQuestions) || IsAValidComplexQuestion(input, possibleComplexQuestions);
        }
        else if ("Affirmations".Equals(phraseTypeDropdown.options[phraseTypeDropdown.value].text))
        {
            return false;
        }
        else if ("Negations".Equals(phraseTypeDropdown.options[phraseTypeDropdown.value].text))
        {
            return true;
        }

        Debug.Log("The phrase is incorrect.");
        return false;
    }

    public void CloseRememberPanel()
    {
        rememberPanel.SetActive(false);
    }
}