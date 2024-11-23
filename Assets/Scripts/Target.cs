using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSheet : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform parent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
            Destroy(collision.gameObject);

        if (collision.gameObject.CompareTag("Arrow") && gameObject.CompareTag("Target"))
        {
            Destroy(gameObject);

            Instantiate(notePrefab, gameObject.transform.position, Quaternion.identity);
            //play note music

        }
    }

}
