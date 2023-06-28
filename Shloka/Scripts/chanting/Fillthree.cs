using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Fillthree : MonoBehaviour
{
    [SerializeField] private Image totalrecordtime; 
    [SerializeField] private Image currentrecordtime; 
    public static float count = 0; 

   
   private void Start()
   {
        totalrecordtime.fillAmount = 100;
   }

   private void Update()
   {
        currentrecordtime.fillAmount = 0.33f*count;
   
   }
   
   
   
   
   public void AddRecordFill(float _value)
   {
    
   }

}
