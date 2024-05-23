// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TensorFlowLite;

// public class Gesture : MonoBehaviour
// {
//     public Texture2D cameraTexture; // The camera texture
//     public TextAsset modelFile; // The Teachable Machine model file

//     private WebCamTexture webcamTexture; // The camera texture object
//     private Interpreter interpreter; // The TensorFlow Lite model interpreter
//     private int inputSize = 224; // The input size of the model
//     private int channelCount = 3; // The number of color channels in the input image
//     private float threshold = 0.8f; // The classification threshold

//     void Start()
//     {
//         // Initialize the camera texture
//         webcamTexture = new WebCamTexture();
//         webcamTexture.Play();

//         // Initialize the TensorFlow Lite interpreter with the model file
//         interpreter = new Interpreter(modelFile.bytes);
//     }

//     void Update()
//     {
//         // Capture the camera texture
//         if (webcamTexture.didUpdateThisFrame)
//         {
//             cameraTexture = new Texture2D(webcamTexture.width, webcamTexture.height);
//             cameraTexture.SetPixels(webcamTexture.GetPixels());
//             cameraTexture.Apply();

//             // Convert the camera texture to a TensorFlow Lite Tensor
//             Color32[] pixels = cameraTexture.GetPixels32();
//             float[] inputs = new float[pixels.Length * channelCount];
//             for (int i = 0; i < pixels.Length; i++)
//             {
//                 inputs[i * channelCount] = pixels[i].r / 255f;
//                 inputs[i * channelCount + 1] = pixels[i].g / 255f;
//                 inputs[i * channelCount + 2] = pixels[i].b / 255f;
//             }
//             Tensor inputTensor = new Tensor(1, webcamTexture.height, webcamTexture.width, channelCount, inputs);

//             // Run the TensorFlow Lite model on the input Tensor and get the output Tensor
//             interpreter.SetInputTensorData(inputTensor);
//             interpreter.Invoke();
//             Tensor outputTensor = interpreter.GetOutputTensor(0);

//             // Get the predicted class index and score from the output Tensor
//             float[] outputScores = outputTensor.data.Download<float>();
//             int predictedIndex = -1;
//             float maxScore = 0;
//             for (int i = 0; i < outputScores.Length; i++)
//             {
//                 if (outputScores[i] > threshold && outputScores[i] > maxScore)
//                 {
//                     predictedIndex = i;
//                     maxScore = outputScores[i];
//                 }
//             }

//             // Do something based on the predicted class
//             if (predictedIndex == 0)
//             {
//                 Debug.Log("Gesture: Fist");
//                 // Do something for Fist gesture
//             }
//             else if (predictedIndex == 1)
//             {
//                 Debug.Log("Gesture: Open Hand");
//                 // Do something for Open Hand gesture
//             }

//             // Dispose of the input and output Tensors
//             inputTensor.Dispose();
//             outputTensor.Dispose();
//         }
//     }
// }

