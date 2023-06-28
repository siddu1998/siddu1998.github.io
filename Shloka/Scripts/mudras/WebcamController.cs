using UnityEngine;
using UnityEngine.UI;

public class WebcamController : MonoBehaviour
{
    private WebCamTexture webcamTexture;
    private RawImage rawImage;
    [SerializeField]
    private Vector3 positionAdjustment = new Vector3(50f, 0f, 0f);
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
        rawImage.rectTransform.sizeDelta = new Vector2(350 , 350);

        // Start the WebCamTexture
        webcamTexture.Play();
    }

    void LateUpdate()
    {
        if (!hasAdjustedPosition && rawImage != null)
        {
            // Move the RawImage
            Vector3 newPosition = rawImage.rectTransform.localPosition + positionAdjustment;
            rawImage.rectTransform.localPosition = newPosition;

            hasAdjustedPosition = true;
        }
    }
}
