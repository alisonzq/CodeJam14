using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public GameObject player;
    public GameObject E;
    private AnimationSwitcher animationSwitcher;
    public static bool collectedInHell;
    public static bool collectedInNature;
    public static bool collectedInTech;

    // Start is called before the first frame update
    void Start()
    {
        animationSwitcher = player.GetComponent<AnimationSwitcher>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 1f)
        {
            E.SetActive(true);
        }
        else
        {
            E.SetActive(false);
        }

        if (E.activeSelf && Input.GetKey(KeyCode.E))
        {
            switch (gameObject.name)
            {
                case "Guitar":
                    collectedInHell = true;
                    break;
                case "Lyre":
                    collectedInNature = true;
                    break;
                case "Launchpad":
                    collectedInTech = true;
                    break;
            }
            animationSwitcher.SwitchToCollected(gameObject.name);
            gameObject.SetActive(false);

        }
    }
}
