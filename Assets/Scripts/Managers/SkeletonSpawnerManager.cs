using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawnerManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public int spawnEnemy;
    public float spawnTime = 3f;
    public Vector3 spawnPoint;
    public float placeX;
    public float placeZ;

    [SerializeField]
    public MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start ()
    {
        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        placeX = Random.Range(-20,20);
        placeZ = Random.Range(-20,20);
        spawnPoint = new Vector3(placeX,0,placeZ);
        Quaternion spawnRotation = Quaternion.identity;
        // Menduplikasi enemy
        Instantiate(Factory.FactoryMethod(spawnEnemy),spawnPoint ,spawnRotation);
        

    }
}
