using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWaveUI : MonoBehaviour
{
    public RowWaveUI rowWaveUIOdd;
    public RowWaveUI rowWaveUIEven;
    public static int scoreWaveUI;
    public static int waveWaveUI;

    public ScoreWaveManager scoreWaveManager;

    private void Start()
    {

        //var WaveScoreJson = PlayerPrefs.GetString("WaveScores");
        ////Debug.Log(ZenScoreJson.Equals(String.Empty));
        //Debug.Log(WaveScoreJson);
        //if (WaveScoreJson.Equals(String.Empty))
        //{
        //    Debug.Log("nulll");
        //    scoreWaveData = new ScoreWaveData();
        //}
        //else
        //{
        //    Debug.Log("not nulll");
        //    scoreWaveData = JsonConvert.DeserializeObject<ScoreWaveData>(WaveScoreJson);
        //}

        //Debug.Log(scoreWaveData);

        //Debug.Log(Player.playerName);
        //Debug.Log(Player.modeGame);

        //if (Player.playerName != null && Player.modeGame.Equals("Wave"))
        //{
        //    scoreWaveManager.AddWaveScore(new ScoreWave(name: Player.playerName, wave: ScoreManager.wave, score: ScoreManager.score));
        //    Player.playerName = null;
        //}

        if (scoreWaveManager.GetScoreWaveData() != null)
        {
            var scores = scoreWaveManager.GetWaveHighScores().ToArray();

            Debug.Log(scores.Length);
            int max_display = scores.Length;

            if (scores.Length > 5)
            {
                max_display = 5; // display 5 first rank
            }
            

            for (int i = 0; i < max_display; i++)
            {
                if (i % 2 == 0)
                {
                    var row = Instantiate(rowWaveUIOdd, transform).GetComponent<RowWaveUI>();
                    row.Rank.text = (i + 1).ToString();

                    string fullName = scores[i].name;
                    string nickName = scores[i].name;
                    if (scores[i].name.Length > 12)
                    {
                        nickName = scores[i].name.Substring(0, 12);
                    }
                    row.Name.text = nickName;
                    row.Wave.text = scores[i].wave.ToString();
                    row.Score.text = scores[i].score.ToString();

                    row.FullName.text = fullName;

                    
                }
                else
                {
                    var row = Instantiate(rowWaveUIEven, transform).GetComponent<RowWaveUI>();
                    row.Rank.text = (i + 1).ToString();


                    string fullName = scores[i].name;
                    string nickName = scores[i].name;
                    if (scores[i].name.Length > 12)
                    {
                        nickName = scores[i].name.Substring(0, 12);
                    }

                    row.Name.text = nickName;
                    row.Wave.text = scores[i].wave.ToString();
                    row.Score.text = scores[i].score.ToString();

                    row.FullName.text = fullName;
                }


            }
        }

        
    }

    //public void Update()
    //{
    //    OnMouseOver();
    ////}

    //public void OnMouseOver()
    //{
    //    Debug.Log("MASUK MOUSE OVER");
    //    //hoverFullName.text = "Over";
    //    hoverFullNamePanel.SetActive(true);

    //}

    //public void OnMouseExit()
    //{
    //    Debug.Log("MASUK MOUSE EXIT");
    //    hoverFullNamePanel.SetActive(false);

    //    //hoverFullName.text = "Exit";
    //}

    // Callback jika ada suatu object masuk ke dalam trigger
    //void OnTriggerEnter(Collider other)
    //{
    //    // Set player in range
    //    if (other.gameObject == hoverFullName)
    //    {
    //        updateText = true;
    //        Debug.Log("MASUK TRIGGER");

    //    }
    //}

    //// Callback jika ada object yang keluar dari trigger
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject == player && other.isTrigger == false)
    //    {
    //        playerInRange = false;
    //    }
    //}

    //public IEnumerable<ScoreWave> GetWaveHighScores()
    //{
    //    return scoreWaveData.WaveScoreList.OrderByDescending(x => x.score);
    //    //.ThenByDescending(x => x.wave);
    //}

    //private void OnDestroy()
    //{
    //    SaveScoreWave();
    //}

    //public void AddWaveScore(ScoreWave score)
    //{
    //    scoreWaveData.WaveScoreList.Add(score);
    //}

    //public void SaveScoreWave()
    //{
    //    //var ZenScoreJson = JsonUtility.ToJson(scoreZenData);
    //    //var ZenScoreJson = JsonConvert.SerializeObject(scoreZenData);
    //    //UnityEngine.Debug.Log(ZenScoreJson);
    //    //PlayerPrefs.SetString("ZenScores", ZenScoreJson);

    //    var WaveScoreJson = JsonConvert.SerializeObject(scoreWaveData);
    //    UnityEngine.Debug.Log(WaveScoreJson);

    //    PlayerPrefs.SetString("WaveScores", WaveScoreJson);

    //    //var SuddenDeathScoreJson = JsonConvert.SerializeObject(scoreSuddenDeathData);
    //    //UnityEngine.Debug.Log(SuddenDeathScoreJson);

    //    //PlayerPrefs.SetString("SuddenDeathScores", SuddenDeathScoreJson);
    //}


}
