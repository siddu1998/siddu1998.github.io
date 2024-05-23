using UnityEngine;
using UnityEngine.Networking;

public class CameraController : MonoBehaviour
{
    private WebCamTexture webcamTexture;

    public void TakeScreenshot()
    {
        // Capture a screenshot from the WebCamTexture
        Texture2D screenshot = new Texture2D(webcamTexture.width, webcamTexture.height);
        screenshot.SetPixels(webcamTexture.GetPixels());
        screenshot.Apply();

        // Convert the screenshot to a PNG byte array
        byte[] screenshotBytes = screenshot.EncodeToPNG();

        // // Set up the URL and form data for the API request
        // string url = "http://0bae-2600-1700-2329-4610-ad83-c89f-f66-db4f.ngrok-free.app/predict";
        // WWWForm form = new WWWForm();
        // form.AddField("image", "file.png");
        // form.AddBinaryData("image", screenshotBytes, "file.png", "image/png");

        // // Send the API request
        // UnityWebRequest request = UnityWebRequest.Post(url, form);
        // request.SendWebRequest();

        // // Check for errors
        // if (request.result == UnityWebRequest.Result.ConnectionError || 
        //     request.result == UnityWebRequest.Result.ProtocolError)
        // {
        //     Debug.Log(request.error);
        // }
        // else
        // {
        //     Debug.Log(request.downloadHandler.text);
        // }
    }
}