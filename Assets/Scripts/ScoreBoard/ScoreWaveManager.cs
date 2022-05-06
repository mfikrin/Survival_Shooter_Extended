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
        if (WaveScoreJson.Equals(String.Empty))
        {
            scoreWaveData = new ScoreWaveData();
        }
        else
        {
            scoreWaveData = JsonConvert.DeserializeObject<ScoreWaveData>(WaveScoreJson);
        }

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
        var WaveScoreJson = JsonConvert.SerializeObject(scoreWaveData);
        PlayerPrefs.SetString("WaveScores", WaveScoreJson);
    }
}
