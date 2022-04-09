using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[SerializeField]
public class ScoreSuddenDeath
{
    public string name;
    public int score;
    public TimeSpan time;

    public ScoreSuddenDeath(string name, int score, TimeSpan time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }
}
