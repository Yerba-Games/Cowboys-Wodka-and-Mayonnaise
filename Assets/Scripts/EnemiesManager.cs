using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager instance;
    [SerializeField] private int privateEnemiesAlive;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public static int EnemiesAlive(int value)
    {
        instance.privateEnemiesAlive += value;
        return value;
    }
    public static bool EnemyDies()
    {
        instance.privateEnemiesAlive--;
        if (instance.privateEnemiesAlive <= 0)
        {
            SpawnManager.SpawnEnemies();
        }
        return true;
    }
}
