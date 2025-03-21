using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class CheckEnglishLogic : MonoBehaviour
{
    // This Scene MUST BE LOADED ASYNC WITH A LOADING BAR
    public EnglishLogic englishLogic;

    Dictionary<string, HashSet<string>> wordCategories;

    HashSet<string> present_simple_questions;
    HashSet<string> present_continuous_questions;
    HashSet<string> present_perfect_questions;
    HashSet<string> present_perfect_continuous_questions;
    HashSet<string> past_simple_questions;
    HashSet<string> past_continuous_questions;
    HashSet<string> past_perfect_questions;
    HashSet<string> past_perfect_continuous_questions;
    HashSet<string> future_simple_questions;
    HashSet<string> future_continuous_questions;
    HashSet<string> future_perfect_questions;
    HashSet<string> future_perfect_continuous_questions;

    HashSet<string> present_simple_affirmations;
    HashSet<string> present_continuous_affirmations;
    HashSet<string> present_perfect_affirmations;
    HashSet<string> present_perfect_continuous_affirmations;
    HashSet<string> past_simple_affirmations;
    HashSet<string> past_continuous_affirmations;
    HashSet<string> past_perfect_affirmations;
    HashSet<string> past_perfect_continuous_affirmations;
    HashSet<string> future_simple_affirmations;
    HashSet<string> future_continuous_affirmations;
    HashSet<string> future_perfect_affirmations;
    HashSet<string> future_perfect_continuous_affirmations;

    HashSet<string> present_simple_negations;
    HashSet<string> present_continuous_negations;
    HashSet<string> present_perfect_negations;
    HashSet<string> present_perfect_continuous_negations;
    HashSet<string> past_simple_negations;
    HashSet<string> past_continuous_negations;
    HashSet<string> past_perfect_negations;
    HashSet<string> past_perfect_continuous_negations;
    HashSet<string> future_simple_negations;
    HashSet<string> future_continuous_negations;
    HashSet<string> future_perfect_negations;
    HashSet<string> future_perfect_continuous_negations;

    private void Start()
    {
        wordCategories = englishLogic.wordCategories;

        // questions
        present_simple_questions = englishLogic.present_simple_questions;
        present_continuous_questions = englishLogic.present_continuous_questions;
        present_perfect_questions = englishLogic.present_perfect_questions;
        present_perfect_continuous_questions = englishLogic.present_perfect_continuous_questions;
        past_simple_questions = englishLogic.past_simple_questions;
        past_continuous_questions = englishLogic.past_continuous_questions;
        past_perfect_questions = englishLogic.past_perfect_questions;
        past_perfect_continuous_questions = englishLogic.past_perfect_continuous_questions;
        future_simple_questions = englishLogic.future_simple_questions;
        future_continuous_questions = englishLogic.future_continuous_questions;
        future_perfect_questions = englishLogic.future_perfect_questions;
        future_perfect_continuous_questions = englishLogic.future_perfect_continuous_questions;


        // per ogni frase nell'hashset
        // prendo la frase e la splitto senza contare la punteggiatura
        // per ogni parola della frase
        // vedo se è contenuta nel dizionario

        ValidatePhrase(present_simple_questions, wordCategories);
        ValidatePhrase(present_continuous_questions, wordCategories);
        ValidatePhrase(present_perfect_questions, wordCategories);
        ValidatePhrase(present_perfect_continuous_questions, wordCategories);
        ValidatePhrase(past_simple_questions, wordCategories);
        ValidatePhrase(past_continuous_questions, wordCategories);
        ValidatePhrase(past_perfect_questions, wordCategories);
        ValidatePhrase(past_perfect_continuous_questions, wordCategories);
        ValidatePhrase(future_simple_questions, wordCategories);
        ValidatePhrase(future_continuous_questions, wordCategories);
        ValidatePhrase(future_perfect_questions, wordCategories);
        ValidatePhrase(future_perfect_continuous_questions, wordCategories);

        // ---------------------------

        // Affirmations
        present_simple_affirmations = englishLogic.present_simple_affirmations;
        present_continuous_affirmations = englishLogic.present_continuous_affirmations;
        present_perfect_affirmations = englishLogic.present_perfect_affirmations;
        present_perfect_continuous_affirmations = englishLogic.present_perfect_continuous_affirmations;
        past_simple_affirmations = englishLogic.past_simple_affirmations;
        past_continuous_affirmations = englishLogic.past_continuous_affirmations;
        past_perfect_affirmations = englishLogic.past_perfect_affirmations;
        past_perfect_continuous_affirmations = englishLogic.past_perfect_continuous_affirmations;
        future_simple_affirmations = englishLogic.future_simple_affirmations;
        future_continuous_affirmations = englishLogic.future_continuous_affirmations;
        future_perfect_affirmations = englishLogic.future_perfect_affirmations;
        future_perfect_continuous_affirmations = englishLogic.future_perfect_continuous_affirmations;

        ValidatePhrase(present_simple_affirmations, wordCategories);
        ValidatePhrase(present_continuous_affirmations, wordCategories);
        ValidatePhrase(present_perfect_affirmations, wordCategories);
        ValidatePhrase(present_perfect_continuous_affirmations, wordCategories);
        ValidatePhrase(past_simple_affirmations, wordCategories);
        ValidatePhrase(past_continuous_affirmations, wordCategories);
        ValidatePhrase(past_perfect_affirmations, wordCategories);
        ValidatePhrase(past_perfect_continuous_affirmations, wordCategories);
        ValidatePhrase(future_simple_affirmations, wordCategories);
        ValidatePhrase(future_continuous_affirmations, wordCategories);
        ValidatePhrase(future_perfect_affirmations, wordCategories);
        ValidatePhrase(future_perfect_continuous_affirmations, wordCategories);

        // ---------------------------

        // Negations
        present_simple_negations = englishLogic.present_simple_negations;
        present_continuous_negations = englishLogic.present_continuous_negations;
        present_perfect_negations = englishLogic.present_perfect_negations;
        present_perfect_continuous_negations = englishLogic.present_perfect_continuous_negations;
        past_simple_negations = englishLogic.past_simple_negations;
        past_continuous_negations = englishLogic.past_continuous_negations;
        past_perfect_negations = englishLogic.past_perfect_negations;
        past_perfect_continuous_negations = englishLogic.past_perfect_continuous_negations;
        future_simple_negations = englishLogic.future_simple_negations;
        future_continuous_negations = englishLogic.future_continuous_negations;
        future_perfect_negations = englishLogic.future_perfect_negations;
        future_perfect_continuous_negations = englishLogic.future_perfect_continuous_negations;

        ValidatePhrase(present_simple_negations, wordCategories);
        ValidatePhrase(present_continuous_negations, wordCategories);
        ValidatePhrase(present_perfect_negations, wordCategories);
        ValidatePhrase(present_perfect_continuous_negations, wordCategories);
        ValidatePhrase(past_simple_negations, wordCategories);
        ValidatePhrase(past_continuous_negations, wordCategories);
        ValidatePhrase(past_perfect_negations, wordCategories);
        ValidatePhrase(past_perfect_continuous_negations, wordCategories);
        ValidatePhrase(future_simple_negations, wordCategories);
        ValidatePhrase(future_continuous_negations, wordCategories);
        ValidatePhrase(future_perfect_negations, wordCategories);
        ValidatePhrase(future_perfect_continuous_negations, wordCategories);

        //RepeatTests(); //Only for test purpose
    }

    public void RepeatTests()
    {
        // Usa il comando interno di Unity per pulire la console
        var logEntries = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");
        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        clearMethod.Invoke(null, null);

        ValidatePhrase(present_simple_questions, wordCategories);
        ValidatePhrase(present_continuous_questions, wordCategories);
        ValidatePhrase(present_perfect_questions, wordCategories);
        ValidatePhrase(present_perfect_continuous_questions, wordCategories);
        ValidatePhrase(past_simple_questions, wordCategories);
        ValidatePhrase(past_continuous_questions, wordCategories);
        ValidatePhrase(past_perfect_questions, wordCategories);
        ValidatePhrase(past_perfect_continuous_questions, wordCategories);
        ValidatePhrase(future_simple_questions, wordCategories);
        ValidatePhrase(future_continuous_questions, wordCategories);
        ValidatePhrase(future_perfect_questions, wordCategories);
        ValidatePhrase(future_perfect_continuous_questions, wordCategories);
        // other...............
    }
    HashSet<string> bonusWordsCopy = new HashSet<string>();
    public void ValidatePhrase(HashSet<string> sentences, Dictionary<string, HashSet<string>> wordCategories)
    {
        foreach (var sentence in sentences)
        {
            // Rimuove la punteggiatura e divide la frase in parole
            var words = RemovePunctuation(sentence.TrimEnd('.', '?', '!')).Split(' ', StringSplitOptions.RemoveEmptyEntries); ;//sentence.TrimEnd('.', '?', '!').Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //Debug.Log($"Validating sentence: \"{sentence}\"");

            foreach (var word in words)
            {
                bool isWordValid = false;
                foreach (var category in wordCategories.Values)
                {
                    if (category.Contains(word.ToLower())) // Case-insensitive check
                    {
                        isWordValid = true;
                        break;
                    }
                }
                if (!isWordValid)
                {
                    //Debug.LogWarning($"Word \"{word}\" is NOT valid or not found in dictionary.");
                    wordCategories["bonusWords"].Add(word.ToLower());
                    bonusWordsCopy.Add(word.ToLower());
                    //Debug.LogWarning($"Word \"{word}\" added");

                }
            }
        }
    }

    string RemovePunctuation(string input)
    {
        // Regex per trovare tutti i caratteri di punteggiatura
        string pattern = @"[^\w\s]";
        // Sostituisce i caratteri di punteggiatura con una stringa vuota
        return Regex.Replace(input, pattern, "");
    }


    public string selectedWordType = "Wh-Words";
    public Text wordList;
    public Text wordTypeTitle;
    public GameObject wordListPanel;
    public Dropdown wordTypeDropdown;
    public void HandleWordType()
    {
        selectedWordType = wordTypeDropdown.options[wordTypeDropdown.value].text;
        if (selectedWordType.Equals("Wh-Words"))
        {
            wordTypeTitle.text = selectedWordType + " + How";
        } 
        else if (selectedWordType.Equals("Sub/Objects"))
        {
            wordTypeTitle.text = "Subjects/Objects";
        }
        else if (selectedWordType.Equals("Time"))
        {
            wordTypeTitle.text = "Time Clause";
        }
        else
        {
            wordTypeTitle.text = selectedWordType;
        }

        // si deve aprire un pannello tipo dizionario dove vengono mostrate le parole di quel tipo
    }

    public void ShowWordTypeList()
    {
        HandleWordType();
        switch (selectedWordType)
        {
            case "Wh-Words": ShowListForType("wh-word"); break;
            case "Auxiliaries": ShowListForType("auxiliary"); break;
            case "Sub/Objects": ShowListForType("subject"); break;
            case "Verbs": ShowListForType("verb"); break;
            case "Prepositions": ShowListForType("preposition"); break;
            case "Adverbs": ShowListForType("averbs"); break;
            case "Time": ShowListForType("time"); break;
            case "Bonus Words": ShowListForType("bonusWords"); break;
            default: Debug.Log("error on HandleWordType"); break;
        }
    }
    public void ShowListForType(string key)
    {
        wordListPanel.SetActive(true);
        wordList.text = "\n";
        if("bonusWords".Equals(key))
        {
            foreach (var word in bonusWordsCopy)
            {
                //Debug.Log(word);
                wordList.text += word + "\n";
            }
        }
        if (wordCategories.ContainsKey(key.ToLower()))
        {
            var words = wordCategories[key.ToLower()];
            //Debug.Log("Words for category '" + key + "':");
            foreach (var word in words)
            {
                //Debug.Log(word);
                wordList.text += word + "\n";
            }
        }
        else
        {
            //Debug.Log("No words found for category: " + key);
        }
    }

    public void CloseWordListPanel()
    {
        wordListPanel.SetActive(false);
    }
}
