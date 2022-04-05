using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreWaveData
{
    public List<ScoreWave> WaveScoreList;

    public ScoreWaveData()
    {
        WaveScoreList = new List<ScoreWave>();
    }
}
