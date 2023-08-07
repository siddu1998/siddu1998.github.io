using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Sbox;
using Aarti;
public class ManagerforAarti : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator; 
    public Animator threeanimtotal;
    public Animator threeanimcurrent;
    public GameObject gestureCanvas;
    public GameObject threetimesCanvas;
    public GameObject firstdbutton;
    public GameObject chantingcanvass;
    public string dialogueName;
    private bool doneonce;
    private bool wantstoshow; 
    [TextArea(3,10)]
    public string[] dialogueSentences;
    public TriggerforAarti dialogueTrigger;
    private bool nomore = false;
    





    
    private Queue<string> sentences; 
    
    void Start()
    {
        doneonce = false;
        wantstoshow = false; 
        sentences = new Queue<string>();
        dialogueTrigger.TriggerDialogue();
        // recordbutton.SetBool("hideing", true);  
    }

    public void StartDiaglogue(DiagforAarti diaglogue)
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


    public void DisplaySecondNextSentence()
    {
        if (sentences.Count == 0){
            EndSecondDialogue();
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
        if (!doneonce) 
        {
            Debug.Log("starting AARTI");
            animator.SetBool("isopen",false);
            gestureCanvas.SetActive(true);


            Debug.Log("End convo");
            doneonce = true; 
        }

        if (doneonce && wantstoshow && !nomore) 
        {
            Debug.Log(wantstoshow);
            Debug.Log("starting CHANT");
            animator.SetBool("isopen",false);
            chantingcanvass.SetActive(true);


            Debug.Log("End convo");
            doneonce = true; 
            nomore = true; 
        }

        
    }

    void EndSecondDialogue()
    {
        threeanimtotal.SetBool("startshowing", true);
        threeanimcurrent.SetBool("startshow", true);
        animator.SetBool("isopen",false);
        Debug.Log("End convo");
    }



    
    public void StartNewDialogue(DiagforAarti newDialogue)
    {
        wantstoshow = true; 
        sentences.Clear();
        foreach (string sentence in newDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // Display the first sentence of the new dialogue
        // DisplayNextSentence();
        // StartDiaglogue(Diaglogue newDialogue);
        FindObjectOfType<ManagerforAarti>().StartDiaglogue(newDialogue);
        
    }
   

 
}
