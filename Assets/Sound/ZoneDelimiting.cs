using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDelimiting : MonoBehaviour
{

    [SerializeField]
    private Collider2D _character;
    [SerializeField]
    private ZonePlayer _player;
    private Collider2D _collider;

    private void Awake() {
        _collider = GetComponent<Collider2D>(); 
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider == _character) {
            _player.playZoneTrack(ZoneContainer.getColliderName(_collider));
        }
    }
}
