using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class ScoreZen
{

    public string name;
    public TimeSpan time;

    public ScoreZen(string name, TimeSpan time)
    {
        this.name = name;
        this.time = time;
    }
}
