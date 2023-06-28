using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Matching : MonoBehaviour
{
    private ShrinkOnClick ShrinkOnClick;
    [SerializeField] private Image totalpattern; 
    [SerializeField] private Image currentpattern;
    public GameObject buttoncavvas;
    string[][] patterns = {
        new string[] {"dhol", "taan", "conch", "tabla", "taan", "tabla", "conch", "dhol"},
        new string[] {"tabla", "conch", "taan", "dhol", "tabla", "dhol", "taan", "conch"},
        new string[] {"conch", "tabla", "conch", "taan", "dhol", "dhol", "tabla", "taan"}

    };

    public AudioSource tablaSound;
    public AudioSource conchSound;
    public AudioSource dholSound;
    public AudioSource taanSound;


    private int currentPatternIndex = 0; // The index of the current pattern in the patterns array
    private int matchedIndex = 0; // The index of the last matched fruit in the current pattern
    public string fruitName; // The name of the fruit that the user clicked

    public void Start(){
        Debug.Log(patterns[currentPatternIndex][matchedIndex]);
        ShrinkOnClick = FindObjectOfType<ShrinkOnClick>();
        if (ShrinkOnClick != null)
        {
            // Access the shrinkSpeed variable from Script1
            float speed = ShrinkOnClick.shrinkSpeed;
            Debug.Log("Shrink Speed: " + speed);
            
    }
    }

    public void OnClick()
    {
        if (fruitName == patterns[currentPatternIndex][matchedIndex])
        {
            if (matchedIndex == patterns[currentPatternIndex].Length - 1)
            {
                // User has matched the entire pattern
                Debug.Log("Pattern matched!");
                matchedIndex = 0; // Reset the matchedIndex variable

                if (currentPatternIndex == patterns.Length - 1)
                {
                    // User has matched all patterns
                    Debug.Log("All patterns matched!");
                    currentpattern.fillAmount = 100;
                    ShrinkOnClick.shrinkSpeed = 10;
                    buttoncavvas.SetActive(false);
                }
                else
                {
                    // Move to the next pattern
                    currentPatternIndex++;
                    currentpattern.fillAmount += 0.33f;
                    matchedIndex = 0; // Reset the matchedIndex to start from the beginning of the next pattern
                    Debug.Log("Click the first fruit of the next pattern: " + patterns[currentPatternIndex][matchedIndex]);
                }
            }
            else
            {
                // Move to the next fruit in the pattern
                matchedIndex++;
                Debug.Log(patterns[currentPatternIndex][matchedIndex]);
                Debug.Log("Click the next fruit: " + patterns[currentPatternIndex][matchedIndex]);
            }
        }
        else
        {
            // User made a mistake, restart the current pattern
            Debug.Log("Incorrect, try again!");
            matchedIndex = 0; // Reset the matchedIndex variable to start from the beginning of the current pattern
            Debug.Log("Click the first fruit of the current pattern: " + patterns[currentPatternIndex][matchedIndex]);
        }
    }


    public void OnClickTabla() {
    fruitName = "tabla";
    tablaSound.Play();
    OnClick();
    }

    public void OnClickConch() {
    fruitName = "conch";
    conchSound.Play();
    OnClick();
    }

    public void OnClickDhol() {
    fruitName = "dhol";
    dholSound.Play();
    OnClick();
    }
    public void OnClickTaan() {
    fruitName = "taan";
    taanSound.Play();
    OnClick();
    }


    

}
