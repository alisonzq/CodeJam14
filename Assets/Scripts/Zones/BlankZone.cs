using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankZone : MonoBehaviour

{

    [SerializeField]
    private MultiSourcePlayer _player;


    public GameObject victory;

    // public static string zoneName;


    public void play() {
        _player.play();
        if (Progression.hell) {
            victory.SetActive(true);
        }
    }

    public void stop() {
        _player.stop();
    }
}

