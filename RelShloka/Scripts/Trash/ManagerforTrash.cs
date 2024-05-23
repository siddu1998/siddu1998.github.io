using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Sbox;
using Trash;
[System.Serializable] 
public class ManagerforTrash : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator; 
    public GameObject webcame;
    public string dialogueName;
    [TextArea(3,10)]
    public string[] dialogueSentences;
    // public Animator recordbutton;
    // public Animator threeanimtotal;
    public Image threecurrent;
    private bool isEventTriggered = false;
    private bool gestured = false;
    public GameObject nextbutton; 
    public GameObject newscenebutton;
    public TriggerforTrash dialogueTrigger;


    
    private Queue<string> sentences; 
    
    void Start()
    {
        sentences = new Queue<string>();
        dialogueTrigger.TriggerDialogue();
        // recordbutton.SetBool("hideing", true);  
    }

    public void StartDiaglogue(DiagforTrash diaglogue)
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

        if (sentences.Count == 1 && !gestured){
           gestured = true; 
           webcame.SetActive(true);
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
        // threeanimtotal.SetBool("startshowing", true);
        // threeanimcurrent.SetBool("startshow", true);
        animator.SetBool("isopen",false);
        // recordbutton.SetBool("hideing", false);


        




        Debug.Log("End convo");
    }
    
    public void StartNewDialogue(DiagforTrash newDialogue)
    {
        sentences.Clear();
        foreach (string sentence in newDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // Display the first sentence of the new dialogue
        // DisplayNextSentence();
        // StartDiaglogue(Diaglogue newDialogue);
        FindObjectOfType<ManagerforTrash>().StartDiaglogue(newDialogue);
        
    }

    public void Update()
    {
        if(threecurrent.fillAmount >= 0.99f && !isEventTriggered){
            isEventTriggered = true;
            webcame.SetActive(false);
            DiagforTrash newDialogue = new DiagforTrash();
            newDialogue.name = dialogueName;
            newDialogue.sentences = dialogueSentences;
            FindObjectOfType<ManagerforTrash>().StartNewDialogue(newDialogue);
        }

        else if (threecurrent.fillAmount < 0.99f)
        {
            isEventTriggered = false;
        }
    }
   

 
}
