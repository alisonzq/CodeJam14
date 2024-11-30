using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField]
    Subscriber[] winners;
    [SerializeField]
    Subscriber[] starters;

    public void Awake() {
        Progression.gameState = this;  
    }
    public void Win(string level) {
        foreach (Subscriber sub in winners){
            sub.Run(this, level);
        }
    }

    public void Open(string level) {
        foreach (Subscriber sub in winners) {
            sub.Run(this, level);
        }
    }

    public void Enter(string level) {
        foreach (Subscriber sub in starters) {
            sub.Run(this, level);
        }
    }
}
