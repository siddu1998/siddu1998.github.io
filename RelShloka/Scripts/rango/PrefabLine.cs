using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLine : MonoBehaviour
{
    public LineRenderer lineRenderer { get; private set; }
    public List<Vector2> Points { get; private set; }

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        CapturePoints();
    }

    public void CapturePoints()
    {
        Points = new List<Vector2>();

        // Make sure lineRenderer is not null
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer component is missing.");
            return;
        }

        // Retrieve the positions from the LineRenderer and store them as points
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Points.Add(lineRenderer.GetPosition(i));
        }

        // Perform further actions with the captured points
        // For example, you can store the points in a separate list or perform matching calculations

        // Print the points for testing
        Debug.Log("Prefab Points Count: " + Points.Count);
        foreach (Vector2 point in Points)
        {
            Debug.Log("Prefab Point: " + point);
        }
    }
}
