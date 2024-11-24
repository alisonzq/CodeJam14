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
    private bool started = false;

    private bool legit = true;

    private int i = 0;

    public static string zoneName;

    private void Awake() {
        _collider = GetComponent<Collider2D>(); 
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(legit && !started && collider == _character) {
            Debug.Log("baa");
            StartCoroutine(Timer(collider));
            started = true;
            i++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(legit && started && collision == _character) {
            Debug.Log("bee");
            StartCoroutine(Timer(collision));
            started = false;
            i++;
        }
    }




    private IEnumerator Timer(Collider2D collider) {
        yield return new WaitForSeconds(0.1f);
        if (i > 1) {
            legit = false;
            yield return Timer2();
        } else {
            i = 0;
            if (legit && started && collider == _character) {
                zoneName = ZoneContainer.getColliderName(_collider);
                _player.playZoneTrack(ZoneContainer.getColliderName(_collider));
            }
        }
    }

    private IEnumerator Timer2() {
        yield return new WaitForSeconds(3f);
        legit = true;
        i = 0;
    }
}
