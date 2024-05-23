using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Talking;
public class DialogueTrigger : MonoBehaviour
{
   public Diaglogue diaglogue;

   public void TriggerDialogue ()
   {
      FindObjectOfType<DiaglogueManager>().StartDiaglogue(diaglogue);
   }

  

   
   
}
