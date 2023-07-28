using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollide : MonoBehaviour
{
   private bool hasBeenShown = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !hasBeenShown)
        {
            
            
            
            hasBeenShown = true;

        }

    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            
        // animator.SetBool("collide", false); 
        Debug.Log("notshowing");
        hasBeenShown = false;


        }

    }


}

