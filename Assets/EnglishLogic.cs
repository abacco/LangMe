using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnglishLogic : MonoBehaviour
{
    public Dropdown tenseDropdown;
    public Dropdown phraseTypeDropdown;

    [SerializeField] GameObject rememberPanel;

    public InputField userInputField;
    public Button checkButton;
    public Text feedbackText;
    public Text rule_dynamic_text;
    public string selectedTense = ""; // Cambia a seconda dell'esercizio
    
    public int how_many_correct_english_phrases = 0;
    public Text how_many_correct_english_phrases_text;

    [SerializeField] ShowAdOnStart ad;

    public Dictionary<string, HashSet<string>> wordCategories = new Dictionary<string, HashSet<string>>()
    {
        { "wh-word", new HashSet<string> { "why", "when", "where", "how", "what", "which", "who", "whom", "whose", "whenever", "wherever", "whatever", "whichever", "whoever", "whomever" } },
        { "auxiliary", new HashSet<string>
            {
                "does", "does not", "doesnt", "doesn't",
                "do", "do not", "dont", "don't",
                "did", "did not", "didnt", "didn't",
                "is", "is not", "isnt", "isn't",
                "are", "are not", "arent", "aren't",
                "was", "was not", "wasnt", "wasn't",
                "were", "were not", "werent", "weren't",
                "has", "has not", "hasnt", "hasn't",
                "have", "have not", "havent", "haven't",
                "had", "had not", "hadnt", "hadn't",
                "will", "will not", "wont", "won't",
                "shall", "shall not", "shallnt", "shalln't",
                "can", "can not", "cannot", "cant", "can't",
                "could", "could not", "couldnt", "couldn't",
                "may", "may not",
                "might", "might not",
                "must", "must not", "mustnt", "mustn't",
                "should", "should not", "shouldnt", "shouldn't",
                "would", "would not", "wouldnt", "wouldn't",
                "have", "have not", "havent", "haven't"
            }},
        { "subject", new HashSet<string>
            {
            "she", "he", "it", "we", "they", "you", "I", "John", "Sarah", "David", "Emma", "Tom",
            "Mike", "Lily", "Alice", "James", "Jack",
            "parents", "students", "brother", "father", "friends",
            "kids", "birds", "engineers", "tourists", "cousins", "classmates", "neighbors", "cousin", "sister",
            "dogs", "boss", "grandparents", "nurses", "cat", "baby", "who", "coffee", "car", "music", "emails",
            "ice cream", "movies", "homework", "office", "sushi", "cakes", "pictures", "glasses", "water", "bicycles",
            "computers", "windows", "news", "bridges", "medicine", "cat", "workers", "mother", "uncle", "boyfriend",
            "teachers", "friends", "guests", "neighbors", "desk", "dog", "room", "house", "train", "bike", "teacher",
            "friends", "cats", "furniture", "jokes", "scarf", "hill", "client", "car", "silverware", "piano", "couch",
            "manager", "garden", "meeting", "book", "partner", "grandmother", "project", "package", "new room", "beach",
            "dress", "pencils", "decorations", "lost items", "heavy boxes", "dance routine", "vase", "favorite song",
            "website", "soup", "trip", "budget", "future", "secrets", "parents", "grandparents", "team", "director",
            "siblings", "art gallery", "application", "teacher", "house", "relatives", "doctor", "party", "museum",
            "concert", "office", "client", "workshop", "novel", "marathon", "rules", "report", "professor", "database",
            "kitchen", "library", "living room", "dishes", "house", "chair", "passport", "room", "workspace", "pet", "flight",
            "software", "surprise party", "portfolio", "podcast", "batteries", "family", "wedding", "community", "garage",
            "clients", "walls", "presentation", "career goals", "dance classes", "flowers", "groceries", "puzzles", "pool",
            "artwork", "English", "play", "lake", "language skills", "countryside", "business strategies", "video games",
            "sandcastle", "dinner", "documentaries", "city", "plants", "friend", "new apartment", "recipes", "exercises",
            "clothes", "basketball skills", "mountains", "job", "siblings", "math skills", "portraits", "notes", "sketches",
            "tickets", "scarf", "speech", "house", "this"

        } },
        { "verb", new HashSet<string>
            {  "drink", "visit", "drive", "enjoy", "rain", "arrive", "play", "listen", "work", "call",
                "write", "like", "walk", "cook", "cost", "watch", "travel", "sleep", "have", "clean",
                "buy", "sell", "exercise", "dance", "sing", "fix", "bake", "swim", "teach", "eat",
                "study", "read", "prefer", "sound", "help", "bark", "go", "ride", "repair", "send",
                "taste", "finish", "build", "wake", "is", "are", "am", "doing", "thinking", "coming",
                "raining", "staying", "shouting", "waiting", "discussing", "having", "running", "arguing",
                "painting", "traveling", "meeting", "talking", "shopping", "learning", "feeling", "crying",
                "sitting", "enjoying", "planning", "moving", "joining", "becoming", "designing", "searching",
                "washing", "speaking", "organizing", "starting", "checking", "preparing", "standing", "trying",
                "exploring", "feeding", "getting", "making", "smiling", "forgetting", "opening", "driving",
                "recording", "solving", "holding", "delivering", "heading", "celebrating", "parking", "leaving",
                "does", "do", "love", "complain", "start", "smell", "take", "paint", "give", "open", "order",
                "wear", "miss", "practice", "meet", "live", "understand", "agree", "find", "lose", "return",
                "accept", "explain", "recommend", "answer", "complete", "borrow", "check", "teach", "prepare",
                "was", "were", "helping", "behaving", "snowing", "performing", "decorating", "reviewing",
                "dusting", "climbing", "answering", "carrying", "planting", "arranging", "calculating", "will",
                "analyze", "attend", "improve", "look", "talk", "cry", "head", "iron", "sweep", "brush", "edit",
                "taste", "whisper", "relax", "dust", "laugh", "wipe", "sew", "dream", "knit", "polish",
                "calculate", "spend", "admire", "submit", "receive", "perform", "celebrate", "adopt", "book",
                "upload", "respect", "aim", "launch", "thought", "replace", "install", "grow", "compete",
                "remove", "volunteer", "focus", "fishing", "cycling", "arrange", "water", "rehearse", "fold",
                "tidy", "memorize", "hang", "cheer", "brainstorm", "adjust", "skip", "babysit", "discover",
                "reads", "swims", "sings", "plays", "travel", "discuss", "helps", "watch", "design", "bake", "clean", "studies", "organizes", "prefer", "assist", "sits", "plays", "melts", "helps", "opens", "process", "keeps", "invite", "waits", "arrives", "share", "looks", "make", "shines", "provides", "moves", "smells", "break", "return", "require", "remain", "visit", "watches", "receives", "call", "treats", "remains", "smells", "welcomes", "breaks", "allows", "need", "improve", "challenge", "serves", "improve", "tastes", "hums", "pass", "improve", "visit", "sharpen", "protects",
                // ing
                "drinking", "visiting", "driving", "enjoying", "raining", "arriving", "playing", "listening", "working", "calling", "writing", "liking", "walking", "cooking", "costing", "watching", "traveling", "sleeping", "having", "cleaning", "buying", "selling", "exercising", "dancing", "singing", "fixing", "baking", "swimming", "teaching", "eating", "studying", "reading", "preferring", "sounding", "helping", "barking", "going", "riding", "repairing", "sending", "tasting", "finishing", "building", "waking", "doing", "loving", "taking", "living",
                // past-part.
                "drunk", "visited", "driven", "enjoyed", "rained", "arrived", "played", "listened", "worked", "called", "written", "liked", "walked", "cooked", "cost", "watched", "traveled", "slept", "had", "cleaned", "bought", "sold", "exercised", "danced", "sung", "fixed", "baked", "swum", "taught", "eaten", "studied", "read", "preferred", "sounded", "helped", "barked", "gone", "ridden", "repaired", "sent", "tasted", "finished", "built", "woken", "done", "loved", "taken", "lived"
        } },
        { "preposition", new HashSet<string> { "in", "on", "at", "to", "with", "for", "before", "after", "during", "as", "by", "about", "over", "under", "of", "through", "between", "into", "onto", "out", "from", "against", "along", "around", "beneath", "beside", "beyond", "near", "off", "past", "since", "until", "within", "without"  } },
        { "averbs", new HashSet<string> {
                "always", "sometimes", "often", "rarely", "never", "usually", "hardly ever", "occasionally",
                "quickly", "quietly", "eagerly", "easily", "regularly", "slowly", "happily", "frequently",
                "seldom", "boldly", "carefully", "patiently", "gracefully", "calmly", "enthusiastically",
                "angrily", "reluctantly", "intensely", "deliberately", "generously", "gently", "bravely",
                "vigorously", "truthfully", "firmly", "beautifully", "recklessly", "skillfully",
                "joyfully", "politely", "thoughtfully", "constantly", "sharply", "swiftly", "horribly",
                "warmly", "wickedly", "noisily", "cheerfully", "terribly"
        } },
        { "time", new HashSet<string> {
            "morning", "weekends", "evening", "night", "winter", "Fridays",
            "afternoon", "spring", "summer", "autumn", "yesterday", "today",
            "tomorrow", "noon", "midnight", "January", "February", "March",
            "April", "May", "June", "July", "August", "September", "October",
            "November", "December", "weekday", "weekend", "holiday", "dawn",
            "dusk", "sunrise", "sunset", "day", "week", "month", "year",
            "hour", "minute", "second", "century", "morning hours", "evening hours"
        } },
        { "bonusWords", new HashSet<string> { // parole che stanno nelle frasi ma non qui dentro mannaggia zio
           "my", "the", "beautiful", "strong", "happy", "sad", "brave", "quick",
            "slow", "bright", "dark", "sharp", "soft", "hard", "warm", "cold", "kind",
            "mean", "friendly", "unfriendly", "quiet", "loud", "tall", "short", "big", "small",
            "rich", "poor", "fast", "lazy", "early", "late", "cheerful", "calm", "angry", "worried",
            "excited", "boring", "interesting", "confident", "nervous", "tired", "energetic", "hungry",
            "thirsty", "curious", "creative", "polite", "rude", "serious", "funny", "bold", "smart", "silly",
            "handsome", "ugly", "dirty", "clean", "helpful", "careless", "truthful", "honest", "generous", "greedy",
            "young", "old", "new", "ancient", "famous", "unknown", "important", "unimportant", "valuable", "useless",
            "safe", "dangerous", "heavy", "light", "weak", "delicious", "tasteless", "spicy", "sweet", "bitter", "hot",
            "frosty", "modern", "traditional", "round", "square", "flat", "bumpy", "smooth", "rough", "hardworking",
            "attentive", "distracted", "brilliant", "dull", "perfect", "imperfect", "realistic", "optimistic", "pessimistic",
            "lucky", "unlucky", "genuine", "fake", "colorful", "colorless", "fun", "playful", "mature", "artistic", "athletic",
            "musical", "logical", "emotional", "adventurous", "reserved", "extroverted", "introverted", "ambitious", "content",
            "open-minded", "stubborn", "organized", "messy", "independent", "dependent", "spontaneous", "planned", "careful",
            "reckless", "proud", "humble", "respectful", "disrespectful", "loyal", "unfaithful", "inattentive", "cooperative",
            "competitive", "uncertain", "precise", "imprecise", "peaceful", "chaotic", "comfortable", "uncomfortable", "parents",
            "are", "traveling", "to", "france", "lily", "often", "goes", "park", "he", "rides", "his", "bicycle", "work", "she",
            "forgets", "her", "keys", "motorcycle", "every", "weekend", "speaks", "three", "different", "languages", "fluently",
            "airplane", "landed", "safely", "on", "runway", "baby", "smiled", "at", "everyone", "in", "room", "must", "we", "really",
            "leave", "now", "why", "didn’t", "reply", "who", "knows", "answer", "which", "path", "you", "tak", "be", "should",
            "they", "reconsider", "their", "plan", "tell", "us", "earlier", "which", "way", "do", "go", "cat", "is", "not", "sleeping",
            "couch", "company", "launching", "a", "product", "sun", "shining", "brightly", "today", "kids", "playing", "garden", "book",
            "was", "written", "by", "author", "scientist", "did", "discover", "species", "children", "laughing", "and", "car", "stop",
            "suddenly", "at", "intersection", "full", "of", "flowers", "professor", "explain", "theory", "detail", "mechanic", "repair",
            "cars", "engine", "does", "always", "drink", "coffee", "morning", "jump", "onto", "kitchen", "table", "dog", "follow", "its",
            "owner", "project", "completed", "ahead", "schedule", "workers", "fix", "broken", "pipe",
            "land"
        } }
    };

    void Start()
    {
        //if (IsAValidNegation("The art gallery is not open this week."))
        //{
        //    Debug.Log("");
        //}
        //TestQuestions(null);

        // ok tutte riconosciute
        //TestQuestions(EnglishHashSets.present_simple_questions);
        //TestQuestions(EnglishHashSets.present_continuous_questions);
        //TestQuestions(EnglishHashSets.present_perfect_questions);
        //TestQuestions(EnglishHashSets.present_perfect_continuous_questions);

        //TestQuestions(EnglishHashSets.past_simple_questions);
        //TestQuestions(EnglishHashSets.past_continuous_questions);
        //TestQuestions(EnglishHashSets.past_perfect_questions);
        //TestQuestions(EnglishHashSets.past_perfect_continuous_questions);

        //TestQuestions(EnglishHashSets.future_simple_questions);
        //TestQuestions(EnglishHashSets.future_continuous_questions);
        //TestQuestions(EnglishHashSets.future_perfect_questions);
        //TestQuestions(EnglishHashSets.future_perfect_continuous_questions);

        //TestQuestions(EnglishHashSets.present_simple_negations);
        //TestQuestions(EnglishHashSets.present_continuous_negations);
        //TestQuestions(EnglishHashSets.present_perfect_negations);
        //TestQuestions(EnglishHashSets.present_perfect_continuous_negations);

        //TestQuestions(EnglishHashSets.past_simple_negations);
        //TestQuestions(EnglishHashSets.past_continuous_negations);
        //TestQuestions(EnglishHashSets.past_perfect_negations);
        //TestQuestions(EnglishHashSets.past_perfect_continuous_negations);

        //TestQuestions(EnglishHashSets.future_simple_negations);
        //TestQuestions(EnglishHashSets.future_continuous_negations);
        //TestQuestions(EnglishHashSets.future_perfect_negations);
        //TestQuestions(EnglishHashSets.future_perfect_continuous_negations);

        //TestQuestions(present_simple_affirmations);
        //TestQuestions(present_continuous_affirmations);
        //TestQuestions(present_perfect_affirmations);
        //TestQuestions(present_perfect_continuous_affirmations);

        //TestQuestions(past_simple_affirmations);
        //TestQuestions(past_continuous_affirmations);
        //TestQuestions(past_perfect_affirmations);
        //TestQuestions(past_perfect_continuous_affirmations);

        //TestQuestions(future_simple_affirmations);
        //TestQuestions(future_continuous_affirmations);
        //TestQuestions(future_perfect_affirmations);
        //TestQuestions(future_perfect_continuous_affirmations);


        //Debug.LogWarning("Show a Panel in which you say that atm no all words are recognized!");
        // in base al primo dropdown fai gli update
        HandlePhraseType();
        checkButton.onClick.AddListener(() => CheckUserInput(userInputField.text, selectedTense));
    }
    public void UpdateSelectedTense()
    {
        checkButton.onClick.RemoveAllListeners();
        checkButton.onClick.AddListener(() => CheckUserInput(userInputField.text, tenseDropdown.options[tenseDropdown.value].text));
        //UpdateQuestionRule();
        UpdateQuestionRule_NEW();
        Debug.Log("Selected Tense: " + tenseDropdown.options[tenseDropdown.value].text);
    }
    public void CheckUserInput(string userInput, string tense)
    {
        if(how_many_correct_english_phrases % 5 == 0 && how_many_correct_english_phrases >= 1) { 
            StartCoroutine(ad.ShowAdOnStartCoroutine());
            how_many_correct_english_phrases = 0;
        }
        switch (phraseTypeDropdown.options[phraseTypeDropdown.value].text)
        {
            case "Questions":
                bool isAValidQuestion = MatchesBasedOnType(userInput);
                //feedbackText.text = isAValidQuestion ? "Grammatically Correct!" : "Incorrect structure (even punctuation matters!) Or some words not yet recognized Or did you miss the '?', Please Retry.";
                userInputField.text = "";
                if (isAValidQuestion) { how_many_correct_english_phrases++; how_many_correct_english_phrases_text.text = how_many_correct_english_phrases.ToString(); }
                break;
            case "Affirmations":
                bool isAValidAffirmation = MatchesBasedOnType(userInput);
                //feedbackText.text = isAValidAffirmation ? "Grammatically Correct!" : "Incorrect structure (even punctuation matters!) Or some words not yet recognized Or did you miss the '.'? Please Retry.";
                userInputField.text = "";
                if (isAValidAffirmation) { how_many_correct_english_phrases++; how_many_correct_english_phrases_text.text = how_many_correct_english_phrases.ToString(); }
                break;
            case "Negations":
                bool isAValidNegations = MatchesBasedOnType(userInput);
                feedbackText.text = isAValidNegations ? "Grammatically Correct!" : "Incorrect structure (even punctuation matters!) Or some words not yet recognized Or did you miss the '.'? Please Retry.";
                userInputField.text = "";
                if (isAValidNegations) { how_many_correct_english_phrases++; how_many_correct_english_phrases_text.text = how_many_correct_english_phrases.ToString(); }
                break;
            default: Debug.Log("error on HandlePhraseType"); break;
        }
    }

    public void UpdateQuestionRule_NEW()
    {
        // spostare in un panel
        switch (phraseTypeDropdown.options[phraseTypeDropdown.value].text)
        {
            case "Questions":
                rule_dynamic_text.text = "1.Am/Are/Is + I/you/she... + verb + sub/obj & adverb OR sub/obj...\n\n" +
                                         "2.whose + subject + verb\n\n" +
                                         "3.what kind of + noun + verb.\n\n" +
                                         "4.modal + subject + verb.\n\n" +
                                         "5.why didn’t + subject + verb.\n\n" +
                                         "6.who/what/how + verb.\n\n" +
                                         "7.modal + subject + optional adverb + verb.\n\n" +
                                         "8.why didn’t + subject + verb.\n\n" +
                                         "9.who + verb.\n\n" +
                                         "10.how often + auxiliary + subject + verb.\n\n" +
                                         "11.were + subject + supposed to + verb.\n\n" +
                                         "12.which + noun + auxiliary + subject + verb.\n\n";
                break;
            case "Affirmations":
                                break;
            case "Negations":
                                break;
            default: Debug.Log("error on UpdateQuestionRule"); break;
        }
    }
    //public void UpdateQuestionRule()
    //{
    //    // spostare in un panel
    //    switch (tenseDropdown.options[tenseDropdown.value].text)
    //    {
    //        case "Present Simple": rule_dynamic_text.text = Return_PresentSimple_Question_Rules(); break;
    //        case "Present Cont.": rule_dynamic_text.text = Return_PresentContinuous_Question_Rules(); break;
    //        case "Present Perfect": rule_dynamic_text.text = Return_Present_Perfect_Question_Rule(); break;
    //        case "Present Perfect Cont.": rule_dynamic_text.text = Return_Present_Perfect_Continuous_Question_Rule(); break;

    //        case "Past Simple": rule_dynamic_text.text = Return_Past_Simple_Question_Rules(); break;
    //        case "Past Cont.": rule_dynamic_text.text = Return_Past_Continuous_Question_Rule(); break;
    //        case "Past Perfect": rule_dynamic_text.text = Return_Past_Perfect_Question_Rule(); break;
    //        case "Past Perfect Cont.": rule_dynamic_text.text = Return_Past_Perfect_Continuous_Question_Rule(); break;

    //        case "Future Simple": rule_dynamic_text.text = Return_Future_Simple_Question_Rule(); break;
    //        case "Future Cont.": rule_dynamic_text.text = Return_Future_Continuous_Question_Rule(); break;
    //        case "Future Perfect": rule_dynamic_text.text = Return_Future_Perfect_Question_Rule(); break;
    //        case "Future Perfect Cont.": rule_dynamic_text.text = Return_Future_Perfect_Continuous_Question_Rule(); break;
    //        default: Debug.LogError("error on UpdateQuestionRule"); break;
    //    }
    //    Debug.Log("Selected Tense: " + tenseDropdown.options[tenseDropdown.value].text);
    //}
    public void UpdateAffirmationsRule()
    {
        // spostare in un panel
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": rule_dynamic_text.text = Return_PresentSimple_Affirmation_Rules(); break;
            case "Present Cont.": rule_dynamic_text.text = Return_PresentContinuous_Affirmation_Rules(); break;
            case "Present Perfect": rule_dynamic_text.text = Return_PresentPerfect_Affirmation_Rules(); break;
            case "Present Perfect Cont.": rule_dynamic_text.text = Return_PresentPerfectContinuous_Affirmation_Rules(); break;

            case "Past Simple": rule_dynamic_text.text = Return_PastSimple_Affirmation_Rules(); break;
            case "Past Cont.": rule_dynamic_text.text = Return_PastContinuous_Affirmation_Rules(); break;
            case "Past Perfect": rule_dynamic_text.text = Return_PastPerfect_Affirmation_Rules(); break;
            case "Past Perfect Cont.": rule_dynamic_text.text = Return_PastPerfectContinuous_Affirmation_Rules(); break;

            case "Future Simple": rule_dynamic_text.text = Return_FutureSimple_Affirmation_Rules(); break;
            case "Future Cont.": rule_dynamic_text.text = Return_FutureContinuous_Affirmation_Rules(); break;
            case "Future Perfect": rule_dynamic_text.text = Return_FuturePerfect_Affirmation_Rules(); break;
            case "Future Perfect Cont.": rule_dynamic_text.text = Return_FuturePerfectContinuous_Affirmation_Rules(); break;
            default: Debug.LogError("error on UpdateQuestionRule"); break;
        }
        Debug.Log("Selected Tense: " + tenseDropdown.options[tenseDropdown.value].text);
    }
    public void UpdateNegationRule()
    {
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": rule_dynamic_text.text = Return_PresentSimple_Negations_Rules(); break;
            case "Present Cont.": rule_dynamic_text.text = Return_PresentContinuous_Negations_Rules(); break;
            case "Present Perfect": rule_dynamic_text.text = Return_Present_Perfect_Negations_Rule(); break;
            case "Present Perfect Cont.": rule_dynamic_text.text = Return_Present_Perfect_Continuous_Negations_Rule(); break;

            case "Past Simple": rule_dynamic_text.text = Return_Past_Simple_Negations_Rules(); break;
            case "Past Cont.": rule_dynamic_text.text = Return_Past_Continuous_Negations_Rule(); break;
            case "Past Perfect": rule_dynamic_text.text = Return_Past_Perfect_Negations_Rule(); break;
            case "Past Perfect Cont.": rule_dynamic_text.text = Return_Past_Perfect_Continuous_Negations_Rule(); break;

            case "Future Simple": rule_dynamic_text.text = Return_Future_Simple_Negations_Rule(); break;
            case "Future Cont.": rule_dynamic_text.text = Return_Future_Continuous_Negations_Rule(); break;
            case "Future Perfect": rule_dynamic_text.text = Return_Future_Perfect_Negations_Rule(); break;
            case "Future Perfect Cont.": rule_dynamic_text.text = Return_Future_Perfect_Continuous_Negations_Rule(); break;
            default: Debug.LogError("error on UpdateNegationRule"); break;
        }
        Debug.Log("Selected Tense: " + tenseDropdown.options[tenseDropdown.value].text);
    }
    public void HandlePhraseType()
    {
        switch (phraseTypeDropdown.options[phraseTypeDropdown.value].text)
        {
            case "Questions":
                /*UpdateQuestionRule();*/
                UpdateQuestionRule_NEW(); break;
            case "Affirmations":
                UpdateAffirmationsRule(); break;
            case "Negations":
                UpdateNegationRule(); break;
            default: Debug.Log("error on HandlePhraseType"); break;
        }
        Debug.Log("Selected Phrase Type: " + phraseTypeDropdown.options[phraseTypeDropdown.value].text);
    }
    private bool MatchesBasedOnType(string input)
    {
        if ("Questions".Equals(phraseTypeDropdown.options[phraseTypeDropdown.value].text))
        {
            return IsAValidSimpleQuestion(input); //ReturnQuestionsBasedOntense(input);
        }
        else if ("Affirmations".Equals(phraseTypeDropdown.options[phraseTypeDropdown.value].text))
        {
            return IsAValidSimpleAffirmation(input); //ReturnAffirmationsBasedOntense(input);
        }
        else if ("Negations".Equals(phraseTypeDropdown.options[phraseTypeDropdown.value].text))
        {
            return IsAValidNegation(input); //ReturnNegationsBasedOntense(input);
        }
        Debug.Log("The phrase is incorrect.");
        return false;
    }
    public void CloseRememberPanel()
    {
        rememberPanel.SetActive(false);
    }
   
    public void TestQuestions(HashSet<string> hashset)
    {
        List<string> validQuestions = new List<string>
        {
            "Does she drink coffee?",
            "Do they play soccer on weekends?",
            "Is he reading a book?",
            "Are we going to the park?",
            "Was she working yesterday?",
            "Were they watching a movie?",
            "Has he finished his homework?",
            "Have you seen the new movie?",
            "Had they already left the house?",
            "Will she call him later?",
            "Shall we start the meeting now?",
            "Can they solve the problem?",
            "Could she help with the project?",
            "May I borrow your pen?",
            "Might they visit us tomorrow?",
            "Must we submit the form today?",
            "Should they take the bus?",
            "Would he like some tea?",
            "Why is she crying?",
            "When will they arrive?",
            "Where are we meeting?",
            "How does he know that?",
            "What did she say?",
            "Which book should I read?",
            "Who is calling at this hour?",
            "Whom should I ask for help?",
            "Whose bag is this?",
            "Whenever will it stop raining?",
            "Wherever did they go?",
            "Whatever can I do now?",
            "Whichever option is better?",
            "Who is coming to the party?",
            "How many friends does he have?",
            "How much time do we need?",
            "What kind of music do they like?",
            "Why are they laughing so loudly?",
            "When did he start working here?",
            "Where has she put her keys?",
            "How do you open this box?",
            "What time is the meeting?",
            "Is it raining outside?",
            "Are they going to join us later?",
            "Was the movie interesting?",
            "Were you listening to the teacher?",
            "Have they been waiting long?",
            "Has she been working hard?",
            "Had they been driving all night?",
            "Will it take much longer?",
            "Shall we order some food?",
            "Can he swim fast?",
            "Could they be lying to us?",
            "May I enter the room?",
            "Might she have misunderstood?",
            "Must we really leave now?",
            "Should I stay or go?",
            "Would it be okay to call later?",
            "Why didn’t she reply?",
            "When will you visit us?",
            "Where are they traveling next?",
            "How does this machine work?",
            "What color do you prefer?",
            "Which song do you recommend?",
            "Who knows the answer?",
            "Whom did you invite?",
            "Whose idea was this?",
            "Whenever did he decide that?",
            "Wherever are you going now?",
            "Whatever happened to him?",
            "Whichever path you take, be careful.",
            "Who is responsible for this?",
            "How often do they meet?",
            "How far is the station?",
            "What sort of food does she enjoy?",
            "Why did he leave early?",
            "When can we meet again?",
            "Where did you park the car?",
            "How have they been doing?",
            "What is she thinking about?",
            "Is she planning to stay?",
            "Are they already there?",
            "Was it a good experience?",
            "Were we supposed to bring something?",
            "Have you ever been to Paris?",
            "Has she already called?",
            "Had they ever tried this before?",
            "Will it snow tomorrow?",
            "Shall I open the window?",
            "Can we finish this on time?",
            "Could it be a mistake?",
            "May I have a moment of your time?",
            "Might it rain later today?",
            "Must he be so rude?",
            "Should they reconsider their plan?",
            "Would she agree with this?",
            "Why didn’t they tell us earlier?",
            "When is the next train arriving?",
            "Where should we meet?",
            "How can we solve this?",
            "What should I bring?",
            "Which way do we go?"
        };
        List<string> validAffirmations = new List<string>()
        {
            "She is reading a book.",
            "He plays soccer every weekend.",
            "They are watching a movie tonight.",
            "We have completed the project.",
            "I will call you later.",
            "John can drive a car.",
            "Sarah should study more often.",
            "It was raining heavily yesterday.",
            "You must finish your homework.",
            "They might visit us tomorrow.",
            "Tom enjoys cooking Italian food.",
            "Emma likes to play the piano.",
            "The cat is sleeping on the couch.",
            "My parents are traveling to France.",
            "Alice has written a beautiful poem.",
            "James is preparing dinner right now.",
            "The students were discussing the topic.",
            "Lily often goes to the park.",
            "The baby cried all night.",
            "Jack has bought a new car.",
            "The teacher explained the lesson clearly.",
            "The birds are singing in the trees.",
            "He rides his bicycle to work.",
            "We are planning a trip to the mountains.",
            "She cleaned her room yesterday.",
            "The company is launching a new product.",
            "They have been working on the presentation.",
            "The train arrived on time.",
            "He was fixing the broken chair.",
            "The team will win the championship.",
            "The dog is barking loudly outside.",
            "She watches TV every evening.",
            "They built a sandcastle at the beach.",
            "The sun is shining brightly today.",
            "The artist painted a beautiful landscape.",
            "They were waiting for the bus.",
            "He studies mathematics every day.",
            "She works in an international company.",
            "We are learning new skills online.",
            "The flowers bloom in the spring.",
            "They went to the cinema last night.",
            "The chef is preparing a delicious meal.",
            "The kids are playing in the garden.",
            "He has traveled to many countries.",
            "She takes good care of her plants.",
            "They attend dance classes twice a week.",
            "The book was written by a famous author.",
            "She sings beautifully in the choir.",
            "He helps his neighbors with their chores.",
            "The scientist discovered a new species.",
            "We are exploring the countryside.",
            "He always arrives early at the meeting.",
            "They enjoy hiking in the mountains.",
            "She is designing a new website.",
            "The city lights look amazing at night.",
            "The baby is learning to walk.",
            "He fixed the computer by himself.",
            "The children are laughing and playing.",
            "She often forgets her keys.",
            "The workers are repairing the road.",
            "They finished their homework before dinner.",
            "The librarian organized the books neatly.",
            "He rides his motorcycle every weekend.",
            "She read an interesting article yesterday.",
            "The car stopped suddenly at the intersection.",
            "The garden is full of colorful flowers.",
            "They were discussing their future plans.",
            "She baked a cake for the party.",
            "He speaks three different languages fluently.",
            "The airplane landed safely on the runway.",
            "The family went camping last weekend.",
            "The tourists are taking photos of the monument.",
            "She plays tennis every Saturday morning.",
            "The professor explained the theory in detail.",
            "They swim in the lake during summer.",
            "The students revised for their exams.",
            "He climbed the mountain in record time.",
            "She received a letter from her friend.",
            "The mechanic repaired the car's engine.",
            "He always drinks coffee in the morning.",
            "They drove to the countryside for a picnic.",
            "The company has achieved great success.",
            "She enjoys painting in her free time.",
            "He reads historical novels regularly.",
            "The team practiced hard for the tournament.",
            "They are organizing a charity event.",
            "The cat jumped onto the kitchen table.",
            "The dog followed its owner to the park.",
            "She wears a beautiful dress to the party.",
            "He opened the window to let in fresh air.",
            "The project was completed ahead of schedule.",
            "The baby smiled at everyone in the room.",
            "She dances gracefully on the stage.",
            "The workers fixed the broken pipe.",
            "He shared his lunch with his colleagues.",
            "The artist created a masterpiece of art.",
            "They visited the museum to learn about history.",
            "She waters her plants every morning.",
            "He turned off the lights before leaving.",
            "We celebrated the festival with joy."

        };
        List<string> validNegations = new List<string>() {
        "She haveasda not readingasdada a bookin", // this must fail
        "AHHAHAHA is not freaking a giant spiderone", // this must fail freaking is not in verbs
        "She is not reading a book.",
        "He does not play soccer every weekend.",
        "They are not watching a movie tonight.",
        "We have not completed the project.",
        "I will not call you later.",
        "John cannot drive a car.",
        "Sarah should not study more often.",
        "It was not raining heavily yesterday.",
        "You must not finish your homework.",
        "They might not visit us tomorrow.",
        "Tom does not enjoy cooking Italian food.",
        "Emma does not like to play the piano.",
        "The cat is not sleeping on the couch.",
        "My parents are not traveling to France.",
        "Alice has not written a beautiful poem.",
        "James is not preparing dinner right now.",
        "The students were not discussing the topic.",
        "Lily does not often go to the park.",
        "The baby did not cry all night.",
        "Jack has not bought a new car.",
        "The teacher did not explain the lesson clearly.",
        "The birds are not singing in the trees.",
        "He does not ride his bicycle to work.",
        "We are not planning a trip to the mountains.",
        "She did not clean her room yesterday.",
        "The company is not launching a new product.",
        "They have not been working on the presentation.",
        "The train did not arrive on time.",
        "He was not fixing the broken chair.",
        "The team will not win the championship.",
        "The dog is not barking loudly outside.",
        "She does not watch TV every evening.",
        "They did not build a sandcastle at the beach.",
        "The sun is not shining brightly today.",
        "The artist did not paint a beautiful landscape.",
        "They were not waiting for the bus.",
        "He does not study mathematics every day.",
        "She does not work in an international company.",
        "We are not learning new skills online.",
        "The flowers do not bloom in the spring.",
        "They did not go to the cinema last night.",
        "The chef is not preparing a delicious meal.",
        "The kids are not playing in the garden.",
        "He has not traveled to many countries.",
        "She does not take good care of her plants.",
        "They do not attend dance classes twice a week.",
        "The book was not written by a famous author.",
        "She does not sing beautifully in the choir.",
        "He does not help his neighbors with their chores.",
        "The scientist did not discover a new species.",
        "We are not exploring the countryside.",
        "He does not always arrive early at the meeting.",
        "They do not enjoy hiking in the mountains.",
        "She is not designing a new website.",
        "The city lights do not look amazing at night.",
        "The baby is not learning to walk.",
        "He did not fix the computer by himself.",
        "The children are not laughing and playing.",
        "She does not often forget her keys.",
        "The workers are not repairing the road.",
        "They did not finish their homework before dinner.",
        "The librarian did not organize the books neatly.",
        "He does not ride his motorcycle every weekend.",
        "She did not read an interesting article yesterday.",
        "The car did not stop suddenly at the intersection.",
        "The garden is not full of colorful flowers.",
        "They were not discussing their future plans.",
        "She did not bake a cake for the party.",
        "He does not speak three different languages fluently.",
        "The airplane did not land safely on the runway.",
        "The family did not go camping last weekend.",
        "The tourists are not taking photos of the monument.",
        "She does not play tennis every Saturday morning.",
        "The professor did not explain the theory in detail.",
        "They do not swim in the lake during summer.",
        "The students did not revise for their exams.",
        "He did not climb the mountain in record time.",
        "She did not receive a letter from her friend.",
        "The mechanic did not repair the car's engine.",
        "He does not always drink coffee in the morning.",
        "They did not drive to the countryside for a picnic.",
        "The company has not achieved great success.",
        "She does not enjoy painting in her free time.",
        "He does not read historical novels regularly.",
        "The team did not practice hard for the tournament.",
        "They are not organizing a charity event.",
        "The cat did not jump onto the kitchen table.",
        "The dog did not follow its owner to the park.",
        "She does not wear a beautiful dress to the party.",
        "He did not open the window to let in fresh air.",
        "The project was not completed ahead of schedule.",
        "The baby did not smile at everyone in the room.",
        "She does not dance gracefully on the stage.",
        "The workers did not fix the broken pipe.",
        "He did not share his lunch with his colleagues.",
        "The artist did not create a masterpiece of art.",
        "They did not visit the museum to learn about history.",
        "She does not water her plants every morning.",
        "He did not turn off the lights before leaving.",
        "We did not celebrate the festival with joy."

        };
        List<string> failedPhrases = new List<string>();

        //bool a = IsAValidSimpleAffirmation("The cat is sleeping on the couch.");
        string allFail = "PORCOZIO: ";
        //if (IsAValidNegation("The art gallery is not open this week."))
        //{
        //    Debug.Log("");
        //}
        //if (IsAValidSimpleQuestion("Am I helping you with the task?"))
        //{
        //    Debug.Log("");
        //}
        foreach (string phrase in hashset)
        {
            // ok 100%
            //if (IsAValidSimpleQuestion(phrase))
            //{
            //    Debug.Log("");
            //}


            //if (IsAValidSimpleAffirmation(phrase))
            //{
            //    Debug.Log("");
            //}


            if (IsAValidNegation(phrase))
            {
                Debug.Log("");
            }
            else
            {
                failedPhrases.Add(phrase);
            }
        }
        foreach (string phrase in failedPhrases)
        {
            allFail += phrase + "\n";
        }
        Debug.Log(allFail);
        Debug.Log("TOTAL FAILED QUESTION: " + failedPhrases.Count);
    }
    bool ContainsWordInCategories(List<string> result, Dictionary<string, HashSet<string>> wordCategories)
    {
        foreach (string word in result) // Itera su ogni parola nella lista `result`
        {
            foreach (string category in wordCategories.Keys) // Itera sulle categorie nel dizionario
            {
                if (wordCategories[category].Contains(word)) // Controlla se la parola appartiene alla categoria
                {
                    Debug.Log($"La parola '{word}' appartiene alla categoria '{category}'.");
                    return true; // Restituisce `true` alla prima corrispondenza trovata
                } else
                {
                    wordCategories["bonusWords"].Add(word);
                    Debug.Log($"La parola '{word}' ora appartiene alla categoria 'bonusWords'.");
                    return true;
                }
            }
        }
        Debug.Log("Nessuna parola in `result` appartiene alle categorie nel dizionario.");
        return false; // Restituisce `false` se nessuna corrispondenza è trovata
    }

    bool IsAValidSimpleQuestion(string input)
    {
        // Pulisce e divide l'input in parole
        List<string> result = SplitAndCleanString(input.ToLower());
        bool found = ContainsWordInCategories(result, wordCategories);

        bool IsInCategory(string word, string category) =>
            wordCategories[category].Contains(word) || wordCategories["bonusWords"].Contains(word);

        // DOes your parents
        // do parents...
        bool FirstIsWithPossessives =
            (result[1].ToLower() == "my" ||
             result[1].ToLower() == "your" ||
             result[1].ToLower() == "her" ||
             result[1].ToLower() == "his" ||
             result[1].ToLower() == "its" ||
             result[1].ToLower() == "our" ||
             result[1].ToLower() == "their");

        bool checkForFirstTwoWords = (FirstIsWithPossessives && IsInCategory(result[2], "subject") || IsInCategory(result[1], "subject"));

        if (result.Count < 2) // Lunghezza minima per una domanda completa
        {
            feedbackText.text = "Sentence Too Short";
            result.Clear();
            return false;
        }

        bool caseAM_I = result[0].ToLower().Equals("am") && result[1].ToLower().Equals("i");
        bool caseAre_you_ = result[0].ToLower().Equals("are") &&
                            (result[1].ToLower().Equals("you") || result[1].ToLower().Equals("we") || result[1].ToLower().Equals("they"));
        bool caseIs_ = result[0].ToLower().Equals("is") &&
                       (result[1].ToLower().Equals("she") || result[1].ToLower().Equals("it") || result[1].ToLower().Equals("he"));

        if (caseAM_I || caseAre_you_ || caseIs_ &&
            wordCategories["verb"].Contains(result[2].ToLower()) &&
            ((IsInCategory(result[3], "subject") && wordCategories["averbs"].Contains(result[3].ToLower())) ||
             IsInCategory(result[3], "subject")))
        {
            feedbackText.text = "Input ok: Am/Are/Is + I/you/she... + verb + sub/obj & adverb OR sub/obj...";
            result.Clear();
            return true;
        }

        // Caso 1: Whose + Soggetto + Verbo
        if ((result[0] == "whose" || wordCategories["wh-word"].Contains(result[0]) /*|| wordCategories["bonusWords"].Contains(result[0])*/) &&
            checkForFirstTwoWords /*|| wordCategories["bonusWords"].Contains(result[1]))*/ &&
            (wordCategories["verb"].Contains(result[2]) || checkForFirstTwoWords))
        {
            feedbackText.text = "Input ok: whose + subject + verb.";
            result.Clear();
            return true;
        }

        // whichever
        // Caso 2: Whichever + Relative Structure
        //if ((result[0] == "whichever" || wordCategories["wh-word"].Contains(result[0])/* || wordCategories["bonusWords"].Contains(result[0])*/) &&
        //    checkForFirstTwoWords /*|| wordCategories["bonusWords"].Contains(result[1]))*/ &&
        //    (wordCategories["verb"].Contains(result[2]) || checkForFirstTwoWords))
        //{
        //    feedbackText.text = "Input ok: whichever/wh-word + ( my/your etc... + subj/obj ) + verb + (sub/obj) ";
        //    return true;
        //}

        // Caso 3: What kind of / What sort of
        if ((result[0] == "what" && (result[1] == "kind" || result[1] == "sort") && result[2] == "of") &&
            (IsInCategory(result[3], "subject")))
        {
            feedbackText.text = "Input ok: what kind of + noun + verb.";
            result.Clear();
            return true;
        }

        // Caso 4: Modals + I/Subject + Verb
        if ((wordCategories["auxiliary"].Contains(result[0]) /*|| wordCategories["bonusWords"].Contains(result[0])*/) &&
            (IsInCategory(result[1], "subject") || result[1] == "i" ) &&
            (wordCategories["verb"].Contains(result[2]) || IsInCategory(result[2], "subject")))
        {
            feedbackText.text = "Input ok: modal + subject + verb.";
            result.Clear();
            return true;
        }

        // Caso 5: Why didn’t + Subject + Verb
        if ((result[0] == "why" || wordCategories["wh-word"].Contains(result[0]) /*|| wordCategories["bonusWords"].Contains(result[0])*/) &&
            wordCategories["auxiliary"].Contains(result[1]) &&
            (IsInCategory(result[2], "subject")) /*|| wordCategories["bonusWords"].Contains(result[2]))*/ &&
            (wordCategories["verb"].Contains(result[3]) || IsInCategory(result[3], "subject")))
        {
            feedbackText.text = "Input ok: why didn’t + subject + verb.";
            result.Clear();
            return true;
        }

        // Caso 6: Domande semplici con Who/What/How + Verbo
        if ((result[0] == "who" || result[0] == "what" || result[0] == "how" ||
             wordCategories["wh-word"].Contains(result[0]) /*|| wordCategories["bonusWords"].Contains(result[0])*/) &&
            (wordCategories["verb"].Contains(result[1]) || IsInCategory(result[1], "subject")))
        {
            feedbackText.text = "Input ok: who/what/how + verb.";
            result.Clear();
            return true;
        }

        if ((wordCategories["auxiliary"].Contains(result[0]) /*|| wordCategories["bonusWords"].Contains(result[0])*/) &&
            (IsInCategory(result[1], "subject") /*|| wordCategories["bonusWords"].Contains(result[1]))*/ &&
            (result.Count >= 3 && (wordCategories["averbs"].Contains(result[2]) || wordCategories["verb"].Contains(result[2]) || IsInCategory(result[2], "subject")))))
        {
            feedbackText.text = "Input ok: modal + subject + optional adverb + verb.";
            result.Clear();
            return true;
        }

        // Caso 7: Why didn’t + Subject + Verb
        if ((result[0] == "why" || wordCategories["wh-word"].Contains(result[0]) /*|| wordCategories["bonusWords"].Contains(result[0])*/) &&
            wordCategories["auxiliary"].Contains(result[1]) &&
            (IsInCategory(result[2], "subject") /*|| wordCategories["bonusWords"].Contains(result[2])*/) &&
            (wordCategories["verb"].Contains(result[3]) || IsInCategory(result[3], "subject")))
        {
            feedbackText.text = "Input ok: why didn’t + subject + verb.";
            result.Clear();
            return true;
        }

        // Caso 8: Who + Verb
        if ((result[0] == "who" || wordCategories["wh-word"].Contains(result[0]) /*|| wordCategories["bonusWords"].Contains(result[0])*/) &&
            (wordCategories["verb"].Contains(result[1]) || IsInCategory(result[1], "subject")))
        {
            feedbackText.text = "Input ok: who + verb.";
            result.Clear();
            return true;
        }

        // Caso 9: Whichever + Subject + Verb + Conditional
        //if ((result[0] == "whichever" || wordCategories["wh-word"].Contains(result[0]) /*|| wordCategories["bonusWords"].Contains(result[0])*/) &&
        //    (IsInCategory(result[1], "subject")) /*|| wordCategories["bonusWords"].Contains(result[1]))*/ &&
        //    (wordCategories["verb"].Contains(result[2]) || IsInCategory(result[2], "subject")) &&
        //    result.Count > 3) // Condizione: ulteriore clausola
        //{
        //    feedbackText.text = "Input ok: whichever + subject + verb + conditional.";
        //    return true;
        //}

        // Caso 10: How often + Auxiliary + Subject + Verb
        if ((result[0] == "how" && result[1] == "often") &&
            (wordCategories["auxiliary"].Contains(result[2]) || wordCategories["bonusWords"].Contains(result[2])) &&
            (IsInCategory(result[3], "subject")) /*|| wordCategories["bonusWords"].Contains(result[3]))*/ &&
            (wordCategories["verb"].Contains(result[4]) || IsInCategory(result[4], "subject")))
        {
            feedbackText.text = "Input ok: how often + auxiliary + subject + verb.";
            result.Clear();
            return true;
        }

        // Caso 11: Were + Subject + Supposed to + Verb
        if ((result[0] == "were" || wordCategories["auxiliary"].Contains(result[0]) /*|| wordCategories["bonusWords"].Contains(result[0])*/) &&
            (IsInCategory(result[1], "subject") /*|| wordCategories["bonusWords"].Contains(result[1])*/) &&
            result[2] == "supposed" &&
            result[3] == "to" &&
            (wordCategories["verb"].Contains(result[4]) || IsInCategory(result[4], "subject")))
        {
            feedbackText.text = "Input ok: were + subject + supposed to + verb.";
            result.Clear();
            return true;
        }

        // Caso 12: Which + Noun + Auxiliary + Subject + Verb
        if ((result[0] == "which" || wordCategories["wh-word"].Contains(result[0]) /*|| wordCategories["bonusWords"].Contains(result[0])*/) &&
            (IsInCategory(result[1], "subject") /*|| wordCategories["bonusWords"].Contains(result[1])*/) &&
            (wordCategories["auxiliary"].Contains(result[2]) || IsInCategory(result[2], "subject")) &&
            (IsInCategory(result[3], "subject") /*|| wordCategories["bonusWords"].Contains(result[3])*/) &&
            (wordCategories["verb"].Contains(result[4]) || IsInCategory(result[4], "subject")))
        {
            feedbackText.text = "Input ok: which + noun + auxiliary + subject + verb.";
            result.Clear();
            return true;
        }

        // Gestione di parole aggiuntive come nel metodo precedente
        for (int i = 2; i < result.Count; i++)
        {
            if (!(wordCategories["time"].Contains(result[i]) || IsInCategory(result[i], "subject")) &&
                !(wordCategories["preposition"].Contains(result[i]) || IsInCategory(result[i], "subject")) &&
                !(wordCategories["averbs"].Contains(result[i]) || IsInCategory(result[i], "subject")))
            {
                feedbackText.text = "Internal Error - The System Can't Detect This Type Of Input Right Now - Try Another";
                result.Clear();
                return false;
            }
        }
        Debug.Log("Domanda valida.");
        result.Clear();
        return true;
    }
    bool IsAValidSimpleAffirmation(string input)
    {
        // Pulisce e divide l'input in parole
        List<string> result = SplitAndCleanString(input.ToLower());
        bool found = ContainsWordInCategories(result, wordCategories);
        if (result.Count < 2) // Lunghezza minima per un'affermazione completa
        {
            Debug.Log("Input troppo breve per essere un'affermazione valida.");
            feedbackText.text = "Sentence Too Short";
            return false;
        }

        // Funzione generica per controllare se una parola appartiene a una categoria
        bool IsInCategory(string word, string category) =>
            wordCategories[category].Contains(word) || wordCategories["bonusWords"].Contains(word);
        // My parents ....
        // parents ...
        bool FirstIsWithPossessives = 
            (result[0].ToLower() == "my" ||
             result[0].ToLower() == "your" ||
             result[0].ToLower() == "her" ||
             result[0].ToLower() == "his" ||
             result[0].ToLower() == "its" ||
             result[0].ToLower() == "our" ||
             result[0].ToLower() == "their");

        bool checkForFirstTwoWords = (FirstIsWithPossessives && IsInCategory(result[1], "subject") || IsInCategory(result[0], "subject"));

        // Caso 0: Frasi che iniziano con "The"
        if (FirstIsWithPossessives || result[0] == "the" && result.Count >= 3 &&
            IsInCategory(result[1], "subject") &&
            wordCategories["verb"].Contains(result[2]) || wordCategories["auxiliary"].Contains(result[2]))
        {
            Debug.Log("Affermazione valida: 'The' + noun + verb/auxiliary.");
            result.Clear();
            return true;
        }

        // Caso 1: Subject + Verb
        if (checkForFirstTwoWords && wordCategories["verb"].Contains(result[1]))
        {
            Debug.Log("Affermazione valida: subject + verb.");
            result.Clear();
            return true;
        }

        // Caso 2: Subject + Auxiliary + Verb
        if (result.Count >= 3 &&
            checkForFirstTwoWords &&
            wordCategories["auxiliary"].Contains(result[1]) &&
            wordCategories["verb"].Contains(result[2]))
        {
            Debug.Log("Affermazione valida: subject + auxiliary + verb.");
            result.Clear();
            return true;
        }

        // Caso 3: Subject + Modal + Verb
        if (result.Count >= 3 &&
            checkForFirstTwoWords &&
            wordCategories["auxiliary"].Contains(result[1]) &&
            wordCategories["verb"].Contains(result[2]))
        {
            Debug.Log("Affermazione valida: subject + modal + verb.");
            result.Clear();
            return true;
        }

        // Caso 4: Subject + Verb-ing
        if (result.Count >= 2 &&
            checkForFirstTwoWords &&
            wordCategories["verb"].Contains(result[1]))
        {
            Debug.Log("Affermazione valida: subject + verb-ing.");
            result.Clear();
            return true;
        }

        // Caso 5: Subject + Past Participle
        if (result.Count >= 3 &&
            checkForFirstTwoWords &&
            wordCategories["auxiliary"].Contains(result[1]) &&
            wordCategories["verb"].Contains(result[2]))
        {
            Debug.Log("Affermazione valida: subject + auxiliary + past participle.");
            result.Clear();
            return true;
        }

        if (result.Count >= 4 &&
            checkForFirstTwoWords &&
            wordCategories["verb"].Contains(result[1]) &&
            result[2] == "to" &&
            IsInCategory(result[3], "bonusWords"))
                {
            Debug.Log("Affermazione valida: subject + verb + 'to' + location.");
            result.Clear();
            return true;
        }

        if (result.Count >= 3 &&
            checkForFirstTwoWords &&
            wordCategories["averbs"].Contains(result[1]) &&
            wordCategories["verb"].Contains(result[2]))
        {
            Debug.Log("Affermazione valida: subject + adverb + verb.");
            result.Clear();
            return true;
        }

        if (result.Count >= 3 &&
            checkForFirstTwoWords &&
            wordCategories["auxiliary"].Contains(result[1]) &&
            wordCategories["averbs"].Contains(result[2]) &&
            result.Count >= 4 &&
            wordCategories["verb"].Contains(result[3]))
        {
            Debug.Log("Affermazione valida: subject + auxiliary + adverb + verb.");
            result.Clear();
            return true;
        }
        // Caso 6: Complementi opzionali dopo il verbo
        for (int i = 2; i < result.Count; i++)
        {
            if (!(wordCategories["time"].Contains(result[1]) ||
                  wordCategories["preposition"].Contains(result[1]) ||
                  wordCategories["averbs"].Contains(result[1]) ||
                  checkForFirstTwoWords))
            {
                Debug.Log($"La parola '{result[i]}' non appartiene a nessuna categoria.");
                feedbackText.text = "Internal Error - The System Can't Detect This Type Of Input Right Now - Try Another";
                result.Clear();
                return false;
            }
        }
        Debug.Log("Affermazione valida.");
        result.Clear();
        return true;
    }
    bool IsAValidNegation(string input)
    {
        // Pulisce e divide l'input in parole
        List<string> result = SplitAndCleanString(input.ToLower());
        bool found = ContainsWordInCategories(result, wordCategories);
        if (result.Count < 3) // Lunghezza minima per una negazione completa
        {
            Debug.Log("Input troppo breve per essere una negazione valida.");
            feedbackText.text = "Sentence Too Short";
            return false;
        }

        // Funzione per controllare se una parola appartiene a una categoria
        bool IsInCategory(string word, string category) =>
            wordCategories.ContainsKey(category) &&
            (wordCategories[category].Contains(word) || wordCategories["bonusWords"].Contains(word));

        bool FirstIsWithPossessives =
            (result[0].ToLower() == "my" ||
             result[0].ToLower() == "your" ||
             result[0].ToLower() == "her" ||
             result[0].ToLower() == "his" ||
             result[0].ToLower() == "its" ||
             result[0].ToLower() == "our" ||
             result[0].ToLower() == "their");

        bool checkForFirstTwoWords = (FirstIsWithPossessives && IsInCategory(result[1], "subject") || IsInCategory(result[0], "subject"));

        // Caso 1: Subject + Auxiliary/Modal + "not" + Verb
        if (result.Count >= 4 &&
            /*IsInCategory(result[0], "subject")*/  checkForFirstTwoWords  &&
            //(IsInCategory(result[1], "auxiliary") || IsInCategory(result[1], "modal")) &&
            wordCategories["auxiliary"].Contains(result[1]) &&
            //result[2] == "not" &&
            wordCategories["verb"].Contains(result[2]))
        {
            feedbackText.text = "Input ok: subject + auxiliary/modal + not + verb.";
            result.Clear();
            return true;
        }

        // Caso 2: Subject + Auxiliary + "not" + Verb-ing (Present Continuous)
        if (result.Count >= 4 &&
             checkForFirstTwoWords &&
            wordCategories["auxiliary"].Contains(result[1]) &&
            //result[2] == "not" &&
            wordCategories["verb"].Contains(result[2]))
        {
            feedbackText.text = "Input ok: subject + auxiliary + not + verb-ing.";
            result.Clear();
            return true;
        }

        // Caso 3: Subject + Auxiliary + "not" + Past Participle (Passato prossimo)
        if (result.Count >= 4 &&
             checkForFirstTwoWords &&
            wordCategories["auxiliary"].Contains(result[1]) &&
            //result[2] == "not" &&
            wordCategories["verb"].Contains(result[2]))
        {
            feedbackText.text = "Input ok: subject + auxiliary + not + past participle.";
            result.Clear();
            return true;
        }

        // Caso 4: Subject + "cannot" + Verb (Forma contratta)
        if (result.Count >= 3 &&
            checkForFirstTwoWords &&
            //result[1] == "cannot" &&
            wordCategories["verb"].Contains(result[1]))
        {
            feedbackText.text = "Input ok: subject + cannot + verb.";
            result.Clear();
            return true;
        }

        // Caso 5: Subject + Auxiliary + "not" + Verb con avverbi aggiuntivi
        if (result.Count >= 5 &&
             checkForFirstTwoWords &&
            wordCategories["auxiliary"].Contains(result[1]) &&
            //result[2] == "not" &&
            wordCategories["verb"].Contains(result[2]) &&
            (wordCategories["averbs"].Contains(result[3]) || wordCategories["time"].Contains(result[3])))
        {
            feedbackText.text = "Input ok: subject + auxiliary + not + verb + adverbs/time.";
            result.Clear();
            return true;
        }
        // Caso 7: Subject + Auxiliary + "not" + Verb + [Adverb/Time/Clause]
        if (result.Count >= 6 &&
            checkForFirstTwoWords &&
            wordCategories["auxiliary"].Contains(result[1]) &&
            wordCategories["verb"].Contains(result[2]) &&
            // Controlla che i restanti elementi siano opzionali e validi
            result.Skip(3).All(word => wordCategories["time"].Contains(word) ||
                                        wordCategories["preposition"].Contains(word) ||
                                        wordCategories["averbs"].Contains(word) ||
                                        IsInCategory(word, "bonusWords")))
        {
            feedbackText.text = "Input ok: subject + auxiliary + not + verb + additional elements.";
            result.Clear();
            return true;
        }

        //if (result.Count >= 7)
        //{
        //    feedbackText.text = "Sorry. Cant Detect Sentences This Long ATM";
        //    return false;
        //}

        // Caso 6: Frasi con elementi aggiuntivi
        for (int i = 4; i < result.Count; i++)
        {
            if (!(wordCategories["time"].Contains(result[i]) ||
                  wordCategories["preposition"].Contains(result[i]) ||
                  wordCategories["averbs"].Contains(result[i]) ||
                  IsInCategory(result[i], "bonusWords") ||
                  wordCategories["verb"].Contains(result[i])) || result.Count >= 7)
            {
                Debug.Log($"La parola '{result[i]}' non appartiene a nessuna categoria.");
                feedbackText.text = "Internal Error - The System Can't Detect This Type Of Input Right Now - Try Another";
                result.Clear();
                return false;
            }
        }

        Debug.Log("Negazione valida.");
        feedbackText.text = "Valid Negation";
        result.Clear();
        return true;
    }

    static List<string> SplitAndCleanString(string input)
    {
        // Rimuove i segni di punteggiatura dalla stringa
        string cleanedInput = new string(input.Where(c => !char.IsPunctuation(c)).ToArray());

        // Splitta la stringa in base agli spazi e crea una lista
        List<string> words = cleanedInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        return words;
    }
 
    #region FILL QUESTIONS RULES
    // PRESENT TENSE
    private string Return_PresentSimple_Question_Rules()
    {
        return "1.(auxiliary) + (subject) + (frequency adverb) + (base verb) + (object) + (other adverbs)?" + "\nEx.Does she often visit her grandparents?\n\n" +
               "2.(wh- word/How) + (frequency adverb) + (auxiliary) + (subject) + (base verb) + (object) + (other adverbs)?" + "\nHow often do you visit your parents?";
    }
    private string Return_PresentContinuous_Question_Rules()
    {
        return "1.(Wh- word}/(How) + (auxiliary verb (am/are/is)} + (subject} + (frequency adverb) + (base verb + -ing) + (other adverbs)" + "\nEx:What are you doing?\n\n" +
               "2.How (auxiliary) + (subject) + (verb) + (complement)." + "\nEx:How is she working today?";
    }
    private string Return_Present_Perfect_Question_Rule()
    {
        return "1. (Wh- word/How) + (have/has) + (subject) + (past participle) + (object/complement)?" + "\nEx: What have you done today?\n\n" +
                   "2. (Have/Has) + (subject) + (past participle) + (object/complement)?" + "\nEx: Have you finished your homework?";
    }
    private string Return_Present_Perfect_Continuous_Question_Rule()
    {
        return "1. Have/Has + (subject) + (frequency/quantity adverb) + been + (base verb + -ing) + (complement) + (other adverbs)?" +
       "\nEx: Have you always been practicing your piano consistently in the living room recently?\n\n" +
       "2. (Wh- word/How) + (have/has) + (subject) + (frequency/quantity adverb) + been + (base verb + -ing) + (complement) + (other adverbs)?" +
       "\nEx: How long have they been working on this project?";
    }

    //  PAST TENSE
    private string Return_Past_Simple_Question_Rules()
    {
        return "1.(Wh- word/How) + (did) + (subject) + (base verb) + (object/complement)?" + "\nEx:What did you do yesterday?\n\n" +
               "2.(Wh- word) + (auxiliary) + (subject) + (base verb) + (complement)?" + "\nEx:Why did he leave early?";
    }
    private string Return_Past_Continuous_Question_Rule()
    {
        return "1.(Wh- word/How) + (was/were} + {subject} + {base verb + -ing} + {object/complement}?" + "\nEx:What were you doing yesterday evening?\n\n" +
               "2.(auxiliary) + (subject) + (base verb + -ing) + (complement)" + "\nEx:Was he sleeping at that time?";
    }
    private string Return_Past_Perfect_Question_Rule()
    {
        return "1. (Wh- word/How) + (had) + (subject) + (optional adverb) + (past participle) + (object/complement)?" +
                   "\nEx: Had she already finished her homework before dinner?\n\n" +
                   "2. (Had) + (subject) + (optional adverb) + (past participle) + (object/complement)?" +
                   "\nEx: Had they completed the task before the manager arrived?";
    }
    private string Return_Past_Perfect_Continuous_Question_Rule()
    {
        return "1.(Wh- word/How) + (had) + (optional adverb) + (subject) + (been) + (verb-ing) + (object/complement)?" + "\nHad she been studying for hours before the exam?\n\n";
    }
    // FUTURE TENSE
    private string Return_Future_Simple_Question_Rule()
    {
        return "1.(Wh- word/How) + (will) + (subject) + (base verb) + (object/complement)?" + "\nWhat will you do tomorrow?\n\n" +
               "2.Will + (subject) + (base verb) + (complement)." + "\nWill she come to the meeting?";
    }
    private string Return_Future_Continuous_Question_Rule()
    {
        return "1. (Wh- word/How) + (will) + (subject) + (be) + (verb-ing) + (object/complement)?" +
                   "\nEx: What will you be doing tomorrow?\n\n";
    }
    private string Return_Future_Perfect_Question_Rule()
    {
        return "1. (Wh- word/How) + (will) + (subject) + (have) + (past participle) + (object/complement)?" +
          "\nEx: Will she have finished her work by tomorrow?\n\n";
    }
    private string Return_Future_Perfect_Continuous_Question_Rule()
    {
        return "1. (Wh- word/How) + (will) + (subject) + (have been) + (verb-ing) + (object/complement)?" +
           "\nEx: How long will you have been working on this project by the end of the month?\n\n";
    }
    #endregion

    #region FILL AFFIRMATION RULES
    private string Return_PresentSimple_Affirmation_Rules()
    {
        return "1.(subject) + (base verb, 3rd person singular adds 's') + (object) + (other adverbs)." + "\nEx.She loves her family.\n\n" +
               "2.(subject) + (frequency adverb) + (base verb) + (object) + (other adverbs)." + "\nEx.They always play football on weekends.";
    }

    private string Return_PresentContinuous_Affirmation_Rules()
    {
        return "1.(subject) + (be verb: am/is/are) + (verb+ing) + (object) + (other adverbs)." + "\nEx.He is reading a book.\n\n" +
               "2.(subject) + (be verb: am/is/are) + (frequency adverb) + (verb+ing) + (object) + (other adverbs)." + "\nEx.She is always studying in the library.";
    }

    private string Return_PresentPerfect_Affirmation_Rules()
    {
        return "1.(subject) + (have/has) + (past participle) + (object) + (other adverbs)." + "\nEx.I have visited Paris.\n\n" +
               "2.(subject) + (frequency adverb) + (have/has) + (past participle) + (object) + (other adverbs)." + "\nEx.She has never eaten sushi.";

    }

    private string Return_PresentPerfectContinuous_Affirmation_Rules()
    {
        return "1.(subject) + (have/has) + (been) + (verb+ing) + (object) + (other adverbs)." + "\nEx.They have been playing football.\n\n" +
               "2.(subject) + (frequency adverb) + (have/has) + (been) + (verb+ing) + (object) + (other adverbs)." + "\nEx.He has always been working hard.";
    }
    //  PAST TENSE
    private string Return_PastSimple_Affirmation_Rules()
    {
        return "1.(subject) + (past tense verb) + (object) + (other adverbs)." + "\nEx.She visited her grandparents yesterday.\n\n" +
               "2.(subject) + (frequency adverb) + (past tense verb) + (object) + (other adverbs)." + "\nEx.They often played chess after dinner.";

    }

    private string Return_PastContinuous_Affirmation_Rules()
    {
        return "1.(subject) + (was/were) + (verb+ing) + (object) + (other adverbs)." + "\nEx.He was reading a book all afternoon.\n\n" +
               "2.(subject) + (frequency adverb) + (was/were) + (verb+ing) + (object) + (other adverbs)." + "\nEx.They were always working late.";
    }

    private string Return_PastPerfect_Affirmation_Rules()
    {
        return "1.(subject) + (had) + (past participle) + (object) + (other adverbs)." + "\nEx.She had already left when he arrived.\n\n" +
               "2.(subject) + (frequency adverb) + (had) + (past participle) + (object) + (other adverbs)." + "\nEx.They had never seen such a beautiful sunset.";

    }

    private string Return_PastPerfectContinuous_Affirmation_Rules()
    {
        return "1.(subject) + (had been) + (verb+ing) + (object) + (other adverbs)." + "\nEx.They had been studying for hours before the exam.\n\n" +
               "2.(subject) + (frequency adverb) + (had been) + (verb+ing) + (object) + (other adverbs).";
    }
    // FUTURE TENSE
    private string Return_FutureSimple_Affirmation_Rules()
    {
        return "1.(subject) + (will) + (base verb) + (object) + (other adverbs)." + "\nEx.She will visit her grandparents tomorrow.\n\n" +
               "2.(subject) + (frequency adverb) + (will) + (base verb) + (object) + (other adverbs)." + "\nEx.They will always remember this moment.";
    }

    private string Return_FutureContinuous_Affirmation_Rules()
    {
        return "1.(subject) + (will be) + (verb+ing) + (object) + (other adverbs)." + "\nEx.She will be studying at the library this evening.\n\n" +
               "2.(subject) + (frequency adverb) + (will be) + (verb+ing) + (object) + (other adverbs)." + "\nEx.They will always be working hard.";
    }

    private string Return_FuturePerfect_Affirmation_Rules()
    {
        return "1.(subject) + (will have) + (past participle) + (object) + (other adverbs)." + "\nEx.She will have finished her homework by 8 PM.\n\n" +
               "2.(subject) + (frequency adverb) + (will have) + (past participle) + (object) + (other adverbs)." + "\nEx.They will always have completed their tasks on time.";
    }

    private string Return_FuturePerfectContinuous_Affirmation_Rules()
    {
        return "1.(subject) + (will have been) + (verb+ing) + (object) + (other adverbs)." + "\nEx.They will have been working on the project for three months by then.\n\n" +
               "2.By + (time reference), (subject) + (frequency adverb) + (will have been) + (verb+ing) + (object) + (other adverbs)." + "\nEx.By next year, I will have been working here for 10 years.";
    }
    #endregion

    #region FILL NEGATIONS RULES
    private string Return_PresentSimple_Negations_Rules()
    {
        return "1. (subject) + (auxiliary 'do/does' + 'not') + (base verb) + (object) + (other adverbs)." + "\nEx. She does not like ice cream.\n\n" +
               "2. (wh- word/How) + (auxiliary 'do/does' + 'not') + (subject) + (base verb) + (object) + (other adverbs)." + "\nEx. Why do they not play football?";
    }

    private string Return_PresentContinuous_Negations_Rules()
    {
        return "1. (subject) + (verb 'to be' + 'not') + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. She is not reading the book.\n\n" +
               "2. (wh- word/How) + (verb 'to be') + (subject) + (not) + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. Why is he not studying?";

    }

    private string Return_Present_Perfect_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'have/has' + 'not') + (past participle) + (object) + (other adverbs)." + "\nEx. I have not finished the report.\n\n" +
               "2. (wh- word/How) + (auxiliary 'have/has') + (subject) + (not) + (past participle) + (object) + (other adverbs)." + "\nEx. Why has she not called?";
    }

    private string Return_Present_Perfect_Continuous_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'have/has' + 'not') + 'been' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. I have not been waiting for hours.\n\n" +
               "2. (wh- word/How) + (auxiliary 'have/has') + (subject) + (not) + 'been' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. Why have they not been studying?";
    }
    //  PAST TENSE
    private string Return_Past_Simple_Negations_Rules()
    {
        return "1. (subject) + (auxiliary 'did' + 'not') + (base verb) + (object) + (other adverbs)." + "\nEx. They did not go to the park.\n\n" +
               "2. (wh- word/How) + (auxiliary 'did') + (subject) + (not) + (base verb) + (object) + (other adverbs)." + "\nEx. Why did she not attend the meeting?";
    }

    private string Return_Past_Continuous_Negations_Rule()
    {
        return "1. (subject) + (verb 'to be' in past + 'not') + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. She was not reading the book.\n\n" +
               "2. (wh- word/How) + (verb 'to be' in past) + (subject) + (not) + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. Why were they not playing football?";
    }

    private string Return_Past_Perfect_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'had' + 'not') + (past participle) + (object) + (other adverbs)." + "\nEx. She had not visited the museum.\n\n" +
               "2. (wh- word/How) + (auxiliary 'had') + (subject) + (not) + (past participle) + (object) + (other adverbs)." + "\nEx. Why had he not finished his homework?";
    }

    private string Return_Past_Perfect_Continuous_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'had' + 'not') + 'been' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. I had not been waiting for long.\n\n" +
               "2. (wh- word/How) + (auxiliary 'had') + (subject) + (not) + 'been' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. Why had they not been studying?";
    }
    // FUTURE TENSE
    private string Return_Future_Simple_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'will' + 'not') + (base verb) + (object) + (other adverbs)." + "\nEx. She will not attend the meeting.\n\n" +
               "2. (wh- word/How) + (auxiliary 'will') + (subject) + (not) + (base verb) + (object) + (other adverbs)." + "\nEx. Why will you not join us?";

    }
    private string Return_Future_Continuous_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'will' + 'not') + 'be' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. He will not be traveling tomorrow.\n\n" +
               "2. (wh- word/How) + (auxiliary 'will') + (subject) + (not) + 'be' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. Why will she not be working?";

    }
    private string Return_Future_Perfect_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'will' + 'not') + 'have' + (past participle) + (object) + (other adverbs)." + "\nEx. They will not have completed the project.\n\n" +
               "2. (wh- word/How) + (auxiliary 'will') + (subject) + (not) + 'have' + (past participle) + (object) + (other adverbs)." + "\nEx. Why will she not have finished the task?";

    }
    private string Return_Future_Perfect_Continuous_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'will' + 'not') + 'have been' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. I will not have been waiting for an hour.\n\n" +
               "2. (wh- word/How) + (auxiliary 'will') + (subject) + (not) + 'have been' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. Why will they not have been studying?";
    }
    #endregion

    public GameObject HelpMePanel;
    public Text help_solution_text;
    public void HelpMeLogic()
    {
        HelpMePanel.SetActive(true);
        switch (phraseTypeDropdown.options[phraseTypeDropdown.value].text)
        {
            case "Questions":
                HelpWithQuestions(); break;
            case "Affirmations":
                HelpWithAffirmations(); break;
            case "Negations":
                HelpWithNegations(); break;
            default: Debug.Log("error on HandlePhraseType"); break;
        }
    }
    private void HelpWithQuestions()
    {
        System.Random random = new System.Random();
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": help_solution_text.text = EnglishHashSets.present_simple_questions.ElementAt(random.Next(EnglishHashSets.present_simple_questions.Count)); break;
            case "Present Cont.": help_solution_text.text = EnglishHashSets.present_continuous_questions.ElementAt(random.Next(EnglishHashSets.present_continuous_questions.Count)); break;
            case "Present Perfect": help_solution_text.text = EnglishHashSets.present_perfect_questions.ElementAt(random.Next(EnglishHashSets.present_perfect_questions.Count)); break;
            case "Present Perfect Cont.": help_solution_text.text = EnglishHashSets.present_perfect_continuous_questions.ElementAt(random.Next(EnglishHashSets.present_perfect_continuous_questions.Count)); break;

            case "Past Simple": help_solution_text.text = EnglishHashSets.past_simple_questions.ElementAt(random.Next(EnglishHashSets.present_simple_questions.Count)); break;
            case "Past Cont.": help_solution_text.text = EnglishHashSets.past_continuous_questions.ElementAt(random.Next(EnglishHashSets.past_continuous_questions.Count)); break;
            case "Past Perfect": help_solution_text.text = EnglishHashSets.past_perfect_questions.ElementAt(random.Next(EnglishHashSets.past_perfect_questions.Count)); break;
            case "Past Perfect Cont.": help_solution_text.text = EnglishHashSets.past_perfect_continuous_questions.ElementAt(random.Next(EnglishHashSets.past_perfect_continuous_questions.Count)); break;

            case "Future Simple": help_solution_text.text = EnglishHashSets.future_simple_questions.ElementAt(random.Next(EnglishHashSets.future_simple_questions.Count)); break;
            case "Future Cont.": help_solution_text.text = EnglishHashSets.future_continuous_questions.ElementAt(random.Next(EnglishHashSets.future_continuous_questions.Count)); break;
            case "Future Perfect": help_solution_text.text = EnglishHashSets.future_perfect_questions.ElementAt(random.Next(EnglishHashSets.future_perfect_questions.Count)); break;
            case "Future Perfect Cont.": help_solution_text.text = EnglishHashSets.future_perfect_continuous_questions.ElementAt(random.Next(EnglishHashSets.future_perfect_continuous_questions.Count)); break;
            default: Debug.LogError("error on UpdateQuestionRule"); break;
        }
    }
    private void HelpWithAffirmations()
    {
        System.Random random = new System.Random();
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": help_solution_text.text = EnglishHashSets.present_simple_affirmations.ElementAt(random.Next(EnglishHashSets.present_simple_affirmations.Count)); break;
            case "Present Cont.": help_solution_text.text = EnglishHashSets.present_continuous_affirmations.ElementAt(random.Next(EnglishHashSets.present_continuous_affirmations.Count)); break;
            case "Present Perfect": help_solution_text.text = EnglishHashSets.present_perfect_affirmations.ElementAt(random.Next(EnglishHashSets.present_perfect_affirmations.Count)); break;
            case "Present Perfect Cont.": help_solution_text.text = EnglishHashSets.present_perfect_continuous_affirmations.ElementAt(random.Next(EnglishHashSets.present_perfect_continuous_affirmations.Count)); break;

            case "Past Simple": help_solution_text.text = EnglishHashSets.past_simple_affirmations.ElementAt(random.Next(EnglishHashSets.present_simple_affirmations.Count)); break;
            case "Past Cont.": help_solution_text.text = EnglishHashSets.past_continuous_affirmations.ElementAt(random.Next(EnglishHashSets.past_continuous_affirmations.Count)); break;
            case "Past Perfect": help_solution_text.text = EnglishHashSets.past_perfect_affirmations.ElementAt(random.Next(EnglishHashSets.past_perfect_affirmations.Count)); break;
            case "Past Perfect Cont.": help_solution_text.text = EnglishHashSets.past_perfect_continuous_affirmations.ElementAt(random.Next(EnglishHashSets.past_perfect_continuous_affirmations.Count)); break;

            case "Future Simple": help_solution_text.text = EnglishHashSets.future_simple_affirmations.ElementAt(random.Next(EnglishHashSets.future_simple_affirmations.Count)); break;
            case "Future Cont.": help_solution_text.text = EnglishHashSets.future_continuous_affirmations.ElementAt(random.Next(EnglishHashSets.future_continuous_affirmations.Count)); break;
            case "Future Perfect": help_solution_text.text = EnglishHashSets.future_perfect_affirmations.ElementAt(random.Next(EnglishHashSets.future_perfect_affirmations.Count)); break;
            case "Future Perfect Cont.": help_solution_text.text = EnglishHashSets.future_perfect_continuous_affirmations.ElementAt(random.Next(EnglishHashSets.future_perfect_continuous_affirmations.Count)); break;
            default: Debug.LogError("error on UpdateQuestionRule"); break;
        }
    }
    private void HelpWithNegations()
    {
        System.Random random = new System.Random();
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": help_solution_text.text = EnglishHashSets.present_simple_negations.ElementAt(random.Next(EnglishHashSets.present_simple_negations.Count)); break;
            case "Present Cont.": help_solution_text.text = EnglishHashSets.present_continuous_negations.ElementAt(random.Next(EnglishHashSets.present_continuous_negations.Count)); break;
            case "Present Perfect": help_solution_text.text = EnglishHashSets.present_perfect_negations.ElementAt(random.Next(EnglishHashSets.present_perfect_negations.Count)); break;
            case "Present Perfect Cont.": help_solution_text.text = EnglishHashSets.present_perfect_continuous_negations.ElementAt(random.Next(EnglishHashSets.present_perfect_continuous_negations.Count)); break;

            case "Past Simple": help_solution_text.text = EnglishHashSets.past_simple_negations.ElementAt(random.Next(EnglishHashSets.present_simple_negations.Count)); break;
            case "Past Cont.": help_solution_text.text = EnglishHashSets.past_continuous_negations.ElementAt(random.Next(EnglishHashSets.past_continuous_negations.Count)); break;
            case "Past Perfect": help_solution_text.text = EnglishHashSets.past_perfect_negations.ElementAt(random.Next(EnglishHashSets.past_perfect_negations.Count)); break;
            case "Past Perfect Cont.": help_solution_text.text = EnglishHashSets.past_perfect_continuous_negations.ElementAt(random.Next(EnglishHashSets.past_perfect_continuous_negations.Count)); break;

            case "Future Simple": help_solution_text.text = EnglishHashSets.future_simple_negations.ElementAt(random.Next(EnglishHashSets.future_simple_negations.Count)); break;
            case "Future Cont.": help_solution_text.text = EnglishHashSets.future_continuous_negations.ElementAt(random.Next(EnglishHashSets.future_continuous_negations.Count)); break;
            case "Future Perfect": help_solution_text.text = EnglishHashSets.future_perfect_negations.ElementAt(random.Next(EnglishHashSets.future_perfect_negations.Count)); break;
            case "Future Perfect Cont.": help_solution_text.text = EnglishHashSets.future_perfect_continuous_negations.ElementAt(random.Next(EnglishHashSets.future_perfect_continuous_negations.Count)); break;
            default: Debug.LogError("error on UpdateQuestionRule"); break;
        }
    }
    public void CloseHelpMePanel()
    {
        HelpMePanel.SetActive(false);
    }
}