using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Aarti;

public class PostAarti : MonoBehaviour
{
    public string dialogueName;
    public string[] dialogueSentences;
    [SerializeField] private Image currentpattern;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer bg2;
    public SpriteRenderer shloka;

    public GameObject canvasgesuture;

    private bool isCoroutineRunning = false;

    public void Update()
    {
        if (!isCoroutineRunning)
        {
            StartCoroutine(PostScreenshot());
        }
    }

    public void CheckFlash()
    {
        if (!isCoroutineRunning)
        {
            StartCoroutine(PostScreenshot());
        }
    }

    IEnumerator PostScreenshot()
    {
        isCoroutineRunning = true;

        yield return new WaitForSeconds(3f);

        string url = "https://shloka.herokuapp.com/predict";

        // Capture the screenshot of the webcam
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height);
        yield return new WaitForEndOfFrame();
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();
        byte[] imageData = screenshot.EncodeToPNG();

        WWWForm form = new WWWForm();
        form.AddField("image", "screenshot.png");
        form.AddBinaryData("image", imageData, "screenshot.png", "image/png");

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                // Print the server response
                Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("Aarti"))
                {
                    currentpattern.fillAmount += 0.33f;

                    if (currentpattern.fillAmount >= 0.99f)
                    {
                        canvasgesuture.SetActive(false);
                        spriteRenderer.color = Color.white;
                        shloka.color = Color.white;
                        bg2.color = Color.white;

                        Aarti.DiagforAarti newDialogue = new DiagforAarti();
                        newDialogue.name = dialogueName;
                        newDialogue.sentences = dialogueSentences;
                        FindObjectOfType<ManagerforAarti>().StartNewDialogue(newDialogue);
                    }
                }
            }
            else
            {
                Debug.Log("Form upload failed: " + www.error);
            }
        }

        isCoroutineRunning = false;
    }
}
