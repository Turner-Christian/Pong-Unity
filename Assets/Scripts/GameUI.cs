using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public ScoreText scoreTextPlayer1, scoreTextPlayer2; // References to the score text components
    public GameObject menuObject; // Reference to the menu object
    public System.Action onStartGame; // Action to be invoked when the game starts
    public TextMeshProUGUI winText; // Reference to the win text component
    public TextMeshProUGUI playModeButtonText; // Reference to the play mode text component

    private void Start()
    {
        AdjustPlayModeButtonText(); // Adjust the play mode text display
    }

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

    public void onGameEnd(int winnerID)
    {
        menuObject.SetActive(true); // Show the menu object
        winText.text = $"Player {winnerID} wins!"; // Display the winner message
    }

    public void OnSwitchPlayModeButtonClicked()
    {
        GameManager.instance.SwitchPlayMode(); // Call the method to switch play mode in GameManager
        AdjustPlayModeButtonText(); // Adjust the play mode text display
    }


    private void AdjustPlayModeButtonText()
    {
        switch (GameManager.instance.playMode) // Check the current play mode
        {
            case GameManager.PlayMode.PlayerVsPlayer: // Player vs Player mode
                playModeButtonText.text = "Player vs AI"; // Set the text to switch to Player vs AI mode
                break;
            case GameManager.PlayMode.PlayerVsAI: // Player vs AI mode
                playModeButtonText.text = "Player vs Player"; // Set the text to switch to Player vs Player mode
                break;
        }
    }
}
