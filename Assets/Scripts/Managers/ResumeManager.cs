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
        ScoreManager.stopwatch.Start();
    }
    public void MainMenuFromResume()
    {
        Debug.Log("To main menu Resume");

        Player.timeBetweenBullets = 0.5f;
        Player.damagePerShot = 50;
        Player.speed = 6f;
        Player.diagonal = 1;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGameFromResume()
    {
        Debug.Log("Quit Resume");
        //Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
