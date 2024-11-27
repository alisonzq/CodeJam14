using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceWithOffset : MonoBehaviour
{
    private AudioSource _source;
    public AudioSourceWithOffset(AudioSource source) {
        _source = source;
    }

    public void Play(RecordedData clip) {
        Debug.Log(clip.offset);
        _source.clip = clip.internalClip;
        _source.Stop();
        _source.timeSamples = clip.offset;
        _source.Play();
    }

}
