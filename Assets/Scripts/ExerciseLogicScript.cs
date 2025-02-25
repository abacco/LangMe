using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExerciseLogicScript : MonoBehaviour
{
    #region Instances
    string s;
    [SerializeField] Button submit_answer_btn;
    [SerializeField] Button next_exercise_btn;
    
    [SerializeField] TMP_InputField inputfield;
    [SerializeField] TMP_Text original_phrase;
    [SerializeField] TMP_Text correct_phrases_counter;
    [SerializeField] TMP_Text diffString; // for levenshteinPanel

    int userLifes;
    [SerializeField] TMP_Text users_lifes_txt;
    
    [SerializeField] GameObject wrong_answer_panel;
    [SerializeField] GameObject well_done_panel;
    [SerializeField] GameObject solution_panel;
    [SerializeField] GameObject warning_panel;
    [SerializeField] GameObject levenshteinPanel;
    [SerializeField] GameObject refillHeartsPanel;
    [SerializeField] TMP_Text wrong_text;


    List<string> frasi_soluzione;
    List<string> frasi_originali;

    #region Dutch Region
    Dictionary<string, string> frasi_originali_e_soluzioni_olandese_a1;
    Dictionary<int, Dictionary<string, string>> dutchHashMap_a1;
    #endregion

    public int solution_counter = 0; // serve per andare avanti nel dizionario e fare l'update delle frasi soluzione
    int correct_answers = 0; // tiene conto solo delle risposte giuste date

    public bool set_completed;

    #endregion

    #region Initialization
    // Awake just being called before Start and while loading unity player where Start is called when game is loaded. source: Unity Staff
    private void Awake()
    {
        // load previous data from JSon
        GameManager.Instance.LoadData();
        // set UserLifes and text update
        userLifes = GameManager.Instance.userLifes;
        users_lifes_txt.text = userLifes.ToString();
        // set solutionCounter to display first Original Phrase 
        solution_counter = GameManager.Instance.solutionCounter;
        // set default correct_phrase counter txt
        correct_phrases_counter.text = "00";

        frasi_soluzione = new List<string>();
        frasi_originali = new List<string>();

        if(userLifes <= 1)
        {
            userLifes = 0;
            GameManager.Instance.userLifes = 0;
            users_lifes_txt.text = 0.ToString();
            ShowRefillHeartsPanel();
        }
        UpdateVeryFirstOriginalPhrase();
    }

    void Start() { }

    void PopulateFrasiOriginaliSoluzioni_OlandeseA1()
    {
        frasi_originali_e_soluzioni_olandese_a1 = new Dictionary<string, string>();

        //frasi_originali_e_soluzioni_olandese_a1.Add("Hallo, hoe heet je?", "Hello, what is your name?");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik heet " + GameManager.Instance.username, "My name is " + GameManager.Instance.username);
        //frasi_originali_e_soluzioni_olandese_a1.Add("Waar kom je vandaan?", "Where are you from?");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik kom uit Italië", "I come from Italy");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Hoe gaat het met je? ", "How are you?");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Goed, dank je!", "Good, thank you!");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik woon in Nederland", "I live in the Netherlands");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik werk als softwareontwikkelaar", "I work as a software developer");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik heb een kleine auto", "I have a small car");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Hij woont in een groot huis", "He lives in a big house");

        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik ga naar de supermarkt", "I am going to the supermarket");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Zij drinkt koffie in de ochtend", "She drinks coffee in the morning");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik spreek een beetje Nederlands", "I speak a little Dutch");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Kun je dat herhalen, alsjeblieft?", "Can you repeat that, please?");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Wij eten pizza vanavond", "We are eating pizza tonight");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Jij leest een boek", "You are reading a book");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Hij slaapt om tien uur", "He sleeps at ten o'clock");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Wij gaan morgen naar Amsterdam", "We are going to Amsterdam tomorrow");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik begrijp het niet", "I don’t understand it");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik heb geen geld", "I don’t have money");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Original 20", " Soluzione 20");

        frasi_originali_e_soluzioni_olandese_a1.Add("1", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("2", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("3", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("4", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("5", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("6", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("7", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("8", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("9", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("10", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("11", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("12", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("13", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("14", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("15", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("16", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("17", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("18", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("19", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("20", "1");
        frasi_originali_e_soluzioni_olandese_a1.Add("21", "1");


    }
    void InitializeDutchHashMapA1(List<string> frasi_soluzione, List<string> frasi_originale)
    {
        dutchHashMap_a1 = new Dictionary<int, Dictionary<string, string>>();
        dutchHashMap_a1.Add(1, frasi_originali_e_soluzioni_olandese_a1);
        
        // inizializzazione frasi originali e soluzioni
        foreach (var coppia_frasi in dutchHashMap_a1.Values)
        {
            Debug.Log("------------");
            foreach (var singola_frase in coppia_frasi)
            {
                //Debug.Log("Sono la Frase da tradurre: " + singola_frase.Key);
                //Debug.Log("Sono la Frase soluzione: " + singola_frase.Value);
                frasi_originali.Add(singola_frase.Key);
                frasi_soluzione.Add(singola_frase.Value);
            }
        }
    }
    #endregion
    
    /*
    in base al solution counter, al livello di difficoltà scelto e alla lingua scelta(?)
    devo far vedere la prima frase del set di esercizi da mostrare
    se gli esercizi sono in divisi in blocchettini da 10 frasi ed ho 20 frasi
    -> mostra la prima frase del primo blocchettino e la prima frase del secondo blocchettino
    per tenere traccia del blocchettino da cui devo partire, il solution counter è a multipli di 10
    se GameManager.Instance.solution_counter == 0 -> sono nel PRIMO blocchettino del dizionario bla bla...
    se GameManager.Instance.solution_counter == 10 -> sono nel SECONDO blocchettino del dizionario bla bla...


    esempio:
        base: devo far vedere la prima frase del 1 set A1 di lingua INGLESE
        induzione: devo far vedere la prima frase del 2 set di A1 di lingua INGLESE     
    NOTA BENE:
    -  clicco Home || Chiudo L'app || viteEsaurite 
        -> check se il solutionCounter è un multiplo di 0
            -> se non lo è 
                   -> devo trovare il modo di resettarlo all'ultimo multiplo 
        Esempio
            perdo le vite quando sono alla frase n. 8 -> il solutionCounter DEVE essere 0!
            -> 8 è multiplo di 10? 

            è sempre il multiplo di 10 precedente....
            18 - la differenza tra 18 e 8
            contare il numero di decine in 18
            se è una decina -> allora il solution counter è 10
            se sono due decine -> allora il solution counter è 20

            come conto il numero di decine? 
            es. ho 10
                10 / 10 = 1
                20 / 10 = 2
                25 / 10 = 3.5 -> 3
    */
    public void UpdateVeryFirstOriginalPhrase()
    {
        
        int decine = GameManager.Instance.solutionCounter / 10;
        Debug.Log("Decine attuali " + decine + " & solutionCounter On Start: " + GameManager.Instance.solutionCounter);
        string valore = "";

        int[] indici = { 0, 10, 20 };

        switch (GameManager.Instance.selectedLanguage)
        {
            case "Dutch":  
                switch (GameManager.Instance.selectedDifficulty)
                {
                    case "A1":
                        PopulateFrasiOriginaliSoluzioni_OlandeseA1();
                        InitializeDutchHashMapA1(frasi_soluzione, frasi_originali);
                        List<string> chiavi_richieste = indici
                                                        .Select(index => dutchHashMap_a1[1].ElementAt(index).Key)
                                                        .ToList();
                        // Populate Holland A1 Dict
                        // PopulateFrasiOriginaliSoluzioni_ItalianoA1(frasi_originali_e_soluzioni_italiano_a1);
                        // InitializeItalianHashMapA1(italianHashMap_a1, frasi_soluzione, frasi_originali);
                        switch (decine)
                        {
                            // 0 decine -> mostro la frase chiave in posizione 0 della lista con solo le frasi chiave in posizione di multipli di 10
                            // 0 = "0", 1 (decina) = frase in posizione 10 del DIZIONARIO INTERNO!!!
                            case 0:  valore = chiavi_richieste[0]; original_phrase.text = valore; /*Debug.Log("VALORE: " + valore + " & " + solution_counter);*/ break;
                            case 1:  valore = chiavi_richieste[1]; original_phrase.text = valore; /*Debug.Log("VALORE: " + valore + " & " + solution_counter);*/ break;
                            default: throw new Exception("Error On solutionCounter: ");
                        }
                        break;
                    default: throw new Exception("Error On selectedDifficulty: ");
                }
                break;
            default: throw new Exception("Error On selectedLanguage: ");
        }
    }

    #region Logic
    

    void DisableSubmitButtonWhenInputVoid(string phrase_without_blanks)
    {
        if ("".Equals(phrase_without_blanks) || phrase_without_blanks == null) {
            ShowWarningPanel();
        }
    }

    public void CheckSolution()
    {
        if (userLifes <= 1) // non so perchè ma vedo 1 ed userLifes è 2, vedi più in là
        {
            Debug.Log("Game Over! Refill Hearts Here!");
            userLifes = 0;
            GameManager.Instance.userLifes = 0;
            users_lifes_txt.text = 0.ToString();
            //submit_answer_btn.interactable = false;
            ShowRefillHeartsPanel();
        }
        else { 
            submit_answer_btn.interactable = true;
            CloseRefillHeartsPanel();
        }


        if (correct_answers == 9) // si conta da 0
        {
            // pannello di wellDone
            // rendere Il pulsante NextExercise cliccabile
            next_exercise_btn.interactable = true;
            set_completed = true;
            ShowWellDonePanel();
        }
        // dato che è diviso in blocchi di 10...solution_counter (global)
        try
        {
            if (inputfield != null)
            {
                string phrase_without_blanks = string.Join(" ", inputfield.text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => x.Trim()));
                string solution = string.Join(" ", frasi_soluzione.ElementAt(solution_counter).Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => x.Trim()));

                //Debug.Log("phrase_without_blanks + " + phrase_without_blanks.ToLower());
                //Debug.Log("solution + " + solution.ToLower());


                bool isCorrect = CompareStrings(phrase_without_blanks, solution, out int errorCount, out string diffOutput);
                string[] s = diffOutput.Split("\n"); ;


                if (isCorrect/*string.Equals(solution.ToLower(), phrase_without_blanks.ToLower(), StringComparison.OrdinalIgnoreCase)*/)
                {
                    correct_answers++;
                    //Debug.Log("correct_answers:" + correct_answers);
                    //Debug.Log("soluzione ok - aumento il counter globale");
                    solution_counter++; 
                    // se fai l'esercizio correttamente aumenta il counter
                    //Debug.Log("counter globale ora è:" + solution_counter);
                    if(s != null && s.Length > 0)
                    {
                        if (!s[0].ToLower().Equals(solution.ToLower()))
                        {
                            OpenLevenshteinPanel();
                            diffString.text = s[0] + "\n" + solution;
                        }
                        //diffString.text = s[0] + "\n" + solution;
                    }
                    GameObject.Find("ShowSolutionAdInit").GetComponent<ShowSolutionAd>().LoadAd(); // se la soluzione è corretta, ricarichi l'ad (caso in cui ho premuto ShowSoluzione)
                }
                else
                {
                    DisableSubmitButtonWhenInputVoid(phrase_without_blanks); // se è vuoto lancio il warning 
                    //Debug.Log("Risposta Sbagliata");
                    // far Uscire un alert o un feedback che la risposta è sbagliata
                    StartCoroutine(FadeImage(true));
                    userLifes = --GameManager.Instance.userLifes;
                    if(userLifes <= 0) {
                        userLifes = 0;
                        GameManager.Instance.userLifes = 0;
                        users_lifes_txt.text = 0.ToString();
                    } else
                    {
                        users_lifes_txt.text = userLifes.ToString();
                    }
                    GameManager.Instance.SaveData();
                    GameObject.Find("ShowSolutionAdInit").GetComponent<ShowSolutionAd>().LoadAd();
                }
            }
            // update Original Frase;
            switch (solution_counter)
            {
                case 0: correct_phrases_counter.text = "00"; UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 1: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 2: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 3: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 4: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 5: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 6: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 7: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 8: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 9: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 10: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                default: SetCorrectPhraseCounter(correct_answers.ToString()); original_phrase.text = "Aumenta i case nello switch!"; break;
            }
        }
        catch (Exception ex)
        {
            Debug.Log("Eccezione: " + ex.ToString());
            Debug.Log("Catched!? - diminuito counter globale per gestire l'eccezione");
            solution_counter--; // yesssss
        }
    }
    public void NextExercise()
    {
        // resetta tutto tranne solution counter ->
        // solution Counter deve essere salvato nei data!!! Sennò ogni volte parte tutto da zero!!!!
        correct_answers = 0;
        inputfield.text = string.Empty;
        GameManager.Instance.solutionCounter = solution_counter;
        GameManager.Instance.SaveData();
        UpdateMainUI(solution_counter, correct_answers.ToString());
    }

    static bool CompareStrings(string input, string solution, out int errorCount, out string diffOutput)
    {
        // 1. Normalizziamo le stringhe
        string normalizedInput = input;//NormalizeString(input);
        string normalizedSolution = solution;//NormalizeString(solution);

        // 2. Calcoliamo la distanza di Levenshtein e le differenze
        errorCount = LevenshteinDistanceWithDiff(normalizedInput, normalizedSolution, out diffOutput);
       

        // 3. Decisione basata sugli errori
        if (errorCount == 0)
        {
            return true; // Perfetto match
        }
        else if (errorCount <= 2) // Permettiamo massimo 2 errori
        {
            Debug.Log($"⚠️ Piccoli errori rilevati: {errorCount}");
            Debug.Log("WHAAAAAAAAAAAAAT " + diffOutput);
            return true; // Accettiamo comunque
        }
        else
        {
            return false; // Troppi errori
        }
    }

    static string NormalizeString(string str)
    {
        str = str.ToLower(); // Ignoriamo maiuscole/minuscole
        str = Regex.Replace(str, @"[^\w\s]", ""); // Rimuoviamo punteggiatura
        str = Regex.Replace(str, @"\s+", " ").Trim(); // Rimuoviamo spazi extra
        return str;
    }

    static int LevenshteinDistanceWithDiff(string s1, string s2, out string diffOutput)
    {
        int len1 = s1.Length;
        int len2 = s2.Length;
        int[,] dp = new int[len1 + 1, len2 + 1];

        for (int i = 0; i <= len1; i++) dp[i, 0] = i;
        for (int j = 0; j <= len2; j++) dp[0, j] = j;

        for (int i = 1; i <= len1; i++)
        {
            for (int j = 1; j <= len2; j++)
            {
                int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                dp[i, j] = Math.Min(
                    Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                    dp[i - 1, j - 1] + cost
                );
            }
        }

        // Ricostruzione delle differenze
        int x = len1, y = len2;
        string highlightedInput = "";
        string highlightedSolution = "";

        while (x > 0 || y > 0)
        {
            if (x > 0 && dp[x, y] == dp[x - 1, y] + 1) // Cancellazione
            {
                highlightedInput = $"[{s1[x - 1]}]" + highlightedInput;
                highlightedSolution = " " + highlightedSolution;
                x--;
            }
            else if (y > 0 && dp[x, y] == dp[x, y - 1] + 1) // Inserimento
            {
                highlightedSolution = $"[{s2[y - 1]}]" + highlightedSolution;
                highlightedInput = " " + highlightedInput;
                y--;
            }
            else
            {
                highlightedInput = s1[x - 1] + highlightedInput;
                highlightedSolution = s2[y - 1] + highlightedSolution;
                x--;
                y--;
            }
        }

        diffOutput = $"{highlightedInput}\n{highlightedSolution}";
        return dp[len1, len2];
    }

    void UpdateMainUI(int solution_counter, string correct_answers)
    {
        SetOriginalPhrase(solution_counter); ResetInputField(); SetCorrectPhraseCounter(correct_answers.ToString());
    }
    void SetOriginalPhrase(int solution_counter) { original_phrase.text = frasi_originali.ElementAt(solution_counter); }
    void ResetInputField() { inputfield.text = ""; }
    // 1/10, 2/10, ... 1,2 è il counter bro
    void SetCorrectPhraseCounter(string correct_answers_text) {

        if (correct_answers < 10) {
            correct_phrases_counter.text = "0" + correct_answers_text.ToString();
        } else
        {
            correct_phrases_counter.text = correct_answers.ToString();
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                wrong_answer_panel.GetComponent<Image>().color = new Color(1, 1, 1, i);
                wrong_text.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                wrong_answer_panel.GetComponent<Image>().color = new Color(1, 1, 1, i);
                wrong_text.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }

    private void ShowWarningPanel()
    {
        warning_panel.SetActive(true);
    }
    public void CloseWarningPanel()
    {
        warning_panel.SetActive(false);
    }

    private void ShowWellDonePanel()
    {
        well_done_panel.SetActive(true);
    }

    public void ShowRefillHeartsPanel()
    {
        refillHeartsPanel.SetActive(true);
    }

    public void CloseRefillHeartsPanel()
    {
        refillHeartsPanel.SetActive(false);
    }

    public void CloseWellDonePanel()
    {
        well_done_panel.SetActive(false);
        GameManager.Instance.solutionCounter = solution_counter;
        GameManager.Instance.SaveData(); // ?
        SceneManager.LoadScene("10 - Progress");
    }

    public void CloseSolutionPanel()
    {
        solution_panel.SetActive(false);
    }

    public void OpenLevenshteinPanel()
    {
        levenshteinPanel.SetActive(true);
    }

    public void CloseLevenshteinPanel()
    {
        levenshteinPanel.SetActive(false);
    }

    public string ShowSolution()
    {
        Debug.Log("SOLUZIONEEE: " + frasi_soluzione[solution_counter]); // funziona!!!!! METTI l'ad
        return frasi_soluzione[solution_counter];
    }

    public void ReturnHome()
    {
        // quando clicco su home
        // a parte il tornare nella home
        // devo resettare il solution_counter con il valore che sta salvato nel GameData
        // esempio: ho completato il primo esercizio fatto da 10 frasi 
        // sono alla 13esima frase
        // torno alla home
        // solution counter al load della exercise scene è = 10
    }
    #endregion

    #region Utils
    // dict example
    public void DictTutorial()
    {
        // Creating a HashMap with keys of type string and values of type int
        Dictionary<string, int> ageMap = new Dictionary<string, int>();
        ageMap.Add("Alice", 25);
        ageMap.Add("Bob", 30);
        int aliceAge = ageMap["Alice"]; // Retrieves the value associated with the key "Alice"
        if (ageMap.ContainsKey("Bob"))
        {
            // Perform operations when "Bob" exists in the HashMap
        }
        ageMap.Remove("Alice"); // Removes the entry with the key "Alice"
        foreach (var pair in ageMap)
        {
            Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
        }


        //string frase_soluzione = "";

        //foreach (var coppia_frasi in italianHashMap_a1.Values)
        //{
        //    Debug.Log("------------");
        //    foreach (var singola_frase in coppia_frasi)
        //    {
        //        Debug.Log("Sono la Frase da tradurre: " + singola_frase.Key);
        //        Debug.Log("Sono la Frase soluzione: " + singola_frase.Value);
        //        frase_soluzione = singola_frase.Value;
        //    }
        //}
        // mostro la frase da tradurre
        // input immesso deve essere uguale alla soluzione
        //string input = "Frase Originale";
        //if (input.Equals(frase_soluzione))
        //{
        //    Debug.Log("Esercizio Ok");
        //}
        //else { Debug.Log("numVite--"); }
    }
    #endregion
}
