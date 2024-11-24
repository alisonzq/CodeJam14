using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{



    public GameObject menuObj;
    public void MenuOpen() {
        if (menuObj.activeInHierarchy) {
            menuObj.SetActive(false);
            gameObject.transform.eulerAngles += new Vector3(0f,0f,-25f);
            gameObject.transform.position += new Vector3(0f, +100f, 0f);
        } else {
            menuObj.SetActive(true);
            gameObject.transform.eulerAngles += new Vector3(0f, 0f, 25f);
            gameObject.transform.position += new Vector3(0f, -100f, 0f);
        }
    }
}
