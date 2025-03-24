using System;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTests : MonoBehaviour
{
    static List<string> definitive_article = new List<string> { "the" };
    static List<string> undefinitive_article = new List<string> { "a", "an" };
    static List<string> have_verb = new List<string> { "has", "have" };
    static List<string> auxiliaries = new List<string> { "has", "have" };
    static List<string> singular_subject = new List<string> { "car", "guy" };
    static List<string> plural_subject = new List<string> { "cars", "guys" };
    static List<string> base_verbs = new List<string> { "love", "drive", "are", "run" };
    static List<string> base_verbs_3rd_person = new List<string> { "loves", "drives", "runs" };
    static List<string> ing_verbs = new List<string> { "loving", "driving" };
    static List<string> past_participle = new List<string> { "loved", "driven" };
    static List<string> modal_verbs = new List<string> { "can", "could", "shall", "should", "will", "would", "may", "might", "must" };
    static List<string> negations = new List<string> { "not", "never", "no" };
    static List<string> question_words = new List<string> { "who", "what", "where", "when", "why", "how", "which", "whose" };
    static List<string> adjectives = new List<string> { "big", "small", "tall", "short", "bright", "dark", "beautiful", "ugly" };
    static List<string> common_nouns = new List<string> { "book", "table", "house", "computer", "dog", "city", "car", "game" };
    static List<string> proper_nouns = new List<string> { "John", "Sarah", "London", "Paris", "Microsoft", "Google" };
    static List<string> plural_nouns = new List<string> { "books", "tables", "houses", "computers", "dogs", "cities", "cars", "games" };

    static bool IsValidSentence(string sentence)
    {
        string[] words = sentence.ToLower().Replace(".", "").Replace("?", "").Split(' ');
        if (words.Length < 2) return false;

        // Verifica soggetto e verbo

        // Article + subject + Is/Is Not + Adjective 
        // article + sub + has/has not + article + object
        if (words[0].ToLower().Equals("the") || words[0].ToLower().Equals("a")) // The | a
        {
            bool subjectRecognized = singular_subject.Contains(words[1]);

            if (words[2].Equals("is"))
            {
                if (words[3].Equals("not"))
                {
                    if (adjectives.Contains(words[4]))
                        return true;

                } else
                {
                    bool adjectiveRecognized = adjectives.Contains(words[3]);
                    if (subjectRecognized && adjectiveRecognized)
                        return true;
                }
            }
            // A guy has a car. - A guy has the car. -  "A guy drives a car.",
            if (words[2].Equals("has") || base_verbs_3rd_person.Contains(words[2]))
            {
                if (words[3].ToLower().Equals("the") || words[3].ToLower().Equals("a"))
                {
                    bool objectRecognized = singular_subject.Contains(words[4]);
                    if(objectRecognized) return true;
                }
                else
                {
                    bool adjectiveRecognized = adjectives.Contains(words[3]);
                    if (subjectRecognized && adjectiveRecognized)
                        return true;
                }
            }
        }


        return false;
    }

    private void Start()
    {
        //Debug.Log(IsValidSentence("A guy has a car."));

        /*
         CONTINUA PROVANDO A METTERE QUESTE:
        Sentence: "The car drives fast." 
        Sentence: "The car does not move." 
        Sentence: "Does the car move?" 
        Sentence: "Why does the car move?" 
        Sentence: "The cars are not fast." 
        Sentence: "Are the cars fast?" 
        Sentence: "The professor explains well." 
        Sentence: "The library does not open today." 
        Sentence: "Do the kids play outside?" 
        Sentence: "The city has been quiet recently." 
        Sentence: "The museum is big." 
         
         */
        List<string> sentences = new List<string>
        {
            "The car is big.", "The car is not big.",
            "A car is big.", "A car is not big.",
            "A guy has a car.", "A guy has the car.",
            "A guy drives a car.",
            //"John loves books.",
            //"Does he love games?",
            //"Why do you drive?",
            //"The dogs run fast.",
            //"Paris is a city."
        };

        foreach (var sentence in sentences)
        {
            Debug.Log($"'{sentence}' è grammaticalmente valido? {IsValidSentence(sentence)}");
        }
    }
}
