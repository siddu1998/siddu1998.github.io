using UnityEngine;
using UnityEngine.UI;

public class WebcamController : MonoBehaviour
{
    private WebCamTexture webcamTexture;
    private RawImage rawImage;
    private bool hasAdjustedPosition = false;

    void Start()
    {
        // Get the name of the webcam to use
        string webcamName = WebCamTexture.devices[0].name;

        // Create a new instance of the WebCamTexture class
        webcamTexture = new WebCamTexture(webcamName);

        // Get the RawImage component
        rawImage = GetComponent<RawImage>();

        // Set the RawImage's texture to the WebCamTexture instance
        rawImage.texture = webcamTexture;

        // Adjust the RawImage's size to make it a square
        rawImage.rectTransform.sizeDelta = new Vector2(300, 100);

        // Start the WebCamTexture
        webcamTexture.Play();
    }

   
}
