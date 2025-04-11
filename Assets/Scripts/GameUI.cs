using UnityEngine;

public class GameUI : MonoBehaviour
{
    public ScoreText scoreTextPlayer1, scoreTextPlayer2; // References to the score text components
    public GameObject menuObject; // Reference to the menu object
    public System.Action onStartGame; // Action to be invoked when the game starts

    public void UpdateScores(int scorePlayer1, int scorePlayer2) // Method to update the scores
    {
        scoreTextPlayer1.SetScore(scorePlayer1); // Update Player 1's score text
        scoreTextPlayer2.SetScore(scorePlayer2); // Update Player 2's score text
    }

    public void HighlightScore(int id)
    {
        if (id == 1) // Check if the score zone ID is 1
        {
            scoreTextPlayer1.Highlight(); // Highlight Player 1's score text
        }
        else
        {
            scoreTextPlayer2.Highlight(); // Highlight Player 2's score text
        }
    }

    public void onGameButtonClicked()
    {
        menuObject.SetActive(false); // Hide the menu object
        onStartGame?.Invoke(); // Invoke the start game action if it's not null
    }
}
