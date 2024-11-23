using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePlayer : MonoBehaviour
{
    AudioSource _source;

    private void Awake() {
        _source = GetComponent<AudioSource>();
    }

    public void playZoneTrack(string zoneName) {
        Debug.Log(zoneName);
        _source.Stop();
        _source.clip = ZoneContainer.GetClip(zoneName);
       _source.Play();
    }

}


