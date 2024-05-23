using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dcollision : MonoBehaviour
{
   public Animator animator; 
   private bool hasBeenShown = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !hasBeenShown)
        {
            
            Debug.Log("showing");
            animator.SetBool("collide", true); 
            hasBeenShown = true;

        }

    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            
        animator.SetBool("collide", false); 
        Debug.Log("notshowing");
        hasBeenShown = false;


        }

    }


}

