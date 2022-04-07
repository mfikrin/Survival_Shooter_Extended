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
    public ScoreManager scoreManager;
    public static int scoreUI;
    public static int timeUI;
    public static TimeSpan TimeSpanZenUI;
  
    private void Start()
    {
        //Time ts = new Time();
        // ... Use days, hours, minutes, seconds, milliseconds.
        TimeSpan ts1 = new TimeSpan(0, 0, 23, 10, 10);
        TimeSpan ts2 = new TimeSpan(0, 0, 0, 12, 11);
        TimeSpan ts3 = new TimeSpan(0, 0, 0, 13, 11);
        TimeSpan ts4 = new TimeSpan(0, 0, 0, 14, 11);
        scoreManager.AddZenScore(new ScoreZen("A", ts1));
        scoreManager.AddZenScore(new ScoreZen("B", ts2));
        scoreManager.AddZenScore(new ScoreZen("C", ts3));
        scoreManager.AddZenScore(new ScoreZen("D", ts4));
        scoreManager.AddZenScore(new ScoreZen("E", ts4));
        Debug.Log("STAT PEMAIN");
        //Debug.Log(ScoreManager.score);
        //Debug.Log(scoreUI);
        Debug.Log(TimeSpanZenUI);

        if (Player.playerName != null && Player.modeGame.Equals("Zen"))
        {
           
           scoreManager.AddZenScore(new ScoreZen(Player.playerName, TimeSpanZenUI));
        }
        //else
        //{
        //    Debug.Log("Player name msh null");
        //}
        
        var scores = scoreManager.GetZenHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            if (i % 2 == 0)
            {
                var row = Instantiate(rowZenUIOdd, transform).GetComponent<RowZenUI>();
                row.Rank.text = (i + 1).ToString();
                row.Name.text = scores[i].name;
                row.Time.text = scores[i].time.ToString().Substring(0,11);
            }
            else
            {
                var row = Instantiate(rowZenUIEven, transform).GetComponent<RowZenUI>();
                row.Rank.text = (i + 1).ToString();
                row.Name.text = scores[i].name;
                row.Time.text = scores[i].time.ToString().Substring(0,11);
            }
            
         
        }
    }

    



    //public void FixedUpdate()
    //{
    //    SceneManager.LoadScene("Menu");
    //}


}
