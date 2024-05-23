using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Music;

public class CollectableMusic : MonoBehaviour
{   
    
    public GameObject collecacble;
    [SerializeField] private string dialogueName;
    [SerializeField] private string[] dialogueSentences;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") )
        {
            
            
            Debug.Log("collected");
            collecacble.SetActive(false);
            Music.Diagformusic newDialogue = new Diagformusic();
            newDialogue.name = dialogueName;
            newDialogue.sentences = dialogueSentences;
            FindObjectOfType<ManagerforMusic>().StartNewDialogue(newDialogue);

        }

    }



}
