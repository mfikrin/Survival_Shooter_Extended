using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Newtonsoft.Json;

public class ScoreSuddenDeathUI : MonoBehaviour
{
    public RowSuddenDeathUI rowSuddenDeathUIOdd;
    public RowSuddenDeathUI rowSuddenDeathUIEven;
 
    public ScoreSuddenDeathManager scoreSuddenDeathManager;

    private void Start()
    {
        if (scoreSuddenDeathManager.GetScoreSuddenDeathData() != null)
        {
            var scores = scoreSuddenDeathManager.GetSuddenDeathHighScores().ToArray();

            int max_display = scores.Length;

            if (scores.Length > 5)
            {
                max_display = 5; // display 5 first rank
            }

            for (int i = 0; i < max_display; i++)
            {
                if (i % 2 == 0)
                {
                    var row = Instantiate(rowSuddenDeathUIOdd, transform).GetComponent<RowSuddenDeathUI>();
                    row.Rank.text = (i + 1).ToString();

                    string fullName = scores[i].name;
                    string nickName = scores[i].name;
                    if (scores[i].name.Length > 12)
                    {
                        nickName = scores[i].name.Substring(0, 12);
                    }
                    row.Name.text = nickName;

                    row.Score.text = scores[i].score.ToString();
                    row.Time.text = scores[i].time.ToString().Substring(0, 11);

                    row.FullName.text = fullName;

                }
                else
                {
                    var row = Instantiate(rowSuddenDeathUIEven, transform).GetComponent<RowSuddenDeathUI>();
                    row.Rank.text = (i + 1).ToString();

                    string fullName = scores[i].name;
                    string nickName = scores[i].name;
                    if (scores[i].name.Length > 12)
                    {
                        nickName = scores[i].name.Substring(0, 12);
                    }
                    row.Name.text = nickName;

                    row.Score.text = scores[i].score.ToString();
                    row.Time.text = scores[i].time.ToString().Substring(0, 11);

                    row.FullName.text = fullName;

                }
            }
        }
    }

}
