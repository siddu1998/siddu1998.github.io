using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rangoli;

public class CollectableRangoli : MonoBehaviour
{   
    
    public GameObject collecatblee;
    [SerializeField] private string dialogueName;
    [SerializeField] private string[] dialogueSentences;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") )
        {
            
            
            Debug.Log("collected");
            collecatblee.SetActive(false);
            Rangoli.DiagforRan newDialogue = new DiagforRan();
            newDialogue.name = dialogueName;
            newDialogue.sentences = dialogueSentences;
            FindObjectOfType<ManagerforRan>().StartNewDialogue(newDialogue);

        }

    }



}
