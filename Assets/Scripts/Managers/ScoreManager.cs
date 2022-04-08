using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static Stopwatch stopwatch;
    public static TimeSpan ts;

    public static bool isUpgradeZen = false ; 

    // wave
    public static int wave;

    
    private ScoreZenData scoreZenData;
    private ScoreWaveData scoreWaveData;


     public GameObject panelUpgradeWeapon;

    public Text textScore;
    public Text textTime;
    public Text textWave;


    void Awake()
    {
        var ZenScoreJson = PlayerPrefs.GetString("ZenScores", "{}");
        scoreZenData = JsonUtility.FromJson<ScoreZenData>(ZenScoreJson);

        var WaveScoreJson = PlayerPrefs.GetString("WaveScores", "{}");
        scoreWaveData = JsonUtility.FromJson<ScoreWaveData>(WaveScoreJson);
        score = 0;
        wave = 1;
        stopwatch = new Stopwatch();
        stopwatch.Start();


    }
    void Update()
    {
        string scene = SceneManager.GetActiveScene().name;

        if (scene.Equals("ZenMode") || scene.Equals("WaveMode"))
        {
            if (Player.modeGame.Equals("Zen"))
            {
                UnityEngine.Debug.Log("MASUK KE ZEN");
                if (stopwatch != null)
                {
                    ts = stopwatch.Elapsed;
                    string time = ts.ToString().Substring(0, 11);
                    if (textTime != null)
                    {
                        textTime.text = time;
                    }
                    if( ts.Seconds % 30 == 0)
                    {
                       
                        isUpgradeZen = true;
                        panelUpgradeWeapon.SetActive(true);
                    }
                }

            }
            else if (Player.modeGame.Equals("Wave"))
            {

                if (textScore != null)
                {
                    textScore.text = "Score: " + score;
                }
                if (textWave != null)
                {
                    textWave.text = "Wave " + wave + "/" + EnemyWaveManager.maxWave;
                }
            }
        }

        
    }

    public IEnumerable<ScoreZen> GetZenHighScores()
    {
        return scoreZenData.ZenScoreList.OrderByDescending(x => x.time);
    }

    public IEnumerable<ScoreWave> GetWaveHighScores()
    {
        return scoreWaveData.WaveScoreList.OrderByDescending(x => x.score);
    }

    public void AddZenScore(ScoreZen score)
    {
        scoreZenData.ZenScoreList.Add(score);
    }

    public void AddWaveScore(ScoreWave score)
    {
        scoreWaveData.WaveScoreList.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var ZenScoreJson = JsonUtility.ToJson(scoreZenData);
        PlayerPrefs.SetString("ZenScores", ZenScoreJson);

        var WaveScoreJson = JsonUtility.ToJson(scoreWaveData);
        PlayerPrefs.SetString("WaveScores", WaveScoreJson);
    }
}
