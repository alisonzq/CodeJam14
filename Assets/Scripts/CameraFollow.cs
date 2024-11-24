using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 1.0f;

    private Vector3 offset;
    private Vector3 targetPos;

    public Vector2 minBlankBounds;
    public Vector2 maxBlankBounds;

    public Vector2 minNatureBounds; 
    public Vector2 maxNatureBounds;

    public Vector2 minHellBounds;
    public Vector2 maxHellBounds;

    public Vector2 minTechBounds;
    public Vector2 maxTechBounds;

    private Camera cam;
    private void Start()
    {
        if (target == null) return;

        offset = transform.position - target.position;

        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (target == null) return;


        Vector3 clampedTargetPos = target.position;


        if (ZoneDelimiting.zoneName == "Nature")
        {
            cam.orthographicSize = 5;
            clampedTargetPos.x = Mathf.Clamp(clampedTargetPos.x, minNatureBounds.x, maxNatureBounds.x);

            if (target.position.y >= 8.3)
            {
                clampedTargetPos.y = Mathf.Clamp(clampedTargetPos.y, maxNatureBounds.y, maxNatureBounds.y);
            }
            else
            {
                clampedTargetPos.y = Mathf.Clamp(clampedTargetPos.y, minNatureBounds.y, maxNatureBounds.y);
            }
        }

        if (ZoneDelimiting.zoneName == "Blank")
        {
            cam.orthographicSize = 5;
            clampedTargetPos.x = Mathf.Clamp(clampedTargetPos.x, minBlankBounds.x, maxBlankBounds.x);
            clampedTargetPos.y = Mathf.Clamp(clampedTargetPos.y, minBlankBounds.y, maxBlankBounds.y);
        }

        if (ZoneDelimiting.zoneName == "Hell")
        {
            cam.orthographicSize = 6.9f;
            clampedTargetPos.x = Mathf.Clamp(clampedTargetPos.x, minHellBounds.x, maxHellBounds.x);
            clampedTargetPos.y = Mathf.Clamp(clampedTargetPos.y, minHellBounds.y, maxHellBounds.y);
        }

        if (ZoneDelimiting.zoneName == "Tech")
        {
            cam.orthographicSize = 3.16f;
            clampedTargetPos.x = Mathf.Clamp(clampedTargetPos.x, minTechBounds.x, maxTechBounds.x);
            clampedTargetPos.y = Mathf.Clamp(clampedTargetPos.y, minTechBounds.y, maxTechBounds.y);
        }

        targetPos = clampedTargetPos + offset;
        targetPos.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }
}
