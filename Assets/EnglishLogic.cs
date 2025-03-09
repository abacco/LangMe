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

    //private Dictionary<string, List<string>> questionTemplates = new Dictionary<string, List<string>>()
    //{
    //    { "Present Simple", new List<string> { "Do {subject} {verb} {object}?", "Does {subject} {verb} {object}?" } },
    //    { "Past Simple", new List<string> { "Did {subject} {verb} {object}?" } },
    //    { "Present Continuous", new List<string> { "Is {subject} {verb-ing} {object}?", "Are {subject} {verb-ing} {object}?" } },
    //    { "Past Continuous", new List<string> { "Was {subject} {verb-ing} {object}?", "Were {subject} {verb-ing} {object}?" } },
    //    { "Future Simple", new List<string> { "Will {subject} {verb} {object}?" } },
    //    { "Present Perfect", new List<string> { "Have {subject} {verb-past} {object}?", "Has {subject} {verb-past} {object}?" } }
    //};
    private Dictionary<string, List<string>> questionTemplates = new Dictionary<string, List<string>>()
    {
        { "Present Simple", new List<string>
            {
                "Do {subject} {verb} {object} {preposition} {complement} {adverb}?",
                "Does {subject} {verb} {object} {preposition} {complement} {adverb}?"
            }
        },
        { "Past Simple", new List<string>
            {
                "Did {subject} {verb} {object} {preposition} {complement} {adverb}?"
            }
        },
        { "Present Continuous", new List<string>
            {
                "Is {subject} {verb-ing} {object} {preposition} {complement} {adverb}?",
                "Are {subject} {verb-ing} {object} {preposition} {complement} {adverb}?"
            }
        },
        { "Past Continuous", new List<string>
            {
                "Was {subject} {verb-ing} {object} {preposition} {complement} {adverb}?",
                "Were {subject} {verb-ing} {object} {preposition} {complement} {adverb}?"
            }
        },
        { "Future Simple", new List<string>
            {
                "Will {subject} {verb} {object} {preposition} {complement} {adverb}?"
            }
        },
        { "Present Perfect", new List<string>
            {
                "Have {subject} {verb-past} {object} {preposition} {complement} {adverb}?",
                "Has {subject} {verb-past} {object} {preposition} {complement} {adverb}?"
            }
        }
    };
    private Dictionary<string, string> affirmativeTemplate = new Dictionary<string, string>()
    {
        { "Present Simple", "{subject} {verb} {object}." },
        { "Past Simple", "{subject} {verb-past} {object}." },
        { "Present Continuous", "{subject} is/are {verb-ing} {object}." },
        { "Past Continuous", "{subject} was/were {verb-ing} {object}." },
        { "Future Simple", "{subject} will {verb} {object}." },
        { "Present Perfect", "{subject} have/has {verb-past} {object}." }
    };
    private Dictionary<string, string> negativeTemplate = new Dictionary<string, string>()
    {
        { "Present Simple", "{subject} do/does not {verb} {object}." },
        { "Past Simple", "{subject} did not {verb} {object}." },
        { "Present Continuous", "{subject} is/are not {verb-ing} {object}." },
        { "Past Continuous", "{subject} was/were not {verb-ing} {object}." },
        { "Future Simple", "{subject} will not {verb} {object}." },
        { "Present Perfect", "{subject} have/has not {verb-past} {object}." }
    };

    // piuttosto che creare un dizionario infinito, mostra la lista di parole disponibili magari
    private HashSet<string> singularSubjects = new HashSet<string>() { "he", "she", "it" };
    private HashSet<string> pluralSubjects = new HashSet<string>() { "i","you", "we", "they" };

    private HashSet<string> singleVerbsforQuestion = new HashSet<string>() { "eat", "like", "play", "read", "write", "run", "speak", "swim" };
    private HashSet<string> singleVerbsforAffirmationsAndNegations = new HashSet<string>() { "eats", "likes", "plays", "reads", "writes", "runs", "speaks", "swims" };
    private HashSet<string> continuousVerbs = new HashSet<string>() { "eating", "liking", "playing", "reading", "writing", "running", "speaking", "swimming" };
    private HashSet<string> pastVerbs = new HashSet<string>() { "ate", "liked", "played", "read", "wrote", "ran", "spoke", "swam" };
    private HashSet<string> futureVerbs = new HashSet<string>() { "eat", "like", "play", "read", "write", "run", "speak", "swim" };

    private HashSet<string> objects = new HashSet<string>() { "apples", "football", "books", "letters", "games", "music", "movies", "languages" };

    private HashSet<string> prepositions = new HashSet<string>
    {
        "aboard", "about", "above", "across", "after", "against", "along", "amid", "among", "anti", "around", "as", "at", "before", "behind", "below", "beneath", "beside", 
        "besides", "between", "beyond", "but", "by", "concerning", "considering", "despite", "down", "during", "except", "excepting", "excluding", "following", "for", "from", "in", 
        "inside", "into", "like", "minus", "near", "of", "off", "on", "onto", "opposite", "outside", "over", "past", "per", "plus", "regarding", "round", "save", "since", "than", 
        "through", "to", "toward", "towards", "under", "underneath", "unlike", "until", "up", "upon", "versus", "via", "with", "within", "without", "in the"
    };

    private HashSet<string> adverbs = new HashSet<string>
        {
            "abnormally", "accidentally", "acidly", "actually", "adventurously", "afterwards", "almost", "always", "angrily", "annually", "anxiously", "arrogantly", "awkwardly", "badly", 
            "bashfully", "beautifully", "bitterly", "bleakly", "blindly", "blissfully", "boastfully", "boldly", "bravely", "briefly", "brightly", "briskly", "broadly", "busily", "calmly", 
            "carefully", "carelessly", "cautiously", "certainly", "cheerfully", "clearly", "cleverly", "closely", "coaxingly", "commonly", "continually", "coolly", "correctly", 
            "courageously", "crossly", "cruelly", "curiously", "daily", "daintily", "dearly", "deceivingly", "deeply", "defiantly", "deliberately", "delightfully", "diligently", "dimly", 
            "doubtfully", "dreamily", "easily", "elegantly", "energetically", "enormously", "enthusiastically", "equally", "especially", "evenly", "eventually", "exactly", "excitedly", 
            "extremely", "fairly", "faithfully", "famously", "fatally", "ferociously", "fervently", "fiercely", "fondly", "foolishly", "fortunately", "frankly", "frantically", "freely", 
            "frenetically", "frightfully", "fully", "furiously", "generally", "generously", "gently", "gladly", "gleefully", "gracefully", "gratefully", "greatly", "greedily", "happily", 
            "hastily", "healthily", "heavily", "helpfully", "helplessly", "highly", "honestly", "hopelessly", "hungrily", "immediately", "innocently", "inquisitively", "instantly", 
            "intensely", "intently", "interestingly", "inwardly", "irritably", "jaggedly", "jealously", "jovially", "joyfully", "joyously", "jubilantly", "judgementally", "justly", 
            "keenly", "kiddingly", "kindheartedly", "kindly", "knavishly", "knowingly", "knowledgeably", "lazily", "lightly", "likely", "limply", "lively", "loftily", "longingly", 
            "loosely", "loudly", "lovingly", "loyally", "madly", "majestically", "meaningfully", "mechanically", "merrily", "miserably", "mockingly", "monthly", "mortally", "mostly", 
            "mysteriously", "naturally", "nearly", "neatly", "needily", "nervously", "never", "nicely", "noisily", "now", "nowhere", "obediently", "obnoxiously", "oddly", "offensively", 
            "officially", "often", "only", "openly", "optimistically", "overconfidently", "owlishly", "painfully", "partially", "patiently", "perfectly", "physically", "playfully", 
            "politely", "poorly", "positively", "potentially", "powerfully", "promptly", "properly", "punctually", "quaintly", "quarrelsomely", "queasily", "queerly", "questionably", 
            "questioningly", "quicker", "quickly", "quietly", "quirkily", "quizzically", "rapidly", "rarely", "readily", "really", "reassuringly", "recklessly", "regularly", "reluctantly", 
            "repeatedly", "reproachfully", "restfully", "righteously", "rightfully", "rigidly", "roughly", "rudely", "sadly", "safely", "scarcely", "scarily", "searchingly", "sedately", 
            "seemingly", "seldom", "selfishly", "separately", "seriously", "shakily", "sharply", "sheepishly", "shrilly", "shyly", "silently", "sleepily", "slowly", "smoothly", "softly", 
            "solemnly", "solidly", "sometimes", "soon", "speedily", "stealthily", "sternly", "strictly", "successfully", "suddenly", "surprisingly", "suspiciously", "sweetly", "swiftly", 
            "sympathetically", "tenderly", "tensely", "terribly", "thankfully", "there", "thoroughly", "thoughtfully", "tightly", "tomorrow", "too", "tremendously", "triumphantly", "truly",
            "truthfully", "ultimately", "unabashedly", "unaccountably", "unbearably", "unethically", "unexpectedly", "unfortunately", "unimpressively", "unnaturally", "unnecessarily", 
            "upliftingly", "upwardly", "urgently", "usefully", "uselessly", "usually", "utterly", "vacantly", "vaguely", "vainly", "valiantly", "vastly", "verbally", "very", "viciously", 
            "victoriously", "violently", "vivaciously", "voluntarily", "warmly", "weakly", "wearily", "wetly", "wholly", "wildly", "willfully", "wilfully", "wisely", "woefully", 
            "wonderfully", "worriedly", "wrongly", "yawningly", "yearly", "yearningly", "yesterday", "yieldingly", "youthfully", "zealously", "zestfully", "zestily"
        };

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
        if (!affirmativeTemplate.ContainsKey(tense))
        {
            feedbackText.text = "Tense not recognized.";
            return;
        }
        if (!negativeTemplate.ContainsKey(tense))
        {
            feedbackText.text = "Tense not recognized.";
            return;
        }

        switch (phraseTypeDropdown.options[phraseTypeDropdown.value].text)
        {
            case "Questions":
                List<string> validStructures = questionTemplates[tense];
                bool isValid = validStructures.Any(template => MatchesPresentSimpleQuestionsStructure(userInput, template));
                feedbackText.text = isValid ? "Correct!" : "Incorrect structure.";
                break;
            case "Affirmations":
                string validStructures_affirmation = affirmativeTemplate[tense];
                bool isValid2 = validStructures_affirmation.Any(template => MatchesPresentSimpleQuestionsStructure(userInput, template.ToString()));
                feedbackText.text = isValid2 ? "Correct!" : "Incorrect structure.";
                break;
            case "Negations":
                string validStructures_negations = affirmativeTemplate[tense];
                bool isValid3 = validStructures_negations.Any(template => MatchesPresentSimpleQuestionsStructure(userInput, template.ToString()));
                feedbackText.text = isValid3 ? "Correct!" : "Incorrect structure.";
                break;
            default: Debug.Log("error on HandlePhraseType"); break;
        }
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


        switch (phraseTypeDropdown.options[phraseTypeDropdown.value].text)
        {
            case "Questions":
                // question logic - COMPLEMENT IS AN OBJECT
                // top-down in or - re organize it
                /*
                 {subject} {adverb} {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}
                 {subject} {adverb} {verb} {object} {preposition} {place} {preposition} {time}.
                 {subject} {verb} {object} {preposition} {place} {preposition} {time}. etc...
                 {subject} {verb} {object} {preposition} {place}.
                 {subject} {verb} {object}.
                 {subject} {verb}.
                
                S + V → "She runs."
                S + V + O → "She reads books."
                S + V + O + Prep + Loc → "She reads books in the library."
                S + V + O + Prep + Loc + Prep + Temp → "She reads books in the library after school."
                S + Adv + V + O + Prep + Loc + Prep + Temp → "She quickly reads books in the library after school."
                S + Adv + V + O + Prep + O + Prep + Loc + Prep + Temp → "She quickly reads books about science in the library after school."
                S + Adv + V + O + Prep + O + Prep + O + Prep + Loc + Prep + Temp + Adv → "She quickly reads books about science with her friends in the library after school happily."
                 */
                if (input.Contains("?"))
                {
                    if (inputWords[0] == "do")
                    {
                        if (pluralSubjects.Contains(inputWords[1]) && ( singleVerbsforQuestion.Contains(inputWords[2]) || continuousVerbs.Contains(inputWords[2])) && objects.Contains(inputWords[3]) &&
                            prepositions.Contains(inputWords[4]) && adverbs.Contains(inputWords[5]))
                        {
                            Debug.Log("The phrase is grammatically correct.");
                            return true;
                        }
                    }
                    else if (inputWords[0] == "does")
                    {
                        if (singularSubjects.Contains(inputWords[1]) && singleVerbsforQuestion.Contains(inputWords[2]) && objects.Contains(inputWords[3]))
                        {
                            Debug.Log("The phrase is grammatically correct.");
                            return true;
                        }
                    }
                } else
                {
                    rememberPanel.SetActive(true);
                    Debug.Log("Remember the '?'");
                }
                break;
            case "Affirmations":

                break;
            case "Negations":

                break;
            default: Debug.Log("error on HandlePhraseType"); break;
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

    public void CloseRememberPanel()
    {
        rememberPanel.SetActive(false);
    }
}