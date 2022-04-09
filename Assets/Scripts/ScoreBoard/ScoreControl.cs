using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour
{
    public void MainMenuButton()
    {
        Player.timeBetweenBullets = 0.5f;
        Player.damagePerShot = 50;
        Player.speed = 6f;
        Player.diagonal = 1; 
        SceneManager.LoadScene("Menu");
    }

    public void ZenScoreButton()
    {
        SceneManager.LoadScene("ZenScoreBoard");
    }

    public void WaveScoreButton()
    {
        SceneManager.LoadScene("WaveScoreBoard");
    }

    public void SuddenDeathScoreButton()
    {
        SceneManager.LoadScene("SuddenDeathScoreBoard");
    }
}
