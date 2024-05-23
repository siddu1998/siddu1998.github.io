using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiocoll : MonoBehaviour
{
   public Animator animator; 
   private bool hasBeenShown = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !hasBeenShown)
        {
            
            Debug.Log("showing");
            animator.SetBool("hideing", true); 
            hasBeenShown = true;

        }

    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            
        animator.SetBool("hideing", false); 
        Debug.Log("notshowing");
        hasBeenShown = false;


        }

    }


}

