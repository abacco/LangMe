using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LanguageProficiencyCompleted : MonoBehaviour
{
    [SerializeField] GameObject congratsPanel;
    [SerializeField] Text congrats_text;
    [SerializeField] Image languageIcon;
    [SerializeField] Sprite[] languageIcons;

    [SerializeField] Image a1_img;
    [SerializeField] Image a2_img;
    [SerializeField] Image b1_img;
    [SerializeField] Image b2_img;
    [SerializeField] Image c1_img;
    [SerializeField] Image c2_img;

    void Start()
    {
        GameManager.Instance.LoadData();
        StartCoroutine(UpdateLanguageIcon());


        GameData.ProficiencyTracker[] pr = GameManager.Instance.proficiencyTracker;
        if (pr == null || pr.Length == 0)
        {
            throw new Exception("Proficiency tracker array is null or empty.");
        }

        ResetColors();

        string key = GameManager.Instance.selectedLanguage + "_" + GameManager.Instance.selectedDifficulty;
        bool needsSave = false;

        // Controlla se il nodo esiste già nell'array
        GameData.ProficiencyTracker existingNode = pr.FirstOrDefault(p => p.key == key);

        if (GameManager.Instance.solutionCounter >= 100)
        {
            if (existingNode != null)
            {
                // Se il nodo esiste già, aggiorna solo lo stato
                existingNode.isCompleted = true;
                needsSave = true;
            }
            else
            {
                // Se non esiste, lo aggiunge all'array senza sovrascrivere vecchi dati
                List<GameData.ProficiencyTracker> proficiencyList = pr.ToList();
                proficiencyList.Add(new GameData.ProficiencyTracker(key, true));
                GameManager.Instance.proficiencyTracker = proficiencyList.ToArray();
                needsSave = true;
                GameManager.Instance.SaveData();
            }
        }

        int how_many_completed = 0;
        // Colora tutti i nodi completati
        foreach (var proficiency in GameManager.Instance.proficiencyTracker)
        {
            if (proficiency.isCompleted)
            {
                how_many_completed++;
                ChangeColor(proficiency.key);
                if(how_many_completed == 6)
                {
                    Debug.Log("you won!"); // ok - inserisci il pannello di win
                    congrats_text.text = "Congratulations On Completing " + GameManager.Instance.selectedLanguage;
                    congratsPanel.SetActive(true);
                }
            }
        }

        if (needsSave)
        {
            GameManager.Instance.SaveData();
        }
    }

    void ResetColors()
    {
        a1_img.color = Color.black;
        a2_img.color = Color.black;
        b1_img.color = Color.black;
        b2_img.color = Color.black;
        c1_img.color = Color.black;
        c2_img.color = Color.black;
    }

    void ChangeColor(string key)
    {
        if (key.Contains("A1")) a1_img.color = Color.white;
        if (key.Contains("A2")) a2_img.color = Color.white;
        if (key.Contains("B1")) b1_img.color = Color.white;
        if (key.Contains("B2")) b2_img.color = Color.white;
        if (key.Contains("C1")) c1_img.color = Color.white;
        if (key.Contains("C2")) c2_img.color = Color.white;
    }

    public IEnumerator UpdateLanguageIcon()
    {
        yield return new WaitForEndOfFrame();
        string language = GameManager.Instance.selectedLanguage;

        switch (language.ToLower())
        {
            case "dutch": languageIcon.sprite = languageIcons[0]; break;
            default: Debug.LogError("Error on language: " + language); break;
        }
    }

    public void CloseCongratsPanel()
    {
        congratsPanel.SetActive(false);
    }
}
