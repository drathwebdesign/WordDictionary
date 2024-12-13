using UnityEngine;
using TMPro;

public class WordChecker : MonoBehaviour {
    public WordListManager wordListManager; // Drag WordListManager GameObject here
    public TMP_InputField inputField;       // Drag the Input Field here
    public TMP_Text resultText;             // Drag the Result Text here

    public void CheckWord() {
        string word = inputField.text.Trim().ToLower();
        if (string.IsNullOrEmpty(word)) {
            resultText.text = "Please enter a word.";
            return;
        }

        if (wordListManager.IsWordValid(word)) {
            resultText.text = "Word recognised!";
        } else {
            resultText.text = "Word not recognised.";
        }
    }
}