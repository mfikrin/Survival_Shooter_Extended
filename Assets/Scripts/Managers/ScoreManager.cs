using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    private ScoreData scoreData;
    Text text;


    void Awake ()
    {
        scoreData = new ScoreData();
        text = GetComponent<Text>();
        score = 0;
    }
    void Update ()
    {
        if (text != null)
        {
           text.text = "Score: " + score;
        }
        
    }

    public IEnumerable<Score> GetHighScores()
    {
        return scoreData.ScoreList.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        scoreData.ScoreList.Add(score);
    }
}
