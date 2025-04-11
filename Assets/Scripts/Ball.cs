using UnityEngine;

public class Ball : MonoBehaviour 
{
    public Rigidbody2D rb2d; // Reference to the Rigidbody2D component
    public float maxInitialAngle = 0.67f; // Maximum initial angle in radians
    public float moveSpeed = 5f; // Speed of the ball
    public float startX = 0f; // Starting X position of the ball
    public float maxStartY = 4f; // Maximum starting Y position of the ball
    public float speedMultiplier = 1.1f; // Speed multiplier for each bounce

    private void Start() {
        GameManager.instance.onReset += ResetBall; // Subscribe to the reset event in GameManager
        GameManager.instance.gameUI.onStartGame += ResetBall; // Subscribe to the start game event in GameUI
    }

    private void ResetBall() {
        ResetBallPosition(); // Call the method to reset the ball's position
        InitialPush(); // Call the method to set the initial velocity of the ball again
    }

    private void InitialPush()
    {
        Vector2 dir = Random.value < 0.5f ? Vector2.right : Vector2.left; // Randomly choose the direction (left or right)
        float posY = Random.Range(-maxStartY, maxStartY); // Randomize the Y position within the specified range
        
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle); // Randomize the y component within the specified range
        rb2d.linearVelocity = dir * moveSpeed; // Set the initial velocity of the ball
    }

    private void ResetBallPosition()
    {
        float posY = Random.Range(-maxStartY, maxStartY); // Randomize the Y position within the specified range
        Vector2 position = new Vector2(startX, posY); // Create a new position vector
        transform.position = position; // Set the ball's position to the new vector
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>(); // Get the ScoreZone component from the collided object
        if(scoreZone) {
            GameManager.instance.OnScoreZoneReached(scoreZone.id); // Call the method to update the score in the GameManager
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Paddle paddle = other.collider.GetComponent<Paddle>(); // Get the Paddle component from the collided object
        if(paddle)
        {
            rb2d.linearVelocity *= speedMultiplier; // Increase the ball's speed by the speed multiplier 
        }
    }
}