using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LanguageProficiencyCompleted : MonoBehaviour
{
    //[SerializeField] Image languageIcon;
    //[SerializeField] Sprite[] languageIcons;

    //[SerializeField] Image a1_img;
    //[SerializeField] Image a2_img;
    //[SerializeField] Image b1_img;
    //[SerializeField] Image b2_img;
    //[SerializeField] Image c1_img;
    //[SerializeField] Image c2_img;

    //// devi salvare questa info nel gameManager
    ////Dictionary<string, bool> proficiencyCompletedDictionary = new Dictionary<string, bool>();
    //void Start()
    //{
    //    GameManager.Instance.LoadData();
    //    StartCoroutine(UpdateLanguageIcon());
    //    GameData.ProficiencyTracker[] pr = (GameData.ProficiencyTracker[])GameManager.Instance.proficiencyTracker.Clone();

    //    if (pr == null) {
    //        throw new Exception();
    //    }
    //    //proficiencyCompletedDictionary.Add("Dutch_B2", true);

    //    string key = GameManager.Instance.selectedLanguage + "_" + GameManager.Instance.selectedDifficulty;
    //    int proficiencyTrackerIndex = GameManager.Instance.proficiencyTrackerIndex;
    //    //GameData.ProficiencyTracker singleProficiencyToSave = pr[0];//new GameData.ProficiencyTracker(key, false);
    //    GameData.ProficiencyTracker singleProficiencyToSave = new GameData.ProficiencyTracker(key, false); //"Dutch_B2", false
    //    if (GameManager.Instance.solutionCounter >= 100)
    //    {
    //        for (int i = 0; i < 6; i++)
    //        {
    //            if (pr.Contains(singleProficiencyToSave))
    //            {
    //                singleProficiencyToSave.isCompleted = true;
    //                ChangeColor(pr[i].key);
    //            }
    //            else
    //            {
    //                singleProficiencyToSave.isCompleted = true;
    //                GameManager.Instance.proficiencyTracker[proficiencyTrackerIndex] = singleProficiencyToSave;
    //                if(proficiencyTrackerIndex < 5)
    //                {
    //                    proficiencyTrackerIndex++;
    //                }
    //                ChangeColor(pr[i].key);
    //                GameManager.Instance.SaveData();
    //                break;
    //            }
    //        }
    //    }
    //    else {
    //        for(int i = 0; i <6 ;i++)
    //        {
    //            if (pr[i].isCompleted)
    //            {
    //                ChangeColor(pr[i].key);
    //            }
    //        }
    //    }

    //}

    //void ChangeColor(string key)
    //{
    //    if(key.Contains("A1"))
    //    {
    //        a1_img.color = Color.yellow;
    //    }
    //    if (key.Contains("A2"))
    //    {
    //        a2_img.color = Color.yellow;
    //    }
    //    if (key.Contains("B1"))
    //    {
    //        b1_img.color = Color.yellow;
    //    }
    //    if (key.Contains("B2"))
    //    {
    //        b2_img.color = Color.yellow;
    //    }
    //    if (key.Contains("C1"))
    //    {
    //        c1_img.color = Color.yellow;
    //    }
    //    if (key.Contains("C2"))
    //    {
    //        c2_img.color = Color.yellow;
    //    }
    //}

    //public IEnumerator UpdateLanguageIcon()
    //{
    //    yield return new WaitForEndOfFrame();
    //    string language = GameManager.Instance.selectedLanguage;

    //    switch (language.ToLower())
    //    {
    //        case "dutch": languageIcon.sprite = languageIcons[0]; break;
    //        default: Debug.Log("Error on language " + language); break;
    //    }
    //}

    [SerializeField] Image languageIcon;
    [SerializeField] Sprite[] languageIcons;

    [SerializeField] Image a1_img;
    [SerializeField] Image a2_img;
    [SerializeField] Image b1_img;
    [SerializeField] Image b2_img;
    [SerializeField] Image c1_img;
    [SerializeField] Image c2_img;

    //void Start()
    //{
    //    GameManager.Instance.LoadData();
    //    StartCoroutine(UpdateLanguageIcon());

    //    GameData.ProficiencyTracker[] pr = (GameData.ProficiencyTracker[])GameManager.Instance.proficiencyTracker.Clone();
    //    if (pr == null)
    //    {
    //        throw new Exception("Proficiency tracker array is null.");
    //    }

    //    ResetColors();

    //    string key = GameManager.Instance.selectedLanguage + "_" + GameManager.Instance.selectedDifficulty;
    //    int proficiencyTrackerIndex = GameManager.Instance.proficiencyTrackerIndex;
    //    GameData.ProficiencyTracker singleProficiencyToSave = new GameData.ProficiencyTracker(key, false);

    //    if (GameManager.Instance.solutionCounter >= 100)
    //    {
    //        bool needsSave = false;

    //        // Controlla se esiste già un nodo con la chiave
    //        if (pr.Any(p => p.key == key))
    //        {
    //            foreach (var proficiency in pr)
    //            {
    //                if (proficiency.key == key)
    //                {
    //                    proficiency.isCompleted = true;
    //                    ChangeColor(proficiency.key);
    //                    needsSave = true;
    //                    break;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            // Se non esiste, lo aggiunge
    //            singleProficiencyToSave.isCompleted = true;
    //            if (proficiencyTrackerIndex < pr.Length)
    //            {
    //                GameManager.Instance.proficiencyTracker[proficiencyTrackerIndex] = singleProficiencyToSave;
    //                proficiencyTrackerIndex++;
    //            }
    //            ChangeColor(singleProficiencyToSave.key);
    //            needsSave = true;
    //        }

    //        if (needsSave)
    //        {
    //            GameManager.Instance.SaveData();
    //        }
    //    }
    //    else
    //    {
    //        // Colora i nodi completati
    //        foreach (var proficiency in pr)
    //        {
    //            if (proficiency.isCompleted)
    //            {
    //                ChangeColor(proficiency.key);
    //            }
    //        }
    //    }
    //}

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
            }
        }

        // Colora tutti i nodi completati
        foreach (var proficiency in GameManager.Instance.proficiencyTracker)
        {
            if (proficiency.isCompleted)
            {
                ChangeColor(proficiency.key);
            }
        }

        if (needsSave)
        {
            GameManager.Instance.SaveData();
        }
    }

    void ResetColors()
    {
        a1_img.color = Color.white;
        a2_img.color = Color.white;
        b1_img.color = Color.white;
        b2_img.color = Color.white;
        c1_img.color = Color.white;
        c2_img.color = Color.white;
    }

    void ChangeColor(string key)
    {
        if (key.Contains("A1")) a1_img.color = Color.yellow;
        if (key.Contains("A2")) a2_img.color = Color.yellow;
        if (key.Contains("B1")) b1_img.color = Color.yellow;
        if (key.Contains("B2")) b2_img.color = Color.yellow;
        if (key.Contains("C1")) c1_img.color = Color.yellow;
        if (key.Contains("C2")) c2_img.color = Color.yellow;
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
}
