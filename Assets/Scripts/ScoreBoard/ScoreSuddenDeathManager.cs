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

        Debug.Log(SuddenDeathScoreJson);
        if (SuddenDeathScoreJson.Equals(String.Empty))
        {
            Debug.Log("nulll");
            scoreSuddenDeathData = new ScoreSuddenDeathData();
        }
        else
        {
            Debug.Log("not nulll");
            scoreSuddenDeathData = JsonConvert.DeserializeObject<ScoreSuddenDeathData>(SuddenDeathScoreJson);
        }

        Debug.Log(scoreSuddenDeathData);

        Debug.Log(Player.playerName);
        Debug.Log(Player.modeGame);

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
        UnityEngine.Debug.Log(SuddenDeathScoreJson);
        PlayerPrefs.SetString("SuddenDeathScores", SuddenDeathScoreJson);
    }
}
