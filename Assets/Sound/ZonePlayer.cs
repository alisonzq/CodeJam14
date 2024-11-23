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
        _source.PlayOneShot(ZoneContainer.GetClip(zoneName));
    }

}


