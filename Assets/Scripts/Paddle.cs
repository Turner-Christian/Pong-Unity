using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rb2d; // Reference to the Rigidbody2D component
    public int id; // ID of the paddle (1 or 2)
    public float moveSpeed = 3f; // Speed of the paddle
    public float aiDeadzone = 1f; // Deadzone for AI movement
    private Vector3 startPosition;
    private int direction = 0; // Initialize direction variable

    private void Start() {
        startPosition = transform.position; // Store the initial position of the paddle
        GameManager.instance.onReset += ResetPosition; // Subscribe to the reset event in GameManager
    }

    private void ResetPosition() {
        transform.position = startPosition; // Reset the paddle's position to the initial position
    }

    private void Update() {
        if(id == 2 && GameManager.instance.IsPlayer2AI())
        {
            MoveAI(); // Call the method to move the paddle for AI
        }
        else
        {
            float movement = ProcessInput(); // Call the method to process input
            Move(movement); // Call the method to move the paddle
        }
    }

    private void MoveAI()
    {
        Vector2 ballPos = GameManager.instance.ball.transform.position; // Get the ball's position
        if (Mathf.Abs(ballPos.y - transform.position.y) > aiDeadzone) // Check if the ball is within the deadzone
        {
            direction = ballPos.y > transform.position.y ? 1 : -1; // Set the direction to move towards the ball
        }
        Move(direction); // Call the method to move the paddle
    }

    private float ProcessInput()
    {
        float movement = 0f; // Initialize movement variable
        switch (id)
        {
            case 1:
                movement = Input.GetAxis("MovePlayer1"); // Get input for Player 1
                break;
            case 2:
                movement = Input.GetAxis("MovePlayer2"); // Get input for Player 2
                break;
        }

        return movement; // Return the movement value
    }

    private void Move(float movement)
    {
        Vector2 velo = rb2d.linearVelocity; // Get the current velocity of the paddle
        velo.y = moveSpeed * movement; // Set the y component of the velocity based on input and speed
        rb2d.linearVelocity = velo; // Update the paddle's velocity
    }
}
