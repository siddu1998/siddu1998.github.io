using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public LineMatcher lineMatcher;
    private List<GameObject> generatedLines = new List<GameObject>();

    private Line activeLine;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newLineObject = Instantiate(linePrefab);
            generatedLines.Add(newLineObject); // Add the new line object to the list
            activeLine = newLineObject.GetComponent<Line>();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (activeLine != null)
            {
                lineMatcher.CheckLineMatching(activeLine);
                activeLine = null;
            }
        }

        if (Input.GetMouseButton(0) && activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }

    public void ClearUserLines()
    {
        foreach (GameObject lineObject in generatedLines)
        {
            Destroy(lineObject);
        }
        generatedLines.Clear();
    }
}