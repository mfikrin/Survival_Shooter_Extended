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
    //private int enemySpawnAmount;
    //private int enemyKilled;
    void Start ()
    { 
        InvokeRepeating(nameof(Spawn), spawnTime, spawnTime);
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
}
