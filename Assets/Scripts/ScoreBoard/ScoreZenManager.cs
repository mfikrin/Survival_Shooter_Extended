using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreZenManager : MonoBehaviour
{
    private ScoreZenData scoreZenData;
    public static TimeSpan TimeSpanZenUI;

    private void Awake()
    {
        var ZenScoreJson = PlayerPrefs.GetString("ZenScores");

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

        Debug.Log(Player.playerName);
        Debug.Log(Player.modeGame);

        if (Player.playerName != null && Player.modeGame.Equals("Zen"))
        {
            AddZenScore(new ScoreZen(Player.playerName, TimeSpanZenUI));
            Player.playerName = null;
        }
    }

    public ScoreZenData GetScoreZenData()
    {
        return scoreZenData;
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
        var ZenScoreJson = JsonConvert.SerializeObject(scoreZenData);
        UnityEngine.Debug.Log(ZenScoreJson);
        PlayerPrefs.SetString("ZenScores", ZenScoreJson);
    }
}
