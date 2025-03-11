using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnglishLogic : MonoBehaviour
{
    public EnglishLogic englishLogic;

    Dictionary<string, HashSet<string>> wordCategories;
    HashSet<string> future_perfect_continuous_questions;
    private void Start()
    {
        wordCategories = englishLogic.wordCategories;

        HashSet<string> present_simple_questions = englishLogic.present_simple_questions;
        HashSet<string> present_continuous_questions = englishLogic.present_continuous_questions;
        HashSet<string> present_perfect_questions = englishLogic.present_perfect_questions;
        HashSet<string> present_perfect_continuous_questions = englishLogic.present_perfect_continuous_questions;
        HashSet<string> past_simple_questions = englishLogic.past_simple_questions;
        HashSet<string> past_continuous_questions = englishLogic.past_continuous_questions;
        HashSet<string> past_perfect_questions = englishLogic.past_perfect_questions;
        HashSet<string> past_perfect_continuous_questions = englishLogic.past_perfect_continuous_questions;
        HashSet<string> future_simple_questions = englishLogic.future_simple_questions;
        HashSet<string> future_continuous_questions = englishLogic.future_continuous_questions;
        HashSet<string> future_perfect_questions = englishLogic.future_perfect_questions;
        future_perfect_continuous_questions = englishLogic.future_perfect_continuous_questions;

        //foreach (var questionSet in wordCategories)
        //{
        //    Debug.Log($"Validating {questionSet.Key} questions:");

        //    foreach (var sentence in questionSet.Value)
        //    {
        //        bool isValid = ValidateSentence(sentence, wordCategories);
        //        Debug.Log($"'{sentence}' is {(isValid ? "valid" : "invalid")}");
        //    }

        //    Debug.Log("");
        //}

        // per ogni frase nell'hashset
        // prendo la frase e la splitto senza contare la punteggiatura
        // per ogni parola della frase
        // vedo se è contenuta nel dizionario
        ValidateFuturePerfectContinuousQuestions(future_perfect_continuous_questions, wordCategories);
        RepeatTests();
    }

    public void RepeatTests()
    {
        // Usa il comando interno di Unity per pulire la console
        var logEntries = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");
        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        clearMethod.Invoke(null, null);
        ValidateFuturePerfectContinuousQuestions(future_perfect_continuous_questions, wordCategories);
        // other...............
    }
    public void ValidateFuturePerfectContinuousQuestions(
    HashSet<string> sentences,
    Dictionary<string, HashSet<string>> wordCategories)
    {
        foreach (var sentence in sentences)
        {
            // Rimuove la punteggiatura e divide la frase in parole
            var words = sentence.TrimEnd('.', '?', '!').Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Debug.Log($"Validating sentence: \"{sentence}\"");

            foreach (var word in words)
            {
                bool isWordValid = false;

                // Controlla se la parola è presente in una delle categorie del dizionario
                foreach (var category in wordCategories.Values)
                {
                    if (category.Contains(word.ToLower())) // Case-insensitive check
                    {
                        isWordValid = true;
                        break;
                    }
                }

                // Stampa il risultato per ciascuna parola
                // Logga il risultato per ciascuna parola
                if (isWordValid)
                {
                    Debug.Log($"Word \"{word}\" is valid and found in dictionary.");
                }
                else
                {
                    Debug.LogWarning($"Word \"{word}\" is NOT valid or not found in dictionary.");
                    wordCategories["otherWords"].Add(word.ToLower());
                }
            }

            Debug.Log("");
        }
    }
    public bool ValidateSentence(string sentence, Dictionary<string, HashSet<string>> wordCategories)
    {
        // Rimuovi il punto finale dalla frase e dividi le parole
        var words = sentence.TrimEnd('.').Split(' ');

        foreach (var word in words)
        {
            bool isWordValid = false;

            // Controlla se la parola appartiene a una delle categorie
            foreach (var category in wordCategories.Values)
            {
                if (category.Contains(word.ToLower())) // Confronto case-insensitive
                {
                    isWordValid = true;
                    break;
                }
            }

            // Se la parola non appartiene a nessuna categoria, la frase non è valida
            if (!isWordValid)
            {
                return false;
            }
        }

        // Se tutte le parole sono valide, la frase è valida
        return true;
    }
}
