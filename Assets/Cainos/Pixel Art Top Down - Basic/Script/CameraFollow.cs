using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 1.0f;

    private Vector3 offset;
    private Vector3 targetPos;

    public bool useBounds = false; 
    public Vector2 minBounds; 
    public Vector2 maxBounds; 

    private void Start()
    {
        if (target == null) return;

        offset = transform.position - target.position;
    }

    private void Update()
    {
        if (target == null) return;

        targetPos = target.position + offset;

        if (useBounds)
        {
            targetPos.x = Mathf.Clamp(targetPos.x, minBounds.x, maxBounds.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minBounds.y, maxBounds.y);
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }
}
