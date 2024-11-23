using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    public RuntimeAnimatorController[] controllers;
    public GameObject[] instruments;

    private Animator currentAnimator;
    private AnimatorOverrideController overrideController;

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
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("Anim Tech");
            SwitchAnimator(1);
        } 
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("Anim Nature");
            SwitchAnimator(2);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            Debug.Log("Anim Hell");
            SwitchAnimator(3);
        } 
    }

    public Animator GetAnimator()
    {
        return currentAnimator;
    }

    private void SwitchAnimator(int index)
    {
        if (index >= 0 && index < controllers.Length)
        {
            currentAnimator.runtimeAnimatorController = controllers[index];
            Debug.Log($"Switched to Animator {index + 1}");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        for (int i = 0; i < controllers.Length; i++)
        {
            GameObject instrument = instruments[i];
            if (collision.gameObject.name == instrument.name)
            {
                Debug.Log($"Collision with {instrument.name} detected!");
                SwitchAnimator(i);
                break;
            }
        }

    }
}
