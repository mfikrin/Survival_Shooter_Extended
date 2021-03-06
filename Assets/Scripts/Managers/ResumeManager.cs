using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeManager : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject panelResume;

    public void Pause()
    {
        panelResume.SetActive(true);
        Time.timeScale = 0.0000001f;
        isGamePaused = true;
        ScoreManager.isTimeActive = false;
    }

    public void Resume()
    {
        panelResume.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        if (Player.modeGame != "Wave")
        {
            ScoreManager.stopwatch.Start();
        }
        
    }
    public void MainMenuFromResume()
    {
        Player.playerName = null;
        Player.timeBetweenBullets = 0.5f;
        Player.damagePerShot = 20;
        Player.speed = 6f;
        Player.diagonal = 1;
        Player.startingHealth = 100;

        SceneManager.LoadScene("Menu");
        Resume();

    }
    public void QuitGameFromResume()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
