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

    public void PlayGame()
    {

        if (nameInputField.text != string.Empty)
        {
            Debug.Log("Masuk not null");
            Player.playerName = nameInputField.text; // nanti ubah playerMovement nya

        }
        else
        {
            Debug.Log("Masuk null");
            DateTime now = DateTime.Now;

            var defaultPlayerName = "Anonymous ";
            defaultPlayerName += now.ToString();
            Debug.Log(defaultPlayerName);
            Player.playerName = defaultPlayerName;
        }

        Debug.Log(GameMode); 

        Debug.Log("Player name" + nameInputField.text);
        if (GameMode == "Zen")
        {
            Debug.Log("Mode Game ZEN");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (GameMode == "Wave")
        {
            Debug.Log("Mode Game WAVE");
        }
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void setZenMode()
    {
        Debug.Log("Sebelum");
        Debug.Log(GameMode);
        GameMode = "Zen";
        Debug.Log("Setelah");
        Debug.Log(GameMode);
    }

    public void setWaveMode()
    {
        Debug.Log("Sebelum");
        Debug.Log(GameMode);
        GameMode = "Wave";
        Debug.Log("Setelah");
        Debug.Log(GameMode);
    }

}
