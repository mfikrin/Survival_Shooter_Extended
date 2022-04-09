using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class OverMenu : MonoBehaviour
{
    public static string GameMode;

    public static string Param1;
    public static string Param2;
    public Text param1;
    public Text param2;


    public static string defaultPlayerName;
    void Awake()
    {
        param1.text = Param1.ToString();
        param2.text = Param2.ToString();
    }
    public void Restart()
    {
        // Debug.Log("GameMode: " + GameMode);
        // Debug.Log("Score: " + Score);

        //Debug.Log(defaultPlayerName);
        Player.playerName = defaultPlayerName;
        

        if (GameMode == "Zen")
        {
            //Debug.Log("Mode Game ZEN");
            Player.modeGame = GameMode;
            SceneManager.LoadScene("ZenMode");

        }
        else if (GameMode == "Wave")
        {
            Player.modeGame = GameMode;
            SceneManager.LoadScene("WaveMode");

        }

    }

    public void ScoreBoard()
    {
        Debug.Log("To scoreBoard");
        SceneManager.LoadScene("ZenScoreBoard");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void setZenMode()
    {
        GameMode = "Zen";

    }

    public void setWaveMode()
    {
        GameMode = "Wave";
    }

    public void setSuddenDeathMode()
    {
        GameMode = "SuddenDeath";

    }

}
