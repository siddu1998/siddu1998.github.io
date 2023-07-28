using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Sbox;
using Talking;
public class DiaglogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator; 
    public Animator recordbutton;
    public GameObject breathebutton;
    // public GameObject gestbutton;
    public DialogueTrigger dialogueTrigger;


    
    private Queue<string> sentences; 
    
    void Start()
    {
     sentences = new Queue<string>();
     dialogueTrigger.TriggerDialogue();
    //  recordbutton.SetBool("hideing", true);  
    }

    public void StartDiaglogue(Diaglogue diaglogue)
    {
        animator.SetBool("isopen",true);
        
        // animator.SetBool("sboxopen",true);
        


        
        Debug.Log("Starting convo with " + diaglogue.name);
        nameText.text = diaglogue.name;
        sentences.Clear();

        foreach (string sentence in diaglogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
       // Reference to the player object
    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isopen",false);
        recordbutton.SetBool("hideing", false);
        breathebutton.SetActive(false);
        // gestbutton.SetActive(true);
        




        Debug.Log("End convo");
    }
    
    public void StartNewDialogue(Diaglogue newDialogue)
    {
        recordbutton.SetBool("hideing", true);
        sentences.Clear();
        foreach (string sentence in newDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // Display the first sentence of the new dialogue
        // DisplayNextSentence();
        // StartDiaglogue(Diaglogue newDialogue);
        FindObjectOfType<DiaglogueManager>().StartDiaglogue(newDialogue);
        
    }
   

 
}
