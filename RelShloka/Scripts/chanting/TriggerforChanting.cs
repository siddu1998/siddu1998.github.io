using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Chanting;
public class TriggerforChanting : MonoBehaviour
{
   public DiagforChanting diaglogue;

   public void TriggerDialogue()
   {
      FindObjectOfType<ManagerforChanting>().StartDiaglogue(diaglogue);
   }

  

   
   
}
