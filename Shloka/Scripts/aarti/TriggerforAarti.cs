using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Aarti;
public class TriggerforAarti : MonoBehaviour
{
   public DiagforAarti diaglogue;

   public void TriggerDialogue ()
   {
      FindObjectOfType<ManagerforAarti>().StartDiaglogue(diaglogue);
   }

  

   
   
}
