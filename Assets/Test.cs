using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool tech;
    public bool nature;
    public bool hell;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Progression.tech = tech;
        Progression.nature = nature;  
        Progression.hell = hell;
        

    }
}
