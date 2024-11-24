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

    public static string zoneName;

    private void Awake() {
        _collider = GetComponent<Collider2D>(); 
        _collider.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if(collider == _character) {
            zoneName = ZoneContainer.getColliderName(_collider);
            _player.playZoneTrack(ZoneContainer.getColliderName(_collider));
        }
    }
}
