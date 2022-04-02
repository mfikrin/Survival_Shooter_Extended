using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public RowUI rowUIEven;
    public ScoreManager scoreManager;


    private void Start()
    {
        scoreManager.AddScore(new Score("A", 20));
        scoreManager.AddScore(new Score("B", 30));
        scoreManager.AddScore(new Score("C", 70));
        scoreManager.AddScore(new Score("D", 70));
        scoreManager.AddScore(new Score("E", 70));
        scoreManager.AddScore(new Score(Player.playerName, ScoreManager.score));
        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            if (i % 2 == 0)
            {
                var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
                row.Rank.text = (i + 1).ToString();
                row.Name.text = scores[i].name;
                row.Score.text = scores[i].score.ToString();
            }
            else
            {
                var row = Instantiate(rowUIEven, transform).GetComponent<RowUI>();
                row.Rank.text = (i + 1).ToString();
                row.Name.text = scores[i].name;
                row.Score.text = scores[i].score.ToString();
            }
            
         
        }
    }


}
