using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gita;

public class CollectableGita : MonoBehaviour
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
            Gita.DiagforGita newDialogue = new DiagforGita();
            newDialogue.name = dialogueName;
            newDialogue.sentences = dialogueSentences;
            FindObjectOfType<ManagerforGita>().StartNewDialogue(newDialogue);

        }

    }



}
