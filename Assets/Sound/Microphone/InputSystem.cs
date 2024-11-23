using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    const int DEFAULTMIC = 0;
    const int RECORDING_LENGTH_SECONDS = 10;
    public AudioClip inputClip;
    public float sensitivity = -1;
    float[] samplesArray = new float[RECORDING_LENGTH_SECONDS*44100];
    public bool isAdjusting = false;
    public float currentPeak = -1;
    public AudioClip sensClip;
    public AudioSource test;


    public void setSensitivity() {
        if (!isAdjusting) {
            isAdjusting = true;
            Debug.Log("Recording started");
            sensClip = Microphone.Start(Microphone.devices[DEFAULTMIC], true, 1, 44100);
            StartCoroutine(SetSensitivity());
           
        }
        else isAdjusting = false;
    }

    public void addToRecordings(string name) {
        RecordedData recording = new(inputClip, 0);
        FindPeak(recording);
        RecordingContainer.recordings.Add(name, recording);
    }

    public IEnumerator SetSensitivity() {
        while (isAdjusting) {
            float[] samples = new float[128];
            if (sensClip != null) {
                sensClip.GetData(samples, Microphone.GetPosition(Microphone.devices[DEFAULTMIC]));
                for (int i = 0; i < samples.Length; i++) {
                    currentPeak = samples[i] * samples[i];
                    if (currentPeak > sensitivity) sensitivity = currentPeak;
                }
            }
            yield return null;
        }
        sensitivity = Mathf.Sqrt(Mathf.Sqrt(sensitivity));
        Debug.Log("Recording stopped.");
    }

    public void FindPeak(RecordedData clip) {
        bool noPeak = true;
        int i = 0;
        clip.internalClip.GetData(samplesArray, 0);
        while (noPeak) {
            float vol = Mathf.Sqrt(Mathf.Sqrt(samplesArray[i] * samplesArray[i]));
            if (vol >= sensitivity) {
                Debug.Log("sens " + sensitivity + "\n volume at offset " + vol);
                clip.offset = i;
                Debug.Log("off " + clip.offset);
                noPeak = false;
            }
            i++;
            if (i > 100000) break;
        }
    }

    private void Awake() {
        sensClip = Microphone.Start(Microphone.devices[DEFAULTMIC], false, 1, 44100);
        for (int i = 0; i < Microphone.devices.Length; i++) {
            Debug.Log("Microphone " + i + ": " + Microphone.devices[i]);
        }

        // inputClip = Microphone.Start(Microphone.devices[DEFAULTMIC], true, RECORDING_LENGTH_SECONDS, 44100);
        // isInit = true;
    }

    IEnumerator RecordingNotif() {
        Debug.Log("recording now");
        inputClip = Microphone.Start(Microphone.devices[DEFAULTMIC], false, 10, 44100);
        yield return new WaitForSeconds(10);
        Debug.Log("recording End");
    }

    public void restartRecording() {
        if (Microphone.IsRecording(Microphone.devices[DEFAULTMIC])) Microphone.End(Microphone.devices[DEFAULTMIC]);
        StartCoroutine(RecordingNotif());
    }

    

}
/** <summary> Structure representing recorded data </summary>*/
public struct RecordedData
{
    public RecordedData(AudioClip clip, int offset) {
        //audioClip contained in the struct
        internalClip = clip;
        // offset from the beginning of the clip where a peak was found
        this.offset = offset;
    }
    public AudioClip internalClip;
    public int offset;
}