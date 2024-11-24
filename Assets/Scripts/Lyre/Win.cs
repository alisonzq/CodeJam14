using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public static bool natureWin;
    void Update()
    {
        // Check if all children are targeted
        if (AreAllChildrenTargeted())
        {
            natureWin = false;
        }
        else
        {
            natureWin = false;
        }
    }

    private bool AreAllChildrenTargeted()
    {
        foreach (Transform child in transform)
        {
            var musicSheetComponent = child.GetComponent<MusicSheet>();

            if (musicSheetComponent == null || !musicSheetComponent.targeted)
            {
                return false;
            }
        }

        return true;
    }

}
