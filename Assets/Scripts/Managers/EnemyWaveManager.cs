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
    public int[] spawnedEnemy;
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
    private int spawnedEnemyAmount;
    public static int enemyKilled;
    public static int maxWave;
    // public int[,] enemyPool = new int[maxWave, spawnedEnemy.Length]; 
    void Start()
    {

        //spawnedEnemy = new int[spawnedEnemyAmount];
        panelUpgradeWeapon.SetActive(false);
        spawnTime = 3f;
        spawnedEnemyAmount = spawnedEnemy.Length;
        enemyKilled = 0;
        maxWave = 6;
        

        FirstWave();

    }

    private void Update()
    {

        // Debug.LogFormat("Enemy Killed",enemyKilled);
        // Debug.Log("Enemy Killed");
        // Debug.Log(enemyKilled);
        // Debug.Log("Enemy Spawn Amount");
        //Debug.Log(spawnedEnemyAmount);
        if (enemyKilled >= spawnedEnemyAmount)
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

    private void FirstWave()
    {
        //Debug.Log("IN START WAVE");
        ScoreManager.wave = 1;
        //spawnedEnemyAmount = 2;
        enemyKilled = 0;
        

        for (int i = 0; i < spawnedEnemyAmount; i++)
        {
            int tag = spawnedEnemy[i];
            Debug.Log("SPAWN");
            Spawn(tag);
        }
    }

    private void NextWave()
    {
        //Debug.Log("IN NEXT WAVE");
        
        ScoreManager.wave++;
        Debug.Log(ScoreManager.wave);
        int enemyCount = 2;
        spawnedEnemyAmount += enemyCount;
        
        int[] addedEnemyArray;
        if (ScoreManager.wave % 3 == 0) // Boss stage
        {
           addedEnemyArray = new int[] { 2, 2 };
        }
        else
        {
           addedEnemyArray = new int[] { 0, 1 }; // 
        }
        

        List<int> spawnedEnemyList = spawnedEnemy.ToList();

        foreach (var tag in addedEnemyArray)
        {
            spawnedEnemyList.Add(tag);
        }

        spawnedEnemy = spawnedEnemyList.ToArray();

        Debug.Log(spawnedEnemy);
        //spawnedEnemy = new int[spawnedEnemyAmount];

        
        
        enemyKilled = 0;


        for (int i = 0; i < spawnedEnemyAmount; i++)
        {
            int tag = spawnedEnemy[i];
            Debug.Log("SPAWN");
            Spawn(tag);
        }
    }
}
