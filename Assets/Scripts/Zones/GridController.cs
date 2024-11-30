using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GridController : MonoBehaviour {
    public GameObject normal;
    public GameObject tech;
    public GameObject nature;
    public GameObject hell;

    public void Update() {
        if (Progression.tech) {
            tech.SetActive(true);
            normal.SetActive(false);
        }
        if (Progression.nature) {
            nature.SetActive(true);
            tech.SetActive(false);
        }
        if (Progression.hell) {
            hell.SetActive(true);
            nature.SetActive(false);
        }

    }
}
