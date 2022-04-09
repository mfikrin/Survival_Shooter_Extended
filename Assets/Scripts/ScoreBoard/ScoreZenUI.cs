using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreZenUI : MonoBehaviour
{
    public RowZenUI rowZenUIOdd;
    public RowZenUI rowZenUIEven;

    public ScoreZenManager scoreZenManager;

 
    private void Start()
    {
        if (scoreZenManager.GetScoreZenData() != null)
        {
            var scores = scoreZenManager.GetZenHighScores().ToArray();

            Debug.Log(scores.Length);
            int max_display = scores.Length;

            if (scores.Length > 5)
            {
                max_display = 5; // display 5 first rank
            }

            for (int i = 0; i < max_display; i++)
            {
                if (i % 2 == 0)
                {
                    var row = Instantiate(rowZenUIOdd, transform).GetComponent<RowZenUI>();
                    row.Rank.text = (i + 1).ToString();
                    row.Name.text = scores[i].name;
                    row.Time.text = scores[i].time.ToString().Substring(0, 11);
                }
                else
                {
                    var row = Instantiate(rowZenUIEven, transform).GetComponent<RowZenUI>();
                    row.Rank.text = (i + 1).ToString();
                    row.Name.text = scores[i].name;
                    row.Time.text = scores[i].time.ToString().Substring(0, 11);
                }
            }
        }
       
    }

}
