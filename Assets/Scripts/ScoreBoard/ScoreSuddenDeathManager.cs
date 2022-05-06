using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreSuddenDeathManager : MonoBehaviour
{
    private ScoreSuddenDeathData scoreSuddenDeathData;
    public static TimeSpan TimeSpanSuddenDeathUI;

    private void Awake()
    {
        var SuddenDeathScoreJson = PlayerPrefs.GetString("SuddenDeathScores");

        if (SuddenDeathScoreJson.Equals(String.Empty))
        {
            scoreSuddenDeathData = new ScoreSuddenDeathData();
        }
        else
        {
            scoreSuddenDeathData = JsonConvert.DeserializeObject<ScoreSuddenDeathData>(SuddenDeathScoreJson);
        }

        if (Player.playerName != null && Player.modeGame.Equals("SuddenDeath"))
        {

            AddSuddenDeathScore(new ScoreSuddenDeath(Player.playerName, ScoreManager.score, TimeSpanSuddenDeathUI));
            Player.playerName = null;
        }
    }

    public ScoreSuddenDeathData GetScoreSuddenDeathData()
    {
        return scoreSuddenDeathData;
    }
    public IEnumerable<ScoreSuddenDeath> GetSuddenDeathHighScores()
    {
        return scoreSuddenDeathData.SuddenDeathScoreList.OrderByDescending(x => x.score).ThenByDescending(x => x.time);
    }

    public void AddSuddenDeathScore(ScoreSuddenDeath score)
    {
        scoreSuddenDeathData.SuddenDeathScoreList.Add(score);
    }

    private void OnDestroy()
    {
        SaveScoreSuddenDeath();
    }

    public void SaveScoreSuddenDeath()
    {
        var SuddenDeathScoreJson = JsonConvert.SerializeObject(scoreSuddenDeathData);
        PlayerPrefs.SetString("SuddenDeathScores", SuddenDeathScoreJson);
    }
}
