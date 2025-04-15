using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{
    private Vector3 initialPosition; // Store the initial position of the object

    private void Awake()
    {
        initialPosition = transform.localPosition; // Initialize the initial position
    }

    public void StartShake(float offset, float duration)
    {
        StopAllCoroutines(); // Stop any ongoing shake coroutines
        StartCoroutine(ShakeSequence(offset, duration)); // Start the shake sequence coroutine
    }

    public void StopShake()
    {
        StopAllCoroutines(); // Stop all coroutines to stop shaking
        transform.localPosition = initialPosition; // Reset the position to the initial position
    }

    private IEnumerator ShakeSequence(float offset, float duration)
    {
        float durationPassed = 0f; // Initialize the duration passed
        while(durationPassed < duration) // Loop until the duration is reached
        {
            DoShake(offset); // Call the shake method with the specified offset
            durationPassed += Time.deltaTime; // Increment the duration passed by the time since last frame
            yield return null; // Wait for the next frame
        }
        transform.localPosition = initialPosition; // Reset the position to the initial position
    }

    private void DoShake(float maxOffset)
    {
        float xOffset = Random.Range(-maxOffset, maxOffset); // Randomize the X offset
        float yOffset = Random.Range(-maxOffset, maxOffset); // Randomize the Y offset
        transform.localPosition = initialPosition + new Vector3(xOffset, yOffset, 0f); // Set the new position with the offsets
    }
}
