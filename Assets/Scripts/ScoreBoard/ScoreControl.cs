using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour
{
    public void MainMenuButton()
    {
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
}
