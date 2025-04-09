using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class ButtonTests : MonoBehaviour
{
    static List<string> singular_subject = new List<string> { "teacher", "student","beef", "dog", "i", "girl", "boy", "coffee", "book", "table", "bike", "car", "guy", "cat", "water", "sun", "he", "she", "it" };
    static List<string> base_verbs = new List<string> { "visit", "need", "make", "live", "do", "work", "respond", "answer", "go", "explain", "write", "cook", "smile", "enjoy", "dance","sing","read","talk","swim", "play", "travel", "sleep", "study", "eat", "be", "walk", "complete", "bark", "visit", "work", "agree", "drink", "like", "love", "drive", "are", "run", "jump", "believe" };
    static List<string> base_verbs_3rd_person = new List<string> { "visits", "needs","makes", "lives", "does", "works", "responds", "answers", "goes", "explains", "writes", "cooks","smiles","enjoys","dances","sings","reads","talks", "swims", "plays", "travels", "sleeps", "studies","eats","walks", "completes", "barks", "visits", "agrees", "likes","loves", "drives", "runs", "jumps", "boils", "rises", "knows", "believes", "likes", "drinks" };
    static List<string> ing_verbs = new List<string> { "visiting", "needing", "making", "living", "doing", "working", "responding", "answering", "going", "explaining", "writing", "cooking", "smiling","enjoying","dancing","singing", "reading","talking","swimming", "playing", "traveling", "sleeping", "studying", "eating", "walking", "completing", "being","agreeing", "liking", "standing", "writing", "playing", "reading", "eating", "running", "loving", "driving", "waiting" };
    static List<string> past_participle = new List<string> {
        "visited", "eaten",
                                                                                "studied",
                                                                                "run",
                                                                                "done",
                                                                                "responded",
                                                                                "enjoyed",
                                                                                "traveled",
                                                                                "visited",
                                                            "liked", "needed", "made", "lived", "did","worked", "responded", "answered", "went","explained", "written", "cooked", "studied", "completed", "finished", "repaired", "loved", "driven" };
    static List<string> modal_verbs = new List<string> { "can", "could", "shall", "should", "will", "would", "may", "might", "must" };

    static List<string> question_words = new List<string> { "who", "what", "where", "when", "why", "how", "which", "whose" };
    static List<string> adjectives = new List<string> { "late", "happy", "sunny", "cold", "big", "small", "tall", "short", "bright", "dark", "beautiful", "ugly", "fast" };

    static List<string> common_nouns = new List<string> { "time", "cake", "student", "friend","teacher", "thing","pizza", "basketball", "football", "soccer","apple", "assignment", "student","beef", "dog", "task", "garden", "day","time", "grandparent", "home", "pizza", "guitar", "letter", "garden", "girl", "boy", "sandwich", "problem", "meeting", "table", "sugar", "house", "jacket", "fight", "lamp","child", "coffee", "table", "bike", "apple", "book", "table", "house", "computer", "dog", "city", "car", "game", "east", "west", "north", "south", "answer", "miracle" };
    static List<string> plural_nouns = new List<string> { "times", "cakes","emails", "students", "friends", "teachers", "things","pizzas", "students", "beefs", "grandparents", "girls", "we", "they", "you",
                                                            "cars", "guys", "books", "dogs", "cats", "apples", "assignments",
                                                            "days", "pizzas", "guitars", "letters", "gardens", "boys",
                                                            "sandwiches", "problems", "meetings", "tables", "sugars", "houses",
                                                            "jackets", "fights", "lamps", "children", "bikes", "computers",
                                                            "cities", "games", "answers", "miracles" };

    static List<string> possessivePronouns = new List<string>{ "my", "your", "his", "her", "its", "our", "your", "their" };

    static List<string> objectPronouns = new List<string>{ "me", "you", "him", "her", "it", "us", "them" };

    static List<string> proper_nouns = new List<string> { "john", "sarah", "london", "paris", "microsoft", "google" };

    static List<string> prepositions = new List<string> { "with","in", "on", "at", "to", "with", "for", "before", "after", "during", "as", "by", 
                                                          "about", "over", "under", "of", "through", "between", "into", "onto", "out", 
                                                          "from", "against", "along", "around", "beneath", "beside", "beyond", "near", "off", 
                                                          "past", "since", "until", "within", "without" };

    static List<string> phrasalVerbs = new List<string>{
                                                        "wake up", "wakes up", "woke up", "woken up",
                                                        "turn on", "turns on", "turned on",
                                                        "turn off", "turns off", "turned off",
                                                        "give up", "gives up", "gave up", "given up",
                                                        "take off", "takes off", "took off", "taken off",
                                                        "look after", "looks after", "looked after",
                                                        "run into", "runs into", "ran into",
                                                        "set up", "sets up", "set up",
                                                        "find out", "finds out", "found out",
                                                        "put off", "puts off", "put off"
    };

    static List<string> frequencyAdverbs = new List<string> { "always", "usually", "often", "sometimes", "rarely", "never", "regularly", "occasionally" };
    static List<string> timeAdverbs = new List<string> { "now", "later", "soon", "tomorrow", "yesterday", "tonight", "at night", "today", "currently", "immediately" };
    static List<string> placeAdverbs = new List<string> { "here", "there", "everywhere", "somewhere", "nearby", "around", "inside", "outside" };
    static List<string> mannerAdverbs = new List<string> { "exactly", "really", "quickly", "slowly", "carefully", "happily", "sadly", "skillfully", "neatly", "badly" };
    
    static List<string> otherAdverbs = new List<string> { "almost", "definitely", "surely", "quite", "probably" };

    public static bool IsValidSentence(string sentence)
    {
        string[] words = sentence.ToLower().Replace(".", "").Replace("?", "").Split(' ');
        if (words.Length < 2) return false;

        //List<string> extender = new List<string>(words);  // Converti l'array in una lista
        //extender.Add("");  // Aggiungi un elemento
        //extender.Add("");  // Aggiungi un elemento
        //extender.Add("");  // Aggiungi un elemento
        //extender.Add("");  // Aggiungi un elemento
        //extender.Add("");  // Aggiungi un elemento
        //extender.Add("");  // Aggiungi un elemento
        //words = extender.ToArray();

        if      (SingularSubjectPresentSimple_Affirmation(words) || IsAQuestion(words)){ return true; }
        else if (PluralSubjectPresentSimple_Affirmation(words))  { return true; }
        else                                                     { return false; }
    }

    public static bool IsAQuestion(string[] words)
    {
        // LEGGI AO
        // la lunghezza dell'array che puoi accettare è uguale alla profondità massima dell'albero (guarda la posizione) - vedi alla fine
        // vedi se fare il check prima o dopo la normalizzazione
        // SULLE FOGLIE L'ACCESSO AGLI ULTIMI NODI LO DEVI FARE SEMPRE CON words.lenght-1 e non con le posizioni fisse per smaltire <--- REFACTORRR!!!
        words = Normalization(words);
        if (IsAQuestionWords(words[0]))
        {
            words = words.Where((value, index) => index != 0 && index != 0).ToArray();
        }
        if (Doesnt(words[1]) && (Have(words[2]) || IsABaseVerb(words[2])))
        {
            if (The(words[3]) || A(words[3])) // The | a
            {
                if (IsASingular(words[4])) return true;
            }
        }
        if (Does(words[1]) && Not(words[2]) && (Have(words[3]) || IsABaseVerb(words[3])))
        {
            string detectedPhrasalVerb = words[0] + " " + words[1]; // she wakes up
            if (phrasalVerbs.Contains(detectedPhrasalVerb))
            {
                words = words.Where((value, index) => index != 0 && index != 1).ToArray();
            }
            if (The(words[4]) || A(words[4]) || IsAPossessivePronouns(words[4])) // The | a
            {
                if (IsASingular(words[5])) return true;
                if (IsAPlural(words[5])) return true;
            }
        }
        
        if (Do(words[0]) || Dont(words[0]))
        {
            if (The(words[1]) || A(words[1]) || An(words[1]) || possessivePronouns.Contains(words[1]))
            {
                words = words.Where((value, index) => index != 1).ToArray();
                if (IsAPlural(words[1]) || words[1].Equals("you"))
                {
                    words = RemoveAdverbs(words, 2);
                    if (IsABaseVerb(words[2]))
                    {
                        if (IsACommon(words[3])) return true;
                    }
                }
            }
            if (IsAPlural(words[1]) || words[1].Equals("you"))
            {
                words = RemoveAdverbs(words, 2);
                if (IsABaseVerb(words[2]))
                {
                    if(!IsFixedLenght(words, 3))
                    {
                        if (IsACommon(words[3])) return true;
                        if (This(words[3]) || That(words[3]))
                        {
                            if (IsACommon(words[4])) return true;
                        }
                    }
                    return true;
                }
            }
            if (Not(words[1]))
            {
                if (The(words[2]) || A(words[2]) || An(words[2]) || possessivePronouns.Contains(words[2]))
                {
                    words = words.Where((value, index) => index != 2).ToArray();
                    if (IsAPlural(words[2]) || words[1].Equals("you"))
                    {
                        words = RemoveAdverbs(words, 3);
                        if (IsABaseVerb(words[3]))
                        {
                            if (IsACommon(words[4])) return true;
                        }
                    }
                }
                if (IsAPlural(words[2]) || words[2].Equals("you"))
                {
                    words = RemoveAdverbs(words, 3);
                    if (IsABaseVerb(words[3]))
                    {
                        if (!IsFixedLenght(words, 4))
                        {
                            if (IsACommon(words[4])) return true;
                        }
                        return true;
                    }
                }
            }
        }
        if (Does(words[0]) || Doesnt(words[0]))
        {
            if (The(words[1]) || A(words[1]) || An(words[1]) || possessivePronouns.Contains(words[1]))
            {
                words = words.Where((value, index) => index != 1).ToArray();
            }
            if (IsASingular(words[1]) || IsAProperNoun(words[1]))
            {
                words = RemoveAdverbs(words, 2);
                if (timeAdverbs.Contains(words[2]))
                {
                    words = words.Where((value, index) => index != 2).ToArray();
                }
                if (IsABaseVerb(words[2]))
                {
                    if (!IsFixedLenght(words, 3))
                    {
                        words = RemoveAdverbs(words, 3);
                        if(!IsFixedLenght(words, 3))
                        {
                            if (IsAPreposition(words[3]))
                            {
                                words = words.Where((value, index) => index != 3).ToArray();
                            }
                            if (IsACommon(words[3])) return true;
                        }
                    }
                    return true;
                }
            }
            if (Not(words[1]))
            {
                if (The(words[2]) || A(words[2]) || An(words[2]) || possessivePronouns.Contains(words[2]))
                {
                    words = words.Where((value, index) => index != 2).ToArray();
                }
                if (IsASingular(words[1]) || IsAProperNoun(words[2]))
                {
                    words = RemoveAdverbs(words, 3);
                    if (timeAdverbs.Contains(words[3]))
                    {
                        words = words.Where((value, index) => index != 3).ToArray();
                    }
                    if (IsABaseVerb(words[3]))
                    {
                        if (!IsFixedLenght(words, 4))
                        {
                            words = RemoveAdverbs(words, 4);
                            if (!IsFixedLenght(words, 4))
                            {
                                if (IsAPreposition(words[4]))
                                {
                                    words = words.Where((value, index) => index != 4).ToArray();
                                }
                                if (IsACommon(words[4])) return true;
                            }
                        }
                        return true;
                    }
                }
            }
        }
        
        if (Are(words[0]) || Arent(words[0]))
        {
            if (IsAPluralSubject(words[1]) || words[1].Equals("you")) 
            {
                if(!IsFixedLenght(words, 3)){
                    words = RemoveAdverbs(words, 2);
                }
                if (IsAnIngVerbs(words[2]))
                {
                    if (IsAnAdjective(words[3]))
                    {
                        return true;
                    }
                }
                if (IsAnAdjective(words[2])) return true;
                if (IsAPluralSubject(words[2])) return true;
                if (IsAPreposition(words[2]))
                {
                    if (IsACommon(words[3])) return true;
                }
            }
        }
        if (Is(words[0]) || Isnt(words[0]))
        {
            words = RemoveAdverbs(words, 1);
            if (IsASingular(words[1]))
            {
                if (The(words[2]) || A(words[2]) || An(words[2]) || possessivePronouns.Contains(words[2]))
                {
                    words = words.Where((value, index) => index != 2).ToArray();
                }
                words = RemoveAdverbs(words, 2);
                if (IsATimeAdverb(words[2])) // iIs she immediately responding to emails quickly?
                {
                    words = words.Where((value, index) => index != 2).ToArray(); // Mangia ultima posizione per togliere l'avv di tempo
                }
                if (Not(words[2]))
                {
                    //words = words.Where((value, index) => index != 2).ToArray(); -- Reminder for refactoring
                    if (The(words[3]) || A(words[3]) || An(words[3]) || possessivePronouns.Contains(words[3]))
                    {
                        words = words.Where((value, index) => index != 3).ToArray();
                    }
                    if (!IsFixedLenght(words, 4))
                    {
                        words = RemoveAdverbs(words, 3);
                    }
                    if (!IsFixedLenght(words, 4))
                    {
                        words = RemoveAdverbs(words, 3);
                    }
                    if (IsAnAdjective(words[3])) return true;
                    if (IsACommon(words[3])) return true;
                }
                if (IsAnIngVerbs(words[2]))
                {
                    if (!IsFixedLenght(words, 4))
                    {
                        words = RemoveAdverbs(words, 3);
                        if (IsAPreposition(words[3]))
                        {
                            if (IsAPlural(words[4]))
                            {
                                return true;
                            }
                        }
                    }
                }
                if (IsAnIngVerbs(words[2])) return true; // is she studying?
                if (IsAnAdjective(words[2])) return true;
                if (IsACommon(words[2])) return true;
            }
            if (IsAnIngVerbs(words[1]))
            {
                if (!IsFixedLenght(words, 3))
                {
                    words = RemoveAdverbs(words, 2);
                    if (IsAPlaceAdverbs(words[2])) // out of bound in singular subject 
                    {
                        words = words.Where((value, index) => index != 2).ToArray();
                    }
                    if(!IsFixedLenght(words, 2))
                    {
                        if (IsATimeAdverb(words[2])) // out of bound in singular subject 
                        {
                            words = words.Where((value, index) => index != 2).ToArray();
                        }
                        if (!IsFixedLenght(words, 2))
                        {
                            if (IsAPreposition(words[2]))
                            {
                                if (IsAPlural(words[3])) return true;
                            }
                        }
                        
                        return true;
                    }
                }
                return true;
            }
        }

        if (Have(words[0]) || Havent(words[0]))
        {
            if (The(words[1]) || A(words[1]) || An(words[1]) || possessivePronouns.Contains(words[1]))
            {
                words = words.Where((value, index) => index != 1).ToArray();
                if (IsAPlural(words[1]) || words[1].Equals("you"))
                {
                    words = RemoveAdverbs(words, 2);
                    if (IsPastParticiple(words[2]))
                    {
                        if (IsACommon(words[3])) return true;
                    }
                    if (IsAnIngVerbs(words[2]))
                    {
                        if (IsACommon(words[3])) return true;
                    }
                }
            }
            if (IsAPlural(words[1]) || words[1].Equals("you"))
            {
                words = RemoveAdverbs(words, 2);
                if (IsPastParticiple(words[2]))
                {
                    if (!IsFixedLenght(words, 3))
                    {
                        if (IsACommon(words[3])) return true;
                        if (This(words[3]) || That(words[3]))
                        {
                            if (IsACommon(words[4])) return true;
                        }
                    }
                    return true;
                }
                if (IsAnIngVerbs(words[2]))
                {
                    words = RemoveAdverbs(words, 2);
                    if (!IsFixedLenght(words, 3)) {
                        if (IsACommon(words[3])) return true;
                    } 
                }
                if (Been(words[2]))
                {
                    if (IsAnIngVerbs(words[3]))
                    {
                        words = RemoveAdverbs(words, 4);
                        if (!IsFixedLenght(words, 4))
                        {
                            if (IsACommon(words[4]))
                            {
                                if (words.Length >= 5) // it means there are more words in the sentence
                                {
                                    if (IsATimeAdverb(words[words.Length - 1]) || IsAPlaceAdverbs(words[words.Length - 1]) || IsAFrequencyAdverb(words[words.Length - 1]))
                                    {
                                        words = words.Where((value, index) => index != words.Length - 1).ToArray();
                                    }
                                    if (IsACommon(words[words.Length - 1])) return true;
                                }
                                return true;
                            }
                            if (IsAPlural(words[4]))
                            {
                                if (words.Length >= 5) // it means there are more words in the sentence
                                {
                                    if (IsATimeAdverb(words[words.Length - 1]) || IsAPlaceAdverbs(words[words.Length - 1]) || IsAFrequencyAdverb(words[words.Length - 1]))
                                    {
                                        words = words.Where((value, index) => index != words.Length - 1).ToArray();
                                    }
                                    if (IsACommon(words[words.Length - 1])) return true;
                                }
                                return true;
                            }
                        }
                        return true;
                    }
                }
            }
            if (Not(words[1]))
            {
                if (The(words[2]) || A(words[2]) || An(words[2]) || possessivePronouns.Contains(words[2]))
                {
                    words = words.Where((value, index) => index != 2).ToArray();
                    if (IsAPlural(words[2]) || words[1].Equals("you"))
                    {
                        words = RemoveAdverbs(words, 3);
                        if (IsPastParticiple(words[3]))
                        {
                            if (IsACommon(words[4])) return true;
                        }
                    }
                    if (Been(words[2]))
                    {
                        if (IsAnIngVerbs(words[3]))
                        {
                            words = RemoveAdverbs(words, 4);
                            if (!IsFixedLenght(words, 4))
                            {
                                if (IsACommon(words[4]))
                                {
                                    if (words.Length >= 5) // it means there are more words in the sentence
                                    {
                                        if (IsATimeAdverb(words[words.Length - 1]) || IsAPlaceAdverbs(words[words.Length - 1]) || IsAFrequencyAdverb(words[words.Length - 1]))
                                        {
                                            words = words.Where((value, index) => index != words.Length - 1).ToArray();
                                        }
                                        if (IsACommon(words[words.Length - 1])) return true;
                                    }
                                    return true;
                                }
                                if (IsAPlural(words[4]))
                                {
                                    if (words.Length >= 5) // it means there are more words in the sentence
                                    {
                                        if (IsATimeAdverb(words[words.Length - 1]) || IsAPlaceAdverbs(words[words.Length - 1]) || IsAFrequencyAdverb(words[words.Length - 1]))
                                        {
                                            words = words.Where((value, index) => index != words.Length - 1).ToArray();
                                        }
                                        if (IsACommon(words[words.Length - 1])) return true;
                                    }
                                    return true;
                                }
                            }
                        }
                    }
                }
                if (IsAPlural(words[2]) || words[2].Equals("you"))
                {
                    words = RemoveAdverbs(words, 3);
                    if (IsPastParticiple(words[3]))
                    {
                        if (!IsFixedLenght(words, 4))
                        {
                            if (IsACommon(words[4])) return true;
                        }
                        return true;
                    }
                }
            }
        }
        if (Has(words[0]) || Hasnt(words[0]))
        {
            words = RemoveAdverbs(words, 1);
            if (The(words[1]) || A(words[1]) || An(words[1]) || possessivePronouns.Contains(words[1]))
            {
                words = words.Where((value, index) => index != 1).ToArray();
            }
            if (IsASingular(words[1]) || IsAProperNoun(words[1]))
            {
                words = RemoveAdverbs(words, 2);
                if (timeAdverbs.Contains(words[2]))
                {
                    words = words.Where((value, index) => index != 2).ToArray();
                }
                if (IsPastParticiple(words[2]))
                {
                    if (!IsFixedLenght(words, 3))
                    {
                        words = RemoveAdverbs(words, 3);
                        if (!IsFixedLenght(words, 3))
                        {
                            if (IsAPreposition(words[3]))
                            {
                                words = words.Where((value, index) => index != 3).ToArray();
                            }
                            if (IsACommon(words[3])) return true;
                        }
                    }
                    return true;
                }
                if (Been(words[2]))
                {
                    if (IsAnIngVerbs(words[3]))
                    {
                        words = RemoveAdverbs(words, 4);
                        if (!IsFixedLenght(words, 4))
                        {
                            if (IsACommon(words[4]))
                            {
                                if (words.Length >= 5) // it means there are more words in the sentence
                                {
                                    if (IsATimeAdverb(words[words.Length - 1]) || IsAPlaceAdverbs(words[words.Length - 1]) || IsAFrequencyAdverb(words[words.Length - 1]))
                                    {
                                        words = words.Where((value, index) => index != words.Length - 1).ToArray();
                                    }
                                    if (IsACommon(words[words.Length - 1])) return true;
                                }
                                return true;
                            }
                            if (IsAPlural(words[4]))
                            {
                                if (words.Length >= 5) // it means there are more words in the sentence
                                {
                                    if (IsATimeAdverb(words[words.Length - 1]) || IsAPlaceAdverbs(words[words.Length - 1]) || IsAFrequencyAdverb(words[words.Length - 1]))
                                    {
                                        words = words.Where((value, index) => index != words.Length - 1).ToArray();
                                    }
                                    if (IsACommon(words[words.Length - 1])) return true;
                                }
                                return true;
                            }
                        }
                        return true;
                    }
                }
            }
            if (Been(words[1])) // il soggetto è tipo Who
            {
                if (IsAnIngVerbs(words[2]))
                {
                    words = RemoveAdverbs(words, 3);
                    if (!IsFixedLenght(words, 3))
                    {
                        if (IsACommon(words[3]))
                        {
                            if (words.Length >= 4) // it means there are more words in the sentence
                            {
                                if (IsATimeAdverb(words[words.Length - 1]) || IsAPlaceAdverbs(words[words.Length - 1]) || IsAFrequencyAdverb(words[words.Length - 1]))
                                {
                                    words = words.Where((value, index) => index != words.Length - 1).ToArray();
                                }
                                if (IsACommon(words[words.Length - 1])) return true;
                            }
                            return true;
                        }
                        if (IsAPlural(words[3]))
                        {
                            if (words.Length >= 4) // it means there are more words in the sentence
                            {
                                if (IsATimeAdverb(words[words.Length - 1]) || IsAPlaceAdverbs(words[words.Length - 1]) || IsAFrequencyAdverb(words[words.Length - 1]))
                                {
                                    words = words.Where((value, index) => index != words.Length - 1).ToArray();
                                }
                                if (IsACommon(words[words.Length - 1])) return true;
                            }
                            return true;
                        }
                    }
                    return true;
                }
            }
            if (IsFixedLenght(words, 3))
            {
                words = RemoveAdverbs(words, 2);
                if(IsFixedLenght(words, 2))
                {
                    if (IsPastParticiple(words[1]))
                    {
                        if (!IsFixedLenght(words, 2))
                        {
                            words = RemoveAdverbs(words, 2);
                            if (!IsFixedLenght(words, 2))
                            {
                                if (IsAPreposition(words[2]))
                                {
                                    words = words.Where((value, index) => index != 2).ToArray();
                                }
                                if (IsACommon(words[2])) return true;
                            }
                        }
                        return true;
                    }
                }
                if (IsPastParticiple(words[2]))
                {
                    if (!IsFixedLenght(words, 3))
                    {
                        words = RemoveAdverbs(words, 3);
                        if (!IsFixedLenght(words, 3))
                        {
                            if (IsAPreposition(words[3]))
                            {
                                words = words.Where((value, index) => index != 3).ToArray();
                            }
                            if (IsACommon(words[3])) return true;
                        }
                    }
                    return true;
                }
            }
            if (IsPastParticiple(words[1]))
            {
                if (!IsFixedLenght(words, 2))
                {
                    words = RemoveAdverbs(words, 2);
                    if (!IsFixedLenght(words, 2))
                    {
                        words = RemoveAdverbs(words, 2);
                        if (!IsFixedLenght(words, 2))
                        {
                            if (IsAPreposition(words[1]))
                            {
                                words = words.Where((value, index) => index != 1).ToArray();
                            }
                            if (IsACommon(words[1])) return true;
                            return true;
                        }
                    }
                }
                return true;
            }
            
            if (Not(words[1]))
            {
                if (The(words[2]) || A(words[2]) || An(words[2]) || possessivePronouns.Contains(words[2]))
                {
                    words = words.Where((value, index) => index != 2).ToArray();
                }
                if (IsASingular(words[1]) || IsAProperNoun(words[2]))
                {
                    words = RemoveAdverbs(words, 3);
                    if (timeAdverbs.Contains(words[3]))
                    {
                        words = words.Where((value, index) => index != 3).ToArray();
                    }
                    if (IsPastParticiple(words[3]))
                    {
                        if (!IsFixedLenght(words, 4))
                        {
                            words = RemoveAdverbs(words, 4);
                            if (!IsFixedLenght(words, 4))
                            {
                                if (IsAPreposition(words[4]))
                                {
                                    words = words.Where((value, index) => index != 4).ToArray();
                                }
                                if (IsACommon(words[4])) return true;
                            }
                        }
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public static bool SingularSubjectPresentSimple_Affirmation(string[] words)
    {
        words = Normalization(words);

        if (possessivePronouns.Contains(words[0])) { words = words.Where((value, index) => index != 0).ToArray(); }

        if (IsFixedLenght(words, 1) && IsASingular(words[0])) return true; // There are dogs here becomes only "dogs" -> valid
        if (The(words[0]) || A(words[0])) 
        { 
            words = words.Where((value, index) => index != 0).ToArray();
        }
        if (IsAnAdjective(words[0])) { 
            words = words.Where((value, index) => index != 0).ToArray(); 
        }
        if (words[0].Equals("no") || words[0].Equals("not")) 
        { 
            words = words.Where((value, index) => index != 0).ToArray(); //There are no cars running here -> a car running
        }
        
        bool subjectRecognized = IsASingular(words[0]) || IsAProperNoun(words[0]);
        if (IsFixedLenght(words, 1)) return true; // There is a dog here -> becomes dog
        if (IsASingular(words[0]))
        {
            if (IsAPreposition(words[1])) return true; // There is no beef in here -> no beef in
            if (IsAnIngVerbs(words[1])) return true; // There is no beef in here -> no beef in
        }
        if (A(words[0]) && IsAPlural(words[1]))
        {
            if (IsAPreposition(words[2])) return true; // There is no beef in here -> no beef in
            if (IsAnIngVerbs(words[2])) return true; // There is no beef in here -> no beef in
        }
        if (IsAFrequencyAdverb(words[1]))
        {
            words = words.Where((value, index) => index != 1).ToArray(); // Mangia seconda posizione per togliere l'avv di frequenza
        }
        if (Is(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsAnIngVerbs(words[2])) // contains ing_verbs OR plurals OR ARTICLE_PREPOSITION 
            {
                if (IsFixedLenght(words, 3)) return true;
                if (IsAPlural(words[3])) return true; // eating sandwiches
                words = RemoveAdverbs(words, 3);
                if(!IsFixedLenght(words, 3))
                {
                    if (A(words[3]) || The(words[3]) || IsAPreposition(words[3])) // eating a/the sandwich
                    {
                        if (IsACommon(words[4])) return true;
                    }
                    if (IsACommon(words[3])) return true;
                    if (IsPastParticiple(words[3])) return true;
                    if (!IsFixedLenght(words, 4))
                    {
                        if (IsAPrasphalVerb(words[3], words[4])) return true;
                    }
                }
            }
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsAnIngVerbs(words[3])) return true;
                if (IsAnAdjective(words[3])) return true;
                if (IsAPrasphalVerb(words[2], words[3])) return true;
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
                if(!IsFixedLenght(words, 4))
                {
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
            }
            if (IsAnAdjective(words[2])) return true;
            if (IsPastParticiple(words[2])) return true;
            if(!IsFixedLenght(words, 3))
            {
                if (IsAPrasphalVerb(words[2], words[3])) return true;
            }
        }
        
        if (Hasnt(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (!IsFixedLenght(words, 3))
            {
                if (IsAPrasphalVerb(words[2], words[3])) return true;
            }
            if (The(words[2]) || A(words[2]) || IsAPossessivePronouns(words[2])) // The | a
            {
                if (IsASingular(words[3])) return true;
                if (IsAPlural(words[3])) return true;
            }
            if (Been(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
                if (IsAnIngVerbs(words[3])) // been being carefully repaired
                {
                    words = RemoveAdverbs(words, 4);
                    if (!IsFixedLenght(words, 4))
                    {
                        if (IsPastParticiple(words[4])) return true;
                        if(!IsFixedLenght(words, 5))
                        {
                            if (IsAPrasphalVerb(words[4], words[5])) return true;
                        }
                    }
                }
                if(!IsFixedLenght(words, 3))
                {
                    try
                    {
                        if (IsAPrasphalVerb(words[3], words[4])) return true;
                    }
                    catch (System.Exception e)
                    {
                        if (IsAPrasphalVerb(words[2], words[3])) return true;
                    }
                }
            }
            if (IsPastParticiple(words[2]))
            {
                if (!IsFixedLenght(words, 3))
                {
                    if (IsAPlural(words[3])) return true;
                    if (IsAnIngVerbs(words[3])) return true;
                    if (The(words[3]) || A(words[3]) || An(words[3]) || IsAPossessivePronouns(words[3]))
                    {
                        if (IsACommon(words[4])) return true;
                        if (IsAPlural(words[4])) return true;
                    }
                }
            }
        }
        if (Has(words[1]))
        {
            words = RemoveAdverbs(words, 2);  //         0   1   2    3
            words = RemoveAdverbs(words, 3); // The big car has not always been being carefully turned on today.
            if (IsPastParticiple(words[2]))
            {
                if(!IsFixedLenght(words, 3))
                {
                    if (The(words[3]) || A(words[3]) || An(words[3]) || IsAPossessivePronouns(words[3]))
                    {
                        if (IsACommon(words[4])) return true;
                        if (IsAPlural(words[4])) return true;
                    }
                }
            }
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3); //         0   1   2          3     4      5  
                if (!IsFixedLenght(words, 5))
                {
                    words = RemoveAdverbs(words, 5); //The big car has not always been being carefully turned on today.
                }
                if (Been(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (IsAnIngVerbs(words[4]))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsPastParticiple(words[5])) return true;
                        if (!IsFixedLenght(words, 5))
                        {
                            if (IsAPrasphalVerb(words[5], words[6])) return true;
                        }
                    }
                    if (!IsFixedLenght(words, 4))
                    {
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
                if (IsPastParticiple(words[3]))
                {
                    if (IsAPlural(words[4])) return true;
                    if (IsAnIngVerbs(words[4])) return true;
                    if (The(words[4]) || A(words[4]))
                    {
                        if (IsACommon(words[5])) return true;
                        if (IsAPlural(words[5])) return true;
                    }
                }
            }
            if (Been(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (!IsFixedLenght(words, 4))
                    {
                        if (IsPastParticiple(words[4])) return true;
                        if (!IsFixedLenght(words, 5)) {

                            if (IsAPrasphalVerb(words[4], words[5])) return true;
                        }
                    }
                }
                if (!IsFixedLenght(words, 3))
                {
                    try
                    {
                        if (IsAPrasphalVerb(words[3], words[4])) return true;
                    } catch(System.Exception e)
                    {
                        if (IsAPrasphalVerb(words[2], words[3])) return true;
                    }
                }
            }
            if (IsAnAdjective(words[2])) return true;
            if (The(words[2]) || A(words[2]) || IsAPossessivePronouns(words[2])) // The | a
            {
                if (IsASingular(words[3])) return true;
                if (IsAPlural(words[3])) return true;
            }
            if(!IsFixedLenght(words, 3))
            {
                if (IsAPrasphalVerb(words[2], words[3])) return true;
            }
        }

        if (Doesnt(words[1]) && (Have(words[2]) || IsABaseVerb(words[2])))
        {
            if (The(words[3]) || A(words[3])) // The | a
            {
                if (IsASingular(words[4])) return true;
            }
        }
        if (Does(words[1]) && Not(words[2]) && (Have(words[3]) || IsABaseVerb(words[3])))
        {
            string detectedPhrasalVerb = words[0] + " " + words[1]; // she wakes up
            if (phrasalVerbs.Contains(detectedPhrasalVerb))
            {
                words = words.Where((value, index) => index != 0 && index != 1).ToArray();
            }
            if (The(words[4]) || A(words[4]) || IsAPossessivePronouns(words[4])) // The | a
            {
                if (IsASingular(words[5])) return true;
                if (IsAPlural(words[5])) return true;
            }
        }

        if (IsA3rdPersonVerb(words[1])) // A/The guy drives a/the (big) car
        {
            if (IsFixedLenght(words, 2)) return true; // the cat jumps
            if (The(words[2]) || A(words[2])) // The | a
            {
                if (IsAnAdjective(words[3]))
                {
                    if (IsACommon(words[4])) return true;
                }
                if (IsACommon(words[3])) return true;
            }
            if (IsAPreposition(words[2]))
            {
                if (The(words[3]))
                {
                    if (IsACommon(words[4])) return true;
                }
            }
        }
        if (IsAPreposition(words[1])) // (there is/are) a book on the table
        {
            if (The(words[2]))
            {
                if (IsACommon(words[3]) || IsAPlural(words[3]))
                    return true;
            }
            if (IsAPlural(words[2])) return true;
        }
        if (Isnt(words[1])) 
        {
            words = RemoveAdverbs(words, 2);
            if (IsAnAdjective(words[2])) return true; // a car isn't big
            if (IsAnIngVerbs(words[2])) return true; // a car isn't running
            if (IsPastParticiple(words[2])) return true;
            if (IsAnIngVerbs(words[2]))
            {
                if (IsPastParticiple(words[3])) return true;
            }
            if (IsAPrasphalVerb(words[2], words[3])) return true;
        }
        if (IsASingular(words[0])) // There isn't a car running here -> a car running
        {
            if (IsAnIngVerbs(words[1])) return true;
        }
        if (!IsFixedLenght(words, 1))
        {
            if (Every(words[words.Length - 2])) // avverbio di tempo alla fine - gestire avverbi come every sunday
            {
                words = words.Where((value, index) => index != words.Length - 2 && index != words.Length - 1).ToArray(); // Mangia ultima posizione per togliere l'avv di tempo
            }
            words = RemoveAdverbs(words, 1);
            // she the child
            if (The(words[1]) || IsAnObjectPronouns(words[1]))
            {
                if (IsACommon(words[2]) || IsAPlural(words[2])) return true;
            }
            if (Is(words[1]))
            {
                if (IsAnIngVerbs(words[2])) // John is playing
                {
                    if (words.Length == 3) return true;
                    words = RemoveAdverbs(words, 3);
                    if ((IsAPreposition(words[3]) && The(words[4])) || The(words[3])) // in the gardent
                    {
                        if (IsACommon(words[4]) || IsAPlural(words[4])) return true;
                    }
                    if (A(words[3])) // a
                    {
                        if (IsACommon(words[4])) return true; // letter
                    }
                }
                if (Not(words[2]))
                {
                    words = RemoveAdverbs(words, 3);
                    if (IsAPreposition(words[3]) || The(words[3]) || words[3].Equals("a")) // in the gardent
                    {
                        if (IsACommon(words[4]) || IsAPlural(words[4])) return true;
                        if (IsAnAdjective(words[4]))
                        {
                            if (IsACommon(words[5]) || IsAPlural(words[5])) return true;
                        }
                    }
                    if (IsAnIngVerbs(words[3])) // John is playing
                    {
                        if (words.Length == 4) return true;
                        words = RemoveAdverbs(words, 4);
                        if ((IsAPreposition(words[4]) && The(words[5])) || The(words[4])) // in the gardent
                        {
                            if (IsACommon(words[5]) || IsAPlural(words[5])) return true;
                        }
                        if (A(words[4])) // a
                        {
                            if (IsACommon(words[5])) return true; // letter
                        }
                    }
                    if (IsAnAdjective(words[3])) return true;
                    if (IsPastParticiple(words[3])) return true;
                }
                if (IsAPreposition(words[2]))
                {
                    if (IsACommon(words[3]) || IsAPlural(words[3])) return true;
                }
                else
                {
                    if (A(words[2]) || The(words[2])) // Paris is a (big) city
                    {
                        if (IsAnAdjective(words[3]))
                        {
                            if (IsACommon(words[4])) return true;
                        }
                        if (IsACommon(words[3])) return true;
                    }
                    if (IsAnAdjective(words[2])) return true;
                }
            }
            if (Has(words[1]))
            {
                words = RemoveAdverbs(words, 2);
                if (The(words[2]) || A(words[2]))
                {
                    if (IsASingular(words[3])) return true;
                }
                else
                {
                    if (IsAnAdjective(words[2]))
                    {
                        if (IsAPlural(words[3])) return true; // John loves big books
                    }
                    if (IsAPlural(words[2])) return true;// john loves books
                }
            }
            if (Doesnt(words[1])) // "doesn't"
            {
                if (IsAFrequencyAdverb(words[2]))
                {
                    words = words.Where((value, index) => index != 1).ToArray(); // he doesn't always
                }
                if (Have(words[2]) || IsABaseVerb(words[2]))
                {
                    if (The(words[3]) || A(words[3])) // The | a
                    {
                        if (IsASingular(words[4])) return true;
                    }
                    if (IsAPreposition(words[3]))
                    {
                        if (IsACommon(words[4])) return true;
                        if (IsAnObjectPronouns(words[4])) return true;
                    }
                    if (IsASingular(words[4]) || IsAPlural(words[4])) return true;
                }
                if (!IsFixedLenght(words, 4))
                {
                    if (IsASingular(words[4]) || IsAPlural(words[4])) return true;
                }
            }
            if (Does(words[1]) && Not(words[2]) && (Have(words[3]) || IsABaseVerb(words[3])))
            {
                if (IsAnObjectPronouns(words[4])) // she does not visit her
                {
                    if (IsACommon(words[5]) || IsAPlural(words[5])) return true; // grandparents....
                }
                if (The(words[4]) || A(words[4])) // The | a
                {
                    if (IsASingular(words[5])) return true;
                }
                if (IsASingular(words[4]) || IsAPlural(words[4])) return true;
            }
            if (IsA3rdPersonVerb(words[1])) // A/The guy drives a/the (big) car
            {
                if (!IsFixedLenght(words, 2))
                {
                    if (The(words[2]) || A(words[2])) // The | a
                    {
                        if (IsAnAdjective(words[3]))
                        {
                            if (IsACommon(words[4])) return true;
                        }
                        if (IsACommon(words[3])) return true;
                    }
                    if (IsACommon(words[2]) || IsAPluralSubject(words[2])) return true;
                    if (IsACommon(words[2]) || IsAPluralSubject(words[2]) || IsAnObjectPronouns(words[2]))
                    {
                        if (IsACommon(words[3]) || IsAPlural(words[3])) return true;
                    }
                    if (IsAnAdjective(words[2]))
                    {
                        if (IsACommon(words[3]) || IsAPlural(words[3])) return true;
                    }
                    if (IsAnIngVerbs(words[2])) return true;
                    if (IsAPreposition(words[2]))
                    {
                        if (IsACommon(words[3]) || IsAPlural(words[3]) || IsAnObjectPronouns(words[3])) return true;
                        if (The(words[3]) || A(words[3])) // she believes in the/a miracle
                        {
                            if (IsACommon(words[4]) || IsAPlural(words[4])) return true;
                        }
                    }
                }
                return true; // she walks
            }
            if (IsA3rdPersonVerb(words[1])) // A/The guy drives a/the (big) car
            {
                if (!IsFixedLenght(words, 2))
                {
                    if (The(words[2]) || A(words[2])) // The | a
                    {
                        if (IsAnAdjective(words[3]))
                        {
                            if (IsACommon(words[4])) return true;
                        }
                        if (IsACommon(words[3])) return true;
                    }
                    if (IsACommon(words[2]) || IsAPluralSubject(words[2])) return true;
                    if (IsACommon(words[2]) || IsAPluralSubject(words[2]) || IsAnObjectPronouns(words[2]))
                    {
                        if (IsACommon(words[3]) || IsAPlural(words[3])) return true;
                    }
                    if (IsAnAdjective(words[2]))
                    {
                        if (IsACommon(words[3]) || IsAPlural(words[3])) return true;
                    }
                    if (IsAnIngVerbs(words[2])) return true;
                    if (IsAPreposition(words[2]))
                    {
                        if (IsACommon(words[3]) || IsAPlural(words[3]) || IsAnObjectPronouns(words[3])) return true;
                        if (The(words[3]) || A(words[3])) // she believes in the/a miracle
                        {
                            if (IsACommon(words[4]) || IsAPlural(words[4])) return true;
                        }
                    }
                }
            }
            if (IsAnAdjective(words[0]))
            {
                if (IsASingular(words[1]) || IsAPlural(words[1]))
                {
                    if (IsAnIngVerbs(words[2])) return true;
                }
            }
        }
        if (!IsFixedLenght(words, 2))
        {
            if (IsAFrequencyAdverb(words[2]))
            {
                words = words.Where((value, index) => index != 2).ToArray(); // Mangia seconda posizione per togliere l'avv di frequenza - He doesn’t ALWAYS agree with me.
            }
        }
        if (I(words[0]))
        {
            if (Dont(words[1]))
            {
                if (Have(words[2]) || IsABaseVerb(words[2])) // i do play
                {
                    if (The(words[3]))
                    {
                        if (IsACommon(words[4])) return true; // i do play the guitar
                    }
                    if (IsAPlural(words[3])) return true; // i do like apples
                    if (IsACommon(words[3])) return true;// i do not have time now
                }
                if (IsAFrequencyAdverb(words[3])) // messo qui altrimenti frasi come John like books schiattano
                {
                    words = words.Where((value, index) => index != 2).ToArray(); // I do not ALWAYS ....
                }
                if (IsABaseVerb(words[3])) // i do not play
                {
                    if (The(words[4]))
                    {
                        if (IsACommon(words[4])) return true;// i do not play the guitar
                    }
                    if (IsAPlural(words[4])) return true;// i do not like apples
                    return true;
                }
            }
            if (Do(words[1]))
            {
                if (IsABaseVerb(words[2])) // i do play
                {
                    if (The(words[3]))
                    {
                        if (IsACommon(words[4])) return true; // i do play the guitar
                    }
                    if (IsAPlural(words[3])) return true;// i do like apples
                    return true;
                }
                if (Not(words[2])) // i do not
                {
                    if (IsAFrequencyAdverb(words[3])) // messo qui altrimenti frasi come John like books schiattano
                    {
                        words = words.Where((value, index) => index != 2).ToArray(); // I do not ALWAYS ....
                    }
                    if (IsABaseVerb(words[3]) || Have(words[3])) // i do not play
                    {
                        if (The(words[4]))
                        {
                            if (IsACommon(words[4])) return true;// i do not play the guitar
                        }
                        if (IsAPlural(words[4])) return true; // i do not like apples
                        if (IsACommon(words[4])) return true; // i do not play the guitar
                        return true;
                    }
                }
            }
            // i drink coffee in the morning
            if (IsABaseVerb(words[1])) // i play
            {
                if (The(words[2]))
                {
                    if (IsACommon(words[3])) return true;// i play the guitar
                }
                if (IsAPlural(words[2])) return true; // i like apples
                return true;
            }
            if (Not(words[2])) // i do not
            {
                if (IsABaseVerb(words[3])) // i do not play
                {
                    if (The(words[4]))
                    {
                        if (IsACommon(words[5])) return true; // i do not play the guitar
                    }
                    if (IsAPlural(words[4])) return true; // i do not like apples
                }
            }
        }
        if (IsPastParticiple(words[1]))
        {
            if (The(words[2]) || A(words[2]) || An(words[2]) || IsAPossessivePronouns(words[2]))
            {
                if (IsACommon(words[3])) return true;
                if (IsAPlural(words[3])) return true;
            }
        }
        
        if (Wasnt(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsAnIngVerbs(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsAnAdjective(words[3])) return true;
                if (IsPastParticiple(words[3])) return true;
                if (IsAPrasphalVerb(words[3], words[4])) return true;
            }
            if (IsPastParticiple(words[2])) return true;
            if (The(words[2]) || A(words[2]))
            {
                if (IsASingular(words[3])) return true;
            }
            if (IsAnAdjective(words[2])) return true;
            if (IsAPrasphalVerb(words[2], words[3])) return true;
        }
        if (Was(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (!IsFixedLenght(words, 4))
            {
                words = RemoveAdverbs(words, 4);
            }
            if (IsPastParticiple(words[2])) return true;
            if (The(words[2]) || A(words[2]))
            {
                if (IsASingular(words[3])) return true;
            }
            if (IsAnAdjective(words[2])) return true;
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsAnAdjective(words[4])) return true;
                    if (IsPastParticiple(words[4])) return true;
                    if (!IsFixedLenght(words, 4))
                    {
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
                if (IsAnAdjective(words[3])) return true;
                if (IsPastParticiple(words[2])) return true;
                if (IsPastParticiple(words[3])) return true;
                if(!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }

            }
            if (IsPastParticiple(words[3])) return true;
            if (IsAnIngVerbs(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
                if (IsAPrasphalVerb(words[3], words[4])) return true;
            }
            if (IsAPrasphalVerb(words[2], words[3])) return true;
        }
        
        if (Had(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (Been(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (IsAnIngVerbs(words[4]))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsPastParticiple(words[5])) return true;
                        if (!IsFixedLenght(words, 6))
                        {
                            words = RemoveAdverbs(words, 6);
                            if (IsAPrasphalVerb(words[5], words[6])) return true;
                        }
                    }
                }
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (!IsFixedLenght(words, 5))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
            }
            if (Been(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (!IsFixedLenght(words, 5))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
            }
        }
        if (Hadnt(words[1])) 
        {
            words = RemoveAdverbs(words, 2);
            if (Been(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (!IsFixedLenght(words, 5))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
                if (!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
            }
        }
        
        if (Will(words[1])) 
        {
            words = RemoveAdverbs(words, 2);
            if (IsABaseVerb(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (!IsFixedLenght(words, 5))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
                if (!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
            }
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if(!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                }
                if (IsABaseVerb(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (IsAnIngVerbs(words[4]))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsPastParticiple(words[5])) return true;
                        if (!IsFixedLenght(words, 6))
                        {
                            words = RemoveAdverbs(words, 6);
                            if (IsAPrasphalVerb(words[5], words[6])) return true;
                        }
                    }
                    if (!IsFixedLenght(words, 5))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
                if (Have(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (!IsFixedLenght(words, 5))
                    {
                        words = RemoveAdverbs(words, 5);
                    }
                    if (Been(words[4]))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsPastParticiple(words[5])) return true;
                        if (IsAnIngVerbs(words[5]))
                        {
                            words = RemoveAdverbs(words, 6);
                            if (IsPastParticiple(words[6])) return true;
                            if (IsAPrasphalVerb(words[6], words[7])) return true;
                        }
                        if (!IsFixedLenght(words, 6))
                        {
                            if (IsAPrasphalVerb(words[5], words[6])) return true;
                        }
                    }
                }
                if (IsAPrasphalVerb(words[3], words[4])) return true;
            }
            if (Have(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (Been(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (IsAnIngVerbs(words[4]))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsPastParticiple(words[5])) return true;
                        if (IsAPrasphalVerb(words[5], words[6])) return true;
                    }
                }
            }
        }
        if (Wont(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsABaseVerb(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (!IsFixedLenght(words, 5))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
                if (!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
            }
            if (Have(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (Been(words[3])) 
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (IsAnIngVerbs(words[4]))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsPastParticiple(words[5])) return true;
                        if (IsAPrasphalVerb(words[5], words[6])) return true;
                    }
                }
            }
        }
        // going to
        if (!IsFixedLenght(words, 2)){
            if (Am(words[1]) || Is(words[1]) || Are(words[1]))
            {
                if(!IsFixedLenght(words, 3))
                {
                    if (GoingTo(words[2], words[3]))
                    {
                        words = RemoveAdverbs(words, 4);
                        if (IsABaseVerb(words[4])) return true;
                        if (!IsFixedLenght(words, 4))
                        {
                            if (IsABaseVerb(words[4]))
                            {
                                if (IsACommon(words[5])) return true;
                                if (IsAPlural(words[5])) return true;
                            }
                            if(!IsFixedLenght(words, 5))
                            {
                                if (IsAPrasphalVerb(words[4], words[5])) return true;
                                if (IsAPrasphalVerb(words[4], words[5]))
                                {
                                    if (IsAPlural(words[6])) return true;
                                    if (IsACommon(words[6])) return true;
                                }
                            }
                        }
                    }
                }
            }
        }
        // used to
        if (!IsFixedLenght(words, 2))
        {
            if (UsedTo(words[1], words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsABaseVerb(words[3])) return true;
                if (!IsFixedLenght(words, 3))
                {
                    if (IsABaseVerb(words[3]))
                    {
                        if (IsACommon(words[4])) return true;
                        if (IsAPlural(words[4])) return true;
                    }
                }
            }
        }

        if (Didnt(words[1])) 
        {
            // use to
            if (!IsFixedLenght(words, 3))
            {
                if (UseTo(words[2], words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (!IsFixedLenght(words, 4))
                    {
                        if (IsABaseVerb(words[4]))
                        {
                            if (!IsFixedLenght(words, 5))
                            {
                                if (IsACommon(words[5])) return true;
                                if (IsAPlural(words[5])) return true;
                            }
                            return true;
                        }
                    }
                    if (IsABaseVerb(words[4])) return true;
                }
            }
            // I didn't always carefully play soccer yesterday.
            words = RemoveAdverbs(words, 2);
            if (!IsFixedLenght(words, 3))
            {
                words = RemoveAdverbs(words, 3);
                if (IsABaseVerb(words[2]))
                {
                    if (IsAPlural(words[3])) return true;
                    if (IsACommon(words[3])) return true;
                }
                if (IsABaseVerb(words[3])) return true;
                if (IsAPrasphalVerb(words[2], words[3]))
                {
                    if (IsAPlural(words[4])) return true;
                    if (The(words[4]) || A(words[4]) || An(words[4]))
                    {
                        if (IsACommon(words[5])) return true;
                    }
                }
            }
        }
        if (Did(words[1])) 
        {
            words = RemoveAdverbs(words, 2);
            if (!IsFixedLenght(words, 3))
            {
                words = RemoveAdverbs(words, 3);
                if (IsABaseVerb(words[2]))
                {
                    if (IsAPlural(words[3])) return true;
                    if (IsACommon(words[3])) return true;
                }
                if (IsABaseVerb(words[3])) return true;
                if (IsAPrasphalVerb(words[2], words[3])) return true;
                if (IsAPrasphalVerb(words[2], words[3]))
                {
                    if (IsAPlural(words[4])) return true;
                    if (The(words[4]) || A(words[4]) || An(words[4])) {
                        if (IsACommon(words[5])) return true;
                    }  
                }
            }
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsABaseVerb(words[3]))
                    {
                        if (IsAPlural(words[4])) return true;
                        if (IsACommon(words[4])) return true;
                    }
                    if (IsABaseVerb(words[4])) return true;
                    if (IsAPrasphalVerb(words[3], words[4]))
                    {
                        if (IsAPlural(words[5])) return true;
                        if (The(words[5]) || A(words[5]) || An(words[5]))
                        {
                            if (IsACommon(words[6])) return true;
                        }
                    }
                }
            }
        }

        if (IsAModal(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsABaseVerb(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
            }
            if (IsAPrasphalVerb(words[3], words[4])) return true;
        }
        return false; 
    }
    public static bool PluralSubjectPresentSimple_Affirmation(string[] words)
    {
        words = Normalization(words);

        if (possessivePronouns.Contains(words[0])) { words = words.Where((value, index) => index != 0).ToArray(); }

        if (The(words[0]) || A(words[0])) { words = words.Where((value, index) => index != 0).ToArray(); }
        if (IsAnAdjective(words[0])) { words = words.Where((value, index) => index != 0).ToArray(); }
        if (words[0].Equals("no") || words[0].Equals("not")) { words = words.Where((value, index) => index != 0).ToArray(); } //There are no cars running here -> a car running
        if (IsAPlural(words[0]))
        {
            if (IsAPreposition(words[1])) return true; // There is no beef in here -> no beef in
            if (IsAnIngVerbs(words[1])) return true; // There is no beef in here -> no beef in
        }
        if (A(words[0]) && IsAPlural(words[1]))
        {
            if (IsAPreposition(words[2])) return true; // There is no beef in here -> no beef in
            if (IsAnIngVerbs(words[2])) return true; // There is no beef in here -> no beef in
        }
        
        bool subjectRecognized = IsAPluralSubject(words[0]) || IsAPlural(words[1]);
        if (Have(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (!IsFixedLenght(words, 3))
            {
                words = RemoveAdverbs(words, 3);
            }
            if (IsPastParticiple(words[2]))
            {
                if (The(words[3]) || A(words[3]) || An(words[3]) || IsAPossessivePronouns(words[3]))
                {
                    if (IsACommon(words[4])) return true;
                }
                if (The(words[3]) || IsAPossessivePronouns(words[3]))
                {
                    if (IsAPlural(words[4])) return true;
                }
            }
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                }
                if (IsAnAdjective(words[3])) return true;
                if (IsPastParticiple(words[2]))
                {
                    if (The(words[3]) || A(words[3]) || An(words[3]) || IsAPossessivePronouns(words[3]))
                    {
                        if (IsACommon(words[4])) return true;
                    }
                    if (The(words[3]) || IsAPossessivePronouns(words[3]))
                    {
                        if (IsAPlural(words[4])) return true;
                    }
                }
                if (Been(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (IsAnIngVerbs(words[4]))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsPastParticiple(words[5])) return true;
                        if (IsAPrasphalVerb(words[5], words[6])) return true;
                    }
                    if (!IsFixedLenght(words, 4))
                    {
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
                if (IsPastParticiple(words[3]))
                {
                    if (IsAPlural(words[4])) return true;
                    if (IsAnIngVerbs(words[4])) return true;
                    if (The(words[4]) || A(words[4]) || IsAPossessivePronouns(words[4]))
                    {
                        if (IsACommon(words[5])) return true;
                        if (IsAPlural(words[5])) return true;
                    }
                }
            }
            if (The(words[2]) || A(words[2]))
            {
                if (IsASingular(words[3])) return true;
            }
            if (IsAnAdjective(words[2])) return true;
            if (Been(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                }
                if (IsPastParticiple(words[3])) return true;
                if (IsAnIngVerbs(words[3]))
                {
                    if (!IsFixedLenght(words, 4))
                    {
                        words = RemoveAdverbs(words, 4);
                    }
                    if (IsPastParticiple(words[4])) return true;
                    if (!IsFixedLenght(words, 5))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
                if (!IsFixedLenght(words, 3))
                {
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
            }
            if (IsAPrasphalVerb(words[2], words[3])) return true;
        }
        if (Do(words[1]) && Not(words[2]) && (Have(words[3]) || IsABaseVerb(words[3])))
        {
            if (IsFixedLenght(words,4)) return true; // The Dogs do not run
            if (IsAnAdjective(words[4])) return true; // The Dogs do not run fast
            if (The(words[3]) || A(words[3]) || IsAPossessivePronouns(words[3])) {
                if (IsASingular(words[4])) return true;
                if (IsAPlural(words[4])) return true;
                if (IsAnAdjective(words[4]))
                {
                    if (IsASingular(words[4])) return true;
                    if (IsAPlural(words[4])) return true;
                }
            }
        }
        if (Are(words[1]) || Arent(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsAnIngVerbs(words[2])) // the dogs are playing
            {
                if(IsFixedLenght(words, 3)) return true;
                if (IsAPreposition(words[3]) && The(words[4])) // in/on the gardent
                {
                    if (IsACommon(words[5]) || IsAPlural(words[5])) return true;
                }
            }
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsAnIngVerbs(words[3])) // the dogs are not playing
                {
                    if (words.Length == 4) return true;
                    if (IsAPreposition(words[4]) && The(words[5])) // in/on the gardent
                    {
                        if (IsACommon(words[6]) || IsAPlural(words[6])) return true;
                    }
                }
                if (!IsFixedLenght(words, 4))
                {
                    if (IsAnAdjective(words[4]))
                    {
                        return true;
                    }
                }
                if (IsPastParticiple(words[3])) return true;
            }
            if (IsAnAdjective(words[2])) return true;
            if (IsPastParticiple(words[2])) return true;
        }
        if (IsABaseVerb(words[1])) // A/The dogs run fast
        {
            if (IsFixedLenght(words, 2)) return true; // the dogs run
            if (IsFixedLenght(words,3)) return true; // Cat jump
            if (IsAnAdjective(words[2])) return true;
            if (IsAPreposition(words[2]))       
            {
                if (The(words[3]) || IsAnObjectPronouns(words[3]))
                {
                    if (IsACommon(words[4]) || IsAPlural(words[4])) return true;
                }
            }
            if (The(words[2]) || A(words[2]) || IsAPossessivePronouns(words[2])) // The | a
            {
                if (IsACommon(words[3]) || IsAPlural(words[3])) return true;
                if (IsAnAdjective(words[3])) { IsACommon(words[4]); }
                else { IsACommon(words[3]); }
            }
            if (IsAnObjectPronouns(words[2]))
            {
                IsAPlural(words[3]);
                IsACommon(words[3]);
            }
            if (IsAnAdjective(words[2]))
            {
                IsAPlural(words[3]);
                IsACommon(words[3]);
            }
            IsAPlural(words[2]);
            IsACommon(words[2]);
        }
        if (Arent(words[1]))
        {
            if (IsAnAdjective(words[2])) return true; // the cars aren't big.
        }
        if (IsAPlural(words[0])) // There aren't cars running here -> a car running
        {
            if (IsAnIngVerbs(words[1])) return true;
        }
        if (IsAnAdjective(words[0]))
        {
            if (IsAPlural(words[1])) // There aren't cars running here -> a car running
            {
                if (IsAnIngVerbs(words[2])) return true;
                if (Are(words[2]) && IsAnIngVerbs(words[3])) return true;
                if (Are(words[2]) && Not(words[3]) && IsAnIngVerbs(words[4])) return true;
                if (Arent(words[2]) && IsAnIngVerbs(words[3])) return true;
            }
        }
        if (IsFixedLenght(words, 1) && subjectRecognized) return true;
        if (IsAFrequencyAdverb(words[1])) // there are dogs here -> dogs -> outOfBoundEx
        {
            words = words.Where((value, index) => index != 1).ToArray(); // Mangia seconda posizione per togliere l'avv di frequenza
        }
        if (The(words[1]) || IsAnObjectPronouns(words[1]))
        {
            if (IsACommon(words[2]) || IsAPlural(words[2])) return true; // this has to remain like this cause of phrasal verbs cause in some case we must RETURN the control
        }
        if (Dont(words[1]) && (Have(words[2]) || IsABaseVerb(words[2])))
        {
            if (IsFixedLenght(words, 4)) return true;
            if (IsAnAdjective(words[4])) return true;  // The Dogs do not run fast
            if (The(words[3]) || A(words[3]) || IsAPossessivePronouns(words[3]))
            {
                if (IsASingular(words[4])) return true;
                if (IsAPlural(words[4])) return true;
                if (IsAnAdjective(words[4]))
                {
                    if (IsASingular(words[4])) return true;
                    if (IsAPlural(words[4])) return true;
                }
            }
        }
        if (Are(words[1]) || Arent(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsFixedLenght(words, 2)) return true; // they are
            if (IsAnIngVerbs(words[2])) return true;
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsFixedLenght(words, 3)) return true;// they are not
                if (IsAnIngVerbs(words[3])) return true;// they are not standig (here)
                if (IsAnAdjective(words[3])) return true;
                if (!IsFixedLenght(words, 4))
                {
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
            }
            if (IsAPreposition(words[2]))
            {
                if (IsACommon(words[3])) return true;
            }
            if (IsAnAdjective(words[2])) return true;
            if (IsAPrasphalVerb(words[2], words[3])) return true;
        }
        if (IsAPreposition(words[1])) // (there is) a book on the table
        {
            if (!IsFixedLenght(words, 2))
            {
                if (The(words[2]))
                {
                    IsAPlural(words[3]);
                    IsACommon(words[3]);
                }
            }
        }
        if (Do(words[1]))
        {
            if (IsABaseVerb(words[2])) // they do play
            {
                if (The(words[3]))
                {
                    IsACommon(words[4]); // they do play the guitar
                }
                IsAPlural(words[3]); // i do like apples
            }
            if (Not(words[2])) // they do not
            {
                if (IsAFrequencyAdverb(words[3]))
                {
                    words = words.Where((value, index) => index != 3).ToArray(); // I do not ALWAYS ....
                }
                if (IsABaseVerb(words[3])) // i do not play
                {
                    if (The(words[4])) { IsACommon(words[4]); }// i do not play the guitar
                    IsAPlural(words[3]); // they do not like apples
                    return true;
                }
            }
        }
        if (IsAnIngVerbs(words[1])) return true; // cars running
        if (Havent(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsPastParticiple(words[2]))
            {
                if (The(words[3]) || A(words[3]) || An(words[3]) || IsAPossessivePronouns(words[3]))
                {
                    if (IsACommon(words[4])) return true;
                }
                if (The(words[3]) || IsAPossessivePronouns(words[3]))
                {
                    if (IsAPlural(words[4])) return true;
                }
            }
            if (The(words[2]) || A(words[2]))
            {
                if (IsASingular(words[3])) return true;
            }
            if (IsAnAdjective(words[2])) return true;
            if (Been(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (!IsFixedLenght(words, 4)){
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
                if (!IsFixedLenght(words, 3))
                {
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
            }
            if (IsAnIngVerbs(words[2]))
            {
                words = RemoveAdverbs(words, 4);
                if (IsPastParticiple(words[3])) return true;
            }
            if (IsAPrasphalVerb(words[2], words[3])) return true;
        }
        if (Werent(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsPastParticiple(words[2])) return true;
            if (IsAnAdjective(words[2])) return true;
            if (The(words[2]) || A(words[2]))
            {
                if (IsASingular(words[3])) return true;
            }
            if (IsAnAdjective(words[2])) return true;
            if (IsAnIngVerbs(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
                if (IsPastParticiple(words[3])) return true;
            }
            if (IsAPrasphalVerb(words[2], words[3])) return true;

        }
        if (Were(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsPastParticiple(words[2])) return true;
            if (The(words[2]) || A(words[2]))
            {
                if (IsASingular(words[3])) return true;
            }
            if (IsAnAdjective(words[2])) return true;
            if (IsAnIngVerbs(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
                if (IsPastParticiple(words[3])) return true;
            }
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsAnAdjective(words[3])) return true;
                if (Been(words[3]))
                {
                    if (IsAMannerAdverbs(words[4]))
                    {
                        words = words.Where((value, index) => index != 4).ToArray();
                    }
                    if (IsPastParticiple(words[4])) return true;
                }
                if (IsPastParticiple(words[3])) return true;
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (!IsFixedLenght(words, 5))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                    
                    if (IsPastParticiple(words[4])) return true;
                }
                if(!IsFixedLenght(words, 4))
                {
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
            }
            if (IsAPrasphalVerb(words[2], words[3])) return true;
        }
        if (Had(words[1]))
        {
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (Been(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (!IsFixedLenght(words, 5))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                }
            }
            words = RemoveAdverbs(words, 2);
            if (Been(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
                if (!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
            }
        }
        if (Hadnt(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (Been(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
                if (!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
            }

        }
        if (Will(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsABaseVerb(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                }
            }
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsABaseVerb(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (IsAnIngVerbs(words[4]))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsPastParticiple(words[5])) return true;
                    }
                }
                if (Have(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsABaseVerb(words[4]))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsPastParticiple(words[5])) return true;
                        if (IsAnIngVerbs(words[5]))
                        {
                            words = RemoveAdverbs(words, 6);
                            if (IsPastParticiple(words[6])) return true;
                        }
                    }
                    if (Been(words[4]))
                    {
                        words = RemoveAdverbs(words, 4);
                        if (IsPastParticiple(words[4])) return true;
                        if (!IsFixedLenght(words, 5))
                        {
                            words = RemoveAdverbs(words, 5);
                            if (IsAPrasphalVerb(words[4], words[5])) return true;
                        }
                    }
                }
            }
            if (Have(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsABaseVerb(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (IsAnIngVerbs(words[4]))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsPastParticiple(words[5])) return true;
                    }
                }
                if (Been(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (!IsFixedLenght(words, 4))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
            }
        }
        if (Wont(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsABaseVerb(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
                if (IsAnIngVerbs(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                }
            }
            if (Have(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsABaseVerb(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsPastParticiple(words[4])) return true;
                    if (IsAnIngVerbs(words[4]))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsPastParticiple(words[5])) return true;
                    }
                }
                if (Been(words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (!IsFixedLenght(words, 5))
                    {
                        words = RemoveAdverbs(words, 5);
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
            }
        }
        // going to - RemoveDuplication!!!!
        if (!IsFixedLenght(words, 2))
        {
            if (Am(words[1]) || Is(words[1]) || Are(words[1]))
            {
                if (!IsFixedLenght(words, 3))
                {
                    if (GoingTo(words[2], words[3]))
                    {
                        words = RemoveAdverbs(words, 4);
                        if (IsABaseVerb(words[4])) return true;
                        if (!IsFixedLenght(words, 4))
                        {
                            if (IsABaseVerb(words[4]))
                            {
                                if (IsACommon(words[5])) return true;
                                if (IsAPlural(words[5])) return true;
                            }
                            if (!IsFixedLenght(words, 5))
                            {
                                if (IsAPrasphalVerb(words[4], words[5])) return true;
                                if (IsAPrasphalVerb(words[4], words[5]))
                                {
                                    if (IsAPlural(words[6])) return true;
                                    if (IsACommon(words[6])) return true;
                                }
                            }
                        }
                    }
                }
            }
        }
        // used to
        if (!IsFixedLenght(words, 2))
        {
            if (UsedTo(words[1], words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsABaseVerb(words[3])) return true;
                if (!IsFixedLenght(words, 3))
                {
                    if (IsABaseVerb(words[3]))
                    {
                        if (IsACommon(words[4])) return true;
                        if (IsAPlural(words[4])) return true;
                    }
                }
            }
        }

        if (Didnt(words[1]))
        {
            // use to
            if (!IsFixedLenght(words, 3))
            {
                if (UseTo(words[2], words[3]))
                {
                    words = RemoveAdverbs(words, 4);
                    if (!IsFixedLenght(words, 4))
                    {
                        if (IsABaseVerb(words[4]))
                        {
                            if (!IsFixedLenght(words, 5))
                            {
                                if (IsACommon(words[5])) return true;
                                if (IsAPlural(words[5])) return true;
                            }
                            return true;
                        }
                    }
                    if (IsABaseVerb(words[4])) return true;
                }
            }
            // They didn't always carefully play soccer yesterday.
            words = RemoveAdverbs(words, 2);
            if (!IsFixedLenght(words, 3))
            {
                words = RemoveAdverbs(words, 3);
                if (IsABaseVerb(words[2]))
                {
                    if (IsAPlural(words[3])) return true;
                    if (IsACommon(words[3])) return true;
                }
                if (IsABaseVerb(words[3])) return true;
            }
        }
        if (Did(words[1]))
        {
            // "they did always carefully play soccer yesterday.",
            words = RemoveAdverbs(words, 2);
            if (!IsFixedLenght(words, 3))
            {
                words = RemoveAdverbs(words, 3);
                if (IsABaseVerb(words[2]))
                {
                    if (IsAPlural(words[3])) return true;
                    if (IsACommon(words[3])) return true;
                }
                if (IsABaseVerb(words[3])) return true;
            }
            if (Not(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (!IsFixedLenght(words, 4))
                {
                    words = RemoveAdverbs(words, 4);
                    if (IsABaseVerb(words[3]))
                    {
                        if (IsAPlural(words[4])) return true;
                        if (IsACommon(words[4])) return true;
                    }
                    if (IsABaseVerb(words[4])) return true;
                }
            }
        }

        if (IsAModal(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsABaseVerb(words[2]))
            {
                words = RemoveAdverbs(words, 3);
                if (IsPastParticiple(words[3])) return true;
            }
            if (IsAPrasphalVerb(words[3], words[4])) return true;
        }
        return false;
    }
    public static string[] RemoveAdverbs(string[] words, int position)
    {
        if (position >= words.Length) position = position - 1;//return words;
        if (words.Length == 3)
        {
            if (IsAMannerAdverbs(words[position]))
            {
                words = words.Where((value, index) => index != position).ToArray();
            }
            if (IsAPlaceAdverbs(words[position]))
            {
                words = words.Where((value, index) => index != position).ToArray();
            }
            if (!IsFixedLenght(words, 2))
            {
                if (IsAFrequencyAdverb(words[position]))
                {
                    words = words.Where((value, index) => index != position).ToArray();
                }
            }
            return words;
        }
        if (!IsFixedLenght(words, position))
        {
            if (IsAMannerAdverbs(words[position]))
            {
                words = words.Where((value, index) => index != position).ToArray();
            }
        }
        if (!IsFixedLenght(words, position))
        {
            if (IsAFrequencyAdverb(words[position]))
            {
                words = words.Where((value, index) => index != position).ToArray();
            }
        }
        position++;
        if(position >= words.Length)
        {
            position = words.Length-1;
        }
        if(IsFixedLenght(words, position))
        {
            if (IsAFrequencyAdverb(words[position - 1]) && IsAMannerAdverbs(words[position]))
            {
                words = words.Where((value, index) => index != position - 1 && index != position).ToArray();
            }
            if (IsAMannerAdverbs(words[position]))
            {
                words = words.Where((value, index) => index != position).ToArray();
            }
        } 
        return words;
    }
    public static string[] Normalization(string[] words) // se clicchi sulla parola, la aggiungi all'array e poi vedi se la frase è corretta
    {
        List<string> list = new List<string>(words);
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].ToLower();
            if (words[words.Length - 1].Contains("?"))
            {
                words[words.Length - 1].TrimEnd('?');
            }
            if (i < words.Length - 1 && words[i].Equals("so") && (words[i + 1].Equals("much") || words[i + 1].Equals("many")))
            {
                list.Remove(words[i]);
                list.Remove(words[i + 1]);
                words = list.ToArray();
            }
            if (i < words.Length - 1 && words[i].Equals("so") && (IsAMannerAdverbs(words[i + 1])))
            {
                list.Remove(words[i]);
                list.Remove(words[i + 1]);
                words = list.ToArray();
            }
        }
        if (There(words[0]) && Are(words[1]) && Not(words[2]))
        {
            words = words.Skip(3).ToArray();
        }
        if (There(words[0]) && Arent(words[1]) && Not(words[2]))
        {
            words = words.Skip(2).ToArray();
        }
        if (There(words[0]) && Is(words[1]) && Not(words[2])) { words = words.Skip(3).ToArray(); }
        if (There(words[0]) && Isnt(words[1]) && Not(words[2])) { words = words.Skip(3).ToArray(); }
        if (There(words[0]) && Are(words[1]))
        {
            words = words.Skip(2).ToArray();
        }
        if (There(words[0]) && Arent(words[1]))
        {
            words = words.Skip(2).ToArray();
        }
        if (There(words[0]) && Is(words[1])) 
        { 
            words = words.Skip(2).ToArray(); 
        }
        if (There(words[0]) && Isnt(words[1]))
        { 
            words = words.Skip(2).ToArray(); 
        }
        if (Every(words[words.Length - 2])) // avverbio di tempo alla fine - gestire avverbi come every sunday
        {
            words = words.Where((value, index) => index != words.Length - 2 && index != words.Length - 1).ToArray(); // Mangia ultima posizione per togliere l'avv di tempo
        }
        
        // Phrasal Verbs
        string tmpPhrasalVerb = "";
        string detectedPhrasalVerb = "";
        if (words.Length > 3)
        {
            tmpPhrasalVerb = words[1] + " " + words[2]; // she wakes up
            if (phrasalVerbs.Contains(tmpPhrasalVerb))
            {
                detectedPhrasalVerb = words[1] + " " + words[2];
                words = words.Where((value, index) => index != 1 && index != 2).ToArray();
            }
        }
        if (words.Length > 4)
        {
            tmpPhrasalVerb = words[2] + " " + words[3];
            if (phrasalVerbs.Contains(tmpPhrasalVerb))
            {
                detectedPhrasalVerb = words[2] + " " + words[3]; // she doesn't wake up
                words = words.Where((value, index) => index != 1 && index != 2 && index != 3).ToArray();
            }
        }
        if (words.Length > 5)
        {
            tmpPhrasalVerb = words[3] + " " + words[4];
            if (phrasalVerbs.Contains(tmpPhrasalVerb))
            {
                detectedPhrasalVerb = words[3] + " " + words[4]; // she does not wakes up
                words = words.Where((value, index) => index != 1 && index != 2 && index != 3 && index != 3 && index != 4).ToArray();
            }
        }
        return words;
    }
    private void Start()
    {
        List<string> questions = new List<string>
        {
            // present_simple_questions
            "Do you really like pizza here?",
            "Do you always like pizza here?",
            "Do the students study today?",
            "Do the students really study today?",
            "Does the student study today?",
            "Does the student really study today?",
            "Does John study today?",
            "Does John really study today?",
            "Does John really study carefully today?", // ok grammar but it is more natural "every day"
            //"Does John carefully really study today?", // NOT RECOGNIZED OK!!! LOVE IT
            //"Does she actually like pizza here?", // gestiscili più in là (actually)
            "Does she often like pizza here?",
            "Does she like pizza?",
            "Does she like pizza often here?", // grammatically correct
            //"Are you quite happy here?", (quite)
            "Do you always study carefully?",
            "Does she usually cook skillfully?",
            "Do they often visit their grandparents nearby?",
            "Does he sometimes write emails quickly?",
            "Do we rarely eat outside?",
            "Does the teacher never explain things slowly?",
            "Do you regularly go to the gym at night?",
            "Does she occasionally travel there?",
            // "Do they currently live somewhere in the city?", // in the city - not handled atm

            "Does John immediately respond to messages neatly?",
            "Doesn't John immediately respond to messages neatly?",
            "Does not John immediately respond to messages neatly?",

            "Don't you really like pizza here?",
            "Don't you always like pizza here?",
            "Don't the students study today?",
            "Don't the students really study today?",
            "Doesn't the student study today?",
            "Doesn't the student really study today?",
            "Doesn't John study today?",
            "Doesn't John really study today?",
            "Doesn't John really study carefully today?", // Ok grammaticalmente, ma più naturale con "every day"
            "Doesn't she often like pizza here?",
            "Doesn't she like pizza?",
            "Doesn't she like pizza often here?",
            "Don't you always study carefully?",
            "Doesn't she usually cook skillfully?",
            "Don't they often visit their grandparents nearby?",
            "Doesn't he sometimes write emails quickly?",
            "Don't we rarely eat outside?",
            "Doesn't the teacher ever explain things slowly?", // Per "never", si usa "ever" nella forma negativa
            "Don't you regularly go to the gym at night?",
            "Doesn't she occasionally travel there?",

            // ARE IS - present simple
            "Are you really happy today?", 
            "Are they students?", 
            "Are we late?", 
            "Are the dogs outside?", 
            "Are the books on the table?", 
            "Are they friends?",

            "Aren't you really happy today?",
            "Aren't they students?",
            "Aren't we late?",
            "Aren't the dogs outside?",
            "Aren't the books on the table?",
            "Aren't they friends?", // ARE NOT THEY____ INNATURALE

            "Is she really happy today?", 
            "Is she a student?",          
            "Is it late?",                   
            "Is the dog outside?",           
            "Is the book on the table?",     
            "Is she a friend?",

            "Isn't she really happy today?",
            "Isn't she a student?",
            "Isn't it late?",
            "Isn't the dog outside?",
            "Isn't the book on the table?",
            "Isn't she a friend?",

            "Is she not really happy today?",
            "Is she not a student?",
            "Is it not late?",
            "Is the dog not outside?",
            "Is the book not on the table?",
            "Is she not a friend?",

            // present continuous
            "Is she always studying carefully now?",
            "Isn't she always studying carefully now?",
            
            "Is she immediately responding to emails quickly?",
            "Isn't she immediately responding to emails quickly?",
            
            "Is he often playing soccer nearby?",
            "Isn't he often playing soccer nearby?",
            
            "Is she never cooking skillfully at night?",
            "Isn't she never cooking skillfully at night?",
            
            "Is he occasionally reading a book outside?",
            "Isn't he occasionally reading a book outside?",

            "Are they usually working late tonight slowly?",
            "Aren't they usually working late tonight slowly?",
            //"Are we usually meeting here later?",
            //"Are you usually practicing piano inside?",
            //"Are they usually discussing the project carefully?",

            "Is the teacher rarely explaining things slowly today?",
            //"Is not the teacher rarely explaining things slowly today?", // IS NOT THEY____ INNATURALE
            "Isn't the teacher rarely explaining things slowly today?",

            // with question words -
            "Why do you really like pizza here so much?", // Aggiunto "so much" per rafforzare il modo
            "Why don't you really like pizza here so much?", // Aggiunto "so much" per rafforzare il modo
            
            "Why does the student really study carefully today?", // Naturalmente contiene già 3 avverbi
            "Why doesn't the student really study carefully today?", // Naturalmente contiene già 3 avverbi
            
            "Why does she often like pizza so much here?", // Aggiunto "so much" per enfatizzare
            "Why doesn't she often like pizza so much here?", // Aggiunto "so much" per enfatizzare
            
            "Why does he sometimes write emails so quickly inside?", // Aggiunto "inside" come luogo
            "Why doesn't he sometimes write emails so quickly inside?", // Aggiunto "inside" come luogo
            
            "When do you always study so carefully?", // Aggiunto "so" per rendere la frase più enfatica
            "When don't you always study so carefully?", // Aggiunto "so" per rendere la frase più enfatica
            
            "When don't you always study so carefully here?", // Aggiunto "here" per completare i 3 avverbi
            "When do you always study so carefully here?", // Aggiunto "here" per completare i 3 avverbi
            
            "When does she exactly study?",
            "When doesn't she exactly study?",

            "How does John really study so carefully every day?", // Aggiunto "every day" per migliorare
            "How doesn't John really study so carefully every day?", // Aggiunto "every day" per migliorare
            
            "How does John immediately respond to messages neatly?",
            "How doesn't John immediately respond to messages neatly?",

            "How do they often visit their grandparents nearby regularly?", // Aggiunto "regularly"
            "How don't they often visit their grandparents nearby regularly?", // Aggiunto "regularly"
            
            "How do you always study carefully?",
            "How don't you always study carefully?",
            
            "Where doesn't she usually cook so skillfully nowadays?", // Aggiunto "nowadays" per riferirsi al tempo
            "Where does she usually cook so skillfully nowadays?", // Aggiunto "nowadays" per riferirsi al tempo
            
            "Where does she occasionally travel there?",
            "Where doesn't she occasionally travel there?",

            "Who is regularly studying so carefully here?", // Uso di 'Who' per identificare chi svolge l'azione
            "Who isn't regularly studying so carefully here?", // Uso di 'Who' per identificare chi svolge l'azione
            "Who is always writing so quickly here today?", // Tre avverbi ben distribuiti (frequenza, modo, luogo/tempo)
            "Who isn't always writing so quickly here today?", // Tre avverbi ben distribuiti (frequenza, modo, luogo/tempo)

            "What is she really doing so carefully now?", // Uso di 'What' per chiedere cosa sta facendo
            "What isn't she really doing so carefully now?", // Uso di 'What' per chiedere cosa sta facendo
            
            "What do they usually enjoy so skillfully at night?", // Aggiunto "skillfully" e "at night" per i tre avverbi
            "What don't they usually enjoy so skillfully at night?", // Aggiunto "skillfully" e "at night" per i tre avverbi
            
            "What do you usually do every morning?",
            "What don't you usually do every morning?",

            "Why do they run really so fast?",
            "Why don't they run really so fast?",
            
            "Why is she always studying so carefully now?", // Frase già corretta e fluida
            "Why isn't she always studying so carefully now?", // Frase già corretta e fluida

            // old ones
            "Do you like pizza here?",
            "Does she like pizza here?",
            "Are you happy here?",
            "Is she a teacher here?",

            "What do you do every morning?",
            "What does she do every morning?",

            "Where does he live?",
            "Where do they live?",

            "Why do they run so fast?",
            "Why does she run so fast?",

            "When does she study?",
            "When do you study?",

            "How do you make this cake?",
            "How does she make this cake?",

            "Does she play tennis?",
            "Do they go to school every day?",
            "Does he work here?",
            "Do we need more time?",
            "Are you happy?",
            "Is she a teacher?",
            "Are they at home?",
            "Is he your friend?",
            "Are we late?",
            "What do you do every morning?",
            "Where does he live?",
            "Why do they run so fast?",
            "When does she study?",

            //present_perfect_questions
            "Why have you really liked pizza here so much?",
            "Why haven't you really liked pizza here so much?",

            "Why has the student really studied carefully today?",
            "Why hasn't the student really studied carefully today?",

            "Why has she often liked pizza so much here?",
            "Why hasn't she often liked pizza so much here?",

            "Why has he sometimes written emails so quickly inside?",
            "Why hasn't he sometimes written emails so quickly inside?",

            "When have you always studied so carefully?",
            "When haven't you always studied so carefully?",

            "When haven't you always studied so carefully here?",
            "When have you always studied so carefully here?",

            "When has she exactly studied?",
            "When hasn't she exactly studied?",

            "How has John really studied so carefully every day?",
            "How hasn't John really studied so carefully every day?",

            "How has John immediately responded to messages neatly?",
            "How hasn't John immediately responded to messages neatly?",

            "How have they often visited their grandparents nearby regularly?",
            "How haven't they often visited their grandparents nearby regularly?",

            "How have you always studied carefully?",
            "How haven't you always studied carefully?",

            "Where hasn't she usually cooked so skillfully nowadays?",
            "Where has she usually cooked so skillfully nowadays?",

            "Where has she occasionally traveled?",
            "Where hasn't she occasionally traveled?",

            "Who has regularly studied so carefully here?",
            "Who hasn't regularly studied so carefully here?",
            "Who has always written so quickly here today?",
            "Who hasn't always written so quickly here today?",

            "What has she really done so carefully now?",
            "What hasn't she really done so carefully now?",

            "What have they usually enjoyed so skillfully at night?",
            "What haven't they usually enjoyed so skillfully at night?",

            "What have you usually done every morning?",
            "What haven't you usually done every morning?",

            "Why have they run really so fast?",
            "Why haven't they run really so fast?",

            "Why has she always studied so carefully now?",
            "Why hasn't she always studied so carefully now?",

            "Why has the cat always eaten so quickly now?",
            "Why hasn't the cat always eaten so quickly now?",

            "Why have cats always eaten so quickly now?",
            "Why haven't cats always eaten so quickly now?",

            //present_perfect_continuous_questions
            "Why have you really been liking pizza here so much?",
            "Why haven't you really been liking pizza here so much?",

            "Why has the student really been studying carefully today?",
            "Why hasn't the student really been studying carefully today?",

            "Why has she often been liking pizza so much here?",
            "Why hasn't she often been liking pizza so much here?",

            "Why has he sometimes been writing emails so quickly inside?",
            "Why hasn't he sometimes been writing emails so quickly inside?",

            "When have you always been studying so carefully?",
            "When haven't you always been studying so carefully?",

            "When haven't you always been studying so carefully here?",
            "When have you always been studying so carefully here?",

            "When has she exactly been studying?",
            "When hasn't she exactly been studying?",

            "How has John really been studying so carefully every day?",
            "How hasn't John really been studying so carefully every day?",

            "How has John immediately been responding to messages neatly?",
            "How hasn't John immediately been responding to messages neatly?",

            "How have they often been visiting their grandparents nearby regularly?",
            "How haven't they often been visiting their grandparents nearby regularly?",

            "How have you always been studying carefully?",
            "How haven't you always been studying carefully?",

            "Where hasn't she usually been cooking so skillfully nowadays?",
            "Where has she usually been cooking so skillfully nowadays?",

            "Where has she occasionally been traveling?",
            "Where hasn't she occasionally been traveling?",

            "Who has regularly been studying so carefully here?",
            "Who hasn't regularly been studying so carefully here?",
            "Who has always been writing so quickly here today?",
            "Who hasn't always been writing so quickly here today?",

            "What has she really been doing so carefully now?",
            "What hasn't she really been doing so carefully now?",

            "What have they usually been enjoying so skillfully at night?",
            "What haven't they usually been enjoying so skillfully at night?",

            "What have you usually been doing every morning?",
            "What haven't you usually been doing every morning?",

            "Why have they really been running so fast?",
            "Why haven't they really been running so fast?",

            "Why has she always been studying so carefully now?",
            "Why hasn't she always been studying so carefully now?",

            "Why has the cat always been eating so carefully now?",
            "Why hasn't the cat always been eating so carefully now?"

        //past_simple_questions
        //past_continuous_questions
        //past_perfect_questions
        //past_perfect_continuous_questions
        //future_simple_questions
        //future_continuous_questions
        //future_perfect_questions
        //future_perfect_continuous_questions
    };
        
        // ok everything fine with sentences (aff/neg)
        List<string> sentences = new List<string>
        {
            //Modal constructions:
            "My big car could always be carefully turned on tomorrow.",
            "My big car could always be carefully repaired tomorrow.",

            "My big cars could always be carefully turned on tomorrow.",
            "My big cars could always be carefully repaired tomorrow.",

            "The big car could always be carefully turned on tomorrow.",

            "The big car could always be carefully repaired tomorrow.",
            "The big cars could always be carefully repaired tomorrow.",
            "The car might be repaired.",
            "The car should be repaired.",
            "The car must be repaired.",
            "The car will be repaired.",
            "The car would be repaired.",
            "The car can be repaired.",
            "The car may be repaired.",
            "The car shall be repaired.",

            // DID e DIDNT + phrasals
            "I did always carefully set up the meeting yesterday.",
            "I did always carefully set up meetings yesterday.",

            "I didn't always carefully set up the meeting yesterday.",
            "I didn't always carefully set up meetings yesterday.",

            "I did not always carefully set up the meeting yesterday.",
            "I did not always carefully set up meetings yesterday.",

            "they did always carefully set up the meeting yesterday.",
            "they did always carefully set up meetings yesterday.",

            "they didn't always carefully set up the meeting yesterday.",
            "they didn't always carefully set up meetings yesterday.",

            "they did not always carefully set up the meeting yesterday.",
            "they did not always carefully set up meetings yesterday.",

            "I did always carefully play soccer yesterday.",
            "I didn't always carefully play soccer yesterday.",
            "I did not always carefully play soccer yesterday.",

            "They did always carefully play soccer yesterday.",
            "They didn't always carefully play soccer yesterday.",
            "They did not always carefully play soccer yesterday.",

            // USED TO
            "I used to read books.",
            "I always used to carefully read books today",

            "She used to sing.",
            "He used to dance.",
            "We used to play.",
            "They used to travel often.",
            "You used to enjoy sports.",

            "I didn't always use to carefully like vegetables today.",

            "I didn't use to like vegetables.",
            "She didn't use to smile.",
            "He didn't use to study.",
            "We didn't use to visit that place.",

            // going to + phrasals
            "I am going to wake up apples.",
            "I am going to wake up.",
            "I am always going to carefully wake up apples today.",
            "She is always going to carefully wake up today.",
            "They are always going to carefully wake up today.",


            "I am always going to carefully eat apples today.",
            "She is always going to carefully run today.",
            "They are always going to carefully study today.",

            "I am going to eat apples.",
            "She is going to run.",
            "He is going to sleep.",
            "We are going to play.",
            "They are going to study.",
            "You are going to talk.",
            "I am going to walk.",
            "She is going to swim.",
            "He is going to work.",
            "We are going to travel.",

            // aggiungere il controllo sui phrasal verb - fatto
            //// present simple - singular
            "The car is repaired.",
            "The car is always carefully repaired.",
            "The car is not always carefully repaired.",
            "The car isn't always carefully repaired.",
            "The car is carefully repaired today.",
            "The car is not carefully repaired today.",
            "The car isn't carefully repaired today.",
            "The car is repaired today.",
            "The car is not repaired today.",
            "The car isn't repaired today.",
            "The car is always carefully repaired today.",
            "The car is not always carefully repaired today.",
            "The car isn't always carefully repaired today.",
            "The big car isn't always carefully repaired today.",
            "The big car is not always carefully repaired today.",
            "The big car is always carefully repaired today.",

            "The big car is always carefully turned on today.",
            "The big car is not always carefully turned on today.",
            "The big car isn't always carefully turned on today.",

            "The big car isn't always carefully turned on every day.",

            //// present simple - plural
            "The cars are repaired.",
            "The cars are always carefully repaired.",
            "The cars are not always carefully repaired.",
            "The cars aren't always carefully repaired.",
            "The cars are carefully repaired today.",
            "The cars are not carefully repaired today.",
            "The cars aren't carefully repaired today.",
            "The cars are repaired today.",
            "The cars are not repaired today.",
            "The cars aren't repaired today.",
            "The cars are always carefully repaired today.",
            "The cars are not always carefully repaired today.",
            "The cars aren't always carefully repaired today.",
            "The big cars are always carefully repaired today.",
            "The big cars are not always carefully repaired today.",
            "The big cars aren't always carefully repaired today.",

            "The big cars are always carefully turned on today.",
            "The big cars aren't always carefully turned on today.",
            "The big cars are not always carefully turned on today.",

                        "My big cars are not always carefully turned on today.",

            // past simple - plural
            "The cars were repaired.",
            "The cars were always carefully repaired.",
            "The cars were not always carefully repaired.",
            "The cars weren't always carefully repaired.",
            "The cars were carefully repaired yesterday.",
            "The cars were not carefully repaired yesterday.",
            "The cars weren't carefully repaired yesterday.",
            "The cars were repaired yesterday.",
            "The cars were not repaired yesterday.",
            "The cars weren't repaired yesterday.",
            "The cars were always carefully repaired yesterday.",
            "The cars were not always carefully repaired yesterday.",
            "The cars weren't always carefully repaired yesterday.",
            "The big cars were always carefully repaired yesterday.",
            "The big cars were not always carefully repaired yesterday.",
            "The big cars weren't always carefully repaired yesterday.",

            "The big car was always carefully turned on today.",
            "The big car wasn't always carefully turned on today.",
            "The big car was not always carefully turned on today.",


            // past simple - singular
            "The car was repaired.",
            "The car was always carefully repaired.",
            "The car was not always carefully repaired.",
            "The car wasn't always carefully repaired.",
            "The car was carefully repaired yesterday.",
            "The car was not carefully repaired yesterday.",
            "The car wasn't carefully repaired yesterday.",
            "The car was repaired yesterday.",
            "The car was not repaired yesterday.",
            "The car wasn't repaired yesterday.",
            "The car was always carefully repaired yesterday.",
            "The car was not always carefully repaired yesterday.",
            "The car wasn't always carefully repaired yesterday.",
            "The big car was always carefully repaired yesterday.",
            "The big car was not always carefully repaired yesterday.",
            "The big car wasn't always carefully repaired yesterday.",

            "The big cars were always carefully turned on today.",
            "The big cars weren't always carefully turned on today.",
            "The big cars were not always carefully turned on today.",
            
            // present perfect - singular
            "The car has been repaired.",
            "The car has always been carefully repaired.",
            "The car has not always been carefully repaired.",
            "The car hasn't always been carefully repaired.",
            "The car has been carefully repaired yesterday.",
            "The car has not been carefully repaired yesterday.",
            "The car hasn't been carefully repaired yesterday.",
            "The car has been repaired yesterday.",
            "The car has not been repaired yesterday.",
            "The car hasn't been repaired yesterday.",
            "The car has always been carefully repaired yesterday.",
            "The car has not always been carefully repaired yesterday.",
            "The car hasn't always been carefully repaired yesterday.",
            "The big car hasn't always been carefully repaired yesterday.",
            "The big car has not always been carefully repaired yesterday.",
            "The big car has always been carefully repaired yesterday.",

            "The big car hasn't always been carefully turned on yesterday.",
            "The big car has not always been carefully turned on yesterday.",
            "The big car has always been carefully turned on yesterday.",

            // present perfect - plural
            "The cars have been repaired.",
            "The cars have always been carefully repaired.",
            "The cars have not always been carefully repaired.",
            "The cars haven't always been carefully repaired.",
            "The cars have been carefully repaired yesterday.",
            "The cars have not been carefully repaired yesterday.",
            "The cars haven't been carefully repaired yesterday.",
            "The cars have been repaired yesterday.",
            "The cars have not been repaired yesterday.",
            "The cars haven't been repaired yesterday.",
            "The cars have always been carefully repaired yesterday.",
            "The cars have not always been carefully repaired yesterday.",
            "The big cars have not always been carefully repaired yesterday.",
            "The big cars have always been carefully repaired yesterday.",
            "The big cars haven't always been carefully repaired yesterday.",

            "The big cars have not always been carefully turned on yesterday.",
            "The big cars have always been carefully turned on yesterday.",
            "The big cars haven't always been carefully turned on yesterday.",

            // present continuous - singular
            "The car is being repaired.",
            "The car is always being carefully repaired.",
            "The car is not always being carefully repaired.",
            "The car isn't always being carefully repaired.",
            "The car is being carefully repaired today.",
            "The car is not being carefully repaired today.",
            "The car isn't being carefully repaired today.",
            "The car is being repaired today.",
            "The car is not being repaired today.",
            "The car isn't being repaired today.",
            "The car is always being carefully repaired today.",
            "The car is not always being carefully repaired today.",
            "The car isn't always being carefully repaired today.",
            "The big car isn't always being carefully repaired today.",
            "The big car is always being carefully repaired today.",
            "The big car is not always being carefully repaired today.",

            "The big car isn't always being carefully turned on today.",
            "The big car is always being carefully turned on today.",
            "The big car is not always being carefully turned on today.",
            
            // present continuous - plural
            "The cars are being repaired.",
            "The cars are always being carefully repaired.",
            "The cars are not always being carefully repaired.",
            "The cars aren't always being carefully repaired.",
            "The cars are being carefully repaired today.",
            "The cars are not being carefully repaired today.",
            "The cars aren't being carefully repaired today.",
            "The cars are being repaired today.",
            "The cars are not being repaired today.",
            "The cars aren't being repaired today.",
            "The cars are always being carefully repaired today.",
            "The cars are not always being carefully repaired today.",
            "The cars aren't always being carefully repaired today.",
            "The big cars are always being carefully repaired today.",
            "The big cars are not always being carefully repaired today.",
            "The big cars aren't always being carefully repaired today.",

            "The big cars are always being carefully turned on today.",
            "The big cars are not always being carefully turned on today.",
            "The big cars aren't always being carefully turned on today.",

            // present perfect continuous - singular
            "The car has been being repaired.",
            "The car has always been being carefully repaired.",
            "The car has not always been being carefully repaired.",
            "The car hasn't always been being carefully repaired.",
            "The car has been being carefully repaired today.",
            "The car has not been being carefully repaired today.",
            "The car hasn't been being carefully repaired today.",
            "The car has been being repaired today.",
            "The car has not been being repaired today.",
            "The car hasn't been being repaired today.",
            "The car has always been being carefully repaired today.",
            "The car has not always been being carefully repaired today.",
            "The car hasn't always been being carefully repaired today.",
            "The big car hasn't always been being carefully repaired today.",
            "The big car has not always been being carefully repaired today.",
            "The big car has always been being carefully repaired today.",

            "The big car hasn't always been being carefully turned on today.",
            "The big car has not always been being carefully turned on today.",
            "The big car has always been being carefully turned on today.",
            
            // present perfect continuous - plural
            "The cars have been being repaired.",
            "The cars have always been being carefully repaired.",
            "The cars have not always been being carefully repaired.",
            "The cars haven't always been being carefully repaired.",
            "The cars have been being carefully repaired today.",
            "The cars have not been being carefully repaired today.",
            "The cars haven't been being carefully repaired today.",
            "The cars have been being repaired today.",
            "The cars have not been being repaired today.",
            "The cars haven't been being repaired today.",
            "The cars have always been being carefully repaired today.",
            "The cars have not always been being carefully repaired today.",
            "The cars haven't always been being carefully repaired today.",
            "The cars have not always been being carefully repaired today.",
            "The cars have always been being carefully repaired today.",

            "The cars haven't always been being carefully turned on today.",
            "The cars have not always been being carefully turned on today.",
            "The cars have always been being carefully turned on today.",


            // past continuous - singular
            "The car was being repaired.",
            "The car was always being carefully repaired.",
            "The car was not always being carefully repaired.",
            "The car wasn't always being carefully repaired.",
            "The car was being carefully repaired today.",
            "The car was not being carefully repaired today.",
            "The car wasn't being carefully repaired today.",
            "The car was being repaired today.",
            "The car was not being repaired today.",
            "The car wasn't being repaired today.",
            "The big car wasn't always being carefully repaired today.",
            "The big car was always being carefully repaired today.",
            "The big car was not always being carefully repaired today.",

            "The big car wasn't always being carefully turned on today.",
            "The big car was always being carefully turned on today.",
            "The big car was not always being carefully turned on today.",

            // past continuous - plural
            "The cars were being repaired.",
            "The cars were always being carefully repaired.",
            "The cars were not always being carefully repaired.",
            "The cars weren't always being carefully repaired.",
            "The cars were being carefully repaired today.",
            "The cars were not being carefully repaired today.",
            "The cars weren't being carefully repaired today.",
            "The cars were being repaired today.",
            "The cars were not being repaired today.",
            "The cars weren't being repaired today.",
            "The cars were always being carefully repaired today.",
            "The cars were not always being carefully repaired today.",
            "The cars weren't always being carefully repaired today.",
            "The big cars were always being carefully repaired today.",
            "The big cars were not always being carefully repaired today.",
            "The big cars weren't always being carefully repaired today.",

            "The big cars were always being carefully turned on today.",
            "The big cars were not always being carefully turned on today.",
            "The big cars weren't always being carefully turned on today.",

            // past perfect - singular
            "The car had been repaired.",
            "The car had always been carefully repaired.",
            "The car had not always been carefully repaired.",
            "The car hadn't always been carefully repaired.",
            "The car had been carefully repaired.",
            "The car had not been carefully repaired.",
            "The car hadn't been carefully repaired.",
            "The car had been repaired.",
            "The car had not been repaired.",
            "The car hadn't been repaired.",
            "The big car hadn't always been carefully repaired.",
            "The big car had always been carefully repaired.",
            "The big car had not always been carefully repaired.",

            "The big car hadn't always been carefully turned on yesterday.",
            "The big car had always been carefully turned on yesterday.",
            "The big car had not always been carefully turned on yesterday.",

            // past perfect - plural
            "The cars had been repaired.",
            "The cars had always been carefully repaired.",
            "The cars had not always been carefully repaired.",
            "The cars hadn't always been carefully repaired.",
            "The cars had been carefully repaired.",
            "The cars had not been carefully repaired.",
            "The cars hadn't been carefully repaired.",
            "The cars had been repaired.",
            "The cars had not been repaired.",
            "The cars hadn't been repaired.",
            "The cars had always been carefully repaired.",
            "The cars had not always been carefully repaired.",
            "The cars hadn't always been carefully repaired.",
            "The big cars had always been carefully repaired.",
            "The big cars had not always been carefully repaired.",
            "The big cars hadn't always been carefully repaired.",

            "The big cars had always been carefully turned on yesterday.",
            "The big cars had not always been carefully turned on yesterday.",
            "The big cars hadn't always been carefully turned on yesterday.",

            // past perfect continuous - singular
            "The car had been being repaired.",
            "The car had always been being carefully repaired.",
            "The car had not always been being carefully repaired.",
            "The car hadn't always been being carefully repaired.",
            "The car had been being carefully repaired.",
            "The car had not been being carefully repaired.",
            "The car hadn't been being carefully repaired.",
            "The car had been being repaired.",
            "The car had not been being repaired.",
            "The car hadn't been being repaired.",
            "The big car hadn't always been being carefully repaired.",
            "The big car had always been being carefully repaired.",
            "The big car had not always been being carefully repaired.",

            "The big car hadn't always been being carefully turned on yesterday.",
            "The big car had always been being carefully turned on yesterday.",
            "The big car had not always been being carefully turned on yesterday.",

            // past perfect continuous - plural
            "The cars had been being repaired.",
            "The cars had always been being carefully repaired.",
            "The cars had not always been being carefully repaired.",
            "The cars hadn't always been being carefully repaired.",
            "The cars had been being carefully repaired.",
            "The cars had not been being carefully repaired.",
            "The cars hadn't been being carefully repaired.",
            "The cars had been being repaired.",
            "The cars had not been being repaired.",
            "The cars hadn't been being repaired.",
            "The cars had always been being carefully repaired.",
            "The cars had not always been being carefully repaired.",
            "The cars hadn't always been being carefully repaired.",
            "The big cars had always been being carefully repaired.",
            "The big cars had not always been being carefully repaired.",
            "The big cars hadn't always been being carefully repaired.",

            "The big cars had always been being carefully turned on yesterday.",
            "The big cars had not always been being carefully turned on yesterday.",
            "The big cars hadn't always been being carefully turned on yesterday.",

            // future simple - singular
            "The car will be repaired.",
            "The car will always be carefully repaired.",
            "The car will not always be carefully repaired.",
            "The car won't always be carefully repaired.",
            "The car will be carefully repaired.",
            "The car will not be carefully repaired.",
            "The car won't be carefully repaired.",
            "The car will be repaired.",
            "The car will not be repaired.",
            "The car won't be repaired.",
            "The big car won't always be carefully repaired.",
            "The big car will always be carefully repaired.",
            "The big car will not always be carefully repaired.",

            "The big car won't always be carefully turned on yesterday.",
            "The big car will always be carefully turned on yesterday.",
            "The big car will not always be carefully turned on yesterday.",

            // future simple - plural
            "The cars will be repaired.",
            "The cars will always be carefully repaired.",
            "The cars will not always be carefully repaired.",
            "The cars won't always be carefully repaired.",
            "The cars will be carefully repaired.",
            "The cars will not be carefully repaired.",
            "The cars won't be carefully repaired.",
            "The cars will be repaired.",
            "The cars will not be repaired.",
            "The cars won't be repaired.",
            "The cars will always be carefully repaired.",
            "The cars will not always be carefully repaired.",
            "The cars won't always be carefully repaired.",
            "The big cars will always be carefully repaired.",
            "The big cars will not always be carefully repaired.",
            "The big cars won't always be carefully repaired.",

            "The big cars will always be carefully turned on yesterday.",
            "The big cars will not always be carefully turned on yesterday.",
            "The big cars won't always be carefully turned on yesterday.",

            // future continuous - singular
            "The car will be being repaired.",
            "The car will always be being carefully repaired.",
            "The car will not always be being carefully repaired.",
            "The car won't always be being carefully repaired.",
            "The car will be being carefully repaired.",
            "The car will not be being carefully repaired.",
            "The car won't be being carefully repaired.",
            "The car will be being repaired.",
            "The car will not be being repaired.",
            "The car won't be being repaired.",
            "The big car won't always be being carefully repaired.",
            "The big car will always be being carefully repaired.",
            "The big car will not always be being carefully repaired.",

            "The big car won't always be being carefully turned on yesterday.",
            "The big car will always be being carefully turned on yesterday.",
            "The big car will not always be being carefully turned on yesterday.",

            // future continuous - plural
            "The cars will be being repaired.",
            "The cars will always be being carefully repaired.",
            "The cars will not always be being carefully repaired.",
            "The cars won't always be being carefully repaired.",
            "The cars will be being carefully repaired.",
            "The cars will not be being carefully repaired.",
            "The cars won't be being carefully repaired.",
            "The cars will be being repaired.",
            "The cars will not be being repaired.",
            "The cars won't be being repaired.",
            "The cars will always be being carefully repaired.",
            "The cars will not always be being carefully repaired.",
            "The cars won't always be being carefully repaired.",
            "The big cars will always be being carefully repaired.",
            "The big cars will not always be being carefully repaired.",
            "The big cars won't always be being carefully repaired.",

            "The big cars will always be being carefully turned on yesterday.",
            "The big cars will not always be being carefully turned on yesterday.",
            "The big cars won't always be being carefully turned on yesterday.",

            // future perfect - singular
            "The car will have been repaired.",
            "The car will have always been carefully repaired.",
            "The car will not have always been carefully repaired.",
            "The car won't have always been carefully repaired.",
            "The car will have been carefully repaired.",
            "The car will not have been carefully repaired.",
            "The car won't have been carefully repaired.",
            "The car will have been repaired.",
            "The car will not have been repaired.",
            "The car won't have been repaired.",
            "The big car won't have always been carefully repaired.",
            "The big car will have always been carefully repaired.",
            "The big car will not have always been carefully repaired.",

            "The big car won't have always been carefully turned on yesterday.",
            "The big car will have always been carefully turned on yesterday.",
            "The big car will not have always been carefully turned on yesterday.",

            // future perfect - plural
            "The cars will have been repaired.",
            "The cars will have always been carefully repaired.",
            "The cars will not have always been carefully repaired.",
            "The cars won't have always been carefully repaired.",
            "The cars will have been carefully repaired.",
            "The cars will not have been carefully repaired.",
            "The cars won't have been carefully repaired.",
            "The cars will have been repaired.",
            "The cars will not have been repaired.",
            "The cars won't have been repaired.",
            "The cars will have always been carefully repaired.",
            "The cars will not have always been carefully repaired.",
            "The cars won't have always been carefully repaired.",
            "The big cars will have always been carefully repaired.",
            "The big cars will not have always been carefully repaired.",
            "The big cars won't have always been carefully repaired.",

            "The big cars will have always been carefully turned on yesterday.",
            "The big cars will not have always been carefully turned on yesterday.",
            "The big cars won't have always been carefully turned on yesterday.",

            // future perfect continuous - singular
            "The car will have been being repaired.",
            "The car will have always been being carefully repaired.",
            "The car will not have always been being carefully repaired.",
            "The car won't have always been being carefully repaired.",
            "The car will have been being carefully repaired.",
            "The car will not have been being carefully repaired.",
            "The car won't have been being carefully repaired.",
            "The car will have been being repaired.",
            "The car will not have been being repaired.",
            "The car won't have been being repaired.",
            "The big car won't have always been being carefully repaired.",
            "The big car will have always been being carefully repaired.",
            "The big car will not have always been being carefully repaired.",

            "The big car won't have always been being carefully turned on yesterday.",
            "The big car will have always been being carefully turned on yesterday.",
            "The big car will not have always been being carefully turned on yesterday.",

            // future perfect continuous - plural
            "The cars will have been being repaired.",
            "The cars will have always been being carefully repaired.",
            "The cars will not have always been being carefully repaired.",
            "The cars won't have always been being carefully repaired.",
            "The cars will have been being carefully repaired.",
            "The cars will not have been being carefully repaired.",
            "The cars won't have been being carefully repaired.",
            "The cars will have been being repaired.",
            "The cars will not have been being repaired.",
            "The cars won't have been being repaired.",
            "The cars will have always been being carefully repaired.",
            "The cars will not have always been being carefully repaired.",
            "The cars won't have always been being carefully repaired.",
            "The big cars will have always been being carefully repaired.",
            "The big cars will not have always been being carefully repaired.",
            "The big cars won't have always been being carefully repaired.",

            "The big cars will have always been being carefully turned on yesterday.",
            "The big cars will not have always been being carefully turned on yesterday.",
            "The big cars won't have always been being carefully turned on yesterday.",

            // Past habitual
            //"The car used to always be carefully repaired in the mornings.",
            //"The cars used to always be carefully repaired in the mornings.",

            // others---------------------------
            "The car has not been repaired.",
            "The car hasn't been repaired.",

            "A student has finished the assignment.",
            "A student has not finished the assignment.",
            "A student hasn't finished the assignment.",

            "Students have finished their assignment",
            "Students have not finished their assignment",
            "Students haven't finished their assignment",

            "Alex has finished the assignment.",
            "Alex has finished his assignment.",

            "A guy has finished his assignment.",

            "There is no beef in here",
            "He completes the task quickly.",
            "She walks slowly.",
            // tmp --------------------- ok all

            "The car is running.", // Exc
            "The car is not running.",
            "The car isn't running.",

            "A car is running.",
            "A car is not running.",
            "A car isn't running.",

            "The cars are running.",
            "The cars are not running.",
            "The cars aren't running.",

                        "There is my car running here",
                        "There is not my car running here",
                        "There isn't my car running here",

            "There is no car running here",
            "There is not a car running here",
            "There isn't a car running here",

            "There are no cars running here",
            "There aren't cars running here",

                        "There are my cars running here",

            "The big car is running.",
            "The big car is not running.",
            "The big car isn't running.",

                        "The big car is running.",
                        "My big car is not running.",
                        "My big car isn't running.",

            "A big car is running.",
            "A big car is not running.",
            "A big car isn't running.",

            "The big cars are running.",
            "The big cars are not running.",
            "The big cars aren't running.",

            "There is no big car running here",
            "There is not a big car running here",
            "There isn't a big car running here",

            "There are no big cars running here",
            "There aren't big cars running here",

            "The car is big.",
            "The car is not big.",
            "The car isn't big.",

            "A car is big.",
            "A car is not big.",
            "A car isn't big.",

            "Cars are big",
            "Cars are not big",
            "Cars aren't big",

            "There aren't big dogs playing here",
            // ---------------------

            // Present Simple - Affermazioni
            "The car is big.",
            "The car is not big.",
            "The car isn't big.",

            "A car is big.",
            "A car is not big.",
            "A car isn't big.",

            "Cars are big",
            "Cars are not big",
            "Cars aren't big",

            "A car is big.",
            "A guy has a car.",
            "Google has a car.",
            "John loves books.",
            
            "John loves his books.",
            "John does not love his books.",
            "John doesn't love his books.",

            "Students love their books.",
            "Students do not love their books.",
            "Students don't love their books.",

            "John loves big books.",
                "John loves his big books.",
            "The sun rises in the east.",
            "He likes apples.",
                "He likes my apples.",
            "She believes in miracles.",
            "She believes in a miracle.",
            "The cat jumps.",
            "Cats jump.",
            "The dogs run fast.",
            "The dogs run.",
    
            // Present Simple - Negazioni

            "The cars aren't big.",
            "A car is not big.",
            "A car isn't big.",

            "A guy has a car.",

            "A guy has his car.",
            "A guy does not have a car.",
            "A guy does not have his car.",
            "A guy doesn't have his car.",

            
            "A guy doesn't have a car.",
            "A guy does not have the car.",
            "Google does not have a car.",
            "John does not love books.",
            "Dogs do not run fast.",
            "The Dogs do not run.",
            "He does not have a bike.",
            "They do not visit her grandparents every Sunday.",
            "They don't wake up her grandparents every Sunday.",
    
            // Avverbi nel Present Simple
            "She never drinks coffee.",
            "I always drink coffee in the morning.",
            "They do not always drink coffee in the morning.",
            "He doesn't always agree with me.",
    
            // Present Simple - Frasi con Verbi Frasali (Phrasal Verbs)
            "She wakes up the child.",
            "He turns on the computer.",
            "She turns off the lamp.",
            "They give up the fight.",
            "He takes off the jacket.",
            "She looks after the house.",
            "We run into the problem.",
            "They set up the table.",
            "She finds out the answer.",
            "He puts off the meeting.",
    
            // Present Continuous - Affermazioni
            "The car is running.",
            "The boy is eating a sandwich.",
            "A girl is reading a book.",
            "The dogs are playing in the garden.",
            "John is writing a letter.",
            "They are standing here.",
    
            // Present Continuous - Negazioni
            "The car is not running.",
            "The boy is not eating a sandwich.",
            "A girl is not reading a book.",
            "The dogs are not playing in the garden.",
            "John is not writing a letter.",
            "He is not standing here.",
    
            // Usi Enfatici con 'do'
            "I do like apples.",
            "They do not like apples.",
            "I do not work at night.",
            "I do not always drink coffee in the morning.",
    
            // Frasi con Soggetto Plurale
            "Cars are big.",
            "Cars are not big.",
            "Cars aren't big.",
            "The dogs run.",
            "The dogs run in the garden.",
            "The dogs are playing in the garden.",
            "The dogs are not playing in the garden.",
            "The dogs aren't playing in the garden.",

            // others
            "It is a sunny day.",
            "It is not a sunny day.",
            "he likes reading",
            "Dogs bark",
            "She is at home",
            "She is not at home",
            "She drives the car carefully.",

            "There are dogs here",
            "There is a dog here",

            "He completed the task quickly.",
            "She drives the car carefully ."
        };
        foreach (var sentence in questions)
        {
            if (!IsValidSentence(sentence))
            {
                Debug.Log(sentence);
            }
        }
    }

    public void Click(string phrase) {
        Debug.Log(IsValidSentence(phrase));
    }

    private static bool IsFixedLenght(string[] words, int lenght) { return words.Length <= lenght; }
    private static bool IsAPlural(string word) => plural_nouns.Contains(word);
    private static bool IsACommon(string word) => common_nouns.Contains(word);
    private static bool IsAPreposition(string word) => prepositions.Contains(word);
    private static bool IsABaseVerb(string word) => base_verbs.Contains(word);
    private static bool IsAnAdjective(string word) => adjectives.Contains(word);
    private static bool IsAnObjectPronouns(string word) => objectPronouns.Contains(word);
    private static bool IsAPossessivePronouns(string word) => possessivePronouns.Contains(word);
    private static bool IsAFrequencyAdverb(string word) => frequencyAdverbs.Contains(word);
    private static bool IsAPlaceAdverbs(string word) => placeAdverbs.Contains(word);
    private static bool IsAMannerAdverbs(string word) => mannerAdverbs.Contains(word);
    private static bool IsAnIngVerbs(string word) => ing_verbs.Contains(word);
    private static bool IsA3rdPersonVerb(string word) => base_verbs_3rd_person.Contains(word);
    private static bool IsATimeAdverb(string word) => timeAdverbs.Contains(word);
    private static bool IsAPluralSubject(string word) => plural_nouns.Contains(word); //plural_subject.Contains(word); - mergiati
    private static bool IsASingular(string word) => singular_subject.Contains(word);
    private static bool IsAProperNoun(string word) => proper_nouns.Contains(word);
    private static bool IsPastParticiple(string word) => past_participle.Contains(word);
    private static bool IsAModal(string word) => modal_verbs.Contains(word);
    private static bool IsAQuestionWords(string word) => question_words.Contains(word);
    private static bool IsAPrasphalVerb(string word1, string word2) => phrasalVerbs.Contains(word1+" "+word2);
    private static bool The(string word) { return word.ToLower().Equals("the"); }
    private static bool GoingTo(string word1, string word2) 
    { 
        string goingTo = word1.ToLower() + " " + word2.ToLower();
        return goingTo.ToLower().Equals("going to"); 
    }
    private static bool UsedTo(string word1, string word2)
    {
        string usedTo = word1.ToLower() + " " + word2.ToLower();
        return usedTo.ToLower().Equals("used to");
    }
    private static bool UseTo(string word1, string word2)
    {
        string usedTo = word1.ToLower() + " " + word2.ToLower();
        return usedTo.ToLower().Equals("use to");
    }
    private static bool A(string word) { return word.ToLower().Equals("a"); }
    private static bool An(string word) { return word.ToLower().Equals("an"); }
    private static bool Do(string word) { return word.ToLower().Equals("do"); }
    private static bool Not(string word) { return word.ToLower().Equals("not"); }
    private static bool Are(string word) { return word.ToLower().Equals("are"); }
    private static bool Am(string word) { return word.ToLower().Equals("am"); }
    private static bool Have(string word) { return word.ToLower().Equals("have"); }
    private static bool Arent(string word) { return word.ToLower().Equals("aren't"); }
    private static bool There(string word) { return word.ToLower().Equals("there"); }
    private static bool Has(string word) { return word.ToLower().Equals("has"); }
    private static bool Hasnt(string word) { return word.ToLower().Equals("hasn't"); }
    private static bool Havent(string word) { return word.ToLower().Equals("haven't"); }
    private static bool Is(string word) { return word.ToLower().Equals("is"); }
    private static bool Isnt(string word) { return word.ToLower().Equals("isn't"); }
    private static bool Every(string word) { return word.ToLower().Equals("every"); }
    private static bool Doesnt(string word) { return word.ToLower().Equals("doesn't"); }
    private static bool Didnt(string word) { return word.ToLower().Equals("didn't"); }
    private static bool Did(string word) { return word.ToLower().Equals("did"); }
    private static bool Dont(string word) { return word.ToLower().Equals("don't"); }
    private static bool Does(string word) { return word.ToLower().Equals("does"); }
    private static bool I(string word) { return word.ToLower().Equals("i"); }
    private static bool Been(string word) { return word.ToLower().Equals("been"); }
    private static bool Was(string word) { return word.ToLower().Equals("was"); }
    private static bool Wasnt(string word) { return word.ToLower().Equals("wasn't"); }
    private static bool Were(string word) { return word.ToLower().Equals("were"); }
    private static bool Werent(string word) { return word.ToLower().Equals("weren't"); }
    private static bool Had(string word) { return word.ToLower().Equals("had"); }
    private static bool Hadnt(string word) { return word.ToLower().Equals("hadn't"); }
    private static bool Wont(string word) { return word.ToLower().Equals("won't"); }
    private static bool Will(string word) { return word.ToLower().Equals("will"); }
    private static bool This(string word) { return word.ToLower().Equals("this"); }
    private static bool That(string word) { return word.ToLower().Equals("that"); }
}
