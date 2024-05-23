using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupSystem : MonoBehaviour
{
   public GameObject popupBox;
   public Animator animator;
   public TMP_Text popUpText;

   public void PopUp(string text)
   {
    popupBox.SetActive(true);
    popUpText.text = text;
    animator.SetTrigger("pop");

   }
}
