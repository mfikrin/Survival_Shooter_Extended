using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyWaveManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public GameObject panelUpgradeWeapon;
    //public Button upgradeSpeed;
    //public Button upgradeDiagonal;
    public int[] spawnEnemy;
    public float spawnTime;
    public Transform[] spawnPoints;

    //// upgrade weapon 
    //public static bool GameIsPaused = false;
    //public bool isExitUpgradeWeapon = false;
    public static bool isAfterWaveBoss = false;

    [SerializeField]
    public MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    //private int waveNumber = 0;
    private int enemySpawnAmount;
    public static int enemyKilled;
    public static int maxWave;
    void Start()
    {

        //spawnEnemy = new int[enemySpawnAmount];
        panelUpgradeWeapon.SetActive(false);
        spawnTime = 3f;
        enemySpawnAmount = spawnEnemy.Length;
        enemyKilled = 0;
        maxWave = 6;
        //Debug.Log("IN START ENEMY MANAGER");

        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        //if (Player.modeGame.Equals("Wave"))
        //{
        //    Debug.Log("SPAWN WAVE MODE");
            
        //}
        StartWave();
        //InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    private void Update()
    {
        //Debug.Log("IN UPDATE ENEMY MANAGER");

        //if (Player.modeGame.Equals("Wave"))
        //{
        //    Debug.Log("SPAWN WAVE MODE IN UPDATE ENEMY MANAGER");
        //    if (enemyKilled >= enemySpawnAmount)
        //    {
        //        Debug.Log("Wave SUDAH SELESAI GAN ?");
        //        NextWave();
        //    }
        //}

        //Debug.Log("SPAWN WAVE MODE IN UPDATE ENEMY MANAGER");
        Debug.LogFormat("Enemy Killed",enemyKilled);
        Debug.Log("Enemy Killed");
        Debug.Log(enemyKilled);
        Debug.Log("Enemy Spawn Amount");
        Debug.Log(enemySpawnAmount);
        if (enemyKilled >= enemySpawnAmount)
        {
            if (ScoreManager.wave == maxWave) // Reached max wave
            {

                // set score
                ScoreWaveUI.scoreWaveUI = ScoreManager.score;
                // set wave
                ScoreWaveUI.waveWaveUI = ScoreManager.wave;

                SceneManager.LoadScene("WaveWinMenu");
            }
            else
            {
                //Debug.Log("Wave SUDAH SELESAI GAN ?");
                if(ScoreManager.wave % 1 == 0)
                {
                    isAfterWaveBoss = true;
                    panelUpgradeWeapon.SetActive(true);

                    Debug.Log("BOSS WAVE");

                    //upgradeWeapon();
                }
               
                
                if (!WeaponUpgradeManager.isGamePaused)
                {
                    NextWave();
                }

                if (WeaponUpgradeManager.isExitUpgradeWeapon)
                {
                    NextWave();
                }

                    
                
            }
           
        }
    }

    //public void exitFromUpgradeWeapon()
    //{
    //    isExitUpgradeWeapon = false;
    //    NextWave();
    //}

    //public void Pause()
    //{
    //    panelUpgradeWeapon.SetActive(true);
    //    Time.timeScale = 0f;
    //    GameIsPaused = true;
    //}

    //public void Resume()
    //{
    //    panelUpgradeWeapon.SetActive(false);
    //    Time.timeScale = 1f;
    //    GameIsPaused = false;
    //}

   

    void Spawn(int tag)
    {
        
        if ((playerHealth.currentHealth <= 0f && Player.modeGame != "SuddenDeath") || (playerHealth.currentHealth < 0 && Player.modeGame.Equals("SuddenDeath")))
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Menduplikasi enemy
        Instantiate(Factory.FactoryMethod(tag), spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }

    private void StartWave()
    {
        Debug.Log("IN START WAVE");
        ScoreManager.wave = 1;
        //enemySpawnAmount = 2;
        enemyKilled = 0;

        

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            int tag = spawnEnemy[i];
            Debug.Log("SPAWN");
            Spawn(tag);
        }
    }

    private void NextWave()
    {
        Debug.Log("IN NEXT WAVE");
        
        ScoreManager.wave++;
        Debug.Log(ScoreManager.wave);
        int addEnemyAmount = 2;
        enemySpawnAmount += addEnemyAmount;
        
        int[] arrayAddEnemey;
        if (ScoreManager.wave % 3 == 0) // Boss stage
        {
           arrayAddEnemey = new int[] { 2, 2 };
        }
        else
        {
           arrayAddEnemey = new int[] { 0, 1 }; // 
        }
        

        List<int> ListSpawnEnemy = spawnEnemy.ToList();

        foreach (var tag in arrayAddEnemey)
        {
            ListSpawnEnemy.Add(tag);
        }

        spawnEnemy = ListSpawnEnemy.ToArray();

        Debug.Log(spawnEnemy);
        //spawnEnemy = new int[enemySpawnAmount];

        
        
        enemyKilled = 0;


        for (int i = 0; i < enemySpawnAmount; i++)
        {
            int tag = spawnEnemy[i];
            Debug.Log("SPAWN");
            Spawn(tag);
        }
    }
}
