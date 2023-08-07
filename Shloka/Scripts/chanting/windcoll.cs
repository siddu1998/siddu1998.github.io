using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chanting;


public class windcoll : MonoBehaviour
{
   public Animator windmills;
   public GameObject pixelsh;
   [SerializeField] private string dialogueName;
   [SerializeField] private string[] dialogueSentences;


   private bool beenshown = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && pixelsh.transform.localScale == new Vector3(80f, 80f,320f))
        {
            
            Debug.Log("showing");
            windmills.SetBool("chantingdone",true);
            Chanting.DiagforChanting newDialogue = new DiagforChanting();
            newDialogue.name = dialogueName;
            newDialogue.sentences = dialogueSentences;
            FindObjectOfType<ManagerforChanting>().StartNewDialogue(newDialogue);

        }

    }

    //  void OnTriggerExit2D(Collider2D other)
    // {
    //     if(other.CompareTag("Player"))
    //     {
            
    //     animator.SetBool("hitit", false); 
    //     Debug.Log("notshowing");
    //     beenshown = false;


    //     }

    // }


}

