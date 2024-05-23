using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Trash;
public class TriggerforTrash : MonoBehaviour
{
   public DiagforTrash diaglogue;

   public void TriggerDialogue ()
   {
      FindObjectOfType<ManagerforTrash>().StartDiaglogue(diaglogue);
   }

  

   
   
}
