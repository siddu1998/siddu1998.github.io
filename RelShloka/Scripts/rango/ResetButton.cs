// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class ResetButton : MonoBehaviour
// {
//     public LineGenerator lineGenerator;
//     public LineMatcher lineMatcher;

//     private void Awake()
//     {
//         Button resetButton = GetComponent<Button>();
//         resetButton.onClick.AddListener(ResetLinesAndMatch);
//     }

//     public void ResetLinesAndMatch()
//     {
//         lineMatcher.ClearUserLinesAndResetMatchedPrefabs(lineGenerator);
//     }
// }
