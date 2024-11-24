using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class Beam : MonoBehaviour
{
    public GameObject beam;
    public Vector2 RayDirection;
    public Vector2 currentPoint;
    public GameObject goalObject;
    public GameObject beamHolder;
    public bool canFire = true;
    private Vector2 goal;
    private LayerMask mirrorMask;
    private LayerMask wallMask;
    public Vector2 MoveDirection;
    private Vector2 currentDirection;
    public List<Vector2> fullbeam;
    public Sprite Light;

    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        mirrorMask = LayerMask.GetMask("Mirror");
        wallMask = LayerMask.GetMask("Layer 1");
        currentPoint = transform.position;
        goal = goalObject.transform.position;
        RayDirection = Vector2.right;
    }

    private void Update()
    {
        if (AnimationSwitcher.currentMode == "Hell" && AnimationSwitcher.collectedInstruments.Contains("Guitar"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }

        }
    }

    public void Fire()
    {
        Debug.Log("Call fire");

        if (canFire)
        {
            Debug.Log("Firing");
            currentPoint = transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentDirection = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
            currentDirection.Normalize();
            canFire = false;
            StartCoroutine(BasisBeamOut());
        }
    }


    public IEnumerator BasisBeamOut()
    {
        while (currentPoint.y > -37 && currentPoint.x > -19 && currentPoint.x < 0)
        {
            RaycastHit2D other = Physics2D.Raycast(currentPoint, currentDirection, 0.11f, wallMask);
            if (other){
                if (other.transform.position == goalObject.transform.position){
                    GameOver();
                }
                break;
            }
            RaycastHit2D hit = Physics2D.Raycast(currentPoint, currentDirection, 0.11f, mirrorMask);
            if (hit)
            {
                Vector2 ihat = new Vector2(hit.normal.x, hit.normal.y);
                Vector2 jhat = new Vector2(ihat.y, -ihat.x);
                float determinant = 1 / (ihat.x * jhat.y - ihat.y * jhat.x);
                Vector2 iinv = determinant * new Vector2(jhat.y, -jhat.x);
                Vector2 jinv = determinant * new Vector2(-ihat.y, ihat.x);
                Vector2 directionAdjusted = new Vector2(-(iinv.x * currentDirection.x + jinv.x * currentDirection.y), iinv.y * currentDirection.x + jinv.y * currentDirection.y);
                currentDirection = new Vector2(ihat.x * directionAdjusted.x + jhat.x * directionAdjusted.y, ihat.y * directionAdjusted.x + jhat.y * directionAdjusted.y);
            }
            currentPoint += currentDirection * Time.deltaTime * 5f;
            Instantiate(beam, currentPoint, Quaternion.identity, beamHolder.transform);
            yield return null;
        }

        yield return new WaitForSeconds(2);
        canFire = true;
        foreach (Transform beamPiece in beamHolder.transform)
        {
            Destroy(beamPiece.gameObject);
        }
    }

    public void GameOver(){
        print("reached goal");
        goalObject.GetComponent<SpriteRenderer>().sprite = Light;
        gameOver = true;
    }
}




