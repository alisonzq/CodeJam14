using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDelimiting : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D _character;
    [SerializeField]
    private ZonePlayer _player;
    private Collider2D _collider;

    private void Awake() {
        _collider = GetComponent<Collider2D>(); 
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.rigidbody == _character) {
            _player.playZoneTrack(ZoneContainer.getColliderName(_collider));
        }
    }
}
