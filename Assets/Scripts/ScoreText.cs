using UnityEngine;
using TMPro; // Assuming you are using TextMeshPro for text rendering

public class ScoreText : MonoBehaviour {
    public TextMeshProUGUI text; // Reference to the TextMeshProUGUI component
    public Animator animator; // Reference to the Animator component

    public void Highlight() 
    {
        animator.SetTrigger("Highlight"); // Trigger the highlight animation
    }

    public void SetScore(int value) {
        text.text = value.ToString(); // Set the text to the score value
    }
}