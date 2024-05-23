using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using static DiaglogueManager;
using Talking;

public class TimeBar : MonoBehaviour
{
    public string dialogueName;
    public string[] dialogueSentences;
    
    public float fillAmountPerSecond = 0.033f; // The amount to fill per second
    public GameObject player; // Reference to the player object
    public GameObject canvasforgesture;
    public GameObject starbreath;
    
    public float playerMoveSpeed = 1.0f; // Speed at which the player moves forward
    public float playerMoveOffset = 1.0f;

    public Image fillImage; // The Image component of the bar
    public TextMeshProUGUI countdownText; // The TextMeshProUGUI component of the countdown
    public TextMeshProUGUI breathingText; // The TextMeshProUGUI component of the breathing instructions
    public Canvas countdownCanvas;
    public GameObject textbox;


    private float fillAmount = 0f;
    private float timeSinceFill = 0f;
    private float countdown = 5f; // The countdown time in seconds
    private bool isBreathingIn = true; // Whether the user should be breathing in or out
    public void Start()
    {
        countdownCanvas.gameObject.SetActive(false);
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;

    }
    public void StartCountdown()
    {
        textbox.SetActive(false);
        countdownCanvas.gameObject.SetActive(true);
        countdownText.gameObject.SetActive(true);
        starbreath.SetActive(false);
        isBreathingIn = true; // Start by breathing in
        fillAmount = 0f; // Reset fill amount to start from empty
        timeSinceFill = 0f; // Reset time since last fill
        fillImage.fillAmount = 0f; // Set fill amount to 0 initially
        StartCoroutine(FillBarGradually());
        StartCoroutine(Countdown());
        StartCoroutine(CheckBarFillAmount());
    }

    private IEnumerator FillBarGradually()
    {
        while (true)
        {
            // Gradually fill the bar during the "Breathe In" phase
            if (!isBreathingIn)
            {
                fillAmount += fillAmountPerSecond * Time.deltaTime;
                fillAmount = Mathf.Clamp01(fillAmount);
                fillImage.fillAmount = fillAmount;
                // Vector3 targetPos = player.transform.position + player.transform.forward * playerMoveOffset;
                Vector3 targetPos = player.transform.position + player.transform.right * 2f;

                // Move player towards target position over time
                player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, playerMoveSpeed * Time.deltaTime);
            }

            yield return null;
        }
    }

    private IEnumerator Countdown()
    {
        while (true)
        {
            timeSinceFill += Time.deltaTime;

            // Update the countdown text every second
            if (timeSinceFill >= 1f)
            {
                timeSinceFill -= 1f;
                countdown -= 1f;

                if (countdown <= 0f)
                {
                    countdown = 5f;
                    isBreathingIn = !isBreathingIn; // Switch between breathing in and out
                }

                countdownText.text = Mathf.CeilToInt(countdown).ToString();

                // Update the breathing text based on whether the user should be breathing in or out
                breathingText.text = isBreathingIn ? "Breathe In" : "Breathe Out";
            }

            yield return null;
        }
    }
    private IEnumerator CheckBarFillAmount()
    {
        while (true)
        {
            if (fillAmount >= 0.95f)
            {
                yield return new WaitForSeconds(1f); // Wait for 1 second before disabling the canvas
                gameObject.SetActive(false); // Disable the canvas that contains the TimeBar script
                

                textbox.SetActive(true);
                Talking.Diaglogue newDialogue = new Diaglogue();
                newDialogue.name = dialogueName;
                newDialogue.sentences = dialogueSentences;
                FindObjectOfType<DiaglogueManager>().StartNewDialogue(newDialogue);
                canvasforgesture.SetActive(true);
                
                yield break; // End the Coroutine

            }

            yield return null;
        }
    }


}

   

