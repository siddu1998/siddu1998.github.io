using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Sbox;
using Music;
public class ManagerforMusic : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator; 
    public GameObject co;
    public GameObject ftrash;
    public GameObject gan;
    public TriggerforMusic dialogueTrigger;
    bool oncedone = true;  
    





    
    private Queue<string> sentences; 
    
    void Start()
    {
        gan.SetActive(true);
        ftrash.SetActive(true);
        sentences = new Queue<string>();
        dialogueTrigger.TriggerDialogue();
        // recordbutton.SetBool("hideing", true);  
    }

    public void StartDiaglogue(Diagformusic diaglogue)
    {
        // animator.SetBool("isopen",true);
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
        // threeanimtotal.SetBool("startshowing", true);
        // threeanimcurrent.SetBool("startshow", true);
        animator.SetBool("isopen",false);
        
        if (oncedone){
            co.SetActive(true);
        }
        // recordbutton.SetBool("hideing", false);


        



        gan.SetActive(false);
        Debug.Log("End convo");
    }
    
    public void StartNewDialogue(Diagformusic newDialogue)
    {
        oncedone = false;

        gan.SetActive(true);
        sentences.Clear();
        foreach (string sentence in newDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // Display the first sentence of the new dialogue
        // DisplayNextSentence();
        // StartDiaglogue(Diaglogue newDialogue);
        FindObjectOfType<ManagerforMusic>().StartDiaglogue(newDialogue);
        
    }
   

 
}
