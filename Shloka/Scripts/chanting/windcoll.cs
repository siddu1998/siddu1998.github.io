using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windcoll : MonoBehaviour
{
   public Animator animator; 
   private bool beenshown = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !beenshown)
        {
            
            Debug.Log("showing");
            animator.SetBool("hitit", true); 
            beenshown = true;

        }

    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            
        animator.SetBool("hitit", false); 
        Debug.Log("notshowing");
        beenshown = false;


        }

    }


}

