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
    //public ScoreManager scoreManager;
    public static int scoreUI;
    public static int timeUI;
    public static TimeSpan TimeSpanZenUI;
    private ScoreZenData scoreZenData;

    //private void Awake()
    //{
    //    var ZenScoreJson = PlayerPrefs.GetString("ZenScores");
    //    //Account account = JsonConvert.DeserializeObject<Account>(json);
    //    if (ZenScoreJson == null)
    //    {
    //        scoreZenData = new ScoreZenData();
    //    }
    //    else
    //    {
    //        scoreZenData = JsonConvert.DeserializeObject<ScoreZenData>(ZenScoreJson);
    //    }
        
    //}
    private void Start()
    {
        var ZenScoreJson = PlayerPrefs.GetString("ZenScores");
        //Account account = JsonConvert.DeserializeObject<Account>(json);
        //Debug.Log(ZenScoreJson.Equals(String.Empty));
        Debug.Log(ZenScoreJson);
        if (ZenScoreJson.Equals(String.Empty))
        {
            Debug.Log("nulll");
            scoreZenData = new ScoreZenData();
        }
        else
        {
            Debug.Log("not nulll");
            scoreZenData = JsonConvert.DeserializeObject<ScoreZenData>(ZenScoreJson);
        }

        Debug.Log(scoreZenData);

        if (Player.playerName != null && Player.modeGame.Equals("Zen"))
        {         
            AddZenScore(new ScoreZen(Player.playerName, TimeSpanZenUI));
            Player.playerName = null;
        }
        if (scoreZenData != null)
        {
            var scores = GetZenHighScores().ToArray();
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

    public IEnumerable<ScoreZen> GetZenHighScores()
    {
        return scoreZenData.ZenScoreList.OrderByDescending(x => x.time);
    }

    private void OnDestroy()
    {
        SaveScoreZen();
    }

    public void AddZenScore(ScoreZen score)
    {
        scoreZenData.ZenScoreList.Add(score);
    }

    public void SaveScoreZen()
    {
        //var ZenScoreJson = JsonUtility.ToJson(scoreZenData);
        var ZenScoreJson = JsonConvert.SerializeObject(scoreZenData);
        UnityEngine.Debug.Log(ZenScoreJson);
        PlayerPrefs.SetString("ZenScores", ZenScoreJson);

        //var WaveScoreJson = JsonConvert.SerializeObject(scoreWaveData);
        //UnityEngine.Debug.Log(WaveScoreJson);

        //PlayerPrefs.SetString("WaveScores", WaveScoreJson);

        //var SuddenDeathScoreJson = JsonConvert.SerializeObject(scoreSuddenDeathData);
        //UnityEngine.Debug.Log(SuddenDeathScoreJson);

        //PlayerPrefs.SetString("SuddenDeathScores", SuddenDeathScoreJson);
    }

}
