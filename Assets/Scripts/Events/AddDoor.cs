using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AddDoor : Subscriber {
    public string levelName;
    public override void Run(GameState g, string level) {
        if (level == levelName) {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
