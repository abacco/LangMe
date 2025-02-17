using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class LanguageDictionary : MonoBehaviour
{
    public List<string> frasi = new List<string>();
    [SerializeField] TMP_Text wordList;
    private Dictionary<string, string> dutchDict = new Dictionary<string, string>();

    private void Start()
    {
        switch (GameManager.Instance.selectedLanguage.ToLower())
        {
            case "dutch": 
                InitializeDutchWordList(); 
                Debug.Log($"Caricate {frasi.Count} frasi!"); 
                PrintDutchWords(); 
                ConvertiListaInDizionario();
                string parolaTest = "ronde"; // inputField.txt
                if (dutchDict.ContainsKey(parolaTest))
                {
                    Debug.Log("parola test trovata"); // funziona
                    //Debug.Log($"Traduzione di '{parolaTest}': {dizionario[parolaTest]}");
                }
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
    
        foreach (string word in frasi)
        {
            wordList.text += "-" + word + "\n";
            Debug.Log(word);
        }
    }

    void ConvertiListaInDizionario()
    {
        foreach (string riga in frasi)
        {
            // Usa una regex per estrarre la parola e la traduzione
            Match match = Regex.Match(riga, @"^(\w+)\s+\[\w+\]\s+\(([^)]+)\)$");

            if (match.Success)
            {
                string parolaOlandese = match.Groups[1].Value;
                string traduzioneInglese = match.Groups[2].Value;

                // Aggiungiamo al dizionario
                if (!dutchDict.ContainsKey(parolaOlandese))
                {
                    dutchDict[parolaOlandese] = traduzioneInglese;
                }
            }
            else
            {
                Debug.LogWarning($"Formato non riconosciuto: {riga}");
            }
        }

        Debug.Log($"Dizionario caricato con {dutchDict.Count} parole!");
    }
}
