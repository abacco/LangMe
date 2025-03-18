using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameData;

public class ExerciseLogicScript : MonoBehaviour
{
    #region Instances
    string s;
    [SerializeField] Button submit_answer_btn;
    [SerializeField] Button next_exercise_btn;
    
    [SerializeField] InputField inputfield;
    [SerializeField] Text original_phrase;
    [SerializeField] Text correct_phrases_counter;
    [SerializeField] Text diffString; // for levenshteinPanel

    public int userLifes;
    [SerializeField] Text users_lifes_txt;
    
    [SerializeField] GameObject wrong_answer_panel;
    [SerializeField] GameObject well_done_panel;
    [SerializeField] GameObject solution_panel;
    [SerializeField] GameObject warning_panel;
    [SerializeField] GameObject levenshteinPanel;
    [SerializeField] GameObject refillHeartsPanel;
    [SerializeField] GameObject checkHeartsPanel;
    [SerializeField] GameObject congrats_panel;

    [SerializeField] GameObject countdownPanel;
    [SerializeField] TMP_Text wrong_text;


    List<string> frasi_soluzione;
    List<string> frasi_originali;

    public int solution_counter = 0; // serve per andare avanti nel dizionario e fare l'update delle frasi soluzione
    int correct_answers = 0; // tiene conto solo delle risposte giuste date
    public bool set_completed;


    int how_many_times_solution_clicked = 0;
    int lostStar = 0;
    int earnedStar = 3;

    [SerializeField] Image star1_img; // refactor
    [SerializeField] Image star2_img;
    [SerializeField] Image star3_img;

    int decine;
    GameData gameData;
    ShowSolutionAd showSolutionAd;
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
        if(GameManager.Instance.ready_for_test)
        {
            solution_counter = new System.Random().Next(0, 99);
            if(userLifes == 0)
            {
                checkHeartsPanel.SetActive(true);
            }
        } else
        {
            solution_counter = GameManager.Instance.solutionCounter;
        }
        // set default correct_phrase counter txt
        if (correct_phrases_counter != null)
        {
            correct_phrases_counter.text = "00";
        }

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
        GameManager.Instance.SaveData();
        try
        {
            showSolutionAd = GameObject.Find("ShowSolutionAdInit").GetComponent<ShowSolutionAd>();
        } catch (Exception ex)
        {
            Debug.LogWarning("No need of showSolutionAd here ex:" + ex.Message);
        }
        UpdateVeryFirstOriginalPhrase();
    }
    void InitializeLanguageHashMap(List<string> frasiSoluzione, List<string> frasiOriginale,
                               Dictionary<int, Dictionary<string, string>> genericHashMap,
                               Dictionary<string, string> genericDict)
    {
        foreach (var coppiaFrasi in genericHashMap.Values)
        {
            Debug.Log("------------");
            foreach (var singolaFrase in coppiaFrasi)
            {
                frasiOriginale.Add(singolaFrase.Key);
                frasiSoluzione.Add(singolaFrase.Value);
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
        int decine;
        if (!GameManager.Instance.ready_for_test)
        {
            decine = GameManager.Instance.solutionCounter / 10;
        }
        else
        {
            decine = solution_counter / 10;
        }

        Debug.Log($"Decine attuali {decine} & solutionCounter On Start: {GameManager.Instance.solutionCounter}");

        Dictionary<string, (Dictionary<int, Dictionary<string, string>> hashMap, Dictionary<string, string> dict)> languageDictionaries =
            new Dictionary<string, (Dictionary<int, Dictionary<string, string>>, Dictionary<string, string>)>
            {
            { "Dutch_A1", (DutchDicts.DutchHashMap_a1, DutchDicts.Frasi_originali_e_soluzioni_olandese_a1) },
            { "Dutch_A2", (DutchDicts.DutchHashMap_a2, DutchDicts.Frasi_originali_e_soluzioni_olandese_a2) },
            { "Dutch_B1", (DutchDicts.DutchHashMap_b1, DutchDicts.Frasi_originali_e_soluzioni_olandese_b1) },
            { "Dutch_B2", (DutchDicts.DutchHashMap_b2, DutchDicts.Frasi_originali_e_soluzioni_olandese_b2) },
            { "Dutch_C1", (DutchDicts.DutchHashMap_c1, DutchDicts.Frasi_originali_e_soluzioni_olandese_c1) },
            { "Dutch_C2", (DutchDicts.DutchHashMap_c2, DutchDicts.Frasi_originali_e_soluzioni_olandese_c2) },
            };

        string key = $"{GameManager.Instance.selectedLanguage}_{GameManager.Instance.selectedDifficulty}";

        if (!languageDictionaries.TryGetValue(key, out var selectedDicts))
            throw new Exception("Error On selectedLanguage or selectedDifficulty");

        InitializeLanguageHashMap(frasi_soluzione, frasi_originali, selectedDicts.hashMap, selectedDicts.dict);

        List<int> indices = new List<int> { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        List<string> chiaviRichieste = indices
            .Select(index => selectedDicts.hashMap[1].ElementAt(index).Key)
            .ToList();

        AdjustSolutionCounter(decine, chiaviRichieste);
    }
    #region Logic


    public void AdjustSolutionCounter(int decine, List<string> chiaviRichieste)
    {
        if (decine < 0 || decine >= chiaviRichieste.Count)
            throw new Exception("Error On solutionCounter");

        original_phrase.text = chiaviRichieste[decine];
    }
    void DisableSubmitButtonWhenInputVoid(string phrase_without_blanks)
    {
        if ("".Equals(phrase_without_blanks) || phrase_without_blanks == null) {
            ShowWarningPanel();
        }
    }

    public void CheckSolution()
    {
        HandleLives();
        HandleCorrectAnswers();

        if (inputfield == null || GameManager.Instance.userLifes <= 0) return;

        string phraseWithoutBlanks = NormalizeString(inputfield.text);
        string solution = NormalizeString(frasi_soluzione.ElementAt(solution_counter));

        bool isCorrect = CompareStrings(phraseWithoutBlanks, solution, out int errorCount, out string diffOutput);

        if (isCorrect)
        {
            HandleCorrectResponse(diffOutput, solution);
        }
        else
        {
            HandleIncorrectResponse(phraseWithoutBlanks);
        }

        UpdateMainUI(solution_counter, correct_answers.ToString());
    }

    private void HandleLives()
    {
        if(userLifes <= 1 && GameManager.Instance.ready_for_test)
        {
            ShowWarningPanel();
        }
        if (userLifes <= 1)
        {
            Debug.Log("Game Over! Refill Hearts Here!");
            userLifes = GameManager.Instance.userLifes = 0;
            users_lifes_txt.text = "0";
            ShowRefillHeartsPanel();
            return;
        }
        submit_answer_btn.interactable = true;
        CloseRefillHeartsPanel();
    }

    private void HandleCorrectAnswers()
    {
        if(correct_answers == 9 && GameManager.Instance.ready_for_test)
        {
            Debug.Log("Test Passed!"); // ok
            congrats_panel.SetActive(true);
        }
        if (correct_answers == 9)
        {
            try
            {
                next_exercise_btn.interactable = true;
                set_completed = true;
                ShowWellDonePanel();
            }
            catch (Exception ex)
            {
                Debug.LogWarning("HandleCorrectAnswers method" + ex);
            }
        }
    }

    private string NormalizeString(string input)
    {
        return string.Join(" ", input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                                     .Select(x => x.Trim()));
    }

    private void HandleCorrectResponse(string diffOutput, string solution)
    {
        correct_answers++;

        if (correct_answers == 3 && how_many_times_solution_clicked == 3)
        {
            // mostrare pannello con piccola animazione che dà feedback di una star in meno
            earnedStar = 3 - lostStar;
            Debug.Log("earnedStar: " + earnedStar);
        }

        solution_counter++;
        if(solution_counter == 100) {
            GameManager.Instance.singleProficiencyTracker.key = GameManager.Instance.selectedLanguage + "_" + GameManager.Instance.selectedDifficulty;
            GameManager.Instance.singleProficiencyTracker.isCompleted = true;
        }

        if (!string.IsNullOrEmpty(diffOutput))
        {
            string[] differences = diffOutput.Split("\n");
            if (differences.Length > 0 && !differences[0].ToLower().Equals(solution.ToLower()))
            {
                OpenLevenshteinPanel();
                if(diffString != null)
                {
                    diffString.text = differences[0] + "\n" + solution;
                }
            }
        }

        ShowSolutionAd();
    }

    private void HandleIncorrectResponse(string phraseWithoutBlanks)
    {
        DisableSubmitButtonWhenInputVoid(phraseWithoutBlanks);

        StartCoroutine(FadeImage(true));
        userLifes = --GameManager.Instance.userLifes;

        if (userLifes <= 0)
        {
            userLifes = GameManager.Instance.userLifes = 0;
            users_lifes_txt.text = "0";
        }
        else
        {
            users_lifes_txt.text = userLifes.ToString();
        }

        GameManager.Instance.SaveData();
        ShowSolutionAd();
    }

    private void ShowSolutionAd()
    {
        showSolutionAd?.LoadAd();
    }
    private void UpdateMainUI(int solution_counter, string correct_answers)
    {
        SetOriginalPhrase(solution_counter);
        ResetInputField();
        SetCorrectPhraseCounter(correct_answers);
    }
    private void SetOriginalPhrase(int solution_counter)
    {
        try
        {
            original_phrase.text = frasi_originali.ElementAt(solution_counter);
        } catch (Exception e){
            // Mostra un pannello che inviti a cambiare difficoltà
            congrats_panel.SetActive(true);
            GameManager.Instance.solutionCounter = 0;
            Debug.LogError("Aumenta le frasi nel dizionario: " + GameManager.Instance.selectedLanguage + " " + GameManager.Instance.selectedDifficulty);
        } 

    }

    public void CloseCongratsPanel()
    {
        congrats_panel.SetActive(false);
    }

    private void ResetInputField()
    {
        inputfield.text = "";
    }

    private void SetCorrectPhraseCounter(string correct_answers_text)
    {
        try
        {
            correct_phrases_counter.text = correct_answers < 10 ? "0" + correct_answers_text : correct_answers_text;
        }
        catch (Exception e)
        {
            Debug.LogWarning("SetCorrectPhraseCounter method" + e);
        }
    }
    public void NextExercise()
    {
        // resetta tutto tranne solution counter ->
        // solution Counter deve essere salvato nei data!!! Sennò ogni volte parte tutto da zero!!!!
        // devi disabilitare il pulsante di next
        well_done_panel.SetActive(false);
        correct_answers = 0;
        inputfield.text = string.Empty;
        GameManager.Instance.solutionCounter = solution_counter;
        GameManager.Instance.SaveData();
        next_exercise_btn.interactable = false;
        UpdateMainUI(solution_counter, correct_answers.ToString());
    }

    static bool CompareStrings(string input, string solution, out int errorCount, out string diffOutput)
    {
        // 1. Normalizziamo le stringhe
        string normalizedInput = input;
        string normalizedSolution = solution;

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

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                try
                {
                    wrong_answer_panel.GetComponent<Image>().color = new Color(1, 1, 1, i);
                    wrong_text.color = new Color(0, 0, 0, i);

                } catch (Exception e)
                {
                    Debug.LogWarning(e);
                }
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
                try
                {
                    wrong_answer_panel.GetComponent<Image>().color = new Color(1, 1, 1, i);
                    wrong_text.color = new Color(1, 1, 1, i);
                }
                catch (Exception e)
                {
                    Debug.LogWarning(e);
                }
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
        Debug.Log("earnedStar: " + this.earnedStar);

        switch (earnedStar) // nella versione con UI seria, al posto di cambiare colore, appaiono semplicemente (tipo scale from 0 to 1)
        {
            // col white si vede la stella gialla
            case 0:
                star1_img.color = Color.black;
                star2_img.color = Color.black;
                star3_img.color = Color.black;

                SaveStarSystemInfo(0);
                break;
            case 1:
                star1_img.color = Color.white;
                star2_img.color = Color.black;
                star3_img.color = Color.black;

                SaveStarSystemInfo(1);
                break;
            case 2:
                star1_img.color = Color.white;
                star2_img.color = Color.white;
                star3_img.color = Color.black;

                SaveStarSystemInfo(2);
                break;
            case 3:
                star1_img.color = Color.white;
                star2_img.color = Color.white;
                star3_img.color = Color.white;

                SaveStarSystemInfo(3);
                break;
        }
    }

    public void SaveStarSystemInfo(int earnedStars)
    {
        // save here max star for user
        GameManager.Instance.totalStarsEarned += earnedStar;
        languageData =
        new GameData.LanguageData(GameManager.Instance.selectedLanguage,
        new GameData.DifficultyData(GameManager.Instance.selectedDifficulty,
        new GameData.NodeData("", earnedStars)));

        GameManager.Instance.LanguageDataStars = languageData;
        GameManager.Instance.SaveData();
    }

    public void ShowRefillHeartsPanel()
    {
        if(refillHeartsPanel != null)
        {
            refillHeartsPanel.SetActive(true);
        }
    }

    public void CloseRefillHeartsPanel()
    {
        if(refillHeartsPanel != null)
        {
            refillHeartsPanel.SetActive(false);
        }
    }

    public void CloseWellDonePanel()
    {
        if(well_done_panel != null)
        {
            well_done_panel.SetActive(false);
        }
        GameManager.Instance.solutionCounter = solution_counter;
        GameManager.Instance.SaveData(); // ?
        SceneManager.LoadScene("10 - Progress");
    }

    public void CloseSolutionPanel()
    {
        StarSystemLogic(); // nello script dell'ad era un casino perchè ad esempio la seconda volta che clicco andava diretto a 3 comunque roba di ciclo di vita che non ho capito bene ancora
        if(solution_panel != null)
        {
            solution_panel.SetActive(false);
        }
    }

    public void OpenLevenshteinPanel()
    {
        if(levenshteinPanel != null)
        {
            levenshteinPanel.SetActive(true);
        }
    }

    public void CloseLevenshteinPanel()
    {
        if(levenshteinPanel != null)
        {
            levenshteinPanel.SetActive(false);
        }
    }

    public string ShowSolution()
    {
        if(frasi_soluzione != null)
        {
            Debug.Log("SOLUZIONEEE: " + frasi_soluzione[solution_counter]); // funziona!!!!! METTI l'ad
            return frasi_soluzione[solution_counter];
        }
        else
        {
            return "";
        }
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


    public TMP_Text timerText; // UI Text per mostrare il countdown
    private int totalTime = 180; // Tempo iniziale in secondi (3 minuti)
    private bool isCounting = false;
    public GameObject testCompletedPanel;

    private void Start()
    {
        if (GameManager.Instance.ready_for_test) // FAI PROPRIO NA SCENA CON UNA LOGICA SUA SENNò SPUTTANI TUTTO GIà HAI PROVATO FIDATI NUN PERD TIEMP
        {
            StartCountdown();
            // annullare tutte le logiche dell'eserciziario normale
            // annullare i progress
            // se resetti il sol counter si resetta anche per le scene normali - risolto con l'old
        }
    }

    public void StartCountdown()
    {
        if (!isCounting)
        {
            isCounting = true;
            countdownPanel.SetActive(true);
            StartCoroutine(UpdateCountdown());
        }
    }

    IEnumerator UpdateCountdown()
    {
        while (totalTime > 0)
        {
            int minutes = totalTime / 60;
            int seconds = totalTime % 60;
            timerText.text = string.Format("{0}:{1:00}", minutes, seconds); // Formato MM:SS

            if(this.solution_counter == 10)
            {
                testCompletedPanel.SetActive(true);
                GameManager.Instance.userLifes = 10;
            }
            yield return new WaitForSeconds(1f); // Aspetta 1 secondo
            totalTime--; // Riduci il tempo
        }

        // Quando il timer arriva a 0
        timerText.text = "0:00";
        isCounting = false;
        countdownPanel.SetActive(false);
        GameManager.Instance.ready_for_test = false;
        GameManager.Instance.SaveData();
    }

    public void CloseTestCompletedPanel()
    {
        SceneManager.LoadScene("7 - Home");
    }
}
