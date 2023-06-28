using UnityEngine;
using System.Collections;
using System.IO;

public class AudioRecorder : MonoBehaviour {
    private AudioClip recordedClip;

    void Start() {
        // Request permission to use the microphone
        StartCoroutine(RequestMicrophonePermission());
    }

    IEnumerator RequestMicrophonePermission() {
        yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
        if (!Application.HasUserAuthorization(UserAuthorization.Microphone)) {
            Debug.LogError("Microphone access denied!");
            yield break;
        }
        Debug.Log("Microphone access granted!");
    }

    public void RecordButtonClicked() {
        if (Microphone.IsRecording(null)) {
            // Stop recording
            Microphone.End(null);
            SaveRecordedClip();
        } else {
            // Start recording
            recordedClip = Microphone.Start(null, false, 10, 44100);
            Debug.Log("started");
        }
    }

    private void SaveRecordedClip() {
        if (recordedClip == null) {
            Debug.LogError("No audio recorded!");
            return;
        }
        string filename = "recording.wav";
        string filePath = Path.Combine(Application.persistentDataPath, filename);
        SavWav.Save(filePath, recordedClip);
        Debug.Log("Audio clip saved to " + filePath);
    }
}
