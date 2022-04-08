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
        //panelUpgradeWeapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("UPDATE IN WEP MANG");
        if (EnemyWaveManager.isAfterWaveBoss)
        {
            Debug.Log("MASUK PAUSEEEEE");
            Pause();
        }
        if (ScoreManager.isUpgradeZen)
        {
            Debug.Log("MASUK PAUSEEEEE ZENNNN");
            Pause();
        }
    }

    public void exitFromUpgradeWeapon()
    {
        //Resume();
        //isExitUpgradeWeapon = true;
        
       
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

    public void upgradeWeapon()
    {
        // munculin panel upgrade 
        //Pause(); 
        Debug.Log("Update Dong");
        // upgradeSpeed.onClick.AddListener(speedup);
        // upgradeDiagonal.onClick.AddListener(diagonalup);

    }

    public void speedup()
    {
        isUpSpeed = true;

        Debug.Log("Speed up");
        if (Player.timeBetweenBullets >= 0.1)
        {
            Player.timeBetweenBullets -= 0.1f;
        }
        else
        {
            Debug.Log("sudah kecepatan maksimal");
        }

        Resume();
       
    }

    public void diagonalup()
    {
        Debug.Log("diagonal up");
        Player.diagonal += 2; 
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
        Debug.Log("Power Up");
        if (Player.damagePerShot != 100)
        {
            Player.damagePerShot += 20;
 
        }
        isUpPower = true; 
        Resume();

    }
}
