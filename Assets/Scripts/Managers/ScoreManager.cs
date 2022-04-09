using UnityEngine;
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
        //var ZenScoreJson = PlayerPrefs.GetString("ZenScores");
        ////Account account = JsonConvert.DeserializeObject<Account>(json);
        //if (ZenScoreJson == null)
        //{
        //    ZenScoreJson = "{}";
        //}
        //scoreZenData = JsonConvert.DeserializeObject<ScoreZenData>(ZenScoreJson);

        var WaveScoreJson = PlayerPrefs.GetString("WaveScores");

        if (WaveScoreJson == null)
        {
            WaveScoreJson = "{}";
        }
        scoreWaveData = JsonConvert.DeserializeObject<ScoreWaveData>(WaveScoreJson);

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
            UnityEngine.Debug.Log("MASUK KE IFFF");

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
                UnityEngine.Debug.Log("MASUK KE WAVE");

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
                    UnityEngine.Debug.Log("AAAAAAAA");
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
                    UnityEngine.Debug.Log("MASUK KE STOPWATCH SUDDEN DEATH");
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

    public ScoreZenData GetScoreZens()
    {
        return scoreZenData;
    }

    public ScoreWaveData GetScoreWave()
    {
        return scoreWaveData;
    }

    public ScoreSuddenDeathData GetScoreSudden()
    {
        return scoreSuddenDeathData;
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

    public IEnumerable<ScoreSuddenDeath> GetSuddenDeathHighScores()
    {
        return scoreSuddenDeathData.SuddenDeathScoreList.OrderByDescending(x => x.score).ThenByDescending(x => x.time);
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

    public void AddSuddenDeathScore(ScoreSuddenDeath score)
    {
        scoreSuddenDeathData.SuddenDeathScoreList.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        //var ZenScoreJson = JsonUtility.ToJson(scoreZenData);
        var ZenScoreJson = JsonConvert.SerializeObject(scoreZenData);
        UnityEngine.Debug.Log(ZenScoreJson);
        PlayerPrefs.SetString("ZenScores", ZenScoreJson);

        var WaveScoreJson = JsonConvert.SerializeObject(scoreWaveData);
        UnityEngine.Debug.Log(WaveScoreJson);

        PlayerPrefs.SetString("WaveScores", WaveScoreJson);

        var SuddenDeathScoreJson = JsonConvert.SerializeObject(scoreSuddenDeathData);
        UnityEngine.Debug.Log(SuddenDeathScoreJson);

        PlayerPrefs.SetString("SuddenDeathScores", SuddenDeathScoreJson);
    }
}
