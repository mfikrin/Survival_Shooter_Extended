using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreWaveUI : MonoBehaviour
{
    public RowWaveUI rowWaveUIOdd;
    public RowWaveUI rowWaveUIEven;
    public ScoreManager scoreManager;
    public static int scoreWaveUI;
    public static int waveWaveUI;


    private void Start()
    {

        scoreManager.AddWaveScore(new ScoreWave(name: "A", wave: 2, score: 100));
        scoreManager.AddWaveScore(new ScoreWave(name: "B", wave: 3, score: 400));
        scoreManager.AddWaveScore(new ScoreWave(name: "C", wave: 4, score: 500));
        scoreManager.AddWaveScore(new ScoreWave(name: "D", wave: 1, score: 90));




        Debug.Log("STAT PEMAIN");
        //Debug.Log(ScoreManager.score);
        //Debug.Log(scoreUI);
        //Debug.Log(TimeSpan);

        if (Player.playerName != null && Player.modeGame.Equals("Wave"))
        {
            scoreManager.AddWaveScore(new ScoreWave(name: Player.playerName, wave: waveWaveUI, score: scoreWaveUI));
        }
        else
        {
            Debug.Log("Player name msh null");
        }

        var scores = scoreManager.GetWaveHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            if (i % 2 == 0)
            {
                var row = Instantiate(rowWaveUIOdd, transform).GetComponent<RowWaveUI>();
                row.Rank.text = (i + 1).ToString();
                row.Name.text = scores[i].name;
                row.Wave.text = scores[i].wave.ToString();
                row.Score.text = scores[i].score.ToString();
            }
            else
            {
                var row = Instantiate(rowWaveUIEven, transform).GetComponent<RowWaveUI>();
                row.Rank.text = (i + 1).ToString();
                row.Name.text = scores[i].name;
                row.Wave.text= scores[i].wave.ToString();
                row.Score.text= scores[i].score.ToString();
            }


        }
    }





    //public void FixedUpdate()
    //{
    //��� SceneManager.LoadScene("Menu");
    //}


}