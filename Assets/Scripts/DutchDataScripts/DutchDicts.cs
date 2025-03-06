using System.Collections.Generic;
using UnityEngine;

public class DutchDicts : MonoBehaviour
{
    #region initializations
    // A1
    private static readonly Dictionary<string, string> frasi_originali_e_soluzioni_olandese_a1 = new Dictionary<string, string>
    {
        //frasi_originali_e_soluzioni_olandese_a1.Add("Hallo, hoe heet je?", "Hello, what is your name?");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik heet " + GameManager.Instance.username, "My name is " + GameManager.Instance.username);
        //frasi_originali_e_soluzioni_olandese_a1.Add("Waar kom je vandaan?", "Where are you from?");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik kom uit Italië", "I come from Italy");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Hoe gaat het met je? ", "How are you?");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Goed, dank je!", "Good, thank you!");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik woon in Nederland", "I live in the Netherlands");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik werk als softwareontwikkelaar", "I work as a software developer");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik heb een kleine auto", "I have a small car");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Hij woont in een groot huis", "He lives in a big house");

        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik ga naar de supermarkt", "I am going to the supermarket");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Zij drinkt koffie in de ochtend", "She drinks coffee in the morning");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik spreek een beetje Nederlands", "I speak a little Dutch");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Kun je dat herhalen, alsjeblieft?", "Can you repeat that, please?");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Wij eten pizza vanavond", "We are eating pizza tonight");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Jij leest een boek", "You are reading a book");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Hij slaapt om tien uur", "He sleeps at ten o'clock");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Wij gaan morgen naar Amsterdam", "We are going to Amsterdam tomorrow");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik begrijp het niet", "I don’t understand it");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Ik heb geen geld", "I don’t have money");
        //frasi_originali_e_soluzioni_olandese_a1.Add("Original 20", " Soluzione 20");

        { "dutchA1_0", "1"}, // reset
        { "dutchA1_1", "1"},
        { "dutchA1_2", "1"},
        { "dutchA1_3", "1"},
        { "dutchA1_4", "1"},
        { "dutchA1_5", "1"},
        { "dutchA1_6", "1"},
        { "dutchA1_7", "1"},
        { "dutchA1_8", "1"},
        { "dutchA1_9", "1"},

        { "dutchA1_10", "1"}, // reset
        { "dutchA1_11", "1"},
        { "dutchA1_12", "1"},
        { "dutchA1_13", "1"},
        { "dutchA1_14", "1"},
        { "dutchA1_15", "1"},
        { "dutchA1_16", "1"},
        { "dutchA1_17", "1"},
        { "dutchA1_18", "1"},
        { "dutchA1_19", "1"},

        { "dutchA1_20", "1"}, // reset
        { "dutchA1_21", "1"},
        { "dutchA1_22", "1"},
        { "dutchA1_23", "1"},
        { "dutchA1_24", "1"},
        { "dutchA1_25", "1"},
        { "dutchA1_26", "1"},
        { "dutchA1_27", "1"},
        { "dutchA1_28", "1"},
        { "dutchA1_29", "1"},

        { "dutchA1_30", "1"}, // reset
        { "dutchA1_31", "1"},
        { "dutchA1_32", "1"},
        { "dutchA1_33", "1"},
        { "dutchA1_34", "1"},
        { "dutchA1_35", "1"},
        { "dutchA1_36", "1"},
        { "dutchA1_37", "1"},
        { "dutchA1_38", "1"},
        { "dutchA1_39", "1"},

        { "dutchA1_40", "1"}, // reset
        { "dutchA1_41", "1"},
        { "dutchA1_42", "1"},
        { "dutchA1_43", "1"},
        { "dutchA1_44", "1"},
        { "dutchA1_45", "1"},
        { "dutchA1_46", "1"},
        { "dutchA1_47", "1"},
        { "dutchA1_48", "1"},
        { "dutchA1_49", "1"},


        { "dutchA1_50", "1"}, // reset
        { "dutchA1_51", "1"},
        { "dutchA1_52", "1"},
        { "dutchA1_53", "1"},
        { "dutchA1_54", "1"},
        { "dutchA1_55", "1"},
        { "dutchA1_56", "1"},
        { "dutchA1_57", "1"},
        { "dutchA1_58", "1"},
        { "dutchA1_59", "1"},

        { "dutchA1_60", "1"}, // reset
        { "dutchA1_61", "1"},
        { "dutchA1_62", "1"},
        { "dutchA1_63", "1"},
        { "dutchA1_64", "1"},
        { "dutchA1_65", "1"},
        { "dutchA1_66", "1"},
        { "dutchA1_67", "1"},
        { "dutchA1_68", "1"},
        { "dutchA1_69", "1"},

        { "dutchA1_70", "1"}, // reset
        { "dutchA1_71", "1"},
        { "dutchA1_72", "1"},
        { "dutchA1_73", "1"},
        { "dutchA1_74", "1"},
        { "dutchA1_75", "1"},
        { "dutchA1_76", "1"},
        { "dutchA1_77", "1"},
        { "dutchA1_78", "1"},
        { "dutchA1_79", "1"},

        { "dutchA1_80", "1"}, // reset
        { "dutchA1_81", "1"},
        { "dutchA1_82", "1"},
        { "dutchA1_83", "1"},
        { "dutchA1_84", "1"},
        { "dutchA1_85", "1"},
        { "dutchA1_86", "1"},
        { "dutchA1_87", "1"},
        { "dutchA1_88", "1"},
        { "dutchA1_89", "1"},

        { "dutchA1_90", "1"}, // reset
        { "dutchA1_91", "1"},
        { "dutchA1_92", "1"},
        { "dutchA1_93", "1"},
        { "dutchA1_94", "1"},
        { "dutchA1_95", "1"},
        { "dutchA1_96", "1"},
        { "dutchA1_97", "1"},
        { "dutchA1_98", "1"},
        { "dutchA1_99", "1"},

        { "dutchA1_100", "1"}
    };
    private static readonly Dictionary<string, string> dutch_a1_rules_titles_and_bodies = new Dictionary<string, string>
    {
        {"1. Pronunciation and Special Sounds ", "The \"g\" sounds like a guttural \"h\" (e.g., goed → /ɣut/).\r\n\nThe \"ui\" sounds similar to the French \"œy\" (e.g., huis → /hœys/).\r\n\nThe \"ij\" and \"ei\" are pronounced like a mix between \"ai\" and \"ei\".\r\n\nThe \"sch\" sounds like an \"s\" followed by a guttural \"ch\" (e.g., school → /sxoːl/)." },
        {"2. Definite and Indefinite Articles ", "De → Used for most common nouns (de man = the man, de vrouw = the woman).\r\n\nHet → Used for neutral words and diminutives (het huis = the house, het kind = the child).\r\n\nEen → Indefinite article, meaning \"a\" or \"an\" (een boek = a book)." },
        {"3. Plural Forms of Nouns ", "Add -en: huis → huizen (house → houses), boom → bomen (tree → trees).\r\n\nAdd -s (if the word ends in a vowel or unstressed syllable): auto → auto’s (car → cars)."},
        {"4. Personal Pronouns ", "I = Ik \n\nYou = Jij / Je\n\nHe/She/It = \tHij / Zij (Ze) / Het\n\nWe = Wij (We)\n\nYou (pl.) = Jullie\n\nThey = Zij (Ze)\n\nNote: \"Jij\" and \"Zij\" are emphasized forms, while \"Je\" and \"Ze\" are neutral and used more often in conversation."},
        {"5. Present Tense Verb Conjugation ", "Dutch verbs are mostly regular. Example with werken (to work):\r\n\r\n\nIk werk (I work)\r\n\nJij werkt (You work)\r\n\nHij/Zij/Het werkt (He/She/It works)\r\n\nWij/Jullie/Zij werken (We/You/They work)Irregular Verbs (Common Examples)\r\n\nHebben (to have) → ik heb, jij hebt, hij heeft, wij hebben\r\n\nZijn (to be) → ik ben, jij bent, hij is, wij zijn"},
        {"6. Word Order (SVO and Question Inversion) ", "Regular sentence: Ik werk vandaag (I work today).\r\n\nQuestion: Werk jij vandaag? (Do you work today?) → The verb moves to the beginning.\r\n\nSubordinate clause: Omdat ik vandaag werk (Because I work today) → The verb moves to the end."},
        {"7. Negation with \"niet\" and \"geen\" ", "Niet negates a verb or adjective: Ik werk niet (I do not work).\r\n\nGeen negates a noun without an article: Ik heb geen auto (I have no car)."},
        {"8. Common Prepositions ", "In → in (in de kamer = in the room)\r\n\nOp → on (op tafel = on the table)\r\n\nOnder → under (onder de stoel = under the chair)\r\n\nMet → with (met vrienden = with friends)\r\n\nBij → at, near (bij de bakker = at the bakery)"},
        {"9. Adjectives and Their Placement ", "Before the noun: een grote auto (a big car).\r\n\nIf the noun is \"het\" and indefinite, the adjective does not take -e: een groot huis (a big house)."},
        {"10. Useful Basic Phrases ", "Hoi / Hallo → Hi / Hello\r\n\nHoe gaat het? → How are you?\r\n\nGoed, en met jou? → Good, and you?\r\n\nDank je (wel)! → Thank you!\r\n\nAlsjeblieft / Alstublieft → Please\r\n\nIk begrijp het niet → I don’t understand\r\n\nKunt u dat herhalen? → Can you repeat that?"},
    };
    private static readonly Dictionary<int, Dictionary<string, string>> dutchHashMap_a1 = new Dictionary<int, Dictionary<string, string>> { { 1, Frasi_originali_e_soluzioni_olandese_a1 } };
   
    // A2
    private static readonly Dictionary<string, string> frasi_originali_e_soluzioni_olandese_a2 = new Dictionary<string, string>
    {
        { "dutchA2_0", "1"},
        { "dutchA2_1", "1"},
        { "dutchA2_2", "1"},
        { "dutchA2_3", "1"},
        { "dutchA2_4", "1"},
        { "dutchA2_5", "1"},
        { "dutchA2_6", "1"},
        { "dutchA2_7", "1"},
        { "dutchA2_8", "1"},
        { "dutchA2_9", "1"},

        { "dutchA2_10", "1"},
        { "dutchA2_11", "1"},
        { "dutchA2_12", "1"},
        { "dutchA2_13", "1"},
        { "dutchA2_14", "1"},
        { "dutchA2_15", "1"},
        { "dutchA2_16", "1"},
        { "dutchA2_17", "1"},
        { "dutchA2_18", "1"},
        { "dutchA2_19", "1"},

        { "dutchA2_20", "1"}
    };
    private static readonly Dictionary<string, string> dutch_a2_rules_titles_and_bodies = new Dictionary<string, string>
    {
        {"1. A2 Rule n.1", "A2 Body Rule n.1" },
        {"2. A2 Rule n.2", "A2 Body Rule n.2" },
        {"3. A2 Rule n.3", "A2 Body Rule n.3" },
        {"4. A2 Rule n.4", "A2 Body Rule n.4" },
        {"5. A2 Rule n.5", "A2 Body Rule n.5" },
    };
    private static readonly Dictionary<int, Dictionary<string, string>> dutchHashMap_a2 = new Dictionary<int, Dictionary<string, string>> { { 1, Frasi_originali_e_soluzioni_olandese_a2 } };

    // B1
    private static readonly Dictionary<string, string> frasi_originali_e_soluzioni_olandese_b1 = new Dictionary<string, string>
    {
        { "dutchB1_0", "1"},
        { "dutchB1_1", "1"},
        { "dutchB1_2", "1"},
        { "dutchB1_3", "1"},
        { "dutchB1_4", "1"},
        { "dutchB1_5", "1"},
        { "dutchB1_6", "1"},
        { "dutchB1_7", "1"},
        { "dutchB1_8", "1"},
        { "dutchB1_9", "1"},

        { "dutchB1_10", "1"},
        { "dutchB1_11", "1"},
        { "dutchB1_12", "1"},
        { "dutchB1_13", "1"},
        { "dutchB1_14", "1"},
        { "dutchB1_15", "1"},
        { "dutchB1_16", "1"},
        { "dutchB1_17", "1"},
        { "dutchB1_18", "1"},
        { "dutchB1_19", "1"},

        { "dutchB1_20", "1"},
        { "dutchB1_21", "1"},
        { "dutchB1_22", "1"},
        { "dutchB1_23", "1"},
        { "dutchB1_24", "1"},
        { "dutchB1_25", "1"},
        { "dutchB1_26", "1"},
        { "dutchB1_27", "1"},
        { "dutchB1_28", "1"},
        { "dutchB1_29", "1"},

        { "dutchB1_30", "1"},
        { "dutchB1_31", "1"},
        { "dutchB1_32", "1"},
        { "dutchB1_33", "1"},
        { "dutchB1_34", "1"},
        { "dutchB1_35", "1"},
        { "dutchB1_36", "1"},
        { "dutchB1_37", "1"},
        { "dutchB1_38", "1"},
        { "dutchB1_39", "1"},

        { "dutchB1_40", "1"},
        { "dutchB1_41", "1"},
        { "dutchB1_42", "1"},
        { "dutchB1_43", "1"},
        { "dutchB1_44", "1"},
        { "dutchB1_45", "1"},
        { "dutchB1_46", "1"},
        { "dutchB1_47", "1"},
        { "dutchB1_48", "1"},
        { "dutchB1_49", "1"},

        { "dutchB1_50", "1"},
        { "dutchB1_51", "1"},
        { "dutchB1_52", "1"},
        { "dutchB1_53", "1"},
        { "dutchB1_54", "1"},
        { "dutchB1_55", "1"},
        { "dutchB1_56", "1"},
        { "dutchB1_57", "1"},
        { "dutchB1_58", "1"},
        { "dutchB1_59", "1"},

        { "dutchB1_60", "1"},
        { "dutchB1_61", "1"},
        { "dutchB1_62", "1"},
        { "dutchB1_63", "1"},
        { "dutchB1_64", "1"},
        { "dutchB1_65", "1"},
        { "dutchB1_66", "1"},
        { "dutchB1_67", "1"},
        { "dutchB1_68", "1"},
        { "dutchB1_69", "1"},

        { "dutchB1_70", "1"},
        { "dutchB1_71", "1"},
        { "dutchB1_72", "1"},
        { "dutchB1_73", "1"},
        { "dutchB1_74", "1"},
        { "dutchB1_75", "1"},
        { "dutchB1_76", "1"},
        { "dutchB1_77", "1"},
        { "dutchB1_78", "1"},
        { "dutchB1_79", "1"},

        { "dutchB1_80", "1"},
        { "dutchB1_81", "1"},
        { "dutchB1_82", "1"},
        { "dutchB1_83", "1"},
        { "dutchB1_84", "1"},
        { "dutchB1_85", "1"},
        { "dutchB1_86", "1"},
        { "dutchB1_87", "1"},
        { "dutchB1_88", "1"},
        { "dutchB1_89", "1"},

        { "dutchB1_90", "1"},
        { "dutchB1_91", "1"},
        { "dutchB1_92", "1"},
        { "dutchB1_93", "1"},
        { "dutchB1_94", "1"},
        { "dutchB1_95", "1"},
        { "dutchB1_96", "1"},
        { "dutchB1_97", "1"},
        { "dutchB1_98", "1"},
        { "dutchB1_99", "1"},

        { "dutchB1_100", "1"}
    };
    private static readonly Dictionary<string, string> dutch_b1_rules_titles_and_bodies = new Dictionary<string, string>
    {
        {"1. B1 Rule n.1", "B1 Body Rule n.1" },
        {"2. B1 Rule n.2", "B1 Body Rule n.2" },
        {"3. B1 Rule n.3", "B1 Body Rule n.3" },
        {"4. B1 Rule n.4", "B1 Body Rule n.4" },
        {"5. B1 Rule n.5", "B1 Body Rule n.5" },
    };
    private static readonly Dictionary<int, Dictionary<string, string>> dutchHashMap_b1 = new Dictionary<int, Dictionary<string, string>> { { 1, Frasi_originali_e_soluzioni_olandese_b1 } };

    // B2
    private static readonly Dictionary<string, string> frasi_originali_e_soluzioni_olandese_b2 = new Dictionary<string, string>
    {
        { "dutchB2_0", "1"},
        { "dutchB2_1", "1"},
        { "dutchB2_2", "1"},
        { "dutchB2_3", "1"},
        { "dutchB2_4", "1"},
        { "dutchB2_5", "1"},
        { "dutchB2_6", "1"},
        { "dutchB2_7", "1"},
        { "dutchB2_8", "1"},
        { "dutchB2_9", "1"},

        { "dutchB2_10", "1"},
        { "dutchB2_11", "1"},
        { "dutchB2_12", "1"},
        { "dutchB2_13", "1"},
        { "dutchB2_14", "1"},
        { "dutchB2_15", "1"},
        { "dutchB2_16", "1"},
        { "dutchB2_17", "1"},
        { "dutchB2_18", "1"},
        { "dutchB2_19", "1"},

        { "dutchB2_20", "1"},
        { "dutchB2_21", "1"},
        { "dutchB2_22", "1"},
        { "dutchB2_23", "1"},
        { "dutchB2_24", "1"},
        { "dutchB2_25", "1"},
        { "dutchB2_26", "1"},
        { "dutchB2_27", "1"},
        { "dutchB2_28", "1"},
        { "dutchB2_29", "1"},

        { "dutchB2_30", "1"},
        { "dutchB2_31", "1"},
        { "dutchB2_32", "1"},
        { "dutchB2_33", "1"},
        { "dutchB2_34", "1"},
        { "dutchB2_35", "1"},
        { "dutchB2_36", "1"},
        { "dutchB2_37", "1"},
        { "dutchB2_38", "1"},
        { "dutchB2_39", "1"},

        { "dutchB2_40", "1"},
        { "dutchB2_41", "1"},
        { "dutchB2_42", "1"},
        { "dutchB2_43", "1"},
        { "dutchB2_44", "1"},
        { "dutchB2_45", "1"},
        { "dutchB2_46", "1"},
        { "dutchB2_47", "1"},
        { "dutchB2_48", "1"},
        { "dutchB2_49", "1"},

        { "dutchB2_50", "1"},
        { "dutchB2_51", "1"},
        { "dutchB2_52", "1"},
        { "dutchB2_53", "1"},
        { "dutchB2_54", "1"},
        { "dutchB2_55", "1"},
        { "dutchB2_56", "1"},
        { "dutchB2_57", "1"},
        { "dutchB2_58", "1"},
        { "dutchB2_59", "1"},

        { "dutchB2_60", "1"},
        { "dutchB2_61", "1"},
        { "dutchB2_62", "1"},
        { "dutchB2_63", "1"},
        { "dutchB2_64", "1"},
        { "dutchB2_65", "1"},
        { "dutchB2_66", "1"},
        { "dutchB2_67", "1"},
        { "dutchB2_68", "1"},
        { "dutchB2_69", "1"},

        { "dutchB2_70", "1"},
        { "dutchB2_71", "1"},
        { "dutchB2_72", "1"},
        { "dutchB2_73", "1"},
        { "dutchB2_74", "1"},
        { "dutchB2_75", "1"},
        { "dutchB2_76", "1"},
        { "dutchB2_77", "1"},
        { "dutchB2_78", "1"},
        { "dutchB2_79", "1"},

        { "dutchB2_80", "1"},
        { "dutchB2_81", "1"},
        { "dutchB2_82", "1"},
        { "dutchB2_83", "1"},
        { "dutchB2_84", "1"},
        { "dutchB2_85", "1"},
        { "dutchB2_86", "1"},
        { "dutchB2_87", "1"},
        { "dutchB2_88", "1"},
        { "dutchB2_89", "1"},

        { "dutchB2_90", "1"},
        { "dutchB2_91", "1"},
        { "dutchB2_92", "1"},
        { "dutchB2_93", "1"},
        { "dutchB2_94", "1"},
        { "dutchB2_95", "1"},
        { "dutchB2_96", "1"},
        { "dutchB2_97", "1"},
        { "dutchB2_98", "1"},
        { "dutchB2_99", "1"},

        { "dutchB2_100", "1"}
    };
    private static readonly Dictionary<string, string> dutch_b2_rules_titles_and_bodies = new Dictionary<string, string>
    {
        {"1. B2 Rule n.1", "B2 Body Rule n.1" },
        {"2. B2 Rule n.2", "B2 Body Rule n.2" },
        {"3. B2 Rule n.3", "B2 Body Rule n.3" },
        {"4. B2 Rule n.4", "B2 Body Rule n.4" },
        {"5. B2 Rule n.5", "B2 Body Rule n.5" },
    };
    private static readonly Dictionary<int, Dictionary<string, string>> dutchHashMap_b2 = new Dictionary<int, Dictionary<string, string>> { { 1, Frasi_originali_e_soluzioni_olandese_b2 } };

    // C1
    private static readonly Dictionary<string, string> frasi_originali_e_soluzioni_olandese_c1 = new Dictionary<string, string>
    {
        { "dutchC1_0", "1"},
        { "dutchC1_1", "1"},
        { "dutchC1_2", "1"},
        { "dutchC1_3", "1"},
        { "dutchC1_4", "1"},
        { "dutchC1_5", "1"},
        { "dutchC1_6", "1"},
        { "dutchC1_7", "1"},
        { "dutchC1_8", "1"},
        { "dutchC1_9", "1"},

        { "dutchC1_10", "1"},
        { "dutchC1_11", "1"},
        { "dutchC1_12", "1"},
        { "dutchC1_13", "1"},
        { "dutchC1_14", "1"},
        { "dutchC1_15", "1"},
        { "dutchC1_16", "1"},
        { "dutchC1_17", "1"},
        { "dutchC1_18", "1"},
        { "dutchC1_19", "1"},

        { "dutchC1_20", "1"},
        { "dutchC1_21", "1"},
        { "dutchC1_22", "1"},
        { "dutchC1_23", "1"},
        { "dutchC1_24", "1"},
        { "dutchC1_25", "1"},
        { "dutchC1_26", "1"},
        { "dutchC1_27", "1"},
        { "dutchC1_28", "1"},
        { "dutchC1_29", "1"},

        { "dutchC1_30", "1"},
        { "dutchC1_31", "1"},
        { "dutchC1_32", "1"},
        { "dutchC1_33", "1"},
        { "dutchC1_34", "1"},
        { "dutchC1_35", "1"},
        { "dutchC1_36", "1"},
        { "dutchC1_37", "1"},
        { "dutchC1_38", "1"},
        { "dutchC1_39", "1"},

        { "dutchC1_40", "1"},
        { "dutchC1_41", "1"},
        { "dutchC1_42", "1"},
        { "dutchC1_43", "1"},
        { "dutchC1_44", "1"},
        { "dutchC1_45", "1"},
        { "dutchC1_46", "1"},
        { "dutchC1_47", "1"},
        { "dutchC1_48", "1"},
        { "dutchC1_49", "1"},

        { "dutchC1_50", "1"},
        { "dutchC1_51", "1"},
        { "dutchC1_52", "1"},
        { "dutchC1_53", "1"},
        { "dutchC1_54", "1"},
        { "dutchC1_55", "1"},
        { "dutchC1_56", "1"},
        { "dutchC1_57", "1"},
        { "dutchC1_58", "1"},
        { "dutchC1_59", "1"},

        { "dutchC1_60", "1"},
        { "dutchC1_61", "1"},
        { "dutchC1_62", "1"},
        { "dutchC1_63", "1"},
        { "dutchC1_64", "1"},
        { "dutchC1_65", "1"},
        { "dutchC1_66", "1"},
        { "dutchC1_67", "1"},
        { "dutchC1_68", "1"},
        { "dutchC1_69", "1"},

        { "dutchC1_70", "1"},
        { "dutchC1_71", "1"},
        { "dutchC1_72", "1"},
        { "dutchC1_73", "1"},
        { "dutchC1_74", "1"},
        { "dutchC1_75", "1"},
        { "dutchC1_76", "1"},
        { "dutchC1_77", "1"},
        { "dutchC1_78", "1"},
        { "dutchC1_79", "1"},

        { "dutchC1_80", "1"},
        { "dutchC1_81", "1"},
        { "dutchC1_82", "1"},
        { "dutchC1_83", "1"},
        { "dutchC1_84", "1"},
        { "dutchC1_85", "1"},
        { "dutchC1_86", "1"},
        { "dutchC1_87", "1"},
        { "dutchC1_88", "1"},
        { "dutchC1_89", "1"},

        { "dutchC1_90", "1"},
        { "dutchC1_91", "1"},
        { "dutchC1_92", "1"},
        { "dutchC1_93", "1"},
        { "dutchC1_94", "1"},
        { "dutchC1_95", "1"},
        { "dutchC1_96", "1"},
        { "dutchC1_97", "1"},
        { "dutchC1_98", "1"},
        { "dutchC1_99", "1"},

        { "dutchC1_100", "1"}
    };
    private static readonly Dictionary<string, string> dutch_c1_rules_titles_and_bodies = new Dictionary<string, string>
    {
        {"1. C1 Rule n.1", "C1 Body Rule n.1" },
        {"2. C1 Rule n.2", "C1 Body Rule n.2" },
        {"3. C1 Rule n.3", "C1 Body Rule n.3" },
        {"4. C1 Rule n.4", "C1 Body Rule n.4" },
        {"5. C1 Rule n.5", "C1 Body Rule n.5" },
    };
    private static readonly Dictionary<int, Dictionary<string, string>> dutchHashMap_c1 = new Dictionary<int, Dictionary<string, string>> { { 1, Frasi_originali_e_soluzioni_olandese_c1 } };

    // C2
    private static readonly Dictionary<string, string> frasi_originali_e_soluzioni_olandese_c2 = new Dictionary<string, string>
    {
        { "dutchC2_0", "1"},
        { "dutchC2_1", "1"},
        { "dutchC2_2", "1"},
        { "dutchC2_3", "1"},
        { "dutchC2_4", "1"},
        { "dutchC2_5", "1"},
        { "dutchC2_6", "1"},
        { "dutchC2_7", "1"},
        { "dutchC2_8", "1"},
        { "dutchC2_9", "1"},

        { "dutchC2_10", "1"},
        { "dutchC2_11", "1"},
        { "dutchC2_12", "1"},
        { "dutchC2_13", "1"},
        { "dutchC2_14", "1"},
        { "dutchC2_15", "1"},
        { "dutchC2_16", "1"},
        { "dutchC2_17", "1"},
        { "dutchC2_18", "1"},
        { "dutchC2_19", "1"},

        { "dutchC2_20", "1"},
        { "dutchC2_21", "1"},
        { "dutchC2_22", "1"},
        { "dutchC2_23", "1"},
        { "dutchC2_24", "1"},
        { "dutchC2_25", "1"},
        { "dutchC2_26", "1"},
        { "dutchC2_27", "1"},
        { "dutchC2_28", "1"},
        { "dutchC2_29", "1"},

        { "dutchC2_30", "1"},
        { "dutchC2_31", "1"},
        { "dutchC2_32", "1"},
        { "dutchC2_33", "1"},
        { "dutchC2_34", "1"},
        { "dutchC2_35", "1"},
        { "dutchC2_36", "1"},
        { "dutchC2_37", "1"},
        { "dutchC2_38", "1"},
        { "dutchC2_39", "1"},

        { "dutchC2_40", "1"},
        { "dutchC2_41", "1"},
        { "dutchC2_42", "1"},
        { "dutchC2_43", "1"},
        { "dutchC2_44", "1"},
        { "dutchC2_45", "1"},
        { "dutchC2_46", "1"},
        { "dutchC2_47", "1"},
        { "dutchC2_48", "1"},
        { "dutchC2_49", "1"},

        { "dutchC2_50", "1"},
        { "dutchC2_51", "1"},
        { "dutchC2_52", "1"},
        { "dutchC2_53", "1"},
        { "dutchC2_54", "1"},
        { "dutchC2_55", "1"},
        { "dutchC2_56", "1"},
        { "dutchC2_57", "1"},
        { "dutchC2_58", "1"},
        { "dutchC2_59", "1"},

        { "dutchC2_60", "1"},
        { "dutchC2_61", "1"},
        { "dutchC2_62", "1"},
        { "dutchC2_63", "1"},
        { "dutchC2_64", "1"},
        { "dutchC2_65", "1"},
        { "dutchC2_66", "1"},
        { "dutchC2_67", "1"},
        { "dutchC2_68", "1"},
        { "dutchC2_69", "1"},

        { "dutchC2_70", "1"},
        { "dutchC2_71", "1"},
        { "dutchC2_72", "1"},
        { "dutchC2_73", "1"},
        { "dutchC2_74", "1"},
        { "dutchC2_75", "1"},
        { "dutchC2_76", "1"},
        { "dutchC2_77", "1"},
        { "dutchC2_78", "1"},
        { "dutchC2_79", "1"},

        { "dutchC2_80", "1"},
        { "dutchC2_81", "1"},
        { "dutchC2_82", "1"},
        { "dutchC2_83", "1"},
        { "dutchC2_84", "1"},
        { "dutchC2_85", "1"},
        { "dutchC2_86", "1"},
        { "dutchC2_87", "1"},
        { "dutchC2_88", "1"},
        { "dutchC2_89", "1"},

        { "dutchC2_90", "1"},
        { "dutchC2_91", "1"},
        { "dutchC2_92", "1"},
        { "dutchC2_93", "1"},
        { "dutchC2_94", "1"},
        { "dutchC2_95", "1"},
        { "dutchC2_96", "1"},
        { "dutchC2_97", "1"},
        { "dutchC2_98", "1"},
        { "dutchC2_99", "1"},

        { "dutchC2_100", "1"}
    };
    private static readonly Dictionary<string, string> dutch_c2_rules_titles_and_bodies = new Dictionary<string, string>
    {
        {"1. C2 Rule n.1", "C2 Body Rule n.1" },
        {"2. C2 Rule n.2", "C2 Body Rule n.2" },
        {"3. C2 Rule n.3", "C2 Body Rule n.3" },
        {"4. C2 Rule n.4", "C2 Body Rule n.4" },
        {"5. C2 Rule n.5", "C2 Body Rule n.5" },
    };
    private static readonly Dictionary<int, Dictionary<string, string>> dutchHashMap_c2 = new Dictionary<int, Dictionary<string, string>> { { 1, Frasi_originali_e_soluzioni_olandese_c2 } };

    #endregion

    #region get method
    // A1
    public static Dictionary<int, Dictionary<string, string>> DutchHashMap_a1 => dutchHashMap_a1; // dutchHasMap_a2 is the prop to get the entire dict
    public static Dictionary<string, string> Frasi_originali_e_soluzioni_olandese_a1 => frasi_originali_e_soluzioni_olandese_a1;
    public static Dictionary<string, string> Dutch_a1_rules_titles_and_bodies => dutch_a1_rules_titles_and_bodies;

    // A2
    public static Dictionary<int, Dictionary<string, string>> DutchHashMap_a2 => dutchHashMap_a2; // dutchHasMap_a2 is the prop to get the entire dict
    public static Dictionary<string, string> Frasi_originali_e_soluzioni_olandese_a2 => frasi_originali_e_soluzioni_olandese_a2;
    public static Dictionary<string, string> Dutch_a2_rules_titles_and_bodies => dutch_a2_rules_titles_and_bodies;

    //B1
    public static Dictionary<int, Dictionary<string, string>> DutchHashMap_b1 => dutchHashMap_b1; // dutchHasMap_a2 is the prop to get the entire dict
    public static Dictionary<string, string> Frasi_originali_e_soluzioni_olandese_b1 => frasi_originali_e_soluzioni_olandese_b1;
    public static Dictionary<string, string> Dutch_b1_rules_titles_and_bodies => dutch_b1_rules_titles_and_bodies;

    // B2
    public static Dictionary<int, Dictionary<string, string>> DutchHashMap_b2 => dutchHashMap_b2; // dutchHasMap_a2 is the prop to get the entire dict
    public static Dictionary<string, string> Frasi_originali_e_soluzioni_olandese_b2 => frasi_originali_e_soluzioni_olandese_b2;
    public static Dictionary<string, string> Dutch_b2_rules_titles_and_bodies => dutch_b2_rules_titles_and_bodies;

    // C1
    public static Dictionary<int, Dictionary<string, string>> DutchHashMap_c1 => dutchHashMap_c1; // dutchHasMap_a2 is the prop to get the entire dict
    public static Dictionary<string, string> Frasi_originali_e_soluzioni_olandese_c1 => frasi_originali_e_soluzioni_olandese_c1;
    public static Dictionary<string, string> Dutch_c1_rules_titles_and_bodies => dutch_c1_rules_titles_and_bodies;

    // C2
    public static Dictionary<int, Dictionary<string, string>> DutchHashMap_c2 => dutchHashMap_c2; // dutchHasMap_a2 is the prop to get the entire dict
    public static Dictionary<string, string> Frasi_originali_e_soluzioni_olandese_c2 => frasi_originali_e_soluzioni_olandese_c2;
    public static Dictionary<string, string> Dutch_c2_rules_titles_and_bodies => dutch_c2_rules_titles_and_bodies;
    #endregion
}
