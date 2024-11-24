using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Progression
{
    public static bool tech = false;
    public static bool hell = false;
    public static bool nature = false;

    public static void progressTech() {tech = true; }
    public static void progressHell() { hell = true; }
    public static void progressNature() { nature = true; }
}
