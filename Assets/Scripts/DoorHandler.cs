using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public GameObject doorNature;
    public GameObject doorHell;
    public GameObject doorTech;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Collect.collectedInHell)
        {
            doorHell.SetActive(true);
            Collect.collectedInHell = false;
        }
        else if (Collect.collectedInNature)
        {
            doorNature.SetActive(true);
            Collect.collectedInNature = false;
        }
        else if (Collect.collectedInTech)
        {
            doorTech.SetActive(true);
            Collect.collectedInTech = false;
        }

        if (WinNature.natureWin)
        {
            doorNature.SetActive(false);
        }
        if (Beam.gameOver)
        {
            doorHell.SetActive(false);
        }
        if (LaunchpadGame.win)
        {
            doorTech.SetActive(false);
        }
    }
}
