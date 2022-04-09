using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] enemyPrefab;
    public int[] enemyWeight;
    [SerializeField] public enemyPool[] waves;

    public GameObject FactoryMethod(int tag)
    {
        GameObject enemy = enemyPrefab[tag];
        return enemy;
    }
    public int GetWeight(int tag)
    {
        return enemyWeight[tag];
    }

    public int[] GetPool(int wave){
        return waves[wave].enemyPrefabIndex;
    }
}

[System.Serializable]
public class enemyPool {

    public int[] enemyPrefabIndex;
    public int maxWeight;

}