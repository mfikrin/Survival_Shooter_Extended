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
    string playerName;

    //public GameObject InputField;
    public TMP_InputField nameInputField;

    //public void Start()
    //{
    //    if (nameInputField != null)
    //    {
    //        nameInputField.onValueChanged.AddListener(UpdateInputField);
    //    }
        
    //}

    private void UpdateInputField(string arg0)
    {
        Debug.Log(arg0);
    }


    public void PlayGame()
    {

        Debug.Log(GameMode); 
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

    public void onInputName()
    {
        //Debug.Log(value);
        //playerName = value;
        //Debug.Log(playerName);
        nameInputField.onValueChanged.AddListener(UpdateInputField);
    }

    public void onEndInputName()
    {
        Debug.Log("In set End Input Name");
        nameInputField.onEndEdit.AddListener(setPlayerName);
    }

    private void setPlayerName(string arg)
    {
        playerName = arg;
        Debug.Log("In set Player Name");
        Debug.Log(playerName);
        Debug.Log("Player name");
        Debug.Log(playerName);

    }


    //public void AboutGame()
    //{
    //    Debug.Log("About click!");
    //    modalWindow.SetActive(true);
    //}
}
