using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameData;
using static Unity.VisualScripting.Icons;

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

    public int userLifes;
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
    Dictionary<string, string> frasi_originali_e_soluzioni_olandese_a2;
    Dictionary<int, Dictionary<string, string>> dutchHashMap_a1;
    Dictionary<int, Dictionary<string, string>> dutchHashMap_a2;
    #endregion

    public int solution_counter = 0; // serve per andare avanti nel dizionario e fare l'update delle frasi soluzione
    int correct_answers = 0; // tiene conto solo delle risposte giuste date
    public bool set_completed;


    int how_many_times_solution_clicked = 0;
    int lostStar = 0;
    int earnedStar = 3;

    [SerializeField] Image star1_img;
    [SerializeField] Image star2_img;
    [SerializeField] Image star3_img;

    int decine;
    GameData gameData;
    private LanguageData languageData;
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

        if(userLifes <= 0)
        {
            userLifes = 0;
            GameManager.Instance.userLifes = 0;
            users_lifes_txt.text = 0.ToString();
            ShowRefillHeartsPanel();
        }

        gameData = new GameData();

        //GameData.NodeData nodeData = new GameData.NodeData();
        //nodeData.Stars = -1;
        //nodeData.NodeName = "Prova";

        //GameData.DifficultyData difficultyData = new GameData.DifficultyData();


        //GameData.LanguageData languageData = 
        //    new GameData.LanguageData("ProvaLinguaggio", new GameData.DifficultyData("ProvaDifficoltà", new GameData.NodeData("ProvaNodo", 1)));


        GameManager.Instance.SaveData();

        UpdateVeryFirstOriginalPhrase();
    }

    void InitializeDutchHashMap(List<string> frasi_soluzione, List<string> frasi_originale, Dictionary<int, Dictionary<string, string>> geenricHashMap, Dictionary<string, string> genericDict)
    {

        // inizializzazione frasi originali e soluzioni
        foreach (var coppia_frasi in geenricHashMap.Values)
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
        /*int */decine = GameManager.Instance.solutionCounter / 10;
        Debug.Log("Decine attuali " + decine + " & solutionCounter On Start: " + GameManager.Instance.solutionCounter);
        string valore = "";

        int[] indici = { 0, 10, 20 };

        switch (GameManager.Instance.selectedLanguage)
        {
            case "Dutch":  
                switch (GameManager.Instance.selectedDifficulty)
                {
                    case "A1":
                        InitializeDutchHashMap(frasi_soluzione, frasi_originali, DutchDicts.DutchHashMap_a1, DutchDicts.Frasi_originali_e_soluzioni_olandese_a1);
                        List<string> chiavi_richieste = indici.Select(index => DutchDicts.DutchHashMap_a1[1].ElementAt(index).Key).ToList();



                        AdjustSolutionCounter(decine, valore, chiavi_richieste);
                       
                        break;
                    case "A2":
                        InitializeDutchHashMap(frasi_soluzione, frasi_originali, DutchDicts.DutchHashMap_a2 ,DutchDicts.Frasi_originali_e_soluzioni_olandese_a2);
                        List<string> chiavi_richieste2 = indici.Select(index => DutchDicts.DutchHashMap_a2[1].ElementAt(index).Key).ToList();
                        AdjustSolutionCounter(decine, valore, chiavi_richieste2);
                        break;
                    default: throw new Exception("Error On selectedDifficulty: ");
                }
                break;
            default: throw new Exception("Error On selectedLanguage: ");
        }
    }

    #region Logic
    
    public void AdjustSolutionCounter(int decine, string valore, List<string> chiavi_richieste)
    {
        // questa è la logica del solution_counter < milestone
        // es. faccio 8 frasi su 10 e NON HO completato un set da 10
        // devo ripartire da 0
        // es. faccio 8 frasi su 10 e HO completato UN set da 10
        // devo ripartire da 10 ---- SE CAPIII ?!?!
        // QUINDI SE PREVEDO 10 SET DA 10, DEVO METTERE CASE FINO A 10 PERCHè HO 10 DECINE, SE CAPIIII ?!?!
        switch (decine)
        {
            // 0 decine -> mostro la frase chiave in posizione 0 della lista con solo le frasi chiave in posizione di multipli di 10
            // 0 = "0", 1 (decina) = frase in posizione 10 del DIZIONARIO INTERNO!!!
            case 0: valore = chiavi_richieste[0]; original_phrase.text = valore; /*Debug.Log("VALORE: " + valore + " & " + solution_counter);*/ break;
            case 1: valore = chiavi_richieste[1]; original_phrase.text = valore; /*Debug.Log("VALORE: " + valore + " & " + solution_counter);*/ break;
            case 2: valore = chiavi_richieste[2]; original_phrase.text = valore; /*Debug.Log("VALORE: " + valore + " & " + solution_counter);*/ break;
            default: throw new Exception("Error On solutionCounter: ");
        }
    }
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
                    if (correct_answers == 3) {
                        if (how_many_times_solution_clicked == 3)
                        {
                            earnedStar = 3 - lostStar;
                            Debug.Log("earnedStar: " + earnedStar);
                        }
                    }
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
                case 11: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 12: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 13: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 14: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 15: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 16: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 17: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 18: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 19: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 20: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
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
        Debug.Log("earnedStar: " + earnedStar);
        // trova il modo di dire che stavi facendo il primo set da 10 dell'a1, o il 3rzo dell'a2 etc...
        // provo in base alle decine, decine 0, nessuno
        // decine = 1, al primo nodo del linguaggio detectato e difficoltà detectata devo mettere le earnedStar

        switch (earnedStar) // nella versione con UI seria, al posto di cambiare colore, appaiono semplicemente (tipo scale from 0 to 1)
        {
            case 0:
                star1_img.color = Color.white;
                star2_img.color = Color.white;
                star3_img.color = Color.white;
                // qua devo salvare il fatto che 
                // per selectedLanguage
                // per selectedDifficulty
                // per n. decine
                // tengo 0 star
                // dutch,
                // a1
                // nodi
                // dizionario<lingua, dizionario<difficoltà, dizionario<nodo, earnedStar>>>

                break;
            case 1:
                star1_img.color = Color.yellow;
                star2_img.color = Color.white;
                star3_img.color = Color.white;

                break;
            case 2:
                star1_img.color = Color.yellow;
                star2_img.color = Color.yellow;
                star3_img.color = Color.white;

                break;
            case 3:
                star1_img.color = Color.yellow;
                star2_img.color = Color.yellow;
                star3_img.color = Color.yellow;

                languageData = 
                    new GameData.LanguageData(GameManager.Instance.selectedLanguage, 
                    new GameData.DifficultyData(GameManager.Instance.selectedDifficulty, 
                    new GameData.NodeData("", 3)));
                
                GameManager.Instance.LanguageDataStars = languageData;
                GameManager.Instance.SaveData();
                break;
        }
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
        StarSystemLogic(); // nello script dell'ad era un casino perchè ad esempio la seconda volta che clicco andava diretto a 3 comunque roba di ciclo di vita che non ho capito bene ancora
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

    public void StarSystemLogic()
    {
        how_many_times_solution_clicked++;
        Debug.Log("Star System - how_many_times_solution_clicked: " + how_many_times_solution_clicked);
        if (how_many_times_solution_clicked == 3) // conti da 0 bro
        {
            how_many_times_solution_clicked = 0;
            lostStar++;
            Debug.Log("Star System - lostStar: " + lostStar);

            if (lostStar == 1 || lostStar == 2 || lostStar == 3)
            {
                earnedStar = 3 - lostStar;
                Debug.Log("Star System - earnedStar: " + earnedStar);
            }
        }
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
