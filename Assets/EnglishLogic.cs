using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;


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

    // Fare HelpMe Button che mostra una delle frasi dopo la pubblicità

    HashSet<string> present_simple_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase){
         "She always eats breakfast in the morning",
        "They sometimes play football on Sundays",
        "He often studies late at night",
        "We rarely watch TV during the week",
        "You never forget your keys",
        "It usually rains in November",
        "I hardly ever drink coffee",
        "She occasionally goes to the gym after work",
        "He quickly finishes his homework",
        "We quietly enter the room to avoid disturbing others",
        "They eagerly wait for the holidays every year",
        "You easily solve math problems",
        "She regularly checks her email in the morning",
        "He slowly walks to school when he feels tired",
        "They happily help their neighbors with gardening",
        "We frequently visit the library on weekends",
        "I seldom eat fast food",
        "He boldly speaks in front of large audiences",
        "She carefully drives on icy roads",
        "You always arrive on time",
        "She is always helping her friends with homework.",
        "They are often playing outside in the garden",
        "He is usually talking to his friends after school",
        "We are constantly working on improving our skills",
        "She is rarely cooking dinner for herself",
        "They are happily discussing the upcoming event",
        "He is slowly learning how to play the guitar",
        "She is completely understanding the lesson now",
        "We are frequently meeting at the cafe to talk",
        "He is hardly ever missing his appointments",
        "They are currently preparing for the big match",
        "She is quickly finishing her presentation",
        "We are patiently waiting for the train to arrive",
        "He is rarely arguing with his brother these days",
        "She is never forgetting to bring her umbrella",
        "They are quietly sitting in the library at the moment",
        "We are regularly exercising to stay fit"
    };
    
    HashSet<string> present_simple_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "What have you done today?",
        "Will she come to the meeting?",
        "What will you do tomorrow?",
        "Was he sleeping at that time?",
        "What were you doing yesterday evening?",
        "Why did he leave early?",
        "What did you do yesterday?",
        "How is she working today?",
        "What are you doing?",
        "How often do you visit your parents?",
        "does she like pizza?",
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
        "does his boss arrive late?",
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
        "How early do my parents wake up in the morning?",
        "Does she often visit her grandparents?",
        "Do you always drink coffee in the morning?",
        "Does she sometimes go to the park?",
        "Do they often play soccer after school?",
        "Does he rarely visit his grandparents?",
        "Do we never forget our appointments?",
        "Do you sing loudly in the shower?",
        "Does she write carefully when sending emails?",
        "Do they speak fluently in English?",
        "Does he read quietly at the library?",
        "Do we work efficiently during the day?",
        "Do you call your friends every evening?",
        "Does he visit his grandmother on Sundays?",
        "Do they study hard before exams?",
        "Does she arrive early every morning?",
        "Do we meet after work on Fridays?",
        "Do you live here in the city?",
        "Does she work there at the office?",
        "Do they play outside when it’s sunny?",
        "Does he stay indoors during winter?",
        "Do we go somewhere special for vacations?",
        "Do you really like this movie?",
        "Does she completely understand the rules?",
        "Do they fully agree with the decision?",
        "Does he hardly finish his tasks on time?",
        "Do we almost miss the bus every day?",
        "How often do you exercise?",
        "Why does he always arrive late?",
        "When do we usually have meetings?",
        "Where do they practice basketball?",
        "What time does she usually wake up?"
    };
    HashSet<string> present_continuous_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "What are you doing?", "Is she working today?", "Are they coming to the meeting?",
        "Why is he laughing?", "Are we going to the cinema tonight?", "What are you thinking about?",
        "Is it raining outside?", "Are you studying English now?", "Who is calling me at this moment?",
        "Are they staying at a hotel?", "Is she cooking dinner tonight?", "Where are you going?",
        "Is he playing the piano right now?", "Why are you shouting?", "Are we waiting for the bus?",
        "Is she reading a book or watching TV?", "Are you working on the project?", "What are they discussing?",
        "Are you having fun?", "Who is running in the park?", "Is the dog barking outside?",
        "Why are they arguing again?", "Is he singing a song?", "What are you eating for lunch?",
        "Is she painting a picture?", "Where are they traveling to?", "Are we meeting him tomorrow?",
        "Why is it snowing in April?", "Are you talking to your friend?", "Is she shopping now?",
        "Who is helping you?", "Are they learning something new?", "Is he swimming at the moment?",
        "Are you feeling okay?", "Why is she crying?", "Are we going together?", "What are they watching?",
        "Is he walking to school?", "Where are you sitting?", "Is she doing yoga this morning?",
        "Are you writing a letter?", "Why is the cat sleeping on the bed?", "Are they enjoying the party?",
        "What are you planning for the weekend?", "Is he fixing his car?", "Are we taking the right road?",
        "Is she practicing her dance routine?", "Where are they moving to?", "Who is joining us for dinner?",
        "Are you dancing to this song?", "Why are they cleaning the house?", "Is it becoming colder?",
        "What are you waiting for?", "Is she designing a new outfit?", "Are they searching for something?",
        "Are you washing the dishes?", "Why is she speaking so loudly?", "What are you learning?",
        "Is he organizing the files?", "Are we starting the meeting soon?", "Who is visiting you today?",
        "Are you checking your email?", "Is she preparing a presentation?", "Why are they standing there?",
        "Are we trying a new recipe?", "What are they building in the garden?", "Is he exploring the city?",
        "Are you enjoying the vacation?", "Why is the baby crying?", "Is she feeding the birds?",
        "What are they repairing?", "Is it getting dark outside?", "Are you making a cake?",
        "Why is she smiling?", "What are we forgetting?", "Is he opening the store?", "Are you calling your mom?",
        "Where are you driving?", "Are they recording the video?", "Is she solving a puzzle?",
        "Why are they sitting there?", "Are we improving our skills?", "What is he playing?",
        "Are you fixing the chair?", "Why is he holding the book?", "Is she delivering a speech?",
        "What are you organizing?", "Is it working as expected?", "Are we heading home?",
        "Why are they celebrating?", "What are you waiting for?", "Is she talking to her teacher?",
        "Where are they parking the car?", "Is he buying groceries?", "Are we leaving soon?",
        "Who is calling at this hour?", "Are they discussing the news?",
        "What are you doing right now?",
        "Is she working on her project?",
        "Are they coming to the party tonight?",
        "Why is he laughing so much?",
        "Are we going to the park this afternoon?",
        "What is it raining for all day?",
        "Are you studying for your exam?",
        "Who is calling you at this moment?",
        "Are they staying at their aunt's house?",
        "Is she cooking dinner for everyone?",
        "Where are you heading to?",
        "Is he playing the guitar right now?",
        "Why are you shouting so loudly?",
        "Are we waiting for the bus here?",
        "Is she reading that new book?",
        "Are you writing an email to your teacher?",
        "What are they discussing during the meeting?",
        "Is the dog barking at the neighbors again?",
        "Why are they arguing this time?",
        "Is he singing that new song?",
        "What are you eating for lunch today?",
        "Is she painting another landscape?",
        "Where are they moving next month?",
        "Are we meeting our friends later?",
        "Why is it snowing in spring?",
        "Are you talking to the new colleague?",
        "Is she shopping for groceries now?",
        "Who is helping you set up the tent?",
        "Are they learning anything useful?",
        "Is he swimming in the cold lake?",
        "Are you feeling better now?",
        "Why is she crying all of a sudden?",
        "Are we going out for dinner tonight?",
        "What are they watching on TV?",
        "Is he walking the dog in the park?",
        "Where are you sitting in the classroom?",
        "Is she doing yoga at this hour?",
        "Are you making a chocolate cake?",
        "Why is the cat sleeping on the couch?",
        "Are they dancing to this song?",
        "Is it becoming colder outside?",
        "What are you planning for the weekend?",
        "Is she designing new clothes for the show?",
        "Are they cleaning the kitchen together?",
        "Are you washing the car this afternoon?",
        "Why is he holding the umbrella inside?",
        "What are you organizing for the party?",
        "Are they recording a new album?",
        "Is he solving that complicated puzzle?",
        "Are we improving our skills at practice?",
        "Why are they celebrating so loudly?",
        "Are you calling your parents tonight?",
        "Is she delivering an important speech tomorrow?",
        "What are they building in their backyard?",
        "Are we starting the project this week?",
        "Is it working as intended?",
        "Are you enjoying the concert so far?",
        "Why are they sitting in the corner?",
        "Who is joining us for dinner tonight?",
        "Where are they parking the car?",
        "Why is she laughing uncontrollably?",
        "Are you checking your messages now?",
        "What is he playing on the piano?",
        "Are you fixing the broken chair?",
        "Is she feeding the birds in the garden?",
        "Are they taking pictures of the sunset?",
        "Are we heading home soon?",
        "Why is the baby crying?",
        "Are you exploring the new city center?",
        "Is he dancing at the party right now?",
        "Where are you going this evening?",
        "Why is she looking at him like that?",
        "Is he opening the store in the morning?",
        "Are you following the instructions carefully?",
        "What are you waiting for?",
        "Is she talking to the manager?",
        "Why are they learning Spanish?",
        "Is he reading the newspaper outside?",
        "Are you staying for lunch?",
        "Where are they playing football?",
        "Why is it getting dark already?",
        "Are you drawing something interesting?",
        "Is she trying on the new dress?",
        "Are they working from home today?",
        "Is he writing a novel at the moment?",
        "What are you listening to?",
        "Are you packing for the trip tomorrow?",
        "Why are they leaving so early?",
        "Is he playing video games again?",
        "What are you looking for in the drawer?",
        "Is she solving the math problems?",
        "Where are you traveling next summer?",
        "Why are they speaking so softly?",
        "Are you helping your friend move?",
        "Is the teacher explaining the lesson now?",
        "Are we preparing for the exam together?",
        "Why are you always laughing so loudly?",
        "Is she really enjoying her vacation now?",
        "Are they studying at home tonight?",
        "What are we doing quickly to solve this problem?",
        "Where are you sitting here during the class?",
        "Are you always helping your friends with their homework?",
        "Is he often working late at the office?",
        "Are they really enjoying the party?",
        "Is she usually talking to her neighbors in the evening?",
        "Are we constantly improving our skills during these sessions?",
        "Is she rarely cooking dinner for herself these days?",
        "Are they happily planning their next holiday?",
        "Is he slowly learning how to play the piano?",
        "Are you carefully writing down the instructions?",
        "Is she completely understanding the new lesson?",
        "Are we frequently meeting at the library after class?",
        "Are they hardly ever missing these important meetings?",
        "Are you currently preparing for your trip abroad?",
        "Is she quickly finishing her assignment now?",
        "Are we patiently waiting for the train to arrive?",
        "Are they always cleaning the kitchen together?",
        "Is he rarely arguing with his siblings lately?",
        "Is she never forgetting to bring her notebook?",
        "Are they quietly sitting in the living room right now?",
        "Are we regularly exercising to stay in shape?"
};

    private Dictionary<string, HashSet<string>> wordCategories = new Dictionary<string, HashSet<string>>()
    {
        { "wh-word", new HashSet<string> { "why", "when", "where", "how", "what", "which" } },
        { "auxiliary", new HashSet<string> { "does", "do", "is", "are" } },
        { "subject", new HashSet<string> 
            { "she", "he", "it", "we", "they", "you", "john", "sarah", "david", "emma", "jack", "i",
            "John", "Sarah", "David", "Emma", "Tom", "Mike", "Lily", "Alice", "James", "Jack", "my parents", "the students",
            "her brother", "his father", "my friends", "the kids", "the birds", "the engineers", "the tourists", "my cousins",
            "my classmates", "my neighbors", "his cousin", "her sister", "the dogs", "his boss", "my grandparents", "the nurses",
            "the cat", "the baby", "who", "coffee", "car", "music", "emails", "ice cream", "movies", "homework", "office", "cat", "sushi", "cakes", "pictures", "glasses", "water", "bicycles", "computers", "tourists", "windows", "news", "bridges", "medicine",
            "she", "they", "he", "you", "it", "we", "John", "the students", "her brother", "my parents", "Sarah", "the kids", "your cat", "my neighbors", "his father", "my friends", "Emma", "the birds", "Alice", "Tom", "the workers", "her mother", "my cousins", "Jack", "the dogs", "his uncle", "my classmates", "Lily", "the tourists", "her boyfriend", "my teachers", "Mike", "the engineers", "his cousin"
        } },
        
        { "verb", new HashSet<string> 
            { "drink", "visit", "drive", "enjoy", "rain", "arrive", "play", "listen", "work", "call", "write", "like", "walk", "cook", "cost", "watch", "travel", "sleep", "have", "clean", "buy", "sell", 
            "exercise", "dance", "sing", "fix", "bake", "swim", "teach", "eat", "study", "read", "prefer", "sound", "help", "bark", "go", "ride", "repair", "send", "taste", "finish", "build", "wake",
            "is", "are", "am", "doing", "working", "thinking", "coming", "raining", "studying", "calling",
             "staying", "cooking", "going", "playing", "shouting", "waiting", "reading", "discussing",
             "having", "running", "barking", "arguing", "singing", "eating", "painting", "traveling",
             "meeting", "talking", "shopping", "helping", "learning", "swimming", "feeling", "crying",
             "watching", "walking", "sitting", "doing", "writing", "enjoying", "planning", "fixing",
             "taking", "practicing", "moving", "joining", "dancing", "cleaning", "becoming", "waiting",
             "designing", "searching", "washing", "speaking", "learning", "organizing", "starting",
             "visiting", "checking", "preparing", "standing", "trying", "building", "exploring",
             "enjoying", "feeding", "repairing", "making", "smiling", "forgetting", "opening",
             "calling", "driving", "recording", "solving", "sitting", "improving", "fixing", "holding",
             "delivering", "organizing", "working", "heading", "celebrating", "talking", "parking",
             "buying", "leaving", "discussing",
             "are", "is", "working", "coming", "laughing", "going", "thinking", "raining", "studying", "calling", "staying", "cooking", "playing", "shouting", "waiting", "reading", "watching", "discussing", "having", "running", "barking", "arguing", "singing", "eating", "painting", "traveling", "meeting", "snowing", "talking", "shopping", "helping", "learning", "swimming", "feeling", "crying", "planning", "fixing", "taking", "practicing", "moving", "joining", "dancing", "cleaning", "becoming", "waiting", "designing", "searching", "washing", "speaking", "learning", "organizing", "starting", "visiting", "checking", "preparing", "standing", "trying", "building", "exploring", "enjoying", "feeding", "repairing", "getting", "making", "smiling", "forgetting", "opening", "driving", "recording", "solving", "sitting", "improving", "playing", "fixing", "holding", "delivering", "organizing", "working", "heading", "celebrating", "talking", "parking", "buying", "leaving",
              "does", "drink", "do", "visit", "drive", "enjoy", "rain", "arrive", "play", "listen", "work", "call", "write", "love", "walk", "cook", "cost", "watch", "travel", "do", "sleep", "complain", "clean", "buy", "sell", "work", "exercise", "dance", "start", "fix", "love", "bake", "enjoy", "swim", "watch", "play", "smell", "take", "paint", "arrive", "call", "visit", "eat", "study", "read", "prefer", "sound", "sleep", "help", "bark", "work", "like", "go", "ride", "repair", "send", "taste", "finish", "play", "visit", "buy", "give", "open", "order", "watch", "wear", "rain", "dance", "play", "build", "study", "wake", "do", "visit", "drink", "go", "play", "forget", "sing", "write", "speak", "read", "work", "call", "visit", "study", "arrive", "meet", "live", "work", "play", "stay", "go", "like", "understand", "agree", "finish", "miss", "exercise", "arrive", "practice", "wake",
            } },
        { "preposition", new HashSet<string> { "in", "on", "at", "to", "with", "for", "before", "after", "during", "as" } },
        { "averbs", new HashSet<string> { "always", "sometimes", "often", "rarely", "never", "usually", "hardly ever", "occasionally", "quickly", "quietly", "eagerly", "easily", "regularly", "slowly", "happily", "frequently", "seldom", "boldly", "carefully" } },
        { "time", new HashSet<string> { "morning", "weekends", "evening", "night", "winter", "Fridays" } }
    };

    void Start()
    {
        Debug.LogWarning("Show a Panel in which you say that atm no all words are recognized!");
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
                feedbackText.text = isValid ? "Correct!" : "Incorrect structure Or some words not yet recognized, please try another";
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
            case "Present Simple": rule_dynamic_text.text = Return_PresentSimple_Question_Rules(); break; // spostare in un panel
            case "Past Simple": rule_dynamic_text.text = Return_Past_Simple_Question_Rules();  break;
            case "Present Continuous": rule_dynamic_text.text = Return_PresentContinuous_Question_Rules(); break;
            case "Past Continuous": rule_dynamic_text.text = Return_Past_Continuous_Question_Rule(); break;
            case "Future Simple": rule_dynamic_text.text = Return_Future_Simple_Question_Rule(); break;
            case "Present Perfect": rule_dynamic_text.text = Return_Present_Perfect_Question_Rule(); break;
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
    private bool MatchesPresentSimpleQuestionsStructure(string input)
    {
        if ("Questions".Equals(phraseTypeDropdown.options[phraseTypeDropdown.value].text))
        {
            return ReturnQuestionsBasedOntense(input);
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
    public bool ReturnQuestionsBasedOntense(string input)
    {
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": return IsAValidSimpleQuestion(input, present_simple_questions);
            //case "Past Simple": return IsAValidSimpleQuestion(input, past_simple_simple_questions);
            case "Present Continuous": return IsAValidSimpleQuestion(input, present_continuous_questions);
            //case "Past Continuous": return IsAValidSimpleQuestion(input, past_continuous_simple_questions);
            //case "Future Simple": return IsAValidSimpleQuestion(input, future_simple_questions);
            //case "Present Perfect": return IsAValidSimpleQuestion(input, present_perfect_questions);
            default: Debug.Log("error on UpdateNegationRule"); return false;
        }
    }

    static bool IsAValidSimpleQuestion(string input, HashSet<string> possibleQuestions)
    {
        return possibleQuestions.Contains(input) ? true : false;
    }


    #region FILL QUESTIONS RULES
    private string Return_PresentSimple_Question_Rules()
    {
        return "1.(auxiliary) + (subject) + (frequency adverb) + (base verb) + (object) + (other adverbs)?" + "\nEx.Does she often visit her grandparents?\n\n" +
               "2.(wh- word/How) + (frequency adverb) + (auxiliary) + (subject) + (base verb) + (object) + (other adverbs)?" + "\nHow often do you visit your parents?";
    }
    private string Return_PresentContinuous_Question_Rules()
    {
        return "1.(Wh- word}/(How) + (auxiliary verb (am/are/is)} + (subject} + (frequency adverb) + (base verb + -ing) + (other adverbs)" + "\nEx.What are you doing?\n\n" +
               "2.How (auxiliary) + (subject) + (verb) + (complement)." + "\nHow is she working today?"; 
    }
    private string Return_Past_Simple_Question_Rules()
    {
        return "1.(Wh- word/How) + (did) + (subject) + (base verb) + (object/complement)?" + "\nWhat did you do yesterday?\n\n" +
               "2.(Wh- word) + (auxiliary) + (subject) + (base verb) + (complement)?" + "\nWhy did he leave early?";
    }
    private string Return_Past_Continuous_Question_Rule()
    {
        return "1.(Wh- word/How) + (was/were} + {subject} + {base verb + -ing} + {object/complement}?" + "\nWhat were you doing yesterday evening?\n\n" +
               "2.(auxiliary) + (subject) + (base verb + -ing) + (complement)" + "\nWas he sleeping at that time?";
    }
    private string Return_Future_Simple_Question_Rule()
    {
        return "1.(Wh- word/How) + (will) + (subject) + (base verb) + (object/complement)?" + "\nWhat will you do tomorrow?\n\n" +
               "2.Will + (subject) + (base verb) + (complement)." + "\nWill she come to the meeting?";
    }
    private string Return_Present_Perfect_Question_Rule()
    {
        return "1.(Wh- word/How) + (have/has) + (subject) + (past participle) + (object/complement)?" + "\nWhat have you done today?\n\n";
    }
    #endregion
}