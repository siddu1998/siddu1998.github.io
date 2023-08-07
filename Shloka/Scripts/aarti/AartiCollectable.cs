using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aarti;

public class AartiCollectable : MonoBehaviour
{   
    
    public GameObject collecatble;
    [SerializeField] private string dialogueName;
    [SerializeField] private string[] dialogueSentences;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") )
        {
            
            
            Debug.Log("collected");
            collecatble.SetActive(false);
            Aarti.DiagforAarti newDialogue = new DiagforAarti();
            newDialogue.name = dialogueName;
            newDialogue.sentences = dialogueSentences;
            FindObjectOfType<ManagerforAarti>().StartNewDialogue(newDialogue);

        }

    }



}
