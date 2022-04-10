using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyWaveManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject panelUpgradeWeapon;
    //public Button upgradeSpeed;
    //public Button upgradeDiagonal;
    public int[] spawnedEnemy;
    public int waveNumber;
    public float spawnTime;
    public Transform[] spawnPoints;

    public int[] enemyWeight;
    [SerializeField] public enemyPool[] waves;

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
    float timeBetweenWaves = 3f;
    float timer;
    float spawnTimer;
    int[][] defaultPool = new int[6][];


    void Start()
    {

        //spawnedEnemy = new int[spawnedEnemyAmount];
        panelUpgradeWeapon.SetActive(false);
        spawnTime = 3f;
        // spawnedEnemyAmount = spawnedEnemy.Length;
        enemyKilled = 0;
        spawnedEnemyAmount = 999;
        maxWave = waves.Length;
        defaultPool = initDefaultPooling();
        FirstWave();

    }

    private void Update()
    {
        if (enemyKilled >= spawnedEnemyAmount)
        {
            timer += Time.deltaTime; 
            if (ScoreManager.wave == maxWave) // Reached max wave
            {

                // set score
                ScoreWaveUI.scoreWaveUI = ScoreManager.score;
                // set wave
                ScoreWaveUI.waveWaveUI = ScoreManager.wave;

                OverMenu.Param1 = ScoreManager.wave.ToString();
                OverMenu.Param2 = ScoreManager.score.ToString();
                Debug.Log(OverMenu.Param1);

                SceneManager.LoadScene("WaveWinMenu");
            }
            else
            {  
                if(timer >= timeBetweenWaves)
                {
                    if(ScoreManager.wave % 3 == 0)
                    {
                    isAfterWaveBoss = true;
                    panelUpgradeWeapon.SetActive(true);

                    //Debug.Log("BOSS WAVE");

                    //upgradeWeapon();
                    }
                    if (!WeaponUpgradeManager.isGamePaused)
                    {
                        NextWave();
                    }

                    else if (WeaponUpgradeManager.isExitUpgradeWeapon)
                    {
                        NextWave();
                    }
                }
   
                
            }
           
        }
    }

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
        timer = 0f;
        //Debug.Log("IN START WAVE");
        ScoreManager.wave = 1;
        //spawnedEnemyAmount = 2;s
        enemyKilled = 0;
        int tempAmount = 0;
        int[] currentPool = randomiseSpawnAmount(waves[0].enemyPrefabIndex, waves[0].maxWeight);
        spawnTimer = 0f;
        for (int i = 0; i < currentPool.Length; i++)
        {
            int tag = waves[0].enemyPrefabIndex[i];
            int amount = currentPool[i];
            tempAmount += amount;
            for (int j = 0; j < amount; j++)
            {
                Spawn(tag);
            }
        }
        Debug.Log("Wave Manager Wave : "+ ScoreManager.wave );
        Debug.Log("Spawned Enemy : " + tempAmount);

        spawnedEnemyAmount = tempAmount;
    }

    private void NextWave()
    {
        //Debug.Log("IN NEXT WAVE");
        timer = 0f;
        ScoreManager.wave++;
        enemyKilled = 0;
        int tempAmount = 0;
        int[] currentPool = randomiseSpawnAmount(waves[ScoreManager.wave-1].enemyPrefabIndex, waves[ScoreManager.wave-1].maxWeight);
        for (int i = 0; i < currentPool.Length; i++)
        {
            int tag = waves[ScoreManager.wave-1].enemyPrefabIndex[i];
            int amount = currentPool[i];
            tempAmount += amount;
            for (int j = 0; j < amount; j++)
            {
                Spawn(tag);
            }

        }
        Debug.Log("Wave Manager Wave : "+ ScoreManager.wave );
        Debug.Log("Spawned Enemy : " + tempAmount);
        spawnedEnemyAmount = tempAmount;      

    }
    private int[] randomiseSpawnAmount(int[] enemyPool,int weight)
    {
        // Every Mobs spawned minimum once
        // Using GCD might work better but ummm
        int initWeight = weight;
        int[] randomisedEnemyPool = new int[enemyPool.Length];
        int removedIndex;
        for (int i = 0; i < enemyPool.Length; i++)
        {
            randomisedEnemyPool[i] = 0;
        }
        for (int i = 0; i < enemyPool.Length; i++)
        {
            int temp = initWeight - GetWeight(enemyPool[i]);
            if(temp >= 0)
            {
                randomisedEnemyPool[i] += 1;
                initWeight = temp;
            }
            if(GetWeight(enemyPool[i]) == 0)
            {
                removedIndex = i;
            }
        }
        int countRepeated = 0;
        while(initWeight > 0 && countRepeated < 50)
        {
            int randomIndex = Random.Range(0, enemyPool.Length);
            if(GetWeight(enemyPool[randomIndex]) != 0)
            {
                int temp = initWeight - GetWeight(enemyPool[randomIndex]);
                if (temp >= 0)
                {
                    randomisedEnemyPool[randomIndex] += 1;
                    initWeight = temp;
                }
                else{
                    countRepeated++;
                }
            }
            else{
                countRepeated++;
            }
        }
        if(countRepeated >= 50)
        {
            Debug.Log("Randomise Spawn Amount Error; Can't get permutation.");
            Debug.Log("Using Default Spawn Amount");
            for (int i = 0; i < randomisedEnemyPool.Length; i++)
            {
                randomisedEnemyPool[i] = defaultPool[ScoreManager.wave-1][i];
            }


        }
        return randomisedEnemyPool;

    }
    public int GetWaveLength()
    {
        return waves.Length;
    }
    public int[] GetPool(int wave){
        return waves[wave].enemyPrefabIndex;
    }
    public int GetWaveMaxWeight(int wave){
        return waves[wave].maxWeight;
    }
    public int GetWeight(int tag)
    {
        return enemyWeight[tag];
    }

    private int[][] initDefaultPooling()
    {
        int[][] dPool = new int[6][];
        dPool[0] = new int[2] {2,4};
        Debug.Log(dPool[0][1]);
        dPool[1] = new int[2] {2,2};
        dPool[2] = new int[3] {1,4,4};
        dPool[3] = new int[3] {6,3,3};
        dPool[4] = new int[3] {10,3,6};
        dPool[5] = new int[4] {1,4,5,6};

        return dPool;
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

}
[System.Serializable]
public class enemyPool {

    public int[] enemyPrefabIndex;
    public int maxWeight;

}