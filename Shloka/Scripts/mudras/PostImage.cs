using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Talking;

public class PostImage : MonoBehaviour
{
    public float interval = 3f; // Time interval in seconds between each screenshot post
    public string dialogueName;
    public string[] dialogueSentences;
    public GameObject Gesturel;
    public Image timetofill;
    private void Start()
    {
        StartCoroutine(PostScreenshotRepeatedly());
    }

    IEnumerator PostScreenshotRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            yield return PostScreenshot();
        }
    }

    IEnumerator PostScreenshot()
    {
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
                    timetofill.fillAmount+=0.33f;
                    Talking.Diaglogue newDialogue = new Diaglogue();
                    newDialogue.name = dialogueName;
                    newDialogue.sentences = dialogueSentences;
                    FindObjectOfType<DiaglogueManager>().StartNewDialogue(newDialogue);
                    Gesturel.SetActive(false);

                }
            }
            else
            {
                Debug.Log("Form upload failed: " + www.error);
            }
        }
    }
}
