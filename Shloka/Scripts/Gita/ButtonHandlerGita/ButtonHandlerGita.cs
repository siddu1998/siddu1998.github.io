using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using AOT;
using TMPro;

public class ButtonHandlerGita : MonoBehaviour
{
    public Button yourButtonGita;
    [SerializeField] public Image progressBar;
    [SerializeField] public Text predefinedText;
    [SerializeField] public TextMeshProUGUI messages;
    [SerializeField] public Image threetimesforchanting;
    [SerializeField] public Image totaltimesforchanting;
    [SerializeField] private GameObject canvasforapires;

    [SerializeField] private GameObject canvasforrec;

    private bool textsAreSimilar = false;
    public GameObject player;

    [DllImport("__Internal")]
    private static extern void StartRecording();

    [DllImport("__Internal")]
    private static extern string StopRecordingAndSendToAPI();

    private Coroutine fillProgressBarCoroutine;

    void Start()
    {
        messages.text = "";
        totaltimesforchanting.fillAmount = 0.33f; // Set initial fill amount to 0
        Button btn = yourButtonGita.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    IEnumerator FillProgressBar(float duration)
    {
        float timer = 0f;
        float fillStartValue = 0f; // Start the fill from 0
        float fillEndValue = 1f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Lerp(fillStartValue, fillEndValue, timer / duration);
            progressBar.fillAmount = progress;
            yield return null;
        }

        // Reset the fill amount to 0 when the progress bar becomes full
        progressBar.fillAmount = 0f;

        // Perform any actions after the progress bar is reset
        // For example, you can call a function or show/hide objects
        OnProgressBarFull();
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        StartRecording();
        fillProgressBarCoroutine = StartCoroutine(FillProgressBar(20f));
        Invoke(nameof(OnStopButtonClicked), 20f); // Call OnStopButtonClicked after 20 seconds
    }

    public void OnStopButtonClicked()
    {
        string res = "checking if this works";
        res = StopRecordingAndSendToAPI();
        Debug.Log(res);
        Debug.Log(predefinedText.text);
    }

    public bool AreTextsSimilar(string text1, string text2, double threshold = 0.2)
    {
        int maxLength = Math.Max(text1.Length, text2.Length);
        int distance = LevenshteinDistance(text1, text2);
        double similarity = (double)(maxLength - distance) / maxLength;
        return similarity >= threshold;
    }

    public void ReceiveSimilarityResult(string similarityResult)
    {
        // Do something with the similarity result
        Debug.Log(similarityResult);
        Debug.Log(predefinedText.text);

        bool mynewres = AreTextsSimilar(similarityResult, predefinedText.text, 0.6);
        Debug.Log(mynewres);

        if (mynewres)
        {
            messages.text = "The Vedas have been read. Put out the fires now!";
            threetimesforchanting.fillAmount += 0.33f; // Increment total fill amount
            if (threetimesforchanting.fillAmount >= 0.33f)
            {
                canvasforrec.SetActive(false);
                canvasforapires.SetActive(false);
            }
        }

        if (!mynewres)
        {
            messages.text = "Try reading from the Gita again!";
        }
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

    public void OnProgressBarFull()
    {
        // Reset any necessary variables or perform additional actions
        Debug.Log("Progress bar is full. Resetting...");
    }
}
