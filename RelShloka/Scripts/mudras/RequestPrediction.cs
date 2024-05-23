using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;

public class RequestPrediction : MonoBehaviour
{
    private WebCamTexture webcamTexture;

    void Start()
    {
        string url = "https://shloka.herokuapp.com/predict";

        webcamTexture = new WebCamTexture();
        webcamTexture.Play();

        // Capture the screen as a Texture2D
        Texture2D screenshot = new Texture2D(webcamTexture.width, webcamTexture.height);
        screenshot.SetPixels(webcamTexture.GetPixels());
        screenshot.Apply();

        // Convert the Texture2D to a byte array
        byte[] screenshotBytes = screenshot.EncodeToPNG();

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "multipart/form-data";

        using (Stream formDataStream = request.GetRequestStream())
        {
            formDataStream.Write(screenshotBytes, 0, screenshotBytes.Length);
            formDataStream.Close();
        }

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader responseReader = new StreamReader(response.GetResponseStream());
        string responseData = responseReader.ReadToEnd();

        Debug.Log(responseData);

        responseReader.Close();
        response.Close();
    }
}
