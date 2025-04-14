using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance of GameManager

    public int scorePlayer1, scorePlayer2; // Player scores
    public Action onReset; // Action to be invoked on reset
    public GameUI gameUI; // Reference to the GameUI component
    public int maxScore = 4; // Maximum score to win the game

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject); // Destroy the duplicate instance
        }
        else
        {
            instance = this; // Set the singleton instance
            gameUI.onStartGame += onStartGame; // Subscribe to the start game event in GameUI
        }
    }

    private void OnDestroy() {
        gameUI.onStartGame -= onStartGame; // Unsubscribe from the start game event in GameUI
    }

    public void OnScoreZoneReached(int id)
    {
        if (id == 1) // Check if the score zone ID is 1
        {
            scorePlayer1++; // Increment Player 1's score
        }
        else if (id == 2) // Check if the score zone ID is 2
        {
            scorePlayer2++; // Increment Player 2's score
        }
        gameUI.UpdateScores(scorePlayer1, scorePlayer2); // Update the score text display
        gameUI.HighlightScore(id); // Highlight the score text for the player who scored
        CheckWin(); // Check if there is a winner
    }

    private void CheckWin()
    {
        int winnerID = scorePlayer1 == maxScore ? 1 : scorePlayer2 == maxScore ? 2 : 0; // Determine the winner ID based on scores
        if (winnerID != 0) // Check if there is a winner
        {
            gameUI.onGameEnd(winnerID); // Invoke the game end action with the winner ID
        }
        else
        {
             onReset?.Invoke(); // Invoke the reset action if it's not null
        }
    }

    private void onStartGame()
    {
        scorePlayer1 = 0; // Reset Player 1's score
        scorePlayer2 = 0; // Reset Player 2's score
        gameUI.UpdateScores(scorePlayer1, scorePlayer2); // Update the score text display
    }
}