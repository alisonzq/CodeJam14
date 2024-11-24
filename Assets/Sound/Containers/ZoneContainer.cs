using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ZoneContainer
{
    public static List<AudioClip> clipList = new();
    public static List<Collider2D> zones = new();
    public static List<string> names = new();

    public static string getColliderName(Collider2D collider) {
        int index = zones.IndexOf(collider);
        return names[index];
    }

    public static AudioClip GetClip(string name) {
        int index = names.IndexOf(name);
        return clipList[index];
    }

    public static void addZone(Collider2D collider) {
        zones.Add(collider);
    }
    public static void addName(string name) {
        names.Add(name);
    }

    public static void addClip(AudioClip clip) {
        clipList.Add(clip);
    }

}
