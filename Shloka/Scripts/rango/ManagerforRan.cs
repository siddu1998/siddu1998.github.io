using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Sbox;
using Rangoli;
[System.Serializable] 
public class ManagerforRan : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator; 
    public GameObject writing;
    public string dialogueName;
    [TextArea(3,10)]
    public string[] dialogueSentences;
    // public Animator recordbutton;
    // public Animator threeanimtotal;
    public Image threecurrent;
    private bool isEventTriggered = false;
    private bool gestured = false;
    public GameObject nextbutton; 
    public TriggerforRan dialogueTrigger;
    public GameObject randomcanvastoo;
    





    
    private Queue<string> sentences; 
    
    void Start()
    {
        sentences = new Queue<string>();
        dialogueTrigger.TriggerDialogue();
        // recordbutton.SetBool("hideing", true);  
    }

    public void StartDiaglogue(DiagforRan diaglogue)
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
           writing.SetActive(true);
           randomcanvastoo.SetActive(true);
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
    
    public void StartNewDialogue(DiagforRan newDialogue)
    {
        sentences.Clear();
        foreach (string sentence in newDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // Display the first sentence of the new dialogue
        // DisplayNextSentence();
        // StartDiaglogue(Diaglogue newDialogue);
        FindObjectOfType<ManagerforRan>().StartDiaglogue(newDialogue);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            
            isEventTriggered = true;
            writing.SetActive(false);
            randomcanvastoo.SetActive(false);
            DiagforRan newDialogue = new DiagforRan();
            newDialogue.name = dialogueName;
            newDialogue.sentences = dialogueSentences;
            nextbutton.SetActive(false);
           
            FindObjectOfType<ManagerforRan>().StartNewDialogue(newDialogue);
        }

        else if (threecurrent.fillAmount < 0.99f)
        {
            isEventTriggered = false;
        }
            
            

    }
    public void Update()
    {
        if(threecurrent.fillAmount >= 0.99f && !isEventTriggered){
            isEventTriggered = true;
            writing.SetActive(false);
            randomcanvastoo.SetActive(false);
            DiagforRan newDialogue = new DiagforRan();
            newDialogue.name = dialogueName;
            newDialogue.sentences = dialogueSentences;
            nextbutton.SetActive(false);
           
            FindObjectOfType<ManagerforRan>().StartNewDialogue(newDialogue);
        }

        else if (threecurrent.fillAmount < 0.99f)
        {
            isEventTriggered = false;
        }
    }
   

 
}
