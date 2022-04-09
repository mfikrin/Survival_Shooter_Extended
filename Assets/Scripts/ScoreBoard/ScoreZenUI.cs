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
    public ScoreManager scoreManager;
    public static int scoreUI;
    public static int timeUI;
    public static TimeSpan TimeSpanZenUI;
    private ScoreZenData scoreZenData;

    private void Awake()
    {
        var ZenScoreJson = PlayerPrefs.GetString("ZenScores");
        //Account account = JsonConvert.DeserializeObject<Account>(json);
        if (ZenScoreJson == null)
        {
            ZenScoreJson = "{}";
        }
        scoreZenData = JsonConvert.DeserializeObject<ScoreZenData>(ZenScoreJson);
    }
    private void Start()
    {
        if (Player.playerName != null && Player.modeGame.Equals("Zen"))
        {  
            
           scoreManager.AddZenScore(new ScoreZen(Player.playerName, TimeSpanZenUI));
        }
        if (scoreManager.GetScoreZens() != null)
        {
            var scores = scoreManager.GetZenHighScores().ToArray();
            for (int i = 0; i < scores.Length; i++)
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
