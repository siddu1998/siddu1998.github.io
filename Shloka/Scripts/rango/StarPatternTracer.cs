using UnityEngine;

public class StarPatternTracer : MonoBehaviour
{
    public LineRenderer patternRenderer; // Reference to the LineRenderer component
    public LineRenderer tracedRenderer; // Reference to the LineRenderer component for tracing

    public float threshold = 0.1f; // Threshold distance for pattern matching

    private Vector3[] patternPoints; // Array to store the pattern points
    private Vector3[] tracedPoints; // Array to store the traced points

    private bool isTracing = false; // Flag to indicate if tracing is in progress

    private void Start()
    {
        patternRenderer.enabled = true;
        tracedRenderer.enabled = false;

        // Get the positions of the points from the LineRenderer of the pattern
        patternPoints = new Vector3[patternRenderer.positionCount];
        patternRenderer.GetPositions(patternPoints);

        // Initialize the traced points array with the same length as the pattern points
        tracedPoints = new Vector3[patternPoints.Length];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartTracing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopTracing();
        }

        if (isTracing)
        {
            UpdateTracedPath();
        }
    }

    private void StartTracing()
    {
        isTracing = true;
        patternRenderer.enabled = false;
        tracedRenderer.enabled = true;
    }

    private void StopTracing()
    {
        isTracing = false;
        tracedRenderer.enabled = false;

        if (CheckPatternMatch())
        {
            Debug.Log("Pattern matched successfully!");
        }
        else
        {
            Debug.Log("Pattern not matched. Try again!");
        }
    }

    private void UpdateTracedPath()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        if (tracedPoints[tracedPoints.Length - 1] != mousePosition)
        {
            tracedPoints[0] = mousePosition;
            tracedRenderer.positionCount = tracedPoints.Length;
            tracedRenderer.SetPositions(tracedPoints);
        }
    }

    private bool CheckPatternMatch()
    {
        if (tracedPoints.Length != patternPoints.Length)
        {
            return false;
        }

        for (int i = 0; i < tracedPoints.Length; i++)
        {
            if (Vector3.Distance(tracedPoints[i], patternPoints[i]) > threshold)
            {
                return false;
            }
        }

        return true;
    }
}
