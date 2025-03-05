using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowRulesPanelLogic : MonoBehaviour
{
    [SerializeField] TMP_Text rulesList;
    [SerializeField] GameObject rulesPanel;

    private void Start()
    {
        switch (GameManager.Instance.selectedLanguage)
        {
            case "Dutch":
                switch (GameManager.Instance.selectedDifficulty)
                {
                    case "A1": UpdateRulesListGeneric(DutchDicts.Dutch_a1_rules_titles_and_bodies);  break;
                    case "A2": UpdateRulesListGeneric(DutchDicts.Dutch_a2_rules_titles_and_bodies);  break;
                    case "B1": UpdateRulesListGeneric(DutchDicts.Dutch_b1_rules_titles_and_bodies); break;
                    case "B2": UpdateRulesListGeneric(DutchDicts.Dutch_b2_rules_titles_and_bodies); break;
                    case "C1": UpdateRulesListGeneric(DutchDicts.Dutch_c1_rules_titles_and_bodies); break;
                    case "C2": UpdateRulesListGeneric(DutchDicts.Dutch_c2_rules_titles_and_bodies); break;
                    default: throw new Exception("Error On selectedDifficulty: ");
                }
                break;
            default: throw new Exception("Error On selectedLanguage: ");
        }
    }

    void UpdateRulesListGeneric(Dictionary<string, string> rules_titles_and_bodies_dict)
    {
        if (rules_titles_and_bodies_dict.Count > 0)
        {
            foreach (KeyValuePair<string, string> entry in rules_titles_and_bodies_dict)
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
