using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] EnemysToSpawn[] enemysToSpawns;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public static void SpawnEnemies()
    {
        instance.Spawn();
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

