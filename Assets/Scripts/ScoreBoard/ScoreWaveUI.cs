using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWaveUI : MonoBehaviour
{
    public RowWaveUI rowWaveUIOdd;
    public RowWaveUI rowWaveUIEven;
    public static int scoreWaveUI;
    public static int waveWaveUI;

    public ScoreWaveManager scoreWaveManager;

    private void Start()
    {
        if (scoreWaveManager.GetScoreWaveData() != null)
        {
            var scores = scoreWaveManager.GetWaveHighScores().ToArray();

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
                    var row = Instantiate(rowWaveUIOdd, transform).GetComponent<RowWaveUI>();
                    row.Rank.text = (i + 1).ToString();

                    string fullName = scores[i].name;
                    string nickName = scores[i].name;
                    if (scores[i].name.Length > 12)
                    {
                        nickName = scores[i].name.Substring(0, 12);
                    }
                    row.Name.text = nickName;
                    row.Wave.text = scores[i].wave.ToString();
                    row.Score.text = scores[i].score.ToString();

                    row.FullName.text = fullName;
                    
                }
                else
                {
                    var row = Instantiate(rowWaveUIEven, transform).GetComponent<RowWaveUI>();
                    row.Rank.text = (i + 1).ToString();


                    string fullName = scores[i].name;
                    string nickName = scores[i].name;
                    if (scores[i].name.Length > 12)
                    {
                        nickName = scores[i].name.Substring(0, 12);
                    }

                    row.Name.text = nickName;
                    row.Wave.text = scores[i].wave.ToString();
                    row.Score.text = scores[i].score.ToString();

                    row.FullName.text = fullName;
                }


            }
        }
        
    }
}
