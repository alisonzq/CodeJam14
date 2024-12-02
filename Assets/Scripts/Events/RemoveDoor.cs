using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDoor : Subscriber
{
    public string levelName;
    public override void Run(GameState g, string level) {
        if (level == levelName) {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
