using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreWaveManager : MonoBehaviour
{
    private ScoreWaveData scoreWaveData;

    private void Awake()
    {
        var WaveScoreJson = PlayerPrefs.GetString("WaveScores");
        //Debug.Log(ZenScoreJson.Equals(String.Empty));
        Debug.Log(WaveScoreJson);
        if (WaveScoreJson.Equals(String.Empty))
        {
            Debug.Log("nulll");
            scoreWaveData = new ScoreWaveData();
        }
        else
        {
            Debug.Log("not nulll");
            scoreWaveData = JsonConvert.DeserializeObject<ScoreWaveData>(WaveScoreJson);
        }

        Debug.Log(scoreWaveData);

        Debug.Log(Player.playerName);
        Debug.Log(Player.modeGame);

        if (Player.playerName != null && Player.modeGame.Equals("Wave"))
        {
            
            AddWaveScore(new ScoreWave(name: Player.playerName, wave: ScoreManager.wave, score: ScoreManager.score));
            Player.playerName = null;
        }
    }

    public ScoreWaveData GetScoreWaveData()
    {
        return scoreWaveData;
    }
    public IEnumerable<ScoreWave> GetWaveHighScores()
    {
        return scoreWaveData.WaveScoreList.OrderByDescending(x => x.wave).ThenByDescending(x => x.score);
    }

    private void OnDestroy()
    {
        SaveScoreWave();
    }

    public void AddWaveScore(ScoreWave score)
    {
        scoreWaveData.WaveScoreList.Add(score);
    }

    public void SaveScoreWave()
    {
        //var ZenScoreJson = JsonUtility.ToJson(scoreZenData);
        //var ZenScoreJson = JsonConvert.SerializeObject(scoreZenData);
        //UnityEngine.Debug.Log(ZenScoreJson);
        //PlayerPrefs.SetString("ZenScores", ZenScoreJson);

        var WaveScoreJson = JsonConvert.SerializeObject(scoreWaveData);
        UnityEngine.Debug.Log(WaveScoreJson);

        PlayerPrefs.SetString("WaveScores", WaveScoreJson);

        //var SuddenDeathScoreJson = JsonConvert.SerializeObject(scoreSuddenDeathData);
        //UnityEngine.Debug.Log(SuddenDeathScoreJson);

        //PlayerPrefs.SetString("SuddenDeathScores", SuddenDeathScoreJson);
    }
}
