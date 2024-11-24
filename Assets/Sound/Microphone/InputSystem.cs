using Lasp;
using System.Collections;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    AudioLevelTracker tracker;
    const int DEFAULTMIC = 3;
    const int RECORDING_LENGTH_SECONDS = 1;

    public AudioClip inputClipLaunch;
    public AudioClip inputClipLyre;
    public AudioClip inputClipBonetar;

    public float sensitivity = -100f;
    float[] samplesArray = new float[RECORDING_LENGTH_SECONDS*44100];
    public bool isAdjusting = false;
    public float currentPeak = -100f;
    public AudioClip sensClip;
    public AudioSource test;
    public int maxMicPostion =  RECORDING_LENGTH_SECONDS*44100;

    public GameObject greenBar;
    public GameObject setBarTotal;
    public GameObject yellowBar;
    public GameObject orangeBarObjLaunch;
    public GameObject orangeBarObjLyre;
    public GameObject orangeBarObjBonetar;
    public GameObject orangeBarLaunch;
    public GameObject orangeBarLyre;
    public GameObject orangeBarBonetar;
    public GameObject micPointer;

    public float modifierScaleOrange;
    public float modifierScale;
    public float modifierPos;
    public float additionPos;


    public void setSensitivity() {
        if (!isAdjusting) {
            setBarTotal.SetActive(true);
            sensitivity = -100;
            isAdjusting = true;

            sensClip = Microphone.Start(Microphone.devices[DEFAULTMIC], true, 1, 44100);
            StartCoroutine(SetSensitivity());

        } else {
            isAdjusting = false;
            setBarTotal.SetActive(false);
        }
    }

    public void testRecordingLauch() {
        RecordedData currentRec= FindPeak(inputClipLaunch);
        testRecording(currentRec);
    }

    public void testRecordingLyre() {
        RecordedData currentRec = FindPeak(inputClipLyre);
        testRecording(currentRec);
    }

    public void testRecordingBonetar() {
        RecordedData currentRec = FindPeak(inputClipBonetar);
        testRecording(currentRec);
    }

    public void testRecording(RecordedData currentRec) {
        if (currentRec.internalClip == null) {
            return;
        }
        Debug.Log(currentRec.offset);
        test.clip = currentRec.internalClip;
        test.Stop();
        test.timeSamples = currentRec.offset;
        test.Play();
    }

    public void addToRecordings(string name, AudioClip inputClip) {
        Debug.Log(inputClip);
        RecordedData recording = FindPeak(inputClip);
        if (RecordingContainer.recordings.ContainsKey(name)) {
            RecordingContainer.recordings[name] = recording;
        } else {
            RecordingContainer.recordings.Add(name, recording);
        }
    }

    public IEnumerator SetSensitivity() {
        while (isAdjusting) {
            currentPeak = tracker.inputLevel;
            currentPeak = (currentPeak + 50) / (50) * (100) - 100;
            greenBar.transform.localScale = new Vector2(1 + (currentPeak * modifierScale)  , greenBar.transform.localScale.y);
            if (currentPeak > sensitivity) {
                sensitivity = currentPeak;
                yellowBar.transform.localPosition = new Vector3((1 + (currentPeak * modifierScale)) * modifierPos +additionPos ,yellowBar.transform.localPosition.y, yellowBar.transform.localPosition.z);
            }
            yield return null;
        }
        Microphone.End(Microphone.devices[DEFAULTMIC]);
    }

    public RecordedData FindPeak(AudioClip clip) {
        if (clip == null) {
            return new RecordedData(null, 0);
        }
        bool noPeak = true;
        int i = 0;
        bool chosen = false;
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
                    chosen = true;
                }
            }
            i++;

            if (i >= samplesArray.Length) {
                break;
            };
        }
        if (!chosen) {
            return new RecordedData(null, 0);
        }
        if (offset >= 128) { offset -= 128; }
        return new(clip, offset);
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

    IEnumerator RecordingNotifLaunch() {
        Debug.Log("recording now");
        inputClipLaunch = Microphone.Start(Microphone.devices[DEFAULTMIC], true, RECORDING_LENGTH_SECONDS, 44100);
        yield return new WaitForSeconds(1);
        addToRecordings("Launch", inputClipLaunch);
    }

    IEnumerator RecordingNotifLyre() {
        Debug.Log("recording now");
        inputClipLyre = Microphone.Start(Microphone.devices[DEFAULTMIC], true, RECORDING_LENGTH_SECONDS, 44100);
        yield return new WaitForSeconds(1);
        addToRecordings("Lyre", inputClipLyre);
    }

    IEnumerator RecordingNotifBonetar() {
        Debug.Log("recording now");
        inputClipBonetar = Microphone.Start(Microphone.devices[DEFAULTMIC], true, RECORDING_LENGTH_SECONDS, 44100);
        yield return new WaitForSeconds(1);
        addToRecordings("Bonetar", inputClipBonetar);
    }


    public void Update() {
        if (Microphone.IsRecording(Microphone.devices[DEFAULTMIC])) {
            orangeBarLaunch.transform.localScale = new Vector2(modifierScaleOrange * Microphone.GetPosition(Microphone.devices[DEFAULTMIC]) ,orangeBarLaunch.transform.localScale.y);
            orangeBarLyre.transform.localScale = new Vector2(modifierScaleOrange * Microphone.GetPosition(Microphone.devices[DEFAULTMIC]), orangeBarLyre.transform.localScale.y);
            orangeBarBonetar.transform.localScale = new Vector2(modifierScaleOrange * Microphone.GetPosition(Microphone.devices[DEFAULTMIC]), orangeBarBonetar.transform.localScale.y);
        }
    }

    public void restartRecordingLaunch() {
        if (Microphone.IsRecording(Microphone.devices[DEFAULTMIC])) {
            Microphone.End(Microphone.devices[DEFAULTMIC]);
            Debug.Log("Recording done");
            orangeBarObjLaunch.SetActive(false);
            return;
        }
        StartCoroutine(RecordingNotifLaunch());
        orangeBarObjLaunch.SetActive(true);
    }

    public void restartRecordingLyre() {
        if (Microphone.IsRecording(Microphone.devices[DEFAULTMIC])) {
            Microphone.End(Microphone.devices[DEFAULTMIC]);
            Debug.Log("Recording done");
            orangeBarObjLyre.SetActive(false);
            return;
        }
        StartCoroutine(RecordingNotifLyre());
        orangeBarObjLyre.SetActive(true);
    }

    public void restartRecordingBonetar() {
        if (Microphone.IsRecording(Microphone.devices[DEFAULTMIC])) {
            Microphone.End(Microphone.devices[DEFAULTMIC]);
            Debug.Log("Recording done");
            orangeBarObjBonetar.SetActive(false);
            return;
        }
        StartCoroutine(RecordingNotifBonetar());
        orangeBarObjBonetar.SetActive(true);
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