using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using AOT;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    public Button yourButton;
    [SerializeField] public Image progressBar;
    [SerializeField] public Text predefinedText;
    [SerializeField] public TextMeshProUGUI message;
    [SerializeField] public Image threetimesforchanting;
    public GameObject canvasforrec;
    public GameObject canvasforapi; 

    private bool textsAreSimilar = false;
    public GameObject player;

    [DllImport("__Internal")]
    private static extern void StartRecording();

    [DllImport("__Internal")]
    private static extern string StopRecordingAndSendToAPI();
    private Coroutine fillProgressBarCoroutine;

    void Start()
    {
        // threetimesforchanting.fillAmount += 0.33f;
        message.text = "";
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    IEnumerator FillProgressBar(float duration)
    {
        float timer = 0f;
        float fillStartValue = progressBar.fillAmount;
        float fillEndValue = 1f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Lerp(fillStartValue, fillEndValue, timer / duration);
            progressBar.fillAmount = progress;
            yield return null;
        }
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        StartRecording();
        fillProgressBarCoroutine = StartCoroutine(FillProgressBar(10f));
        Invoke(nameof(OnStopButtonClicked), 10f); // Call OnStopButtonClicked after 10 seconds
    }

    public void OnStopButtonClicked()
    {
        string res = "checking if this works";
        res = StopRecordingAndSendToAPI();
        Debug.Log(res);
        Debug.Log(predefinedText.text);
        if (fillProgressBarCoroutine != null)
        {
            StopCoroutine(fillProgressBarCoroutine);
        }


    }

    public bool AreTextsSimilar(string text1, string text2, double threshold = 0.4)
    {
        int maxLength = Math.Max(text1.Length, text2.Length);
        int distance = LevenshteinDistance(text1, text2);
        double similarity = (double)(maxLength - distance) / maxLength;
        return similarity >= threshold;
    }

    public void ReceiveSimilarityResult(string similarityResult)
    {
        // Do something with the similarity result
        message.text  = similarityResult;
        Debug.Log(similarityResult);
        Debug.Log(predefinedText.text);
        
        bool mynewres = AreTextsSimilar(similarityResult, predefinedText.text,  0.1);
        Debug.Log(mynewres);
        
        if (mynewres)
        {
            message.text = "Stotra reached hanuman. Success!";
            threetimesforchanting.fillAmount += 0.33f;
            if (threetimesforchanting.fillAmount >= 0.99f)
            {
                canvasforrec.SetActive(false);
                canvasforapi.SetActive(false);
                player.transform.localScale = new Vector3(80f, 80f, 80f);
            }
        }

        if (!mynewres)
        {
            message.text = "Stotra did not reach hanuman. Try again!";
        }
        
        // if (similarityResult)
        // {
        //     threetimes.fillAmount += 0.33f;
        //     if (threetimes.fillAmount >= 0.99f)
        //     {
        //         canvasforrec.SetActive(false);
        //         player.transform.localScale = new Vector3(80f, 80f, 80f);
        //     }
        // }
    }

    public int LevenshteinDistance(string s, string t)
    {
        int[,] d = new int[s.Length + 1, t.Length + 1];

        for (int i = 0; i <= s.Length; i++)
        {
            d[i, 0] = i;
        }

        for (int j = 0; j <= t.Length; j++)
        {
            d[0, j] = j;
        }

        for (int j = 1; j <= t.Length; j++)
        {
            for (int i = 1; i <= s.Length; i++)
            {
                if (s[i - 1] == t[j - 1])
                {
                    d[i, j] = d[i - 1, j - 1];
                }
                else
                {
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + 1);
                }
            }
        }

        return d[s.Length, t.Length];
    }

//     private void Update()
//     {
//         if (threetimesforchanting.fillAmount >= 0.99f)
//         {
//             player.transform.localScale = new Vector3(80f, 80f, 80f);
//         }
//     }
}


