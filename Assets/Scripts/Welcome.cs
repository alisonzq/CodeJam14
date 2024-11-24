using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome : MonoBehaviour
{
    public GameObject welcomeToNature;
    public GameObject welcomeToHell;
    public GameObject welcomeToFuture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ZoneDelimiting.zoneName == "Nature")
        {
            welcomeToNature.SetActive(true);
            StartCoroutine(StartWelcomeAnim());
            Destroy(welcomeToNature);

        }

        if (ZoneDelimiting.zoneName == "Hell")
        {
            welcomeToHell.SetActive(true);
            StartCoroutine(StartWelcomeAnim());
            Destroy(welcomeToHell);

        }

        if (ZoneDelimiting.zoneName == "Tech")
        {
            welcomeToFuture.SetActive(true);
            StartCoroutine(StartWelcomeAnim());
            Destroy(welcomeToFuture);
        }
    }

    IEnumerator StartWelcomeAnim()
    {
        yield return new WaitForSeconds(3);

    }
}
