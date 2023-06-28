using UnityEngine;

public class StarDrawer : MonoBehaviour
{
    public int numberOfPoints = 5; // Number of points in the star
    public float radius = 1f; // Radius of the star
    public float rotation = 0f; // Rotation of the star in degrees

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        DrawStar();
    }

    void DrawStar()
    {
        float angle = 360f / numberOfPoints;
        float currentAngle = rotation;

        // Set the number of positions in the LineRenderer
        lineRenderer.positionCount = numberOfPoints * 2 + 1;

        Vector3[] positions = new Vector3[numberOfPoints * 2 + 1];

        for (int i = 0; i <= numberOfPoints; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * currentAngle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * currentAngle) * radius;

            positions[i * 2] = new Vector3(x, y, 0f);

            float innerRadius = radius / 2f;
            float innerX = Mathf.Sin(Mathf.Deg2Rad * (currentAngle + angle / 2f)) * innerRadius;
            float innerY = Mathf.Cos(Mathf.Deg2Rad * (currentAngle + angle / 2f)) * innerRadius;

            positions[i * 2 + 1] = new Vector3(innerX, innerY, 0f);

            currentAngle += angle;
        }

        lineRenderer.SetPositions(positions);
    }
}
