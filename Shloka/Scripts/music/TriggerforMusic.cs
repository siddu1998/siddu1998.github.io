using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Music;
public class TriggerforMusic : MonoBehaviour
{
   public Diagformusic diaglogue;

   public void TriggerDialogue ()
   {
      FindObjectOfType<ManagerforMusic>().StartDiaglogue(diaglogue);
   }

  

   
   
}
