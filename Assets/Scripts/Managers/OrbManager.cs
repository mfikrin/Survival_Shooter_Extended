using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public int spawnOrb; // index orb


    public float spawnTime;
    //public float spawnLifeTime; // destroy after spawnLifeTime second
    public Transform[] spawnPoints;

    [SerializeField]
    public MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnTime, spawnTime);
    }

    void Spawn()
    {
        if ((playerHealth.currentHealth <= 0f && Player.modeGame != "SuddenDeath") || (playerHealth.currentHealth < 0 && Player.modeGame.Equals("SuddenDeath")))
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Menduplikasi orb
        Instantiate(Factory.FactoryMethod(spawnOrb), spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

}
