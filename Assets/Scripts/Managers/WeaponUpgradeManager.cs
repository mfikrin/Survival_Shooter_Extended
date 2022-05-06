using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool isGamePaused = false;
    public static bool isExitUpgradeWeapon = false;
    public static bool isUpSpeed = false;
    public static bool isUpPower = false;
    public GameObject panelUpgradeWeapon;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
    public GameObject weapon5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyWaveManager.isAfterWaveBoss)
        {
            Pause();
        }
        if (ScoreManager.isUpgradeZen)
        {
            Pause();
        }
    }

    public void Pause()
    {
        panelUpgradeWeapon.SetActive(true);
        Time.timeScale = 0.0000001f;
        isGamePaused = true;
        ScoreManager.isTimeActive = false; 
    }

    public void Resume()
    {
        panelUpgradeWeapon.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        ScoreManager.stopwatch.Start();
    }

    public void speedup()
    {
        isUpSpeed = true;

        if (Player.timeBetweenBullets >= 0.1)
        {
            Player.timeBetweenBullets -= 0.1f;
        }
        //else
        //{
        //    Debug.Log("sudah kecepatan maksimal");
        //}

        Resume();
       
    }

    public void diagonalup()
    {
        if (Player.diagonal < 5)
        {
           Player.diagonal += 2;
        }
         
        if(Player.diagonal == 3)
        {
            weapon2.SetActive(true);
            weapon3.SetActive(true);
        }
        else if (Player.diagonal == 5)
        {
            weapon4.SetActive(true);
            weapon5.SetActive(true);
        }
        Resume(); 
        
    }

    public void powerup()
    {
        if (Player.damagePerShot != 100)
        {
            Player.damagePerShot += 20;
 
        }
        isUpPower = true; 
        Resume();

    }
}
