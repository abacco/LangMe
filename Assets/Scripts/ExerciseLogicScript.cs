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
    
    [SerializeField] TMP_InputField inputfield;
    [SerializeField] TMP_Text original_phrase;
    [SerializeField] TMP_Text correct_phrases_counter;
    
    [SerializeField] GameObject wrong_answer_panel;
    [SerializeField] TMP_Text wrong_text;


    List<string> frasi_soluzione;
    List<string> frasi_originali;

    Dictionary<string, string> frasi_originali_e_soluzioni;
    Dictionary<int, Dictionary<string, string>> italianHashMap_a1;

    public int solution_counter = -1;
    int correct_answers = 0;
    #endregion

    #region Initialization
    void Start() // dict initialization
    {
        frasi_soluzione = new List<string>();
        frasi_originali = new List<string>();

        frasi_originali_e_soluzioni = new Dictionary<string, string>();  // ne fai 500 e poi prendi a caso?
        frasi_originali_e_soluzioni.Add("Original Phrase", "Frase Originale");
        frasi_originali_e_soluzioni.Add("Original Phrase 2", "Frase Originale 2");
        frasi_originali_e_soluzioni.Add("Original Phrase 3", "Frase Originale 3");
        frasi_originali_e_soluzioni.Add("Original Question", "Domanda Originale");
        frasi_originali_e_soluzioni.Add("Original Negation", "Negazione Originale");

        italianHashMap_a1 = new Dictionary<int, Dictionary<string, string>>();
        italianHashMap_a1.Add(1, frasi_originali_e_soluzioni); // identifica il primo esercizio dell'A1

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

    #region Logic
    private void Update()
    {
        DisableSubmitButtonWhenInputVoid();
    }

    void DisableSubmitButtonWhenInputVoid()
    {
        if (inputfield.text.Equals("")) { submit_answer_btn.enabled = false; }
        else { submit_answer_btn.enabled = true; }
    }

    public void CheckSolution()
    {
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
                    Debug.Log("Risposta Sbagliata");
                    // far Uscire un alert o un feedback che la risposta è sbagliata
                    StartCoroutine(FadeImage(true));
                }
            }
            // update Original Frase;
            switch (solution_counter)
            {
                case 0: break;
                case 1: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 2: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 3: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                case 4: UpdateMainUI(solution_counter, correct_answers.ToString()); break;
                default: SetCorrectPhraseCounter(correct_answers.ToString()); original_phrase.text = "Well Done!"; break;
            }
        }
        catch (Exception ex)
        {
            Debug.Log("Eccezione: " + ex.ToString());
            Debug.Log("Catched!? - diminuito counter globale per gestire l'eccezione");
            solution_counter--; // yesssss
        }
    }

    void UpdateMainUI(int solution_counter, string correct_answers)
    {
        SetOriginalPhrase(solution_counter); ResetInputField(); SetCorrectPhraseCounter(correct_answers.ToString());
    }
    void SetOriginalPhrase(int solution_counter) { original_phrase.text = frasi_originali.ElementAt(solution_counter); }
    void ResetInputField() { inputfield.text = ""; }
    // 1/10, 2/10, ... 1,2 è il counter bro
    void SetCorrectPhraseCounter(string correct_answers) { correct_phrases_counter.text = correct_answers.ToString(); }

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
    }
    #endregion
}
