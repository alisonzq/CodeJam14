using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TopDownCharacterController : MonoBehaviour
{
    public float speed;

    private bool walkingSound;

    public AudioSource source;
    public AudioClip[] clip;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;

        if (!walkingSound && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))) {
            walkingSound = true;
            StartCoroutine(WalkingSound());
        }

        if (walkingSound && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))) {
            walkingSound = false;
        }
    }


    private IEnumerator WalkingSound() {
        int x;
        while (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)) {
            x = Random.Range(0, 4);
            int pitch = Random.Range(9,12);
            float pitch2 = (float)(pitch) / 10f;
            source.pitch = pitch2;


            int volume = Random.Range(8, 10);
            float volume2 = (float)(volume) / 1000f;

            source.volume = volume2;

            source.PlayOneShot(clip[x]);

            int wait = Random.Range(40, 50);
            float wait2 = (float)(wait) / 100f;


            yield return new WaitForSeconds(wait2);
        }
    }
}

