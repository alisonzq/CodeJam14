using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Progression
{

    public static GameState gameState;
    public static bool tech = false;
    public static bool hell = false;
    public static bool nature = false;

    public static void WinTech() {
        gameState.Win("Tech");
        tech = true; 
    }
    public static void WinNature() {
        gameState.Win("Nature");
        nature = true;
    }
    public static void WinHell() {
        gameState.Win("Hell");
        hell = true;
    }

    public static void OpenTech() {
        gameState.Open("Tech");
    }
    public static void OpenNature() {
        gameState.Open("Nature");
    }
    public static void OpenHell() {
        gameState.Open("Hell");
    }


    public static void EnterTech() {
        gameState.Enter("Tech");
        tech = true;
    }
    public static void EnterNature() {
        gameState.Enter("Nature");
        nature = true;
    }
    public static void EnterHell() {
        gameState.Enter("Hell");
        hell = true;
    }
}
