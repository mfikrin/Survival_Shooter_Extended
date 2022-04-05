using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    private ScoreData scoreData;
    public Text textScore;
    public Text timeScore;

    public static Stopwatch stopwatch;
    public static TimeSpan ts;


    void Awake ()
    {
        var scoreJson = PlayerPrefs.GetString("scores","{}");
        scoreData = JsonUtility.FromJson<ScoreData>(scoreJson); 
        score = 0;
        stopwatch = new Stopwatch();
        stopwatch.Start();

      
}
    void Update ()
    {
        if (textScore != null)
        {
            textScore.text = "Score: " + score;
        }
        

        if (stopwatch != null)
        {
            ts = stopwatch.Elapsed;
            string time = ts.ToString().Substring(0, 11);
            if (timeScore != null)
            {
                timeScore.text = time;
                //UnityEngine.Debug.Log(timeScore.text);
            }
            
        }
        
        
    }

    public IEnumerable<ScoreZen> GetZenHighScores()
    {
        return scoreData.ScoreList.OrderByDescending(x => x.time);
    }

    public void AddZenScore(ScoreZen score)
    {
        scoreData.ScoreList.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var scoreJson = JsonUtility.ToJson(scoreData);
        PlayerPrefs.SetString("scores", scoreJson);
    }
}
