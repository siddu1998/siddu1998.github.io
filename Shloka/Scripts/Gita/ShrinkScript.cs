using UnityEngine;

public class ShrinkScript : MonoBehaviour
{
    public float shrinkDuration = 10f; // The total time it takes to shrink to size 0
    private float elapsedTime = 0f; // The time elapsed since the script started

    private ParticleSystem particleSystem;
    private ParticleSystem.MainModule particleMainModule; // Store the MainModule separately
    private float initialSize; // The initial size of the particle system

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleMainModule = particleSystem.main; // Get the MainModule
        initialSize = particleMainModule.startSize.constant; // Use the MainModule to get the start size
    }

    private void Update()
    {
        // Check if the particle system is still active and has particles
        if (particleSystem != null && particleSystem.isPlaying)
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the new size based on the elapsed time and total duration
            float newSize = Mathf.Lerp(initialSize, 0f, elapsedTime / shrinkDuration);

            // Assign the new size to the MainModule's startSize
            ParticleSystem.MinMaxCurve startSize = particleMainModule.startSize;
            startSize.constant = newSize;
            particleMainModule.startSize = startSize;

            // Check if the particle system has reached size 0, and stop it if needed
            if (elapsedTime >= shrinkDuration)
            {
                particleSystem.Stop();
            }
        }
    }
}
