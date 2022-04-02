using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreData
{
    public List<Score> ScoreList;

    public ScoreData()
    {
        ScoreList = new List<Score>();
    }

    
}
