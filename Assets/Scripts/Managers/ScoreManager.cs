﻿using UnityEngine;
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
    public static bool isTimeActive = true ;
    public static int stopTime;
    public int counterPanel = 0;

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
                    //if (isTimeActive && counterPanel == 2)
                    //{
                    //    stopTime = 0;
                    //    counterPanel = 0; 
                    //}
                    //if (!isTimeActive)
                    //{
                    //    counterPanel += 1;
                    //    isTimeActive = true; 
                    //}
                    ts = stopwatch.Elapsed; 
                    string time = ts.ToString().Substring(0, 11);
                    if (textTime != null)
                    {
                        textTime.text = time;
                    }
                    if( ts.Seconds > 0 && ts.Seconds % 30 == 0 && stopTime != ts.Seconds)
                    {
                        counterPanel += 1;
                        stopTime = ts.Seconds;
                        isUpgradeZen = true;
                        isTimeActive = false;
                        stopwatch.Stop(); 
                        panelUpgradeWeapon.SetActive(true);
                    }
                    if (ts.Seconds % 30 != 0)
                    {
                        stopTime = 0; 
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
            else if (Player.modeGame.Equals("SuddenDeath"))
            {

                if (textScore != null)
                {
                    textScore.text = "Score: " + score;
                }
                if (stopwatch != null)
                {
                    UnityEngine.Debug.Log("MASUK KE ZEN");
                    ts = stopwatch.Elapsed;
                    string time = ts.ToString().Substring(0, 11);
                    if (textTime != null)
                    {
                        textTime.text = time;
                    }
                    if (ts.Seconds > 0 && ts.Seconds % 30 == 0)
                    {

                        isUpgradeZen = true;
                        panelUpgradeWeapon.SetActive(true);
                    }
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
            //.ThenByDescending(x => x.wave);
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
