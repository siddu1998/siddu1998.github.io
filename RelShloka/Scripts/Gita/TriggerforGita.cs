using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Gita;
public class TriggerforGita : MonoBehaviour
{
   public DiagforGita diaglogue;

   public void TriggerDialogue ()
   {
      FindObjectOfType<ManagerforGita>().StartDiaglogue(diaglogue);
   }

  

   
   
}
