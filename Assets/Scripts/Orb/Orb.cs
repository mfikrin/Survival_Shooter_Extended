using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public static TimeSpan maxOrbLife = new TimeSpan(0,0,5);
    public static Stopwatch stopwatchOrb;
    void Start()
    {
        stopwatchOrb = new Stopwatch();
        stopwatchOrb.Start();
    }
}
