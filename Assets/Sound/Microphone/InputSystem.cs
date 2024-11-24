using Lasp;
using System.Collections;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    AudioLevelTracker tracker;
    const int DEFAULTMIC = 3;
    const int RECORDING_LENGTH_SECONDS = 1;

    public AudioClip inputClip;
    public float sensitivity = -100f;
    float[] samplesArray = new float[RECORDING_LENGTH_SECONDS*44100];
    public bool isAdjusting = false;
    public float currentPeak = -100f;
    public AudioClip sensClip;
    public AudioSource test;
    public int maxMicPostion =  RECORDING_LENGTH_SECONDS*44100;

    public GameObject greenBar;
    public GameObject yellowBar;

    public float modifierScale;
    public float modifierPos;
    public float additionPos;


    public void setSensitivity() {
        if (!isAdjusting) {
            sensitivity = -100;
            isAdjusting = true;

            sensClip = Microphone.Start(Microphone.devices[DEFAULTMIC], true, 1, 44100);
            StartCoroutine(SetSensitivity());
           
        }
        else isAdjusting = false;
    }

    /*
    public void testRecording() {
        RecordedData currentRec= FindPeak(inputClip);
        Debug.Log(currentRec.offset);
        test.clip = currentRec.internalClip;
        test.Stop();
        test.timeSamples = currentRec.offset;
        test.Play();
    }
    */

    public void addToRecordings(string name) {
        RecordedData recording = FindPeak(inputClip);
        RecordingContainer.recordings.Add(name, recording);
    }

    public IEnumerator SetSensitivity() {
        while (isAdjusting) {
            currentPeak = tracker.inputLevel;
            if (currentPeak > sensitivity) sensitivity = currentPeak;
            yield return null;
        }
        Microphone.End(Microphone.devices[DEFAULTMIC]);
    }

    public RecordedData FindPeak(AudioClip clip) {
        bool noPeak = true;
        int i = 0;
        int offset = 0;
        float lastVol = -1000;
        clip.GetData(samplesArray, 0);
        while (noPeak) {
            float vol = 20.0f * Mathf.Log10(samplesArray[i]);
            if (vol >= sensitivity) {
                if (lastVol < vol) {
                    offset = i;
                    Debug.Log("off " + offset);
                    lastVol = vol;
                    Debug.Log("sens " + sensitivity + "\n volume at offset " + vol);
                }
            }
            i++;
            if (i >= samplesArray.Length) break;
        }
        return new(clip, offset-128);
    }

    private void Awake() {
        tracker = GetComponent<AudioLevelTracker>();
        sensClip = Microphone.Start(Microphone.devices[DEFAULTMIC], false, 1, 44100);
        for (int i = 0; i < Microphone.devices.Length; i++) {
            Debug.Log("Microphone " + i + ": " + Microphone.devices[i]);
        }

        // inputClip = Microphone.Start(Microphone.devices[DEFAULTMIC], true, RECORDING_LENGTH_SECONDS, 44100);
        // isInit = true;
    }

    IEnumerator RecordingNotif() {
        Debug.Log("recording now");
        inputClip = Microphone.Start(Microphone.devices[DEFAULTMIC], true, RECORDING_LENGTH_SECONDS, 44100);
        yield return new WaitForSeconds(1);
    }

    public void restartRecording() {
        if (Microphone.IsRecording(Microphone.devices[DEFAULTMIC])) {
            Microphone.End(Microphone.devices[DEFAULTMIC]);
            Debug.Log("Recording done");
            return;
        }
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