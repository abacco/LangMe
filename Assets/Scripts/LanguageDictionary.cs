﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class LanguageDictionary : MonoBehaviour
{
    private const string API_URL = "https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}"; 
    private static readonly HttpClient client = new HttpClient();

    public List<string> frasi = new List<string>();
    [SerializeField] GameObject wordFoundPanel;
    [SerializeField] GameObject wordNotFoundPanel;
    [SerializeField] GameObject dictionaryPanel;
    [SerializeField] GameObject inputVoidPanel;
    [SerializeField] TMP_Text wordList;
    [SerializeField] TMP_Text keyFound;
    [SerializeField] TMP_Text valueFound;
    [SerializeField] TMP_InputField word_to_be_find;
    
    private Dictionary<string, string> dutchDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    string newDictfilePath;

    private void Start()
    {
        switch (GameManager.Instance.selectedLanguage.ToLower())
        {
            case "dutch": 
                InitializeDutchWordList("dutchDict"); 
                ConvertiListaInDizionario(dutchDict);
                PrintDutchWords(dutchDict);
                break;
            default: Debug.Log("error"); break;
        }
    }

    void InitializeDutchWordList(string dictFileName)
    {
        TextAsset file = Resources.Load<TextAsset>(dictFileName); // Senza .txt
        if (file != null)
        {
            frasi = new List<string>(file.text.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.RemoveEmptyEntries));
        }
        else
        {
            Debug.LogError("File frasi.txt non trovato in Resources!");
        }
        // C:/Users/bacco/AppData/LocalLow/DefaultCompany/LangMe/dutchDict_custom.txt
        // Carica le parole salvate nel file modificabile - questo perchè le robe in resources sono in sola lettura!!
        string filePath = UnityEngine.Application.persistentDataPath + "/" + dictFileName + "_custom.txt"; // contiene le nuove parole aggiunte che sono state trovate tramite google translate
        if (System.IO.File.Exists(filePath))
        {
            string[] savedWords = System.IO.File.ReadAllLines(filePath);
            frasi.AddRange(savedWords);
        }

        //Debug.Log("✅ Dizionario caricato con " + frasi.Count + " parole.");
    }
    void ConvertiListaInDizionario(Dictionary<string, string> genericDict) // metti anche qui lo switch sulla lingua per dividere i dizionari!!!!
    {
        foreach (string riga in frasi)
        {
            // Usa una regex per estrarre la parola e la traduzione
            Match match = Regex.Match(riga, @"^(\w+)\s+\[(\w+)\]\s+\(([^)]+)\)$", RegexOptions.IgnoreCase);
            Match match_for_google_words = Regex.Match(riga, @"^(\w+)\s+\[(\w+)\]\s+(.+)$", RegexOptions.IgnoreCase);
            
            if (match_for_google_words.Success)
            {
                string parolaDaTradurre = match_for_google_words.Groups[1].Value.Trim();
                string undefined = match_for_google_words.Groups[2].Value.Trim();
                string traduzioneInglese = match_for_google_words.Groups[3].Value.Trim();

                if (!genericDict.ContainsKey(parolaDaTradurre))
                {
                    genericDict[parolaDaTradurre] = $"{undefined} ({traduzioneInglese})";
                }
            }
            if (match.Success)
            {
                string parolaDaTradurre = CapitalizeFirstLetter(match.Groups[1].Value.Trim()); // Es: "ronde" // parolaDaTradurre
                string tipoGrammaticale = CapitalizeFirstLetter(match.Groups[2].Value.Trim()); // Es: "noun" // grammar
                string traduzioneInglese = CapitalizeFirstLetter(match.Groups[3].Value.Trim()); // Es: "round" // traduzione

                // Aggiungiamo al dizionario
                if (!genericDict.ContainsKey(parolaDaTradurre))
                {
                    //dutchDict[parolaOlandese] = traduzioneInglese;
                    genericDict[parolaDaTradurre] = $"{traduzioneInglese} ({tipoGrammaticale})";
                }
            }
            else
            {
                //Debug.LogWarning($"Formato non riconosciuto: {riga}");
            }
        }

        Debug.Log($"Dizionario caricato con {genericDict.Count} parole!");
    }

    void PrintDutchWords(Dictionary<string, string> genericDict)
    {
        foreach (var dictionary in genericDict)
        {
            wordList.text += "-" + dictionary.Key + ": " + dictionary.Value + "\n\n";
            //Debug.Log("DICT ENTRY: " + dictionary.Key + dictionary.Value);
        }
    }

    string CapitalizeFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input; // Evita errori con stringhe vuote o null

        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }

    public void WordFinderWrapper() // ok
    {
        switch (GameManager.Instance.selectedLanguage.ToLower())
        {
            case "dutch":
                WordFinder(dutchDict);
                break;
            case "french":
                //WordFinder(frenchDict);
                break;
            default:
                Debug.LogError("❌ Dizionario non supportato!");
                break;
        }
    }

    public void WordFinder(Dictionary<string, string> generiDict)
    {
        string parolaTest = word_to_be_find.text; // inputField.txt
        if (!"".Equals(parolaTest) && parolaTest != null )
        {
            if (generiDict.ContainsKey(parolaTest))
            {
                wordFoundPanel.SetActive(true);
                keyFound.text = parolaTest;
                valueFound.text = generiDict[parolaTest];
            }
            else
            {
                switch (GameManager.Instance.selectedLanguage.ToLower())
                {
                    case "dutch":
                        newDictfilePath = UnityEngine.Application.persistentDataPath + "/dutchDict_custom.txt";
                        wordNotFoundPanel.SetActive(true);
                        StartCoroutine(TranslateAndAdd(parolaTest, "nl", "en")); // chiama l'api
                        break;
                }
            }
        }else
        {
            ShowInputVoidPanel();
            Debug.Log("Input Field Is Empty");
        }
    }

    // 🟢 Nuova coroutine che gestisce traduzione e aggiunta al file
    IEnumerator TranslateAndAdd(string parolaTest, string sourceLang, string targetLang)
    {
        switch (GameManager.Instance.selectedLanguage.ToLower())
        {
            case "dutch":
                yield return StartCoroutine(TranslateText(parolaTest, sourceLang, targetLang, dutchDict));
                if (dutchDict.ContainsKey(parolaTest)) // Doppio check per sicurezza
                {
                    AddNewWord(newDictfilePath, parolaTest, dutchDict[parolaTest]);
                }
                break;
        }
    }

    void AddNewWord(string newDictfilePath, string dutchWord, string englishTranslation)
    {
        string newEntry = dutchWord + " [undefined] " + "(" + englishTranslation + ")";

        // Evita duplicati
        if (!frasi.Contains(newEntry))
        {
            frasi.Add(newEntry);

            // Salva nel file personalizzato

            System.IO.File.AppendAllText(newDictfilePath, newEntry + "\n");

            Debug.Log("📖 Aggiunta nuova parola: " + newEntry);
        }
        else
        {
            Debug.LogWarning("⚠ La parola è già nel dizionario!");
        }
    }


    public void CloseWordFinder()
    {
        wordFoundPanel.SetActive(false);
    }
    public void CloseWordNotFinder()
    {
        wordNotFoundPanel.SetActive(false);
    }
    public void OpenDictionary()
    {
        dictionaryPanel.SetActive(true);
    }
    public void CloseDictionary()
    {
        dictionaryPanel.SetActive(false);
    }
    public void CloseInputVoidPanel() // on find
    {
        inputVoidPanel.SetActive(false);
    }
    public void ShowInputVoidPanel() // on find
    {
        inputVoidPanel.SetActive(true);
    }


    IEnumerator TranslateText(string text, string sourceLang, string targetLang, Dictionary<string, string> dict)
    {
        string url = string.Format(API_URL, sourceLang, targetLang, HttpUtility.UrlEncode(text));

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("❌ Errore: " + request.error);
            }
            else
            {
                string responseText = request.downloadHandler.text;
                string translatedText = ParseTranslation(responseText); // aggiungere al dizionario!!
                dict.Add(text, translatedText);
                //AddNewWord(newDictfilePath, text, dutchDict[text]);
            }
        }
    }

    string ParseTranslation(string json)
    {
        try
        {
            int start = json.IndexOf("[[[") + 3;
            int end = json.IndexOf("\",\"", start);
            string translation = json.Substring(start, end - start);

            // Se il primo carattere è una doppia virgoletta (") la rimuove
            if (translation.StartsWith("\""))
            {
                translation = translation.Substring(1);
            }

            return translation.Trim();
        }
        catch
        {
            Debug.LogError("❌ Errore nel parsing della traduzione!");
            return "Errore nella traduzione";
        }
    }
}
