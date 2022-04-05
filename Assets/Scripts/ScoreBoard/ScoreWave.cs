using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class ScoreWave
{
    public string name;
    public int wave;
    public int score;

    public ScoreWave(string name, int wave, int score)
    {
        this.name = name;
        this.wave = wave;
        this.score = score;
    }
}
