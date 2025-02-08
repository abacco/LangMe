using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
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

    Dictionary<string, string> frasi_originali_e_soluzioni;
    Dictionary<int, Dictionary<string, string>> italianHashMap_a1;

    public int solution_counter = 0; // serve per andare avanti nel dizionario e fare l'update delle frasi soluzione
    int correct_answers = 0; // tiene conto solo delle risposte giuste date

    public bool set_completed;
    
    #endregion

    #region Initialization

    private void Awake()
    {
        GameManager.Instance.LoadData();
        userLifes = GameManager.Instance.userLifes;
        users_lifes_txt.text = userLifes.ToString();
    }

    void Start() // dict initialization
    {
        correct_phrases_counter.text = "00";

        frasi_soluzione = new List<string>();
        frasi_originali = new List<string>();

        frasi_originali_e_soluzioni = new Dictionary<string, string>();  // ne fai 500 e poi prendi a caso?
        frasi_originali_e_soluzioni.Add("0", "0");
        frasi_originali_e_soluzioni.Add("1", "1");
        frasi_originali_e_soluzioni.Add("2", "2");
        frasi_originali_e_soluzioni.Add("3", "3");
        frasi_originali_e_soluzioni.Add("4", "4");
        frasi_originali_e_soluzioni.Add("5", "5");
        frasi_originali_e_soluzioni.Add("6", "6");
        frasi_originali_e_soluzioni.Add("7", "7");
        frasi_originali_e_soluzioni.Add("8", "8");
        frasi_originali_e_soluzioni.Add("9", "9");


        italianHashMap_a1 = new Dictionary<int, Dictionary<string, string>>();
        italianHashMap_a1.Add(1, frasi_originali_e_soluzioni); // identifica il primo esercizio dell'A1


    }
    #endregion

    #region Logic
    private void Update()
    {
    }

    void DisableSubmitButtonWhenInputVoid(string phrase_without_blanks)
    {
        if ("".Equals(phrase_without_blanks) || phrase_without_blanks == null) {
            //StartCoroutine(ShowWarningPanel());
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
            if (inputfield != null)
            {
                string phrase_without_blanks = string.Join(" ", inputfield.text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => x.Trim()));
                if (string.Equals(frasi_soluzione.ElementAt(solution_counter), phrase_without_blanks, StringComparison.OrdinalIgnoreCase))
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
