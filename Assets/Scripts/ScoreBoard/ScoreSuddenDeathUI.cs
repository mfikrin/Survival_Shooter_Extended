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

        if (Player.playerName != null && Player.modeGame.Equals("SuddenDeath"))
        {

            scoreManager.AddSuddenDeathScore(new ScoreSuddenDeath(Player.playerName, scoreSuddenDeathUI, TimeSpanSuddenDeathUI));
        }

        if (scoreManager.GetScoreSudden() != null)
        {
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
}
