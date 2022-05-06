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
            Player.playerName = defaultPlayerName;
        }

        if (GameMode == "Zen")
        {
            Player.modeGame = GameMode;
            SceneManager.LoadScene("ZenMode");

        }
        else if (GameMode == "Wave")
        {
            Player.modeGame = GameMode;
            SceneManager.LoadScene("WaveMode");

        }

        else if (GameMode == "SuddenDeath")
        {
            Player.modeGame = GameMode;
            SceneManager.LoadScene("SuddenDeathMode");

        }

    }

    public void ScoreBoard()
    {
        SceneManager.LoadScene("ZenScoreBoard");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
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
