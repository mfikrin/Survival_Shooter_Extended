using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    string GameMode = "Zen";

    public GameObject modalWindow;
    public void PlayGame()
    {

        Debug.Log(GameMode); 
        if (GameMode == "Zen")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (GameMode == "Wave")
        {

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
