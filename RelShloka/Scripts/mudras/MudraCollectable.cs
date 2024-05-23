using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Talking;

public class MudraCollectable : MonoBehaviour
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
            Talking.Diaglogue newDialogue = new Diaglogue();
            newDialogue.name = dialogueName;
            newDialogue.sentences = dialogueSentences;
            FindObjectOfType<DiaglogueManager>().StartNewDialogue(newDialogue);

        }

    }



}
