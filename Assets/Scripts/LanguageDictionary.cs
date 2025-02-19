using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class LanguageDictionary : MonoBehaviour
{
    // IMPORTANTISSIMO: https://it.libretranslate.com/?utm_source=chatgpt.com&source=auto&target=it&q=hallo
    //private const string API_URL = "https://it.libretranslate.com/translate";
    private const string API_URL = "https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}"; 
    private static readonly HttpClient client = new HttpClient();

    public List<string> frasi = new List<string>();
    [SerializeField] GameObject wordFoundPanel;
    [SerializeField] GameObject wordNotFoundPanel;
    [SerializeField] GameObject dictionaryPanel;
    [SerializeField] TMP_Text wordList;
    [SerializeField] TMP_Text keyFound;
    [SerializeField] TMP_Text valueFound;
    [SerializeField] TMP_InputField word_to_be_find;
    private Dictionary<string, string> dutchDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    private void Start()
    {
        switch (GameManager.Instance.selectedLanguage.ToLower())
        {
            case "dutch": 
                InitializeDutchWordList(); 
                ConvertiListaInDizionario();
                PrintDutchWords();
                break;
            default: Debug.Log("error"); break;
        }
    }

    void InitializeDutchWordList()
    {
        TextAsset file = Resources.Load<TextAsset>("dutchDict"); // Senza .txt
        if (file != null)
        {
            frasi = new List<string>(file.text.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.RemoveEmptyEntries));
        }
        else
        {
            Debug.LogError("File frasi.txt non trovato in Resources!");
        }
    }

    void PrintDutchWords() {
        foreach (var dictionary in dutchDict)
        {
            wordList.text += "-" + dictionary.Key + ": " + dictionary.Value + "\n\n";
            //Console.WriteLine("dictionary key is {0} and value is {1}", dictionary.Key, dictionary.Value);
        }
    }

    void ConvertiListaInDizionario()
    {
        foreach (string riga in frasi)
        {
            // Usa una regex per estrarre la parola e la traduzione
            Match match = Regex.Match(riga, @"^(\w+)\s+\[(\w+)\]\s+\(([^)]+)\)$", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                string parolaOlandese = CapitalizeFirstLetter(match.Groups[1].Value.Trim()); // Es: "ronde"
                string tipoGrammaticale = CapitalizeFirstLetter(match.Groups[2].Value.Trim()); // Es: "noun"
                string traduzioneInglese = CapitalizeFirstLetter(match.Groups[3].Value.Trim()); // Es: "round"

                // Aggiungiamo al dizionario
                if (!dutchDict.ContainsKey(parolaOlandese))
                {
                    //dutchDict[parolaOlandese] = traduzioneInglese;
                    dutchDict[parolaOlandese] = $"{traduzioneInglese} ({tipoGrammaticale})";
                }
            }
            else
            {
                //Debug.LogWarning($"Formato non riconosciuto: {riga}");
            }
        }

        Debug.Log($"Dizionario caricato con {dutchDict.Count} parole!");
    }

    string CapitalizeFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input; // Evita errori con stringhe vuote o null

        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }

    public void WordFinder()
    {
        string parolaTest = word_to_be_find.text; // inputField.txt
        if (dutchDict.ContainsKey(parolaTest))
        {
            wordFoundPanel.SetActive(true);
            keyFound.text = parolaTest;
            valueFound.text = dutchDict[parolaTest];
        } else
        {
            switch (GameManager.Instance.selectedLanguage.ToLower())
            {
                case "dutch":
                    wordNotFoundPanel.SetActive(true);
                    StartCoroutine(TranslateText(parolaTest, "nl", "en"));
                    break;
            }
        }
    }

    /*
            // chiamata all'api!!
            switch (GameManager.Instance.selectedLanguage.ToLower()) {
                case "dutch":
                    wordNotFoundPanel.SetActive(true);
                    StartCoroutine(TranslateText(parolaTest, "nl", "en"));
                    Debug.Log("new Word successully ADDED!"); // ok
                break;
     */

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


    IEnumerator TranslateText(string text, string sourceLang, string targetLang)
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
                dutchDict.Add(text, translatedText);
                Debug.Log($"🌍 Traduzione: {translatedText}");
                Debug.Log("Dizionario Aggiornato!!");
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
    //string ParseTranslation(string json)
    //{
    //    // Il formato della risposta è simile a: [[["Ciao","hello",null,null,1]],null,"en"]
    //    try
    //    {
    //        int start = json.IndexOf("[[[") + 3;
    //        int end = json.IndexOf("\",\"", start);
    //        string translation = json.Substring(start, end - start);

    //        // Rimuove eventuali spazi iniziali/finali
    //        return translation.Trim();
    //    }
    //    catch
    //    {
    //        Debug.LogError("❌ Errore nel parsing della traduzione!");
    //        return "Errore nella traduzione";
    //    }
    //}
}
