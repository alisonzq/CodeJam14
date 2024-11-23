using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationSwitcher : MonoBehaviour
{
    public RuntimeAnimatorController[] controllers;
    public GameObject[] instruments;

    private Animator currentAnimator;

    private HashSet<string> collectedInstruments = new HashSet<string>();

    private void Start()
    {
        currentAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Anim BLANK");
            SwitchAnimator(0);
        }
        if (Input.GetKey(KeyCode.Alpha2) && collectedInstruments.Contains("Launchpad"))
        {
            Debug.Log("Anim Tech");
            SwitchAnimator(1);
        } 
        if (Input.GetKey(KeyCode.Alpha3) && collectedInstruments.Contains("Lyre"))
        {
            Debug.Log("Anim Nature");
            SwitchAnimator(2);
        }
        if (Input.GetKey(KeyCode.Alpha4) && collectedInstruments.Contains("Guitar"))
        {
            Debug.Log("Anim Hell");
            SwitchAnimator(3);
        } 
    }

    private void SwitchAnimator(int index)
    {
        if (index >= 0 && index < controllers.Length)
        {
            currentAnimator.runtimeAnimatorController = controllers[index];
        }
    }

    public void SwitchToCollected(string name)
    {
        for (int i = 0; i < controllers.Length; i++)
        {
            GameObject instrument = instruments[i];
            if (name == instrument.name)
            {
                Debug.Log($"Collision with {instrument.name} detected!");
                collectedInstruments.Add(instrument.name);
                SwitchAnimator(i+1);
                instrument.SetActive(false);
                break;
            }
        }

    }

}
