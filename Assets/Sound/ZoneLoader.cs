using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneLoader : MonoBehaviour
{
    [SerializeField]
    public List<Collider2D> zones = new();
    [SerializeField]
    public List<string> names = new();
    [SerializeField]
    public List<AudioClip> clips = new();
    void Start()
    {
        Debug.Log(zones[1]);
        foreach (Collider2D zone in zones) {
            Debug.Log(zone); 
            ZoneContainer.addZone(zone);
        }
        foreach (string name in names) {
            ZoneContainer.addName(name);
        }
        foreach (AudioClip clip in clips) {
            ZoneContainer.addClip(clip);
        }
    }
}
