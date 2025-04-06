using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonTests : MonoBehaviour
{
    static List<string> singular_subject = new List<string> { "student","beef", "dog", "i", "girl", "boy", "coffee", "book", "table", "bike", "car", "guy", "cat", "water", "sun", "he", "she", "it" };
    static List<string> base_verbs = new List<string> { "smile", "enjoy", "dance","sing","read","talk","swim", "play", "travel", "sleep", "study", "eat","be", "walk", "complete", "bark", "visit", "work", "agree", "drink", "like", "love", "drive", "are", "run", "jump", "believe" };
    static List<string> base_verbs_3rd_person = new List<string> { "smiles","enjoys","dances","sings","reads","talks", "swims", "plays", "travels", "sleeps", "studies","eats","walks", "completes", "barks", "visits", "agrees", "likes","loves", "drives", "runs", "jumps", "boils", "rises", "knows", "believes", "likes", "drinks" };
    static List<string> ing_verbs = new List<string> { "smiling","enjoying","dancing","singing", "reading","talking","swimming", "playing", "traveling", "sleeping", "studying", "eating", "walking", "completing", "being","agreeing", "liking", "standing", "writing", "playing", "reading", "eating", "running", "loving", "driving", "waiting" };
    static List<string> past_participle = new List<string> { "studied", "completed", "finished", "repaired", "loved", "driven" };
    static List<string> modal_verbs = new List<string> { "can", "could", "shall", "should", "will", "would", "may", "might", "must" };

    static List<string> question_words = new List<string> { "who", "what", "where", "when", "why", "how", "which", "whose" };
    static List<string> adjectives = new List<string> { "sunny","cold", "big", "small", "tall", "short", "bright", "dark", "beautiful", "ugly", "fast" };

    static List<string> common_nouns = new List<string> { "basketball","football","soccer","apple", "assignment", "student","beef", "dog", "task", "garden", "day","time", "grandparent", "home", "pizza", "guitar", "letter", "garden", "girl", "boy", "sandwich", "problem", "meeting", "table", "sugar", "house", "jacket", "fight", "lamp","child", "coffee", "table", "bike", "apple", "book", "table", "house", "computer", "dog", "city", "car", "game", "east", "west", "north", "south", "answer", "miracle" };
    static List<string> plural_nouns = new List<string> { "students", "beefs", "grandparents", "girls", "we", "they", "you",
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
    static List<string> timeAdverbs = new List<string> { "now", "later", "soon", "tomorrow", "yesterday", "tonight", "every", "at night", "today" };
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

        if      (SingularSubjectPresentSimple_Affirmation(words)){ return true; }
        else if (PluralSubjectPresentSimple_Affirmation(words))  { return true; }
        else                                                     { return false; }
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
                if (A(words[3]) || The(words[3]) || IsAPreposition(words[3])) // eating a/the sandwich
                {
                    if (IsACommon(words[4])) return true;
                }
                if (IsACommon(words[3])) return true;
                if (IsPastParticiple(words[3])) return true;
                if (IsAPrasphalVerb(words[3], words[4])) return true;
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
            if (IsAPrasphalVerb(words[2], words[3])) return true;
        }
        
        if (Hasnt(words[1]))
        {
            words = RemoveAdverbs(words, 2);
            if (IsAPrasphalVerb(words[2], words[3])) return true;
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
                    if (IsPastParticiple(words[4])) return true;
                    if (!IsFixedLenght(words, 4))
                    {
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
                if(!IsFixedLenght(words, 3))
                {
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
            }
            if (IsPastParticiple(words[2]))
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
        if (Has(words[1]))
        {
            words = RemoveAdverbs(words, 2);  //         0   1   2    3
            words = RemoveAdverbs(words, 3); // The big car has not always been being carefully turned on today.
            if (IsPastParticiple(words[2]))
            {
                if (The(words[3]) || A(words[3]) || An(words[3]) || IsAPossessivePronouns(words[3]))
                {
                    if (IsACommon(words[4])) return true;
                    if (IsAPlural(words[4])) return true;
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
                        //if (IsAnIngVerbs(words[5]))
                        //{
                        //    words = RemoveAdverbs(words, 5);
                        //    if (IsPastParticiple(words[6])) return true;
                        //}
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
                    if (IsPastParticiple(words[4])) return true;
                    if (!IsFixedLenght(words, 4))
                    {
                        if (IsAPrasphalVerb(words[4], words[5])) return true;
                    }
                }
                if (!IsFixedLenght(words, 3))
                {
                    if (IsAPrasphalVerb(words[3], words[4])) return true;
                }
            }
            if (IsAnAdjective(words[2])) return true;
            if (The(words[2]) || A(words[2]) || IsAPossessivePronouns(words[2])) // The | a
            {
                if (IsASingular(words[3])) return true;
                if (IsAPlural(words[3])) return true;
            }
            if (IsAPrasphalVerb(words[2], words[3])) return true;
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
                if (IsASingular(words[4]) || IsAPlural(words[4])) return true;
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
        if(position > words.Length) return words;
        if (IsAFrequencyAdverb(words[position]))
        {
            words = words.Where((value, index) => index != position).ToArray();
        }
        if (IsAMannerAdverbs(words[position]))
        {
            words = words.Where((value, index) => index != position).ToArray();
        }
        position++;
        if(IsFixedLenght(words, position))
        {
            if (IsAFrequencyAdverb(words[position-1]) && IsAMannerAdverbs(words[position]))
            {
                words = words.Where((value, index) => index != position-1 && index != position).ToArray();
            }
        }
        return words;
    }
    public static string[] Normalization(string[] words) // se clicchi sulla parola, la aggiungi all'array e poi vedi se la frase è corretta
    {
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].ToLower();
            //if (i != 0 && (The(words[i]) || A(words[i]) || An(words[i])))
            //{
            //    List<string> list = new List<string>(words);
            //    list.Remove(words[i]);
            //    list.Insert(i, "");
            //    words = list.ToArray(); // remove middle the || a || an
            //}
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
        if (IsAPlaceAdverbs(words[words.Length - 1]) || IsAMannerAdverbs(words[words.Length - 1]))
        {
            words = words.Where((value, index) => index != words.Length - 1).ToArray(); // Mangia ultima posizione per togliere l'avv di modo
        }
        if (IsATimeAdverb(words[words.Length - 1])) // avverbio di tempo alla fine
        {
            words = words.Where((value, index) => index != words.Length - 1).ToArray(); // Mangia ultima posizione per togliere l'avv di tempo
        }
        if (IsATimeAdverb(words[0])) // avverbio di tempo all'inizio
        {
            words = words.Where((value, index) => index != 0).ToArray(); // Mangia prima posizione per togliere l'avv di tempo
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
        foreach (var sentence in sentences)
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


}
