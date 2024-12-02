using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource player;
    [SerializeField]
    private List<AudioClip> musicClipList = new(5);

    public void Awake() {
        player = GetComponent<AudioSource>();
    }
    public void playNote(int degree) {
        player.clip = musicClipList[degree];
        player.Play();
    }
}
