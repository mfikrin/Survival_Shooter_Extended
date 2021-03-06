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
        Player.playerName = defaultPlayerName;
        

        if (GameMode == "Zen")
        {
            Player.modeGame = GameMode;
            Player.timeBetweenBullets = 0.5f;
            Player.damagePerShot = 20;
            Player.speed = 6f;
            Player.diagonal = 1;
            SceneManager.LoadScene("ZenMode");

        }
        else if (GameMode == "Wave")
        {
            Player.modeGame = GameMode;
            Player.timeBetweenBullets = 0.5f;
            Player.damagePerShot = 20;
            Player.speed = 6f;
            Player.diagonal = 1;
            SceneManager.LoadScene("WaveMode");
        }
        else if (GameMode == "SuddenDeath")
        {
            Player.modeGame = GameMode;
            Player.timeBetweenBullets = 0.5f;
            Player.damagePerShot = 20;
            Player.speed = 6f;
            Player.diagonal = 1;
            SceneManager.LoadScene("SuddenDeathMode");
        }

    }

    public void ScoreBoard()
    {
        Debug.Log("To scoreBoard");
        if (Player.modeGame.Equals("Zen"))
        {
           SceneManager.LoadScene("ZenScoreBoard");
        }
        else if (Player.modeGame.Equals("Wave"))
        {
           SceneManager.LoadScene("WaveScoreBoard");
        }
        else if (Player.modeGame.Equals("SuddenDeath"))
        {
            Player.startingHealth = 100;
            SceneManager.LoadScene("SuddenDeathScoreBoard");
        }

    }

    public void QuitGame()
    {
        Player.timeBetweenBullets = 0.5f;
        Player.damagePerShot = 20;
        Player.speed = 6f;
        Player.diagonal = 1;
        Player.playerName = null;
        Player.startingHealth = 100;
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
