using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LineMatcher : MonoBehaviour
{
    public Line userLine;
    public GameObject[] prefabLineObjects;
    public Image onethird;
    public LineGenerator lineGenerator;
    public Animator firstrock;
    public Animator secondrock;
    public Animator thirdrock;
    public GameObject wallobject;
    public TextMeshProUGUI clearbutton;
    public GameObject dicanvas;


    public float matchingThreshold = 0.5f;

    private bool[] prefabLineMatched;
    private int matchingCount = 0;

    private void Start()
    {
        CapturePrefabLines();
        prefabLineMatched = new bool[prefabLineObjects.Length];
        clearbutton.text = "Clear";
    }

    private void CapturePrefabLines()
    {
        prefabLineObjects = GameObject.FindGameObjectsWithTag("PrefabLine");

        foreach (GameObject prefabLineObject in prefabLineObjects)
        {
            PrefabLine prefabLine = prefabLineObject.GetComponent<PrefabLine>();
            prefabLine.CapturePoints();
        }
    }

    public void CheckLineMatching(Line userLine)
    {
        this.userLine = userLine;

        if (userLine == null)
        {
            Debug.Log("User line is null.");
            return;
        }

        List<Vector2> userPoints = userLine.GetPoints();

        int matchingPointsCount = 0;

        foreach (GameObject prefabLineObject in prefabLineObjects)
        {
            PrefabLine prefabLine = prefabLineObject.GetComponent<PrefabLine>();

            if (prefabLine.Points.Count == 0 || userPoints.Count == 0)
            {
                Debug.Log("User line or prefab line has no points.");
                continue;
            }

            Debug.Log("Prefab: " + prefabLineObject.name + ", Points Count: " + prefabLine.Points.Count);

            foreach (Vector2 userPoint in userPoints)
            {
                foreach (Vector2 prefabPoint in prefabLine.Points)
                {
                    if (Vector2.Distance(userPoint, prefabPoint) < matchingThreshold)
                    {
                        matchingPointsCount++;
                        break;
                    }
                }
            }

            if (matchingPointsCount > 5 && !prefabLineMatched[matchingCount])
            {
                Debug.Log("Similar line found for prefab: " + prefabLineObject.name);
                prefabLineMatched[matchingCount] = true;
                matchingCount++; // Increment matchingCount only when a matching line is found
                break;
            }

            matchingPointsCount = 0; // Reset matchingPointsCount for the next prefab line
        }

        Debug.Log("matching count: " + matchingCount);

        int prefabsLeftToMatch = prefabLineObjects.Length - matchingCount;
        Debug.Log("Prefabs left to match: " + prefabsLeftToMatch);

        if (matchingCount == prefabLineObjects.Length-1)
        {
            Debug.Log("All elements matched!");
            onethird.fillAmount+= 0.33f;
            if (onethird.fillAmount== 0.33f)
            {
                firstrock.SetBool("written",true);
            }
            if (onethird.fillAmount== 0.66f)
            {
                secondrock.SetBool("wrote2",true);
            }
            if (onethird.fillAmount== 0.99f)
            {
                thirdrock.SetBool("popped",true);
                wallobject.SetActive(false);
                dicanvas.SetActive(true);
            }
            ClearUserLinesAndResetMatchedPrefabs(lineGenerator);

            // Perform actions when all elements are matched
        }
        else if (matchingCount >= 4)
        {
            Debug.Log("Matched 4 or more prefabs!");
            // Perform actions when 4 or more prefabs are matched
        }
        else
        {
            Debug.Log("Lines do not match enough prefabs.");
        }
    }

   
    public void ClearUserLinesAndResetMatchedPrefabs(LineGenerator lineGenerator)
    {
        lineGenerator.ClearUserLines();

        matchingCount = 0; // Reset matchingCount

        for (int i = 0; i < prefabLineMatched.Length; i++)
        {
            prefabLineMatched[i] = false;
        }

        Debug.Log("Prefab bools and matchingCount reset.");
        string boolArrayLog = "PrefabLineMatched Array: ";
        for (int i = 0; i < prefabLineMatched.Length; i++)
        {
            boolArrayLog += prefabLineMatched[i] ? "1" : "0";
        }
        Debug.Log(boolArrayLog);
        
    }



}