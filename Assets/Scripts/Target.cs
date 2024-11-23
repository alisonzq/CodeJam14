using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSheet : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform parent;
    public MusicPlayer musicPlayer;
    public int degree;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
            Destroy(collision.gameObject);

        if (collision.gameObject.CompareTag("Arrow") && gameObject.CompareTag("Target"))
        {
            Transform transform = gameObject.transform;
            Destroy(gameObject);

            Instantiate(notePrefab, transform.position, Quaternion.identity, parent);

            musicPlayer.playNote(degree);

        }
    }

}
