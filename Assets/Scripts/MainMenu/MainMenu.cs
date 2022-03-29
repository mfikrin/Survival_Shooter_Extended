using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    string GameMode = "Zen";
    string playerName;

    public GameObject modalWindow;
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


    //public void AboutGame()
    //{
    //    Debug.Log("About click!");
    //    modalWindow.SetActive(true);
    //}
}
