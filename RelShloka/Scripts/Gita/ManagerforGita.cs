using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Sbox;
using Gita;
public class ManagerforGita: MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public Animator gitabox;
    public GameObject once;
    public GameObject myrecording;
    public GameObject canvasforapiresp;
    public string dialogueName;
    public string[] dialogueSentences;
    // public string dialogueName;
    // [TextArea(3,10)]
    // public string[] dialogueSentences;
    public TriggerforGita dialogueTrigger;
    public Animator recorderbutton;
    public Image fillImage;
    private bool hasStartedNewDialogue = false;
    public GameObject gonextbutton;
    





    
    private Queue<string> sentences; 
    
    public void Start()
    {
        sentences = new Queue<string>(); 
        dialogueTrigger.TriggerDialogue();
        
        // recordbutton.SetBool("hideing", true);  
    }

    public void TriggerFirstDialogue()
    {
        DiagforGita firstDialogue = new DiagforGita();
        StartDiaglogue(firstDialogue);
    }

    public void StartDiaglogue(DiagforGita diaglogue)
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
        Debug.Log(sentences.Count);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0){
            EndDialogue();
            myrecording.SetActive(true);
            // gitabox.SetBool("Gitclose", true);
            once.SetActive(true);
            // recorderbutton.SetBool("hideing", true);
            
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
      
        myrecording.SetActive(true);
        canvasforapiresp.SetActive(true);
      


        Debug.Log("End convo");
    }

    void EndSecondDialogue()
    {
       
        animator.SetBool("isopen",false);
        Debug.Log("End convo");
    }

    public void CheckFillAmountAndStartDialogue()
    {
        if (fillImage.fillAmount >= 0.33f && !hasStartedNewDialogue)
        {
            // Start a new dialogue here
            myrecording.SetActive(false);
            gonextbutton.SetActive(false);
            DiagforGita newDialogue = new DiagforGita();
            newDialogue.name = dialogueName;
            newDialogue.sentences = dialogueSentences;
            StartNewDialogue(newDialogue);

            // Set the flag to prevent starting another dialogue immediately
            hasStartedNewDialogue = true;
        }
    }

    public void Update()
    {
        CheckFillAmountAndStartDialogue();
    }



    
    public void StartNewDialogue(DiagforGita newDialogue)
    {
        sentences.Clear();
        foreach (string sentence in newDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // Display the first sentence of the new dialogue
        // DisplayNextSentence();
        // StartDiaglogue(Diaglogue newDialogue);
        FindObjectOfType<ManagerforGita>().StartDiaglogue(newDialogue);
        
    }
   

 
}
