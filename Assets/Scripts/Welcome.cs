using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome : MonoBehaviour
{
    public GameObject welcomeToNature;
    public GameObject welcomeToHell;
    public GameObject welcomeToFuture;

    private bool[] isDone = new bool[3];

    // Start is called before the first frame update
    void Start()
    {
        isDone[0] = false;
        isDone[1] = false;
        isDone[2] = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDone[0] && ZoneDelimiting.zoneName == "Nature")
        {
            isDone[0] = true;
            welcomeToNature.SetActive(true);
            StartCoroutine(StartWelcomeAnim(welcomeToNature));

        }

        if (!isDone[1] && ZoneDelimiting.zoneName == "Hell") {
            isDone[1] = true;
            welcomeToHell.SetActive(true);
            StartCoroutine(StartWelcomeAnim(welcomeToHell));

        }

        if (!isDone[2] && ZoneDelimiting.zoneName == "Tech") {
            isDone[2] = true;
            welcomeToFuture.SetActive(true);
            StartCoroutine(StartWelcomeAnim(welcomeToFuture));
        }
    }

    IEnumerator StartWelcomeAnim(GameObject obj)
    {
        yield return new WaitForSeconds(3);
        Destroy(obj);

    }
}
