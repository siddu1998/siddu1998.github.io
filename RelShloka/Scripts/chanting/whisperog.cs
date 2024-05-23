
// using System;
// using UnityEngine;
// using UnityEngine.UI;
// using static Fillthree; 
// using OpenAI; // Add this line to include the OpenAIApi namespace
// namespace UnityWebGLMicrophone
// {
// namespace OpenAI
// {
//     public class Whisper : MonoBehaviour
//     {
//         [SerializeField] private Button recordButton;
//         [SerializeField] public Image progressBar;
//         [SerializeField] private Text message;
//         [SerializeField] private Dropdown dropdown;
//         [SerializeField] private Text predefinedText;
//         public bool alreadyScaled = false;
//         private Vector3 originalScale;
//         private bool textsAreSimilar = false;
//         public float scaleFactor = 1.5f;
//         private int repetitions = 0;
        


        
//         private readonly string fileName = "output.wav";
//         private readonly int duration = 5;
        
//         private AudioClip clip;
//         private bool isRecording;
//         public GameObject player;

//         private float time;
//         private OpenAIApi openai = new OpenAIApi("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");

//         public Animator animation;
//         public Animator threeanimtotal;
//         public Animator threeanimcurrent;





//         public void Start()
//             {
//                 recordButton.onClick.AddListener(StartRecording);
//             }

//             public void StartRecording()
//             {
//                 threeanimtotal.SetBool("startshowing", true);
//                 threeanimcurrent.SetBool("startshow", true);
//                 isRecording = true;
//                 recordButton.enabled = false;
//                 clip = Microphone.Start(null, false, duration, 44100);
//             }

//             private async void EndRecording()
//             {
//                 message.text = "Transcripting...";
//                 Microphone.End(null);
//                 byte[] data = SaveWav.Save(fileName, clip);

//                 var req = new CreateAudioTranslationRequest()
//                 {
//                     FileData = new FileData() { Data = data, Name = "audio.wav" },
//                     Model = "whisper-1",
//                 };
//                 var res = await openai.CreateAudioTranslation(req);

//                 progressBar.fillAmount = 0;
//                 message.text = res.Text;
//                 recordButton.enabled = true;
//                 if (AreTextsSimilar(message.text, predefinedText.text))
//                 {
//                     Debug.Log("are similar");
//                     textsAreSimilar = true;
//                     Fillthree.count++;
//                     Debug.Log(count);
//                 }
//             }
//         public static bool AreTextsSimilar(string text1, string text2, double threshold = 0.5)
//         {
//             int maxLength = Math.Max(text1.Length, text2.Length);
//             int distance = LevenshteinDistance(text1, text2);
//             double similarity = (double)(maxLength - distance) / maxLength;
//             return similarity >= threshold;
//         }

//         public static int LevenshteinDistance(string s, string t)
//         {
//             int[,] d = new int[s.Length + 1, t.Length + 1];

//             for (int i = 0; i <= s.Length; i++)
//             {
//                 d[i, 0] = i;
//             }

//             for (int j = 0; j <= t.Length; j++)
//             {
//                 d[0, j] = j;
//             }

//             for (int j = 1; j <= t.Length; j++)
//             {
//                 for (int i = 1; i <= s.Length; i++)
//                 {
//                     if (s[i - 1] == t[j - 1])
//                     {
//                         d[i, j] = d[i - 1, j - 1];
//                     }
//                     else
//                     {
//                         d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + 1);
//                     }
//                 }
//             }

//             return d[s.Length, t.Length];
//         }


//         private void Update()
//         {
//             if (isRecording)
//             {
//                 time += Time.deltaTime;
//                 progressBar.fillAmount = time / duration;
                
//                 if (time >= duration)
//                 {
//                     time = 0;
//                     isRecording = false;
//                     EndRecording();
//                 }

                
//             }

                
                
//             if (Fillthree.count == 3)
//             {
//                 player.transform.localScale = new Vector3(80f, 80f, 80f);
//             }
                    

//                 // Save the new scale value to PlayerPrefs
                    
//         }



                
            
//     }

       


// }
// }