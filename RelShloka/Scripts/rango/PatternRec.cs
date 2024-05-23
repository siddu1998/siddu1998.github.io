using UnityEngine;

public class PatternRec : MonoBehaviour
{
    public Transform patternContainer; // Reference to the GameObject containing the traced pattern
    public Transform templateContainer; // Reference to the GameObject containing the star template
    public float matchThreshold = 0.8f; // Threshold for pattern matching, adjust as needed

    private Vector3[] tracedPattern;
    private Vector3[] starTemplate;

    void Start()
    {
        // Get the pattern points from the traced pattern container
        tracedPattern = GetPatternPoints(patternContainer);

        // Get the star template points from the template container
        starTemplate = GetPatternPoints(templateContainer);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // Check if the left mouse button is released
        {
            // Get the final traced pattern points
            tracedPattern = GetPatternPoints(patternContainer);

            // Compare the traced pattern with the star template
            float matchPercentage = ComparePatterns(tracedPattern, starTemplate);

            if (matchPercentage >= matchThreshold)
            {
                Debug.Log("Star pattern detected!");
                // Perform actions for when the star pattern is recognized
            }
        }
    }

    Vector3[] GetPatternPoints(Transform container)
    {
        // Get all the points from the LineRenderer attached to the container
        LineRenderer lineRenderer = container.GetComponent<LineRenderer>();
        Vector3[] points = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(points);

        return points;
    }

    float ComparePatterns(Vector3[] patternA, Vector3[] patternB)
    {
        // Perform pattern matching comparison here, e.g., using distance comparison or other algorithms
        // Calculate a match percentage and return it

        // For simplicity, let's assume the patterns have the same length
        int totalPoints = patternA.Length;
        int matchedPoints = 0;

        for (int i = 0; i < totalPoints; i++)
        {
            float distance = Vector3.Distance(patternA[i], patternB[i]);
            if (distance <= matchThreshold)
                matchedPoints++;
        }

        return (float)matchedPoints / totalPoints;
    }
}
