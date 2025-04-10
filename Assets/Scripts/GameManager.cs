using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance of GameManager

    public int scorePlayer1, scorePlayer2; // Player scores
    public ScoreText scoreTextLeft, scoreTextRight; // References to the score text components
    public Action onReset; // Action to be invoked on reset

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject); // Destroy the duplicate instance
        }
        else
        {
            instance = this; // Set the singleton instance
        }
    }
    public void OnScoreZoneReached(int id)
    {

        onReset?.Invoke(); // Invoke the reset action if it's not null

        if (id == 1) // Check if the score zone ID is 1
        {
            scorePlayer1++; // Increment Player 1's score
        }
        else if (id == 2) // Check if the score zone ID is 2
        {
            scorePlayer2++; // Increment Player 2's score
        }
        UpdateScores(); // Update the score text display
    }

    private void UpdateScores()
    {
        scoreTextLeft.SetScore(scorePlayer1); // Update Player 1's score text
        scoreTextRight.SetScore(scorePlayer2); // Update Player 2's score text
    }
}