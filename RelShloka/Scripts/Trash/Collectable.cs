using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trash;

public class Collectable : MonoBehaviour
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
            Trash.DiagforTrash newDialogue = new DiagforTrash();
            newDialogue.name = dialogueName;
            newDialogue.sentences = dialogueSentences;
            FindObjectOfType<ManagerforTrash>().StartNewDialogue(newDialogue);

        }

    }



}
