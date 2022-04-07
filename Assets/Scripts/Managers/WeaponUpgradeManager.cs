using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool isGamePaused = false;
    public static bool isExitUpgradeWeapon = false;
    public static bool isUpSpeed = false;
    public GameObject panelUpgradeWeapon;
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
    }

    public void Resume()
    {
        panelUpgradeWeapon.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
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
        Resume(); 
        
    }
}
