using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Sbox;
using Chanting;
public class ManagerforChanting : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator recordbutton;
    public Animator threeanimtotal;
    public Animator threeanimcurrent;
    public Animator hidehanuman;
    public TriggerforChanting dialogueTrigger;
    public GameObject canvasforrecord;
    public GameObject canvasforapiresponse;
    public bool chantedalready; 





    
    private Queue<string> sentences; 
    
    void Start()
    {
        sentences = new Queue<string>();
        dialogueTrigger.TriggerDialogue();
        Debug.Log(sentences);
        // recordbutton.SetBool("hideing", false);  
    }

    public void StartDiaglogue(DiagforChanting diaglogue)
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
        if (!chantedalready)
        {
            canvasforrecord.SetActive(true);
            canvasforapiresponse.SetActive(true);
        // threeanimtotal.SetBool("startshowing", true);
        // threeanimcurrent.SetBool("startshow", true);
        // animator.SetBool("isopen",false);
        // recordbutton.SetBool("hideing", true);
        // hidehanuman.SetBool("hidehan", true);
        }
        chantedalready = true;



        




        Debug.Log("End convo");
    }
    
    public void StartNewDialogue(DiagforChanting newDialogue)
    {
        sentences.Clear();
        foreach (string sentence in newDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // Display the first sentence of the new dialogue
        // DisplayNextSentence();
        // StartDiaglogue(Diaglogue newDialogue);
        FindObjectOfType<ManagerforChanting>().StartDiaglogue(newDialogue);
        
    }
   

 
}
