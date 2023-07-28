using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TrashImage : MonoBehaviour
{
    public Image threecurrent;
    public Image threetotal;
    bool prana = true;
    bool isRunning = true;

    public void Start()
    {
        // Start the coroutine to post the screenshot every 2.5 seconds
        StartCoroutine(PostScreenshotRoutine(1.5f));
    }

    IEnumerator PostScreenshotRoutine(float interval)
    {
        // Execute the coroutine until threecurrent.fillAmount >= 0.99f
        while (isRunning && threecurrent.fillAmount < 0.99f)
        {
            yield return new WaitForSeconds(interval); // Wait for the specified interval

            yield return StartCoroutine(PostScreenshot()); // Execute the screenshot posting

            // Additional code if needed
        }
    }

    IEnumerator PostScreenshot()
    {
        string url = "https://shloka.herokuapp.com/predictPrana";

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

                if (www.downloadHandler.text.Contains("Pranayam"))
                {
                    threecurrent.fillAmount += 0.33f;
                }
            }
            else
            {
                Debug.Log("Form upload failed: " + www.error);
            }
        }
    }
}
