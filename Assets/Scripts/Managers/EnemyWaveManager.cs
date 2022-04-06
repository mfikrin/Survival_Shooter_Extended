using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public int[] spawnEnemy;
    public float spawnTime;
    public Transform[] spawnPoints;

    [SerializeField]
    public MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    //private int waveNumber = 0;
    private int enemySpawnAmount;
    public static int enemyKilled;
    void Start()
    {
        //spawnEnemy = new int[enemySpawnAmount];
        spawnTime = 3f;
        enemySpawnAmount = spawnEnemy.Length;
        enemyKilled = 0;
        Debug.Log("IN START ENEMY MANAGER");

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
        if (enemyKilled >= enemySpawnAmount)
        {
            Debug.Log("Wave SUDAH SELESAI GAN ?");
            NextWave();
        }
    }


    void Spawn(int tag)
    {

        if (playerHealth.currentHealth <= 0f)
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
        int addEnemyAmount = 2;
        enemySpawnAmount += addEnemyAmount;

        int[] arrayAddEnemey = new int[] {0,0};

        List<int> ListSpawnEnemy = spawnEnemy.ToList();

        foreach (var tag in arrayAddEnemey)
        {
            ListSpawnEnemy.Add(tag);
        }

        spawnEnemy = ListSpawnEnemy.ToArray();

        Debug.Log(spawnEnemy);
        //spawnEnemy = new int[enemySpawnAmount];

        ScoreManager.wave++;
        
        enemyKilled = 0;


        for (int i = 0; i < enemySpawnAmount; i++)
        {
            int tag = spawnEnemy[i];
            Debug.Log("SPAWN");
            Spawn(tag);
        }
    }
}
