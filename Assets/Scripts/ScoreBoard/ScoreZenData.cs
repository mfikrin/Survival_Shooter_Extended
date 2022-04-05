using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreZenData
{
    public List<ScoreZen> ZenScoreList;

    public ScoreZenData()
    {
        ZenScoreList = new List<ScoreZen>();
    }
}
