using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] enemyPrefab;

    public GameObject FactoryMethod(int tag)
    {
        GameObject enemy = enemyPrefab[tag];
        return enemy;
    }

}