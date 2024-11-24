using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankZone : MonoBehaviour

{

    [SerializeField]
    private Collider2D _character;
    [SerializeField]
    private ZonePlayer _player;
    private Collider2D _collider;
    private bool started = false;

    public static string zoneName;

    private void Awake() {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (!started && collider == _character) {
            started = true;
            zoneName = ZoneContainer.getColliderName(_collider);
            _player.playZoneTrack(ZoneContainer.getColliderName(_collider));
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision == _character) {
            started = true;
        }
    }
}

