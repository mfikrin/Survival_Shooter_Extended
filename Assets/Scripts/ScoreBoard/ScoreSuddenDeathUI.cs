using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Newtonsoft.Json;

public class ScoreSuddenDeathUI : MonoBehaviour
{
    public RowSuddenDeathUI rowSuddenDeathUIOdd;
    public RowSuddenDeathUI rowSuddenDeathUIEven;
    public static int scoreSuddenDeathUI;
    public static TimeSpan TimeSpanSuddenDeathUI;

    private ScoreSuddenDeathData scoreSuddenDeathData;

    private void Start()
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

            AddSuddenDeathScore(new ScoreSuddenDeath(Player.playerName, scoreSuddenDeathUI, TimeSpanSuddenDeathUI));
            Player.playerName = null;
        }

        if (scoreSuddenDeathData != null)
        {
            var scores = GetSuddenDeathHighScores().ToArray();


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
                    var row = Instantiate(rowSuddenDeathUIOdd, transform).GetComponent<RowSuddenDeathUI>();
                    row.Rank.text = (i + 1).ToString();
                    row.Name.text = scores[i].name;
                    row.Score.text = scores[i].score.ToString();
                    row.Time.text = scores[i].time.ToString().Substring(0, 11);
                }
                else
                {
                    var row = Instantiate(rowSuddenDeathUIEven, transform).GetComponent<RowSuddenDeathUI>();
                    row.Rank.text = (i + 1).ToString();
                    row.Name.text = scores[i].name;
                    row.Score.text = scores[i].score.ToString();
                    row.Time.text = scores[i].time.ToString().Substring(0, 11);
                }
            }
        }
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
