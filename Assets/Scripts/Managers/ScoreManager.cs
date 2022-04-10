﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
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
    private ScoreSuddenDeathData scoreSuddenDeathData;


    public GameObject panelUpgradeWeapon;
    public GameObject panelResume;


    public Text textScore;
    public Text textTime;
    public Text textWave;


    void Awake()
    {
      
        var SuddenDeathScoreJson = PlayerPrefs.GetString("SuddenDeathScores");
        if (SuddenDeathScoreJson == null)
        {
            SuddenDeathScoreJson = "{}";
        }
        scoreSuddenDeathData = JsonConvert.DeserializeObject<ScoreSuddenDeathData>(SuddenDeathScoreJson);

        score = 0;
        wave = 1;
        stopwatch = new Stopwatch();
        stopwatch.Start();
      

    }


    void Update()
    {
        string scene = SceneManager.GetActiveScene().name;
        UnityEngine.Debug.Log(scene);
        if (scene.Equals("ZenMode") || scene.Equals("WaveMode") || scene.Equals("SuddenDeathMode"))
        {
            //UnityEngine.Debug.Log("MASUK KE IFFF");

            if (Player.modeGame.Equals("Zen"))
            {
                //UnityEngine.Debug.Log("MASUK KE ZEN");
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

                    if (ResumeManager.isGamePaused)
                    {
                        isTimeActive = false;
                        stopwatch.Stop();
                        panelResume.SetActive(true);
                    }
                }
            }
            else if (Player.modeGame.Equals("Wave"))
            {
                //UnityEngine.Debug.Log("MASUK KE WAVE");

                if (textScore != null)
                {
                    textScore.text = "Score: " + score;
                }
                if (textWave != null)
                {
                    textWave.text = "Wave " + wave + "/" + EnemyWaveManager.maxWave;
                }
                if (ResumeManager.isGamePaused)
                {
                    //UnityEngine.Debug.Log("AAAAAAAA");
                    isTimeActive = false;
                    //stopwatch.Stop();
                    panelResume.SetActive(true);
                }
            }
            else if (Player.modeGame.Equals("SuddenDeath"))
            {
                UnityEngine.Debug.Log("Sud");
                if (textScore != null)
                {
                    textScore.text = "Score: " + score;
                }
                if (stopwatch != null)
                {
                    //UnityEngine.Debug.Log("MASUK KE STOPWATCH SUDDEN DEATH");
                    ts = stopwatch.Elapsed;
                    string time = ts.ToString().Substring(0, 11);
                    if (textTime != null)
                    {
                        textTime.text = time;
                    }
                    if (ts.Seconds > 0 && ts.Seconds % 30 == 0 && stopTime != ts.Seconds)
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

                    if (ResumeManager.isGamePaused)
                    {
                        isTimeActive = false;
                        stopwatch.Stop();
                        panelResume.SetActive(true);
                    }
                }
            }
        }
    }
}
