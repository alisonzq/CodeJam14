using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ZoneContainer
{
    public static List<AudioClip> clipList = new();
    public static List<Collider2D> zones = new();
    public static List<string> names = new();
    public static List<int> offsets = new();

    public static string getColliderName(Collider2D collider) {
        int index = zones.IndexOf(collider);
        if(index < 0) {
            return null;
        }
        return names[index];
    }

    public static string getClipName(AudioClip clip) {
        int index = clipList.IndexOf(clip);
        if(index < 0) {
            return null;
        }
        return names[index];
    }


    public static AudioClip GetClip(string name) {
        int index = names.IndexOf(name);
        return clipList[index];
    }

    public static void SetOffset(string name, int offset) {
        int index = names.IndexOf(name);
        offsets[index] = offset;
    }
    public static int GetOffset(string name) {
        int index = names.IndexOf(name);
        return offsets[index];
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
