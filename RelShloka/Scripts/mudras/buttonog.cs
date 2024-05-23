using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using AOT;

public class buttonog : MonoBehaviour
{
    public Button yourButton;
    [SerializeField] public Image progressBar;
    [SerializeField] private Text predefinedText;
    [SerializeField] private Text message;
    [SerializeField] public Image threetimes;

    private bool textsAreSimilar = false;
    public GameObject player;

    [DllImport("__Internal")]
    private static extern void StartRecording();

    [DllImport("__Internal")]
    private static extern string StopRecordingAndSendToAPI();

    // {
    //     Debug.Log("API response: " + response);
    //     bool isSimilar = AreTextsSimilar(response, predefinedText.text);
    //     if (isSimilar)
    //     {
    //         threetimes.fillAmount += 0.33f;
    //     }
    // }

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        StartRecording();
        Invoke(nameof(OnStopButtonClicked), 10f); // Call OnStopButtonClicked after 10 seconds
    }

    public void OnStopButtonClicked()
    {
        string res = "checking if this works";
        res = StopRecordingAndSendToAPI();
        Debug.Log(res);
        Debug.Log(predefinedText.text);
        Debug.Log(AreTextsSimilar(res,predefinedText.text));
    }

    public bool AreTextsSimilar(string text1, string text2, double threshold = 0.2)
    {
        int maxLength = Math.Max(text1.Length, text2.Length);
        int distance = LevenshteinDistance(text1, text2);
        double similarity = (double)(maxLength - distance) / maxLength;
        return similarity >= threshold;
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

    private void Update()
    {
        if (threetimes.fillAmount >= 0.99f)
        {
            player.transform.localScale = new Vector3(80f, 80f, 80f);
        }
    }
}
