using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreSuddenDeathData
{
    public List<ScoreSuddenDeath> SuddenDeathScoreList;

    public ScoreSuddenDeathData()
    {
        SuddenDeathScoreList = new List<ScoreSuddenDeath>();
    }
}
