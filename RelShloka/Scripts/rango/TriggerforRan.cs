using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Rangoli;
public class TriggerforRan : MonoBehaviour
{
   public DiagforRan diaglogue;

   public void TriggerDialogue ()
   {
      FindObjectOfType<ManagerforRan>().StartDiaglogue(diaglogue);
   }

  

   
   
}
