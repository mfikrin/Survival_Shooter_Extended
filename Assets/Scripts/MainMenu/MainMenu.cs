using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class MainMenu : MonoBehaviour
{
    string GameMode = "Zen";

    public TMP_InputField nameInputField;

    public static string defaultPlayerName;

    public void PlayGame()
    {

        if (nameInputField.text != string.Empty)
        {
            Player.playerName = nameInputField.text; // nanti ubah playerMovement nya

        }
        else
        {
            DateTime now = DateTime.Now;
            defaultPlayerName = "Anonymous ";
            defaultPlayerName += now.ToString();
            //Debug.Log(defaultPlayerName);
            Player.playerName = defaultPlayerName;
        }

        if (GameMode == "Zen")
        {
            //Debug.Log("Mode Game ZEN");
            Player.modeGame = GameMode;
            SceneManager.LoadScene("ZenMode");

        }
        else if (GameMode == "Wave")
        {
            Player.modeGame = GameMode;
            //SceneManager.LoadScene("WaveMode");

        }

    }

    public void ScoreBoard()
    {
        Debug.Log("To scoreBoard");
        SceneManager.LoadScene("ZenScoreBoard");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void setZenMode()
    {
        GameMode = "Zen";

    }

    public void setWaveMode()
    {
        GameMode = "Wave";
    }

}
