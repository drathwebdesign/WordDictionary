using System.Collections.Generic;
using UnityEngine;

public class WordListManager : MonoBehaviour {
    private HashSet<string> wordSet;

    void Start() {
        LoadWordList();
    }

    void LoadWordList() {
        // Load the word list from the Resources folder
        TextAsset wordFile = Resources.Load<TextAsset>("enable1wordlist"); // Omit the .txt extension
        if (wordFile == null) {
            Debug.LogError("Word list file not found in Resources!");
            return;
        }

        // Split the file content into individual words
        string[] words = wordFile.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        // Add words to a HashSet for fast lookups
        wordSet = new HashSet<string>(words);
        Debug.Log($"Loaded {wordSet.Count} words into the dictionary.");
    }

    public bool IsWordValid(string word) {
        // Ensure the word list has been loaded
        if (wordSet == null) {
            Debug.LogError("Word list is not loaded!");
            return false;
        }

        // Check if the word exists in the dictionary
        return wordSet.Contains(word.ToLower());
    }
}