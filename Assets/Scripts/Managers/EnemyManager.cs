using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    //public GameObject enemy;
    public int spawnEnemy;
    public float spawnTime;
    public Transform[] spawnPoints;

    [SerializeField]
    public MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    //private int waveNumber = 0;
    private int enemySpawnAmount;
    private int enemyKilled;
    void Start ()
    {
        spawnTime = 3f;
        enemySpawnAmount = 2;
        enemyKilled = 0;
        Debug.Log("IN START ENEMY MANAGER");

        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        if (Player.modeGame.Equals("Wave"))
        {
            Debug.Log("SPAWN WAVE MODE");
            StartWave();
        }
        else
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
        
        //InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    private void Update()
    {
        Debug.Log("IN UPDATE ENEMY MANAGER");

        

        if (Player.modeGame.Equals("Wave"))
        {
            Debug.Log("SPAWN WAVE MODE IN UPDATE ENEMY MANAGER");
            if (enemyKilled >= enemySpawnAmount)
            {
                Debug.Log("Emang ini masuk ?");
                NextWave();
            }
        }
    }


    void Spawn ()
    {
        
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        // Menduplikasi enemy
        Instantiate(Factory.FactoryMethod(spawnEnemy), spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }

    private void StartWave()
    {
        Debug.Log("IN START WAVE");
        ScoreManager.wave = 1;
        enemySpawnAmount = 2;
        enemyKilled = 0;

        for (int i=0; i < enemySpawnAmount; i++)
        {
            Debug.Log("SPAWN");
            Spawn();
        }
    }

    private void NextWave()
    {
        Debug.Log("IN NEXT WAVE");

        ScoreManager.wave++;
        enemySpawnAmount += 2;
        enemyKilled = 0;


        for (int i = 0; i < enemySpawnAmount; i++)
        {
            Debug.Log("SPAWN");
            Spawn();
        }
    }

}
