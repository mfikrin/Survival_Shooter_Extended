using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ScoreSuddenDeathUI : MonoBehaviour
{
    public RowSuddenDeathUI rowSuddenDeathUIOdd;
    public RowSuddenDeathUI rowSuddenDeathUIEven;
    public ScoreManager scoreManager;
    public static int scoreSuddenDeathUI;
    public static TimeSpan TimeSpanSuddenDeathUI;

    private void Start()
    {
        //Time ts = new Time();
        // ... Use days, hours, minutes, seconds, milliseconds.
        TimeSpan ts1 = new TimeSpan(0, 0, 0, 12, 11);
        TimeSpan ts2 = new TimeSpan(0, 0, 0, 13, 11);
        TimeSpan ts3 = new TimeSpan(0, 0, 0, 14, 11);
        scoreManager.AddSuddenDeathScore(new ScoreSuddenDeath("A", 200, ts1));
        scoreManager.AddSuddenDeathScore(new ScoreSuddenDeath("B", 250, ts2));
        scoreManager.AddSuddenDeathScore(new ScoreSuddenDeath("C",200, ts3));
        scoreManager.AddSuddenDeathScore(new ScoreSuddenDeath("D",400, ts3));
        Debug.Log("STAT PEMAIN");
        //Debug.Log(ScoreManager.score);
        //Debug.Log(scoreUI);
        Debug.Log(TimeSpanSuddenDeathUI);

        if (Player.playerName != null && Player.modeGame.Equals("SuddenDeath"))
        {

            scoreManager.AddSuddenDeathScore(new ScoreSuddenDeath(Player.playerName, scoreSuddenDeathUI, TimeSpanSuddenDeathUI));
        }
        //else
        //{
        //    Debug.Log("Player name msh null");
        //}

        var scores = scoreManager.GetSuddenDeathHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            if (i % 2 == 0)
            {
                var row = Instantiate(rowSuddenDeathUIOdd, transform).GetComponent<RowSuddenDeathUI>();
                row.Rank.text = (i + 1).ToString();
                row.Name.text = scores[i].name;
                row.Score.text = scores[i].score.ToString();
                row.Time.text = scores[i].time.ToString().Substring(0, 11);
            }
            else
            {
                var row = Instantiate(rowSuddenDeathUIEven, transform).GetComponent<RowSuddenDeathUI>();
                row.Rank.text = (i + 1).ToString();
                row.Name.text = scores[i].name;
                row.Score.text = scores[i].score.ToString();
                row.Time.text = scores[i].time.ToString().Substring(0, 11);
            }


        }
    }
}
