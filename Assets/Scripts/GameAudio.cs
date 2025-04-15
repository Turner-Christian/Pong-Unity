using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource asSounds; // Reference to the AudioSource component for sound effects
    
    public AudioClip paddleSound; // Sound effect for paddle hit
    public AudioClip scoreSound; // Sound effect for scoring
    public AudioClip winSound; // Sound effect for winning
    public AudioClip wallSound; // Sound effect for wall hit

    public void PlayPaddleSound()
    {
        asSounds.PlayOneShot(paddleSound); // Play the paddle sound effect
    }

    public void PlayScoreSound()
    {
        asSounds.PlayOneShot(scoreSound); // Play the score sound effect
    }

    public void PlayWinSound()
    {
        asSounds.PlayOneShot(winSound); // Play the win sound effect
    }

    public void PlayWallSound()
    {
        asSounds.PlayOneShot(wallSound); // Play the wall sound effect
    }
}
