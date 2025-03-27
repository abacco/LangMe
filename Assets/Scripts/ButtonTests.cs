using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class ButtonTests : MonoBehaviour
{
    static List<string> singular_subject = new List<string> { "i", "girl", "boy", "coffee", "book", "table", "bike", "car", "guy", "cat", "water", "sun", "he", "she", "it" };
    static List<string> plural_subject = new List<string> { "grandparents", "girls", "we", "they", "you", "cars", "guys", "books", "dogs", "cats", "apples" };
    static List<string> base_verbs = new List<string> { "bark", "visit","work","agree","drink", "like", "love", "drive", "are", "run", "jump", "believe" };
    static List<string> base_verbs_3rd_person = new List<string> { "barks", "visits", "agrees", "likes","loves", "drives", "runs", "jumps", "boils", "rises", "knows", "believes", "likes", "drinks" };
    static List<string> ing_verbs = new List<string> { "agreeing", "liking", "standing", "writing","playing", "reading", "eating", "running", "loving", "driving", "waiting" };
    static List<string> past_participle = new List<string> { "loved", "driven" };
    static List<string> modal_verbs = new List<string> { "can", "could", "shall", "should", "will", "would", "may", "might", "must" };
    static List<string> negations = new List<string> { "not", "never", "no" };
    static List<string> question_words = new List<string> { "who", "what", "where", "when", "why", "how", "which", "whose" };
    static List<string> adjectives = new List<string> { "sunny","cold", "big", "small", "tall", "short", "bright", "dark", "beautiful", "ugly", "fast" };

    static List<string> common_nouns = new List<string> { "task","garden", "day","time", "grandparent", "home", "pizza", "guitar", "letter", "garden", "girl", "boy", "sandwich", "problem", "meeting", "table", "sugar", "house", "jacket", "fight", "lamp","child", "coffee", "table", "bike", "apple", "book", "table", "house", "computer", "dog", "city", "car", "game", "east", "west", "north", "south", "answer", "miracle" };
    static List<string> plural_nouns = new List<string> { "days", "grandparents", "pizzas", "guitars", "letters", "gardens", "girls", "boys","sandwiches", "problems","meetings", "tables", "sugars", "houses", "jackets", "fights", "lamps", "children","tables","bikes","apples", "cats", "apples", "books", "tables", "houses", "computers", "dogs", "cities", "cars", "games", "answers", "miracles" };

    static List<string> objectPronouns = new List<string>{ "me", "you", "him", "her", "it", "us", "them" };
    static List<string> proper_nouns = new List<string> { "john", "sarah", "london", "paris", "microsoft", "google" };
    static List<string> prepositions = new List<string> { "with","in", "on", "at", "to", "with", "for", "before", "after", "during", "as", "by", 
                                                          "about", "over", "under", "of", "through", "between", "into", "onto", "out", 
                                                          "from", "against", "along", "around", "beneath", "beside", "beyond", "near", "off", 
                                                          "past", "since", "until", "within", "without" };

    static List<string> phrasalVerbs = new List<string>{
                                                        "wake up", "wakes up",
                                                        "turn on", "turns on",
                                                        "turn off", "turns off",
                                                        "give up", "gives up",
                                                        "take off", "takes off",
                                                        "look after", "looks after",
                                                        "run into", "runs into",
                                                        "set up", "sets up",
                                                        "find out", "finds out",
                                                        "put off", "puts off"
    };

    // Avverbi di frequenza
    /*
            Esempio: I always drink coffee in the morning.
            Esempio (to be): She is often late for work.
            Esempio: He doesn’t always agree with me.
            Esempio (to be): They aren’t usually at home.
     */
    static List<string> frequencyAdverbs = new List<string> { "always", "usually", "often", "sometimes", "rarely", "never" };
    // Avverbi di tempo
    /*
            Esempio: We are going to the park tomorrow.
            Esempio: Tomorrow, we are going to the park.
            Negazioni: La posizione rimane invariata.
            Esempio: I don’t have time now.
     */
    static List<string> timeAdverbs = new List<string> { "now", "later", "soon", "tomorrow", "yesterday", "tonight", "every", "at night" };
    // Avverbi di luogo
    static List<string> placeAdverbs = new List<string> { "here", "there", "everywhere", "somewhere", "nearby" };
    // Avverbi di modo
    /*
            in inglese generalmente si collocano alla fine della frase

            She drives the car carefully.
            He completed the task quickly.

            prima del verbo principale per dare enfasi o un tono più formale:
            She carefully drives the car.
            He quickly completed the task.
     */
    static List<string> mannerAdverbs = new List<string> { "quickly", "slowly", "carefully", "happily", "sadly" };
    // Altri avverbi utili
    /*
            Vanno generalmente alla fine della frase.
            Esempio: He is standing here.
            Esempio: We met them there.
     */
    static List<string> otherAdverbs = new List<string> { "almost", "definitely", "surely", "quite", "probably" };

    static bool IsValidSentence(string sentence)
    {
        string[] words = sentence.ToLower().Replace(".", "").Replace("?", "").Split(' ');
        if (words.Length < 2) return false;

        return SingularSubjectPresentSimple_Affirmation(words) || PluralSubjectPresentSimple_Affirmation(words);
    }

    // Article + subject + Is/Is Not + Adjective 
    // article + sub + has/has not + article + object
    // Article + sub + does not have + article + object
    // Proper Noun + is/is not + big 
    public static bool SingularSubjectPresentSimple_Affirmation(string[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].ToLower();
        }
        // avverbi di luogo alla fine della frase
        if (placeAdverbs.Contains(words[words.Length-1]) || mannerAdverbs.Contains(words[words.Length - 1]))
        {
            words = words.Where((value, index) => index != words.Length - 1).ToArray(); // Mangia ultima posizione per togliere l'avv di modo
        }
        if (words[words.Length - 2].Equals("every")) // avverbio di tempo alla fine - gestire avverbi come every sunday
        {
            words = words.Where((value, index) => index != words.Length - 2 && index != words.Length - 1).ToArray(); // Mangia ultima posizione per togliere l'avv di tempo
        }
        if (timeAdverbs.Contains(words[words.Length - 1]))
        {
            words = words.Where((value, index) => index != words.Length - 1).ToArray(); // Mangia ultima posizione per togliere l'avv di tempo
        }
        if (timeAdverbs.Contains(words[0])) // avverbio di tempo all'inizio
        {
            words = words.Where((value, index) => index != 0).ToArray(); // Mangia prima posizione per togliere l'avv di tempo
        }
        if (words[0].Equals("there") && (words[1].Equals("is")))
        {
            words = words.Skip(2).ToArray();
        }
        if (words[1].Equals("never") || words[1].Equals("always"))
        {
            // Salta solo il secondo elemento (indice 1).
            words = words.Where((value, index) => index != 1).ToArray();
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
                detectedPhrasalVerb = words[2] + " " + words[3]; // she doesn't wake up the child
                words = words.Where((value, index) => index != 1 && index != 2 && index != 3).ToArray();
            }
        }
        if (words.Length > 5)
        {
            tmpPhrasalVerb = words[3] + " " + words[4];
            if (phrasalVerbs.Contains(tmpPhrasalVerb))
            {
                detectedPhrasalVerb = words[3] + " " + words[4]; // she does not wakes up
                words = words.Where((value, index) => index != 1 && index != 2 && index != 3 && index != 4).ToArray(); // she the child
            }
        }
        
        if (words[0].ToLower().Equals("the") || words[0].ToLower().Equals("a"))
        {
            bool subjectRecognized = singular_subject.Contains(words[1]);
            if (!subjectRecognized) { return false; }
            if (frequencyAdverbs.Contains(words[2]))  
            {
                words = words.Where((value, index) => index != 1).ToArray(); // Mangia seconda posizione per togliere l'avv di frequenza
            }
            if (words[2].Equals("is"))
            {
                if (ing_verbs.Contains(words[3])) // contains ing_verbs OR plurals OR ARTICLE_PREPOSITION 
                {
                    if(words.Length == 4)
                    {
                        return true;
                    }
                    if (plural_nouns.Contains(words[4])) // eating sandwiches
                    {
                        return true;
                    }
                    if (words[4].Equals("a") || words[4].Equals("the") || prepositions.Contains(words[4])) // eating a/the sandwich
                    {
                        if (common_nouns.Contains(words[5]))
                        {
                            return true;
                        }
                        else { return false; }
                    }
                }
                if (words[3].Equals("not"))
                {
                    if (ing_verbs.Contains(words[4]))
                    {
                        return true;
                    }
                    if (adjectives.Contains(words[4]))
                    {
                        return true;
                    }
                }
                if (adjectives.Contains(words[3]))
                {
                    return true;
                }
            }
            if (words[2].Equals("has"))
            {
                if (words[3].ToLower().Equals("the") || words[3].ToLower().Equals("a"))
                {
                    if (singular_subject.Contains(words[4])) return true;
                }
                if (adjectives.Contains(words[3])) return true;
            }
            if (words[2].Equals("doesn't") && (words[3].Equals("have") || base_verbs.Contains(words[3])))
            {
                if (words[4].ToLower().Equals("the") || words[4].ToLower().Equals("a")) // The | a
                {
                    if (singular_subject.Contains(words[5])) return true;
                }
            }
            if (words[2].Equals("does") && words[3].Equals("not") && (words[4].Equals("have") || base_verbs.Contains(words[4])))
            {
                tmpPhrasalVerb = words[1] + " " + words[2]; // she wakes up
                if (phrasalVerbs.Contains(tmpPhrasalVerb))
                {
                    detectedPhrasalVerb = words[1] + " " + words[2];
                    words = words.Where((value, index) => index != 1 && index != 2).ToArray();
                }
                if (words[5].ToLower().Equals("the") || words[5].ToLower().Equals("a")) // The | a
                {
                    if (singular_subject.Contains(words[6])) return true;
                }
            }
            if (base_verbs_3rd_person.Contains(words[2])) // A/The guy drives a/the (big) car
            {
                if (words.Length <= 3)
                {
                    return true; // the cat jumps}
                }
                if (words[3].ToLower().Equals("the") || words[3].ToLower().Equals("a")) // The | a
                {
                    if (adjectives.Contains(words[4]))
                    {
                        if (common_nouns.Contains(words[5]))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (common_nouns.Contains(words[4]))
                        {
                            return true;
                        }
                    }
                }
                if (prepositions.Contains(words[3]))
                {
                    if (words[4].ToLower().Equals("the"))
                    {
                        if (common_nouns.Contains(words[5]))
                        {
                            return true;
                        }
                    }
                }
            }
            if (prepositions.Contains(words[2])) // (there is) a book on the table
            {
                if (words[3].Equals("the"))
                {
                    if (common_nouns.Contains(words[4]) || plural_nouns.Contains(words[4]))
                        return true;
                }
            }
            if (prepositions.Contains(words[2])) // (there are) books on the table
            {
                if (plural_nouns.Contains(words[3])) return true;
            }
        }
        else
        {
            bool subjectRecognized = proper_nouns.Contains(words[0]) || singular_subject.Contains(words[0]);
            if (!subjectRecognized) { return false; }
            if (words[words.Length - 2].Equals("every")) // avverbio di tempo alla fine - gestire avverbi come every sunday
            {
                words = words.Where((value, index) => index != words.Length - 2 && index != words.Length - 1).ToArray(); // Mangia ultima posizione per togliere l'avv di tempo
            }
            if (frequencyAdverbs.Contains(words[1]))
            {
                words = words.Where((value, index) => index != 1).ToArray(); // Mangia seconda posizione per togliere l'avv di frequenza
            }
            if (frequencyAdverbs.Contains(words[2]))
            {
                words = words.Where((value, index) => index != 2).ToArray(); // Mangia seconda posizione per togliere l'avv di frequenza - He doesn’t ALWAYS agree with me.
            }
            // she the child
            if (words[1].Equals("the") || objectPronouns.Contains(words[1]))
            {
                if (common_nouns.Contains(words[2]) || plural_nouns.Contains(words[2]))
                {
                    return true;
                }
            }
            if (words[1].Equals("is"))
            {
                if (ing_verbs.Contains(words[2])) // John is playing
                {
                    if (words.Length == 3) { return true; }
                    if ((prepositions.Contains(words[3]) && words[4].Equals("the")) || words[3].Equals("the")) // in the gardent
                    {
                        if (common_nouns.Contains(words[4]) || plural_nouns.Contains(words[4]))
                        {
                            return true;
                        }
                    }
                    if (words[3].Equals("a")) // a
                    {
                        if (common_nouns.Contains(words[4])) // letter
                        {
                            return true;
                        }
                    }
                }
                if (words[2].Equals("not"))
                {
                    if (prepositions.Contains(words[3]) || words[3].Equals("the") || words[3].Equals("a")) // in the gardent
                    {
                        if (common_nouns.Contains(words[4]) || plural_nouns.Contains(words[4]))
                        {
                            return true;
                        }
                        if (adjectives.Contains(words[4]))
                        {
                            if (common_nouns.Contains(words[5]) || plural_nouns.Contains(words[5]))
                            {
                                return true;
                            }
                        }
                    }
                    if (ing_verbs.Contains(words[3])) // John is playing
                    {
                        if (words.Length == 4) { return true; }
                        if ((prepositions.Contains(words[4]) && words[5].Equals("the")) || words[4].Equals("the")) // in the gardent
                        {
                            if (common_nouns.Contains(words[5]) || plural_nouns.Contains(words[5]))
                            {
                                return true;
                            }
                        }
                        if (words[4].Equals("a")) // a
                        {
                            if (common_nouns.Contains(words[5])) // letter
                            {
                                return true;
                            } 
                        }
                    }
                    if (adjectives.Contains(words[3]))
                    {
                        return true;
                    }
                }
                if (prepositions.Contains(words[2]))
                {
                    if (common_nouns.Contains(words[3]) || plural_nouns.Contains(words[3]))
                    {
                        return true;
                    }
                }
                else
                {
                    if (words[2].Equals("a") || words[2].Equals("the")) // Paris is a (big) city
                    {
                        bool adjective = adjectives.Contains(words[3]);
                        if (adjective)
                        {
                            if (common_nouns.Contains(words[4]))
                                return true;
                        }
                        else
                        {
                            if (common_nouns.Contains(words[3]))
                                return true;
                        }
                    }
                    if (adjectives.Contains(words[2])) return true;
                }
            }
            if (words[1].Equals("has"))
            {
                if (words[2].ToLower().Equals("the") || words[2].ToLower().Equals("a"))
                {
                    if (singular_subject.Contains(words[3])) return true;
                }
                else
                {
                    if (adjectives.Contains(words[2]))
                    {
                        if (plural_nouns.Contains(words[3])) return true; // John loves big books
                    }
                    if (plural_nouns.Contains(words[2])) return true;// john loves books
                }
            }
            if (words[1].Equals("doesn't")) // "doesn't"
            {
                if (frequencyAdverbs.Contains(words[2]))
                {
                    words = words.Where((value, index) => index != 1).ToArray(); // he doesn't always
                }
                if (words[2].Equals("have") || base_verbs.Contains(words[2]))
                {
                    if (words[3].ToLower().Equals("the") || words[3].ToLower().Equals("a")) // The | a
                    {
                        if (singular_subject.Contains(words[4])) return true;
                    }
                    if (prepositions.Contains(words[3]))
                    {
                        if (common_nouns.Contains(words[4]))
                        {
                            return true;
                        }
                        if (objectPronouns.Contains(words[4]))
                        {
                            return true;
                        }
                    }
                    if (singular_subject.Contains(words[4]) || plural_nouns.Contains(words[4])) return true;
                }
                if (singular_subject.Contains(words[4]) || plural_nouns.Contains(words[4])) return true;
                
            }
            if (words[1].Equals("does") && words[2].Equals("not") && (words[3].Equals("have") || base_verbs.Contains(words[3])))
            {
                if (objectPronouns.Contains(words[4])) // she does not visit her
                {
                    if (common_nouns.Contains(words[5]) || plural_nouns.Contains(words[5])) // grandparents....
                    {
                        return true;
                    }
                }
                if (words[4].ToLower().Equals("the") || words[4].ToLower().Equals("a")) // The | a
                {
                    if (singular_subject.Contains(words[5])) return true;
                }
                else
                {
                    if (singular_subject.Contains(words[4]) || plural_nouns.Contains(words[4])) return true;
                }
            }
            if (base_verbs_3rd_person.Contains(words[1])) // A/The guy drives a/the (big) car
            {
                if (words[2].ToLower().Equals("the") || words[2].ToLower().Equals("a")) // The | a
                {
                    if (adjectives.Contains(words[3]))
                    {
                        if (common_nouns.Contains(words[4]))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (common_nouns.Contains(words[3]))
                        {
                            return true;
                        }
                    }
                }
                if (common_nouns.Contains(words[2]) || plural_subject.Contains(words[2]))
                {
                    return true;
                }
                if (common_nouns.Contains(words[2]) || plural_subject.Contains(words[2]) || objectPronouns.Contains(words[2]))
                {
                    if (common_nouns.Contains(words[3]) || plural_subject.Contains(words[3]))
                    {
                        return true;
                    }
                }
                if (adjectives.Contains(words[2]))
                {
                    if (common_nouns.Contains(words[3]) || plural_subject.Contains(words[3]))
                    {
                        return true;
                    }
                }
                if (ing_verbs.Contains(words[2]))
                {
                    return true;
                }
                if (prepositions.Contains(words[2]))
                {
                    if (common_nouns.Contains(words[3]) || plural_nouns.Contains(words[3]) || objectPronouns.Contains(words[3]))
                    {
                        return true;
                    }
                    if (words[3].ToLower().Equals("the") || words[3].ToLower().Equals("a")) // she believes in the/a miracle
                    {
                        if (common_nouns.Contains(words[4]) || plural_nouns.Contains(words[4]))
                        {
                            return true;
                        }
                    }
                }
            }
            if(subjectRecognized && words[0].Equals("i")){
                if (words[1].Equals("don't"))
                {
                    if (words[2].Equals("have") || base_verbs.Contains(words[2])) // i do play
                    {
                        if (words[3].Equals("the"))
                        {
                            if (common_nouns.Contains(words[4])) // i do play the guitar
                            {
                                return true;
                            }
                        }
                        if (plural_nouns.Contains(words[3])) // i do like apples
                        {
                            return true;
                        }
                        if (common_nouns.Contains(words[3])) // i do not have time now
                        {
                            return true;
                        }
                    }
                    if (frequencyAdverbs.Contains(words[3])) // messo qui altrimenti frasi come John like books schiattano
                    {
                        words = words.Where((value, index) => index != 2).ToArray(); // I do not ALWAYS ....
                    }
                    if (base_verbs.Contains(words[3])) // i do not play
                    {
                        if (words[4].Equals("the"))
                        {
                            if (common_nouns.Contains(words[4])) // i do not play the guitar
                            {
                                return true;
                            }
                        }
                        if (plural_nouns.Contains(words[4])) // i do not like apples
                        {
                            return true;
                        }
                        return true;
                    }
                }
                if (words[1].Equals("do"))
                {
                    if (base_verbs.Contains(words[2])) // i do play
                    {
                        if (words[3].Equals("the"))
                        {
                            if (common_nouns.Contains(words[4])) // i do play the guitar
                            {
                                return true;
                            }
                        }
                        if (plural_nouns.Contains(words[3])) // i do like apples
                        {
                            return true;
                        }
                        return true;
                    }
                    if (words[2].Equals("not")) // i do not
                    {
                        if (frequencyAdverbs.Contains(words[3])) // messo qui altrimenti frasi come John like books schiattano
                        {
                            words = words.Where((value, index) => index != 2).ToArray(); // I do not ALWAYS ....
                        }
                        if (base_verbs.Contains(words[3]) || words[3].Equals("have")) // i do not play
                        {
                            if (words[4].Equals("the"))
                            {
                                if (common_nouns.Contains(words[4])) // i do not play the guitar
                                {
                                    return true;
                                }
                            }
                            if (plural_nouns.Contains(words[4])) // i do not like apples
                            {
                                return true;
                            }
                            if (common_nouns.Contains(words[4])) // i do not play the guitar
                            {
                                return true;
                            }
                            return true;
                        }
                    }
                }
                // i drink coffee in the morning
                if (base_verbs.Contains(words[1])) // i play
                {
                    if (words[2].Equals("the"))
                    {
                        if (common_nouns.Contains(words[3])) // i play the guitar
                        {
                            return true;
                        }
                    }
                    if (plural_nouns.Contains(words[2])) // i like apples
                    {
                        return true;
                    }
                    return true;
                }
                if (words[2].Equals("not")) // i do not
                {
                    if (base_verbs.Contains(words[3])) // i do not play
                    {
                        if (words[4].Equals("the"))
                        {
                            if (common_nouns.Contains(words[5])) // i do not play the guitar
                            {
                                return true;
                            }
                        }
                        if (plural_nouns.Contains(words[4])) // i do not like apples
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
    public static bool PluralSubjectPresentSimple_Affirmation(string[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].ToLower();
        }
        // avverbi di modo alla fine della frase
        if (placeAdverbs.Contains(words[words.Length-1]) || mannerAdverbs.Contains(words[words.Length - 1]))
        {
            words = words.Where((value, index) => index != words.Length - 1).ToArray(); // Mangia ultima posizione per togliere l'avv di modo
        }
        if (timeAdverbs.Contains(words[words.Length - 1])) // avverbio di tempo alla fine
        {
            words = words.Where((value, index) => index != words.Length - 1).ToArray(); // Mangia ultima posizione per togliere l'avv di tempo
        }
        if (timeAdverbs.Contains(words[0])) // avverbio di tempo all'inizio
        {
            words = words.Where((value, index) => index != 0).ToArray(); // Mangia prima posizione per togliere l'avv di tempo
        }
        if (words[0].Equals("there") && (words[1].Equals("are")))
        {
            words = words.Skip(2).ToArray();
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
        if (words[0].ToLower().Equals("the") || words[0].ToLower().Equals("a"))
        {
            bool subjectRecognized = plural_subject.Contains(words[1]) || plural_nouns.Contains(words[1]);
            if (!subjectRecognized) { return false; }
            if (frequencyAdverbs.Contains(words[2]))
            {
                words = words.Where((value, index) => index != 1).ToArray(); // Mangia seconda posizione per togliere l'avv di frequenza
            }
            if (words[2].Equals("have"))
            {
                if (words[3].Equals("not"))
                {
                    if (adjectives.Contains(words[4]))
                        return true;
                }
                else
                {
                    if (adjectives.Contains(words[2])) return true;
                }
                if (words[3].ToLower().Equals("the") || words[3].ToLower().Equals("a"))
                {
                    if (singular_subject.Contains(words[4])) return true;
                }
                else
                {
                    if (adjectives.Contains(words[3])) return true;
                }
            }
            if (words[2].Equals("do") && words[3].Equals("not") && (words[4].Equals("have") || base_verbs.Contains(words[4])))
            {
                if (words.Length <= 5)
                {
                    return true; // The Dogs do not run
                }
                if (adjectives.Contains(words[5]))
                {
                    return true; // The Dogs do not run fast
                }
            }
            if (words[2].Equals("are"))
            {
                if (ing_verbs.Contains(words[3])) // the dogs are playing
                {
                    if(words.Length == 4) { return true; }
                    if (prepositions.Contains(words[4]) && words[5].Equals("the")) // in/on the gardent
                    {
                        if (common_nouns.Contains(words[6]) || IsAPlural(words[6]))
                        {
                            return true;
                        }
                    }
                }
                if (words[3].Equals("not"))
                {
                    if (ing_verbs.Contains(words[4])) // the dogs are not playing
                    {
                        if (words.Length == 5) 
                        { 
                            return true; 
                        }
                        if (prepositions.Contains(words[5]) && words[6].Equals("the")) // in/on the gardent
                        {
                            if (common_nouns.Contains(words[7]) || IsAPlural(words[7]))
                            {
                                return true;
                            }
                        }
                    }
                    if (adjectives.Contains(words[4]))
                    {
                        return true;
                    }
                }
                else
                {
                    if (adjectives.Contains(words[3])) return true;
                }
            }
            if (base_verbs.Contains(words[2])) // A/The dogs run fast
            {
                if (words.Length <= 3)
                {
                    return true; // the dogs run}
                }
                if (adjectives.Contains(words[3]))
                {
                    return true;
                }
                if (prepositions.Contains(words[3]))
                {
                    if (words[4].Equals("the") || objectPronouns.Contains(words[4]))
                    {
                        if (common_nouns.Contains(words[5]) || IsAPlural(words[5]))
                        {
                            return true;
                        }
                    }
                }
            }
        }
        else
        {
            bool subjectRecognized =  plural_subject.Contains(words[0]) || IsAPlural(words[0]);
            if (!subjectRecognized) { return false; }
            if (frequencyAdverbs.Contains(words[1]))
            {
                words = words.Where((value, index) => index != 1).ToArray(); // Mangia seconda posizione per togliere l'avv di frequenza
            }
            if (words[1].Equals("the") || objectPronouns.Contains(words[1]))
            {
                if (common_nouns.Contains(words[2]) || IsAPlural(words[2]))
                {
                    return true;
                }
            }
            if (words[1].Equals("do") && words[2].Equals("not") && (words[3].Equals("have") || base_verbs.Contains(words[3])))
            {
                if (words.Length <= 4)
                {
                    return true; // Dogs do not run
                }
                if (adjectives.Contains(words[4]))
                {
                    return true; // The Dogs do not run fast
                }
            }
            if (words[1].Equals("are") || words[1].Equals("aren't"))
            {
                if (frequencyAdverbs.Contains(words[2]))
                {
                    words = words.Where((value, index) => index != 2).ToArray(); // Mangia seconda posizione per togliere l'avv di frequenza
                }
                if (words.Length <= 2) // they are
                {
                    return true;
                }
                if (ing_verbs.Contains(words[2]))
                {
                    return true;
                }
                if (words[2].Equals("not"))
                {
                    if(words.Length <= 3) // they are not
                    {
                        return true;
                    }
                    // continua present continuous 
                    if (ing_verbs.Contains(words[3])) // they are not standig (here)
                    {
                        return true;
                    }
                    if (adjectives.Contains(words[3]))
                    {
                        return true;
                    }
                }
                if (prepositions.Contains(words[2]))
                {
                    if (common_nouns.Contains(words[3]))
                    {
                        return true;
                    }
                }
                else
                {
                    if (adjectives.Contains(words[2])) return true;
                }
            }
            if (base_verbs.Contains(words[1])) // A/The guy drives a/the (big) car
            {
                if (words.Length < 3)
                {
                    return true; // Cat jump
                }
                if (words[2].ToLower().Equals("the") || words[2].ToLower().Equals("a")) // The | a
                {
                    if (adjectives.Contains(words[3]))
                    {
                        if (common_nouns.Contains(words[4]))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (common_nouns.Contains(words[3]))
                        {
                            return true;
                        }
                    }
                }
                IsAPlural(words[2]);
                if (common_nouns.Contains(words[2]) /*|| plural_subject.Contains(words[2])*/)
                {
                    return true;
                }
                if (objectPronouns.Contains(words[2]))
                {
                    IsAPlural(words[3]);
                    if (common_nouns.Contains(words[3]) /*|| plural_subject.Contains(words[3])*/)
                    {
                        return true;
                    }
                }
                if (adjectives.Contains(words[2]))
                {
                    IsAPlural(words[3]);
                    if (common_nouns.Contains(words[3]) /*|| plural_subject.Contains(words[3])*/)
                    {
                        return true;
                    }
                }
            }
            if (prepositions.Contains(words[1])) // (there is) a book on the table
            {
                if (words[2].Equals("the"))
                {
                    IsAPlural(words[3]);
                    if (common_nouns.Contains(words[3])/* || plural_nouns.Contains(words[3])*/)
                        return true;

                }
            }
            if (words[1].Equals("do"))
            {
                if (base_verbs.Contains(words[2])) // they do play
                {
                    if (words[3].Equals("the"))
                    {
                        if (common_nouns.Contains(words[4])) // they do play the guitar
                        {
                            return true;
                        }
                    }
                    IsAPlural(words[3]); // i do like apples
                    //if (plural_nouns.Contains(words[3])) // i do like apples
                    //{
                    //    return true;
                    //}
                }
                if (words[2].Equals("not")) // they do not
                {
                    if (frequencyAdverbs.Contains(words[3]))
                    {
                        words = words.Where((value, index) => index != 3).ToArray(); // I do not ALWAYS ....
                    }
                    if (base_verbs.Contains(words[3])) // i do not play
                    {
                        if (words[4].Equals("the"))
                        {
                            if (common_nouns.Contains(words[4])) // i do not play the guitar
                            {
                                return true;
                            }
                        }
                        IsAPlural(words[3]); // they do not like apples
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private static bool IsAPlural(string word) => plural_nouns.Contains(word);
















    private void Start()
    {
        List<string> sentences = new List<string>
        {
            // Present Simple - Affermazioni
            "The car is big.",
            "The cars are big.",
            "A car is big.",
            "A guy has a car.",
            "Google has a car.",
            "John loves books.",
            "John loves big books.",
            "The sun rises in the east.",
            "He likes apples.",
            "She believes in miracles.",
            "She believes in a miracle.",
            "The cat jumps.",
            "Cats jump.",
            "The dogs run fast.",
            "The dogs run.",
    
            // Present Simple - Negazioni
            "The car is not big.",
            "The cars are not big.",
            "A car is not big.",
            "A guy does not have a car.",
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
            "The dogs run.",
            "The dogs run in the garden.",
            "The dogs are playing in the garden.",

            // others
            "It is a sunny day.",
            "It is not a sunny day.",
            "he likes reading",

            "Dogs bark",
            "She is at home",
            "She is not at home",

            "She drives the car carefully." 

            //"He completed the task quickly.",

            //"She carefully drives the car.",
            //"He quickly completed the task."
        };

        foreach (var sentence in sentences)
        {
            if (!IsValidSentence(sentence))
            {
                Debug.Log(sentence);
            }
            //Debug.Log($"'{sentence}' è grammaticalmente valido? {IsValidSentence(sentence)}");
        }
    }

    public void Click(string phrase) {
        Debug.Log(IsValidSentence(phrase));
    }

    // CanDetectThisgrammaticalStructures
    string[] CanDetectThisgrammaticalStructures = {
    "Subject + Verb 'to be' + Adjective",
    "Subject + Verb 'to be' + Negation + Adjective",
    "Subject + Verb 'has' + Object",
    "Proper Noun + Verb 'has' + Object",
    "Proper Noun + Verb + Object",
    "Subject + Verb + Object",
    "Subject + Verb + Prepositional Complement",
    "Subject + Verb + Adjective + Object",
    "Plural Subject + Verb 'to be' + Adjective",
    "Plural Subject + Verb",
    "Plural Subject + Verb 'to be' + Negation + Adjective",
    "Plural Subject + Auxiliary 'do not' + Base Verb + Object",
    "Subject + Auxiliary 'does not' + Base Verb + Object",
    "Subject + Auxiliary 'do/does' + (not) + Base Verb + Object",
    "Subject + Frequency Adverb + Verb + Object",
    "Subject + Frequency Adverb + Verb + Object + Time Adverb",
    "Subject + Contraction 'doesn't/don't' + Frequency Adverb + Base Verb + Prepositional Complement",
    "Subject + Phrasal Verb + Object",
    "Subject + Verb 'to be' + Verb -ing",
    "Subject + Verb 'to be' + Negation + Verb -ing",
    "Proper Noun + Verb 'to be' + Verb -ing + Object",
    "Subject + Verb 'to be' + Verb -ing + Prepositional Complement"
};

}
