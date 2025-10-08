using UnityEngine;
using TMPro; // Make sure to include this line to use TextMeshPro

public class FPSCounter : MonoBehaviour
{
    // This will hold the reference to our UI text component
    [SerializeField] private TextMeshProUGUI fpsText;

    // Variables to calculate FPS
    [SerializeField] private float pollingTime = 1f; // We'll update the display every second
    private float timeAccumulator;
    private int frameCount;

    void Update()
    {
        // Add the time since the last frame to our accumulator
        timeAccumulator += Time.deltaTime;

        // Increment the frame count
        frameCount++;

        // When the accumulated time is greater than our polling time...
        if (timeAccumulator >= pollingTime)
        {
            // Calculate the FPS
            int fps = Mathf.RoundToInt(frameCount / timeAccumulator);

            // Update the text display
            fpsText.text = "FPS: " + fps;

            // Reset the counters
            timeAccumulator = 0f;
            frameCount = 0;
        }
    }
}