using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] EnemysToSpawn[] enemysToSpawns;
    [SerializeField] int spawnCount=3;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public static bool SpawnEnemies()
    {
        if (instance.spawnCount >= 0)
        {
            instance.spawnCount--;
            instance.Spawn();
            return true;
        }
        GM.ActivateBossFight();
        return false;
    }
    private void Spawn()
    {
        foreach (var enemy in enemysToSpawns)
        {
            for (int i = 0; i < enemy.enemyNumber; i++)
            {
                int index = Random.Range(0, spawnPoints.Length);
                Debug.Log($@"spawnig at index: {index}");
                Instantiate(enemy.enemyType, spawnPoints[index]);
                EnemiesManager.EnemiesAlive(+1);
            }
        }
    }

}

