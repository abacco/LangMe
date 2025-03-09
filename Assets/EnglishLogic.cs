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

    // time = adverb ? tonight or tomorrow or ... 
    private Dictionary<string, List<string>> questionTemplates = new Dictionary<string, List<string>>()
    {
        { "Present Simple", new List<string>
            {
                "Does {subject} {verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}?",
                "Does {subject} {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}?",
                "Does {subject} {verb} {object} {preposition} {place} {preposition} {time}?",
                "Does {subject} {verb} {object}?",
                "Is {subject} {adjective/noun}?"
            }
        },
        { "Past Simple", new List<string>
            {
                "Did {subject} {verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}?",
                "Did {subject} {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}?",
                "Did {subject} {verb} {object} {preposition} {place} {preposition} {time}?",
                "Did {subject} {verb} {object}?",
                "Was {subject} {adjective/noun}?"
            }
        },
        { "Present Continuous", new List<string>
            {
                "Is {subject} {continuous verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}?",
                "Is {subject} {continuous verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}?",
                "Is {subject} {continuous verb} {object} {preposition} {place} {preposition} {time}?",
                "Is {subject} {continuous verb} {object}?",
                "Is {subject} being {adjective/noun}?"
            }
        },
        { "Past Continuous", new List<string>
            {
                "Was {subject} {continuous verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}?",
                "Was {subject} {continuous verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}?",
                "Was {subject} {continuous verb} {object} {preposition} {place} {preposition} {time}?",
                "Was {subject} {continuous verb} {object}?",
                "Was {subject} being {adjective/noun}?"
            }
        },
        { "Future Simple", new List<string>
            {
                "Will {subject} {verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}?",
                "Will {subject} {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}?",
                "Will {subject} {verb} {object} {preposition} {place} {preposition} {time}?",
                "Will {subject} {verb} {object}?",
                "Will {subject} be {adjective/noun}?"
            }
        },
        { "Present Perfect", new List<string>
            {
                "Has {subject} {verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}?",
                "Has {subject} {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}?",
                "Has {subject} {verb} {object} {preposition} {place} {preposition} {time}?",
                "Has {subject} {verb} {object}?",
                "Has {subject} been {adjective/noun}?"
            }
        }
    };
    private Dictionary<string, List<string>> affirmativeTemplate = new Dictionary<string, List<string>>()
    {
        { "Present Simple", new List<string>
            {
                "{subject} {adverb} {verb (base form)} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.",
                "{subject} {adverb} {verb (base form)} {object} {preposition} {object} {preposition} {place} {preposition} {time}.",
                "{subject} {verb (base form)} {object} {preposition} {place} {preposition} {time}.",
                "{subject} {verb (base form)} {object}."
            }
        },
        { "Past Simple", new List<string>
            {
                "{subject} {adverb} {verb (past simple)} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.",
                "{subject} {adverb} {verb (past simple)} {object} {preposition} {object} {preposition} {place} {preposition} {time}.",
                "{subject} {verb (past simple)} {object} {preposition} {place} {preposition} {time}.",
                "{subject} {verb (past simple)} {object}."
            }
        },
        { "Present Continuous", new List<string>
            {
                "{subject} {adverb} {to be} {verb-ing} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.",
                "{subject} {adverb} {to be} {verb-ing} {object} {preposition} {object} {preposition} {place} {preposition} {time}.",
                "{subject} {to be} {verb-ing} {object} {preposition} {place} {preposition} {time}.",
                "{subject} {to be} {verb-ing} {object}."
            }
        },
        { "Past Continuous", new List<string>
            {
                "{subject} {adverb} {was/were} {verb-ing} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.",
                "{subject} {adverb} {was/were} {verb-ing} {object} {preposition} {object} {preposition} {place} {preposition} {time}.",
                "{subject} {was/were} {verb-ing} {object} {preposition} {place} {preposition} {time}.",
                "{subject} {was/were} {verb-ing} {object}."
            }
        },
        { "Future Simple", new List<string>
            {
                "{subject} {adverb} {will} {verb (base form)} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.",
                "{subject} {adverb} {will} {verb (base form)} {object} {preposition} {object} {preposition} {place} {preposition} {time}.",
                "{subject} {will} {verb (base form)} {object} {preposition} {place} {preposition} {time}.",
                "{subject} {will} {verb (base form)} {object}."
            }
        },
        { "Present Perfect", new List<string>
            {
                "{subject} {adverb} {have/has} {verb (past participle)} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.",
                "{subject} {adverb} {have/has} {verb (past participle)} {object} {preposition} {object} {preposition} {place} {preposition} {time}.",
                "{subject} {have/has} {verb (past participle)} {object} {preposition} {place} {preposition} {time}.",
                "{subject} {have/has} {verb (past participle)} {object}."
            }
        }
    };
    private Dictionary<string, List<string>> negativeTemplate = new Dictionary<string, List<string>>()
    {
        { "Present Simple", new List<string>
            {
                "{subject} {adverb} do/does not {verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.",
                "{subject} {adverb} do/does not {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}.",
                "{subject} do/does not {verb} {object} {preposition} {place} {preposition} {time}.",
                "{subject} do/does not {verb} {object}.",
                "{subject} {to be} not {adjective/noun}."
            }
        },
        { "Past Simple", new List<string>
            {
                "{subject} {adverb} did not {verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.",
                "{subject} {adverb} did not {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}.",
                "{subject} did not {verb} {object} {preposition} {place} {preposition} {time}.",
                "{subject} did not {verb} {object}.",
                "{subject} {to be} not {adjective/noun}."
            }
        },
        { "Present Continuous", new List<string>
            {
                "{subject} {adverb} is/are not {continuous verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.",
                "{subject} {adverb} is/are not {continuous verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}.",
                "{subject} is/are not {continuous verb} {object} {preposition} {place} {preposition} {time}.",
                "{subject} is/are not {continuous verb} {object}.",
                "{subject} is/are not being {adjective/noun}."
            }
        },
        { "Past Continuous", new List<string>
            {
                "{subject} {adverb} was/were not {continuous verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.",
                "{subject} {adverb} was/were not {continuous verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}.",
                "{subject} was/were not {continuous verb} {object} {preposition} {place} {preposition} {time}.",
                "{subject} was/were not {continuous verb} {object}.",
                "{subject} was/were not being {adjective/noun}."
            }
        },
        { "Future Simple", new List<string>
            {
                "{subject} {adverb} will not {verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.",
                "{subject} {adverb} will not {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}.",
                "{subject} will not {verb} {object} {preposition} {place} {preposition} {time}.",
                "{subject} will not {verb} {object}.",
                "{subject} will not be {adjective/noun}."
            }
        },
        { "Present Perfect", new List<string>
            {
                "{subject} {adverb} has/have not {past participle} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.",
                "{subject} {adverb} has/have not {past participle} {object} {preposition} {object} {preposition} {place} {preposition} {time}.",
                "{subject} has/have not {past participle} {object} {preposition} {place} {preposition} {time}.",
                "{subject} has/have not {past participle} {object}.",
                "{subject} has/have not been {adjective/noun}."
            }
        }
    };


    // piuttosto che creare un dizionario infinito, mostra la lista di parole disponibili magari
    private HashSet<string> singularSubjects = new HashSet<string>() { "he", "she", "it" };
    private HashSet<string> pluralSubjects = new HashSet<string>() { "i","you", "we", "they" };

    private HashSet<string> singleVerbsforQuestion = new HashSet<string>() { "eat", "like", "play", "read", "write", "run", "speak", "swim" };
    private HashSet<string> singleVerbsforAffirmationsAndNegations = new HashSet<string>() { "eats", "likes", "plays", "reads", "writes", "runs", "speaks", "swims" };
    private HashSet<string> continuousVerbs = new HashSet<string>() { "eating", "liking", "playing", "reading", "writing", "running", "speaking", "swimming" };
    private HashSet<string> pastVerbs = new HashSet<string>() { "ate", "liked", "played", "read", "wrote", "ran", "spoke", "swam" };
    private HashSet<string> futureVerbs = new HashSet<string>() { "eat", "like", "play", "read", "write", "run", "speak", "swim" };

    private HashSet<string> objects_and_subjects = new HashSet<string>() { "apples", "football", "books", "letters", "games", "music", "movies", "languages" };
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
    private HashSet<string> wh_words = new HashSet<string>() { "when", "why", "where", "what", "how", "who" };
    private HashSet<string> nouns = new HashSet<string>() { "a teacher", "a student", "teacher", "student" };
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
                //List<string> validStructures = questionTemplates[tense];
                //bool isValid = validStructures.Any(template => MatchesPresentSimpleQuestionsStructure(userInput, template));
                bool isValid2 = MatchesPresentSimpleQuestionsStructure(userInput);
                feedbackText.text = isValid2 ? "Correct!" : "Incorrect structure. Try To Remove Blank Char before '?'";
                break;
            case "Affirmations":
                //List<string> validStructures_affirmation = affirmativeTemplate[tense];
                //bool isValid2 = validStructures_affirmation.Any(template => MatchesPresentSimpleQuestionsStructure(userInput, template));
                //feedbackText.text = isValid2 ? "Correct!" : "Incorrect structure.";
                break;
            case "Negations":
                //List<string> validStructures_negations = affirmativeTemplate[tense];
                //bool isValid3 = validStructures_negations.Any(template => MatchesPresentSimpleQuestionsStructure(userInput, template));
                //feedbackText.text = isValid3 ? "Correct!" : "Incorrect structure.";
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
                /*
                 * Templates
                 {wh-word} {auxiliary} {subject} {adverb} {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}?
                 {wh-word} {auxiliary} {subject} {verb} {object} {preposition} {place} {preposition} {time}?
                 {wh-word} {auxiliary} {subject} {verb} {object}?
                 {auxiliary} {subject} {verb} {object}?
                 {verb} {subject} {adjective} {noun}? Is She Tired? Is she A teacher
                 */

                IsValidSentence(input);


                //if (input.Contains("?"))
                //{
                //    //if (inputWords[0] == "do")
                //    //{
                //    //    if (pluralSubjects.Contains(inputWords[1]) && 
                //    //        ( singleVerbsforQuestion.Contains(inputWords[2]) || continuousVerbs.Contains(inputWords[2])) && 
                //    //        objects_and_subjects.Contains(inputWords[3]) &&
                //    //        prepositions.Contains(inputWords[4]) && 
                //    //        adverbs.Contains(inputWords[5]))
                //    //    {
                //    //        Debug.Log("The phrase is grammatically correct.");
                //    //        return true;
                //    //    }
                //    //}
                //    //else if (inputWords[0] == "does")
                //    //{
                //    //    if (singularSubjects.Contains(inputWords[1]) && singleVerbsforQuestion.Contains(inputWords[2]) && objects.Contains(inputWords[3]))
                //    //    {
                //    //        Debug.Log("The phrase is grammatically correct.");
                //    //        return true;
                //    //    }
                //    //}
                //    //IsValidSentence(input);
                //} else
                //{
                //    rememberPanel.SetActive(true);
                //    Debug.Log("Remember the '?'");
                //}
                break;
            case "Affirmations":
                // top-down in or - re organize it
                 /*
                 {subject} {adverb} {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}
                 {subject} {adverb} {verb} {object} {preposition} {place} {preposition} {time}.
                 {subject} {verb} {object} {preposition} {place} {preposition} {time}. etc...
                 {subject} {verb} {object} {preposition} {place}.
                 {subject} {verb} {object}.
                 {subject} {verb}.
                 */
                string subject_tmp  = inputWords[0].ToLower();
                string adverb_tmp   = inputWords[1].ToLower();
                string verb_tmp     = inputWords[2].ToLower();
                string object_1_tmp = inputWords[3].ToLower();
                string prep_1_tmp   = inputWords[4].ToLower();
                string place_tmp    = inputWords[5].ToLower();
                string prep_2_tmp   = inputWords[6].ToLower();
                string time_tmp     = inputWords[7].ToLower();
                
                break;
            case "Negations":
                /*
                 {subject} {adverb} {auxiliary} not {verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.
                 {subject} {adverb} {auxiliary} not {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}.
                 {subject} {auxiliary} not {verb} {object} {preposition} {place} {preposition} {time}.
                 {subject} {auxiliary} not {verb} {object}.
                 {subject} {to be} not {adjective/noun}.
                 */
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
            case "Present Simple": rule_dynamic_text.text = "TEST"; break;//Return_PresentSimple_Question_Rules(); break; // spostare nel panel
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

    private string Return_PresentSimple_Question_Rules()
    {
        return "Does {subject} {verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}?" +
                "Does {subject} {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}?" +
                "Does {subject} {verb} {object} {preposition} {place} {preposition} {time}?" +
                "Does {subject} {verb} {object}?" +
                "Is {subject} {adjective/noun}?";
    }


    private static Dictionary<string, List<string>> wordCategories = new Dictionary<string, List<string>>()
    {
        { "wh-word", new List<string> { "who", "what", "where", "when", "why", "how", "which" } },
        { "auxiliary", new List<string> { "do", "does", "did", "is", "are", "was", "were", "will", "have", "has" } },
        { "subject", new List<string> { "I", "you", "he", "she", "it", "we", "they", "John", "Alice", "the dog" } },
        { "adverb", new List<string> { "always", "never", "sometimes", "often", "rarely", "usually", "hardly ever" } },
        { "verb", new List<string> { "eat", "drink", "go", "see", "play", "work", "study", "run", "write", "sleep" } },
        { "object", new List<string> { "pizza", "water", "the park", "a book", "music", "football", "English", "a letter", "early" } },
        { "preposition", new List<string> { "in", "on", "at", "to", "with", "for", "about", "by", "under", "between" } },
        { "place", new List<string> { "home", "the office", "the park", "school", "the beach", "the restaurant" } },
        { "time", new List<string> { "yesterday", "today", "tomorrow", "next week", "last year", "this morning", "at night" } },
        { "adjective", new List<string> { "happy", "sad", "tired", "hungry", "angry", "excited", "bored", "nervous", "confident" } },
        
        { "noun", new List<string> 
            { "teacher", "student", "doctor", "engineer", "musician", "artist", "driver", "chef",
              "a teacher", "a student", "a doctor", "a engineer", "a musician", "a artist", "a driver", "a chef",
              "the teacher", "the student", "the doctor", "the engineer", "the musician", "the artist", "the driver", "the chef"
            } 
        }
    };


    static bool IsValidSentence(string input)
    {
        string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<string> result = new List<string>();
        for (int i = 0; i < words.Length - 1; i++)
        {
            if (words[i] != "") {
                result.Add(words[i]);
            }
        }
        bool question_mark_is_present = words[words.Length - 1].Contains("?");
        bool a = wordCategories["auxiliary"].Contains(words[0]);
        bool a1 = wordCategories["subject"].Contains(words[1]);
        bool a2 = wordCategories["adjective"].Contains(words[2]);

        // Se l'ultima parola termina con '?', rimuoviamolo e aggiungiamolo separatamente
        if (question_mark_is_present)
        {
            words[words.Length - 1] = words[words.Length - 1].TrimEnd('?');
            words = words.Append("?").ToArray();
            Debug.Log("");
        }

        // Template 5 (Regola base)
        if (words.Length == 4 )
        {
            if (wordCategories["auxiliary"].Contains(words[0]) &&
                wordCategories["subject"].Contains(words[1]) &&
                (wordCategories["adjective"].Contains(words[2]) || wordCategories["noun"].Contains(words[2])))
            {
                return true;
            }
        }

        // Template 4: {auxiliary} {subject} {verb} {object}?
        if (words.Length >= 4 && wordCategories["auxiliary"].Contains(words[0]) && wordCategories["subject"].Contains(words[1]) && wordCategories["verb"].Contains(words[2]))
        {
            return true;
        }

        // Template 3: {wh-word} {auxiliary} {subject} {verb} {object}?
        if (words.Length >= 5 && wordCategories["wh-word"].Contains(words[0]) && wordCategories["auxiliary"].Contains(words[1]) && wordCategories["subject"].Contains(words[2]) && wordCategories["verb"].Contains(words[3]))
        {
            return true;
        }

        // Template 2: {wh-word} {auxiliary} {subject} {verb} {object} {preposition} {place} {preposition} {time}?
        if (words.Length >= 7 && wordCategories["wh-word"].Contains(words[0]) && wordCategories["auxiliary"].Contains(words[1]) && wordCategories["subject"].Contains(words[2]) && wordCategories["verb"].Contains(words[3]))
        {
            return true;
        }

        // Template 1: {wh-word} {auxiliary} {subject} {adverb} {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}?
        if (words.Length >= 8 && wordCategories["wh-word"].Contains(words[0]) && wordCategories["auxiliary"].Contains(words[1]) && wordCategories["subject"].Contains(words[2]) && wordCategories["verb"].Contains(words[4]))
        {
            return true;
        }

        return false;
    }

    private bool MatchesPresentSimpleQuestionsStructure(string input)
    {
        string[] inputWords = input.ToLower().Split(' '); // Does he play football?
        //string[] templateParts = template.Split(' '); // Does {subject} {verb} {object}?

        //if (inputWords.Length != templateParts.Length)
        //    return false;

        //if (inputWords.Length != 4)
        //    return false; // Deve avere esattamente 4 parole: (Do/Does) (subject) (verb) (object)?


        switch (phraseTypeDropdown.options[phraseTypeDropdown.value].text)
        {
            case "Questions":
                // question logic - COMPLEMENT IS AN OBJECT
                if (input.Contains("?")) 
                { 
                    return IsValidSentence(input);
                }
                else
                {
                    rememberPanel.SetActive(true);
                    return false;
                }
            //break;
            case "Affirmations":
                // top-down in or - re organize it
                /*
                {subject} {adverb} {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}
                {subject} {adverb} {verb} {object} {preposition} {place} {preposition} {time}.
                {subject} {verb} {object} {preposition} {place} {preposition} {time}. etc...
                {subject} {verb} {object} {preposition} {place}.
                {subject} {verb} {object}.
                {subject} {verb}.
                */
                string subject_tmp = inputWords[0].ToLower();
                string adverb_tmp = inputWords[1].ToLower();
                string verb_tmp = inputWords[2].ToLower();
                string object_1_tmp = inputWords[3].ToLower();
                string prep_1_tmp = inputWords[4].ToLower();
                string place_tmp = inputWords[5].ToLower();
                string prep_2_tmp = inputWords[6].ToLower();
                string time_tmp = inputWords[7].ToLower();

                break;
            case "Negations":
                /*
                 {subject} {adverb} {auxiliary} not {verb} {object} {preposition} {object} {preposition} {object} {preposition} {place} {preposition} {time} {adverb}.
                 {subject} {adverb} {auxiliary} not {verb} {object} {preposition} {object} {preposition} {place} {preposition} {time}.
                 {subject} {auxiliary} not {verb} {object} {preposition} {place} {preposition} {time}.
                 {subject} {auxiliary} not {verb} {object}.
                 {subject} {to be} not {adjective/noun}.
                 */
                break;
            default: Debug.Log("error on HandlePhraseType"); break;
        }

        Debug.Log("The phrase is incorrect.");
        return false;
    }
}