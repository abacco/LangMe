using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseLogicScript : MonoBehaviour
{
    #region Instances
    [SerializeField] Button submit_answer_btn;
    [SerializeField] Button next_exercise_btn;
    
    [SerializeField] TMP_InputField inputfield;
    [SerializeField] TMP_Text original_phrase;
    [SerializeField] TMP_Text correct_phrases_counter;

    int userLifes;
    [SerializeField] TMP_Text users_lifes_txt;
    
    [SerializeField] GameObject wrong_answer_panel;
    [SerializeField] GameObject well_done_panel;
    [SerializeField] GameObject warning_panel;
    [SerializeField] TMP_Text wrong_text;


    List<string> frasi_soluzione;
    List<string> frasi_originali;

    Dictionary<string, string> frasi_originali_e_soluzioni_italiano_a1;
    Dictionary<int, Dictionary<string, string>> italianHashMap_a1;

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

        italianHashMap_a1 = new Dictionary<int, Dictionary<string, string>>();

        // in base alle robe salvate su JSon -> inizializzo le robe relative -> DA SPOSTARE NELLO SWITCH SOTTO!!!!!!!
        PopulateFrasiOriginaliSoluzioni_ItalianoA1();
        InitializeItalianHashMapA1(frasi_soluzione, frasi_originali);
        // -------------------

        UpdateVeryFirstOriginalPhrase();
    }

    void Start() { }

    void PopulateFrasiOriginaliSoluzioni_ItalianoA1()
    {
        frasi_originali_e_soluzioni_italiano_a1 = new Dictionary<string, string>();

        frasi_originali_e_soluzioni_italiano_a1.Add("Original 0", " Soluzione 0");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 1", " Soluzione 1");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 2", " Soluzione 2");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 3", " Soluzione 3");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 4", " Soluzione 4");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 5", " Soluzione 5");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 6", " Soluzione 6");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 7", " Soluzione 7");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 8", " Soluzione 8");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 9", " Soluzione 9");

        frasi_originali_e_soluzioni_italiano_a1.Add("Original 10", " Soluzione 10");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 11", " Soluzione 11");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 12", " Soluzione 12");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 13", " Soluzione 13");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 14", " Soluzione 14");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 15", " Soluzione 15");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 16", " Soluzione 16");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 17", " Soluzione 17");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 18", " Soluzione 18");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 19", " Soluzione 19");
        frasi_originali_e_soluzioni_italiano_a1.Add("Original 20", " Soluzione 20");
    }
    void InitializeItalianHashMapA1(List<string> frasi_soluzione, List<string> frasi_originale)
    {
        italianHashMap_a1 = new Dictionary<int, Dictionary<string, string>>();
        italianHashMap_a1.Add(1, frasi_originali_e_soluzioni_italiano_a1);
        
        // inizializzazione frasi originali e soluzioni
        foreach (var coppia_frasi in italianHashMap_a1.Values)
        {
            Debug.Log("------------");
            foreach (var singola_frase in coppia_frasi)
            {
                Debug.Log("Sono la Frase da tradurre: " + singola_frase.Key);
                Debug.Log("Sono la Frase soluzione: " + singola_frase.Value);
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
        List<string> chiavi_richieste = indici
            .Select(index => italianHashMap_a1[1].ElementAt(index).Key)
            .ToList();

        switch (GameManager.Instance.selectedLanguage)
        {
            case "Holland":  
                switch (GameManager.Instance.selectedDifficulty)
                {
                    case "A1":
                        // Populate Holland A1 Dict
                        // PopulateFrasiOriginaliSoluzioni_ItalianoA1(frasi_originali_e_soluzioni_italiano_a1);
                        // InitializeItalianHashMapA1(italianHashMap_a1, frasi_soluzione, frasi_originali);
                        switch (decine)
                        {
                            // 0 decine -> mostro la frase chiave in posizione 0 della lista con solo le frasi chiave in posizione di multipli di 10
                            // 0 = "0", 1 (decina) = frase in posizione 10 del DIZIONARIO INTERNO!!!
                            case 0:  valore = chiavi_richieste[0]; original_phrase.text = valore; Debug.Log("VALORE: " + valore + " & " + solution_counter); break;
                            case 1:  valore = chiavi_richieste[1]; original_phrase.text = valore; Debug.Log("VALORE: " + valore + " & " + solution_counter); break;
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

                Debug.Log("phrase_without_blanks + " + phrase_without_blanks.ToLower());
                Debug.Log("solution + " + solution.ToLower());
                if (phrase_without_blanks.ToLower().Equals(solution.ToLower())) {  }

                if (string.Equals(solution.ToLower(), phrase_without_blanks.ToLower(), StringComparison.OrdinalIgnoreCase))
                {
                    correct_answers++;
                    Debug.Log("correct_answers:" + correct_answers);
                    Debug.Log("soluzione ok - aumento il counter globale");
                    solution_counter++; // se fai l'esercizio correttamente aumenta il counter
                    Debug.Log("counter globale ora è:" + solution_counter);
                }
                else
                {
                    DisableSubmitButtonWhenInputVoid(phrase_without_blanks); // se è vuoto lancio il warning 
                    Debug.Log("Risposta Sbagliata");
                    // far Uscire un alert o un feedback che la risposta è sbagliata
                    StartCoroutine(FadeImage(true));
                    userLifes = --GameManager.Instance.userLifes;
                    users_lifes_txt.text = userLifes.ToString();
                    GameManager.Instance.SaveData();
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
                default: SetCorrectPhraseCounter(correct_answers.ToString()); original_phrase.text = "Error!"; break; // not working
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

    public void CloseWellDonePanel()
    {
        well_done_panel.SetActive(false);
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
