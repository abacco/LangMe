using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

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
        //wordCategories = englishLogic.wordCategories;

        // questions
        //present_simple_questions = EnglishHashSets.present_simple_questions;
        //present_continuous_questions = EnglishHashSets.present_continuous_questions;
        //present_perfect_questions = EnglishHashSets.present_perfect_questions;
        //present_perfect_continuous_questions = EnglishHashSets.present_perfect_continuous_questions;
        //past_simple_questions = EnglishHashSets.past_simple_questions;
        //past_continuous_questions = EnglishHashSets.past_continuous_questions;
        //past_perfect_questions = EnglishHashSets.past_perfect_questions;
        //past_perfect_continuous_questions = EnglishHashSets.past_perfect_continuous_questions;
        //future_simple_questions = EnglishHashSets.future_simple_questions;
        //future_continuous_questions = EnglishHashSets.future_continuous_questions;
        //future_perfect_questions = EnglishHashSets.future_perfect_questions;
        //future_perfect_continuous_questions = EnglishHashSets.future_perfect_continuous_questions;


        //// per ogni frase nell'hashset
        //// prendo la frase e la splitto senza contare la punteggiatura
        //// per ogni parola della frase
        //// vedo se è contenuta nel dizionario

        //ValidatePhrase(present_simple_questions, wordCategories);
        //ValidatePhrase(present_continuous_questions, wordCategories);
        //ValidatePhrase(present_perfect_questions, wordCategories);
        //ValidatePhrase(present_perfect_continuous_questions, wordCategories);
        //ValidatePhrase(past_simple_questions, wordCategories);
        //ValidatePhrase(past_continuous_questions, wordCategories);
        //ValidatePhrase(past_perfect_questions, wordCategories);
        //ValidatePhrase(past_perfect_continuous_questions, wordCategories);
        //ValidatePhrase(future_simple_questions, wordCategories);
        //ValidatePhrase(future_continuous_questions, wordCategories);
        //ValidatePhrase(future_perfect_questions, wordCategories);
        //ValidatePhrase(future_perfect_continuous_questions, wordCategories);

        //// ---------------------------

        //// Affirmations
        //present_simple_affirmations = EnglishHashSets.present_simple_affirmations;
        //present_continuous_affirmations = EnglishHashSets.present_continuous_affirmations;
        //present_perfect_affirmations = EnglishHashSets.present_perfect_affirmations;
        //present_perfect_continuous_affirmations = EnglishHashSets.present_perfect_continuous_affirmations;
        //past_simple_affirmations = EnglishHashSets.past_simple_affirmations;
        //past_continuous_affirmations = EnglishHashSets.past_continuous_affirmations;
        //past_perfect_affirmations = EnglishHashSets.past_perfect_affirmations;
        //past_perfect_continuous_affirmations = EnglishHashSets.past_perfect_continuous_affirmations;
        //future_simple_affirmations = EnglishHashSets.future_simple_affirmations;
        //future_continuous_affirmations = EnglishHashSets.future_continuous_affirmations;
        //future_perfect_affirmations = EnglishHashSets.future_perfect_affirmations;
        //future_perfect_continuous_affirmations = EnglishHashSets.future_perfect_continuous_affirmations;

        //ValidatePhrase(present_simple_affirmations, wordCategories);
        //ValidatePhrase(present_continuous_affirmations, wordCategories);
        //ValidatePhrase(present_perfect_affirmations, wordCategories);
        //ValidatePhrase(present_perfect_continuous_affirmations, wordCategories);
        //ValidatePhrase(past_simple_affirmations, wordCategories);
        //ValidatePhrase(past_continuous_affirmations, wordCategories);
        //ValidatePhrase(past_perfect_affirmations, wordCategories);
        //ValidatePhrase(past_perfect_continuous_affirmations, wordCategories);
        //ValidatePhrase(future_simple_affirmations, wordCategories);
        //ValidatePhrase(future_continuous_affirmations, wordCategories);
        //ValidatePhrase(future_perfect_affirmations, wordCategories);
        //ValidatePhrase(future_perfect_continuous_affirmations, wordCategories);

        //// ---------------------------

        //// Negations
        //present_simple_negations = EnglishHashSets.present_simple_negations;
        //present_continuous_negations = EnglishHashSets.present_continuous_negations;
        //present_perfect_negations = EnglishHashSets.present_perfect_negations;
        //present_perfect_continuous_negations = EnglishHashSets.present_perfect_continuous_negations;
        //past_simple_negations = EnglishHashSets.past_simple_negations;
        //past_continuous_negations = EnglishHashSets.past_continuous_negations;
        //past_perfect_negations = EnglishHashSets.past_perfect_negations;
        //past_perfect_continuous_negations = EnglishHashSets.past_perfect_continuous_negations;
        //future_simple_negations = EnglishHashSets.future_simple_negations;
        //future_continuous_negations = EnglishHashSets.future_continuous_negations;
        //future_perfect_negations = EnglishHashSets.future_perfect_negations;
        //future_perfect_continuous_negations = EnglishHashSets.future_perfect_continuous_negations;

        //ValidatePhrase(present_simple_negations, wordCategories);
        //ValidatePhrase(present_continuous_negations, wordCategories);
        //ValidatePhrase(present_perfect_negations, wordCategories);
        //ValidatePhrase(present_perfect_continuous_negations, wordCategories);
        //ValidatePhrase(past_simple_negations, wordCategories);
        //ValidatePhrase(past_continuous_negations, wordCategories);
        //ValidatePhrase(past_perfect_negations, wordCategories);
        //ValidatePhrase(past_perfect_continuous_negations, wordCategories);
        //ValidatePhrase(future_simple_negations, wordCategories);
        //ValidatePhrase(future_continuous_negations, wordCategories);
        //ValidatePhrase(future_perfect_negations, wordCategories);
        //ValidatePhrase(future_perfect_continuous_negations, wordCategories);

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
        else if (selectedWordType.Equals("Auxiliaries"))
        {
            wordTypeTitle.text = "Auxiliaries";
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
            case "Wh-Words":
                wordListPanel.SetActive(true);
                wordList.text = "\n";
                wordList.text = "\nhow\nwhy\nwhat\nwhere\nwhen\nwhich\nwho\nwhose";
                break;
            case "Auxiliaries":
                wordListPanel.SetActive(true);
                wordList.text = "\n";
                wordList.text = "\ndoes\ndo\ndid\nis\nare\nwas\nwere\ncan\ncould\nshall\nshould\nwill\nwould\nhave\nhas\nhad\ndoesn't\ndon't\ndidn't\nisn't\naren't\nwasn't\nweren't\ncan't\ncouldn't\nshan't\nshouldn't\nwon't\nwouldn't\nhaven't\nhasn't\nhadn't";
                    break;
            case "Articles":
                wordListPanel.SetActive(true);
                wordList.text = "\n";
                wordList.text = "\na\n\an\nthe\n";
                break;
            case "Pronouns":
                wordListPanel.SetActive(true);
                wordList.text = "\n";
                wordList.text = "\nPossessivesmy\nyour\nhis\nher\nits\nnour\ntheir\n" + "\nObjectives\nme\nyou\nhim\nher\nit\nus\nthem\n";
                break;
            case "Sub/Objects":
                wordListPanel.SetActive(true);
                wordList.text = "\n";
                wordList.text += "Singulars:\n\n";
                foreach (string singular in ButtonTests.singular_subjects)
                {
                    wordList.text += singular + "\n";
                }
                wordList.text += "\nPlurals:\n\n";
                foreach (string plural in ButtonTests.plural_subjects)
                {
                    wordList.text += plural + "\n";
                }
                wordList.text += "\nProper:\n\n";
                foreach (string proper_noun in ButtonTests.proper_nouns)
                {
                    wordList.text += proper_noun + "\n";
                }
                break;
            case "Verbs":
                wordListPanel.SetActive(true);
                wordList.text = "\n";
                wordList.text += "\nBase Verb:\n";
                foreach (string base_verb in ButtonTests.base_verbs)
                {
                    wordList.text += base_verb + "\n";
                }
                wordList.text += "\n3rd Person Verbs:\n";
                foreach (string thirdPersonVerb in ButtonTests.base_verbs_3rd_person)
                {
                    wordList.text += thirdPersonVerb + "\n";
                }
                wordList.text += "\nModal Verbs:\n";
                foreach (string modal_verb in ButtonTests.modal_verbs)
                {
                    wordList.text += modal_verb + "\n";
                }
                wordList.text += "\nPast Participle:\n";
                foreach (string past_participle in ButtonTests.past_participle)
                {
                    wordList.text += past_participle + "\n";
                }
                wordList.text += "\nIng Verbs:\n";
                foreach (string ing_verb in ButtonTests.ing_verbs)
                {
                    wordList.text += ing_verb + "\n";
                }
                break;
            case "Prepositions":
                wordListPanel.SetActive(true);
                wordList.text = "\n";
                wordList.text = "\nwith\nin\non\nat\nto\nwith\nfor\nbefore\nafter\nduring\nas\nby\nup\nabout\nover\nunder\nof\nthrough\nbetween\ninto\nonto\nout\nfrom\nagainst\nalong\naround\nbeneath\nbeside\nbeyond\nnear\noff\npast\nsince\nuntil\nwithin\nwithout";
                break;
            case "Adjectives":
                wordListPanel.SetActive(true);
                wordList.text = "\n";
                foreach (string adjective in ButtonTests.adjectives)
                {
                    wordList.text += adjective + "\n";
                }
                break;
            case "Adverbs":
                wordListPanel.SetActive(true);
                wordList.text = "\n";
                wordList.text += "\nFrequency:\n";
                foreach (string freq_adverb in ButtonTests.frequencyAdverbs)
                {
                    wordList.text += freq_adverb + "\n";
                }
                wordList.text += "\nTime:\n";
                foreach (string timeAdverb in ButtonTests.timeAdverbs)
                {
                    wordList.text += timeAdverb + "\n";
                }
                wordList.text += "\nPlace:\n";
                foreach (string placeAdverb in ButtonTests.placeAdverbs)
                {
                    wordList.text += placeAdverb + "\n";
                }
                wordList.text += "\nPlace:\n";
                foreach (string mannerAdverb in ButtonTests.mannerAdverbs)
                {
                    wordList.text += mannerAdverb + "\n";
                }
                break;
            default: Debug.Log("error on HandleWordType"); break;
        }
    }
    public void ShowListForType(string key)
    {
        wordListPanel.SetActive(true);
        wordList.text = "\n";
        wordList.text = "\nBRODA";
        // wordTypeDropdown.
    }

    public void CloseWordListPanel()
    {
        wordListPanel.SetActive(false);
    }
}
