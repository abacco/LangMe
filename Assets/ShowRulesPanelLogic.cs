using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ShowRulesPanelLogic : MonoBehaviour
{
    [SerializeField] TMP_Text rulesList;
    [SerializeField] GameObject rulesPanel;

    Dictionary<string, string> dutch_a1_rules_titles_and_bodies = new Dictionary<string, string>();

    private void Start()
    {
        switch (GameManager.Instance.selectedLanguage)
        {
            case "Dutch":
                switch (GameManager.Instance.selectedDifficulty)
                {
                    case "A1": InitDutchA1Rule(); UpdateRulesList(dutch_a1_rules_titles_and_bodies);  break;
                    default: throw new Exception("Error On selectedDifficulty: ");
                }
                break;
            default: throw new Exception("Error On selectedLanguage: ");
        }
    }
    public void InitDutchA1Rule()
    { 
        dutch_a1_rules_titles_and_bodies.Add("1. Pronunciation and Special Sounds", "The \"g\" sounds like a guttural \"h\" (e.g., goed → /ɣut/).\r\n\nThe \"ui\" sounds similar to the French \"œy\" (e.g., huis → /hœys/).\r\n\nThe \"ij\" and \"ei\" are pronounced like a mix between \"ai\" and \"ei\".\r\n\nThe \"sch\" sounds like an \"s\" followed by a guttural \"ch\" (e.g., school → /sxoːl/).");
        dutch_a1_rules_titles_and_bodies.Add("2. Definite and Indefinite Articles", "De → Used for most common nouns (de man = the man, de vrouw = the woman).\r\n\nHet → Used for neutral words and diminutives (het huis = the house, het kind = the child).\r\n\nEen → Indefinite article, meaning \"a\" or \"an\" (een boek = a book).");
        dutch_a1_rules_titles_and_bodies.Add("3. A1 Rules 3", "Add -en: huis → huizen (house → houses), boom → bomen (tree → trees).\r\n\nAdd -s (if the word ends in a vowel or unstressed syllable): auto → auto’s (car → cars).");
        dutch_a1_rules_titles_and_bodies.Add("4. Personal Pronouns", "I = Ik \n\nYou = Jij / Je\n\nHe/She/It = \tHij / Zij (Ze) / Het\n\nWe = Wij (We)\n\nYou (pl.) = Jullie\n\nThey = Zij (Ze)\n\nNote: \"Jij\" and \"Zij\" are emphasized forms, while \"Je\" and \"Ze\" are neutral and used more often in conversation.");
        dutch_a1_rules_titles_and_bodies.Add("5. Present Tense Verb Conjugation", "Dutch verbs are mostly regular. Example with werken (to work):\r\n\r\n\nIk werk (I work)\r\n\nJij werkt (You work)\r\n\nHij/Zij/Het werkt (He/She/It works)\r\n\nWij/Jullie/Zij werken (We/You/They work)Irregular Verbs (Common Examples)\r\n\nHebben (to have) → ik heb, jij hebt, hij heeft, wij hebben\r\n\nZijn (to be) → ik ben, jij bent, hij is, wij zijn");
        dutch_a1_rules_titles_and_bodies.Add("6. Word Order (SVO and Question Inversion)", "Regular sentence: Ik werk vandaag (I work today).\r\n\nQuestion: Werk jij vandaag? (Do you work today?) → The verb moves to the beginning.\r\n\nSubordinate clause: Omdat ik vandaag werk (Because I work today) → The verb moves to the end.");
        dutch_a1_rules_titles_and_bodies.Add("7. Negation with \"niet\" and \"geen\"", "Niet negates a verb or adjective: Ik werk niet (I do not work).\r\n\nGeen negates a noun without an article: Ik heb geen auto (I have no car).");
        dutch_a1_rules_titles_and_bodies.Add("8. Common Prepositions", "In → in (in de kamer = in the room)\r\n\nOp → on (op tafel = on the table)\r\n\nOnder → under (onder de stoel = under the chair)\r\n\nMet → with (met vrienden = with friends)\r\n\nBij → at, near (bij de bakker = at the bakery)");
        dutch_a1_rules_titles_and_bodies.Add("9. Adjectives and Their Placement", "Before the noun: een grote auto (a big car).\r\n\nIf the noun is \"het\" and indefinite, the adjective does not take -e: een groot huis (a big house).");
        dutch_a1_rules_titles_and_bodies.Add("10. Useful Basic Phrases", "Hoi / Hallo → Hi / Hello\r\n\nHoe gaat het? → How are you?\r\n\nGoed, en met jou? → Good, and you?\r\n\nDank je (wel)! → Thank you!\r\n\nAlsjeblieft / Alstublieft → Please\r\n\nIk begrijp het niet → I don’t understand\r\n\nKunt u dat herhalen? → Can you repeat that?");
        
    }
    void UpdateRulesList(Dictionary<string, string> dutch_a1_rules_titles_and_bodies)
    {
        if (dutch_a1_rules_titles_and_bodies.Count > 0)
        {
            foreach (KeyValuePair<string, string> entry in dutch_a1_rules_titles_and_bodies)
            {
                // do something with entry.Value or entry.Key
                rulesList.text += entry.Key + entry.Value;
                rulesList.text += "\n-----------------------------------";
            }
        }
        else { rulesList.text += "Error On Dutch_a1_rules dict - ShowRulesPanelLogic"; }
    }

    public void ShowRulesPanel()
    {
        rulesPanel.SetActive(true);
    }

    public void CloseRulesPanel()
    {
        rulesPanel.SetActive(false);
    }
}
