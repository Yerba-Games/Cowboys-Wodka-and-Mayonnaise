using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] EnemysToSpawn[] enemysToSpawns;
    [SerializeField] int spawnCount=3;
    [SerializeField] GameObject[] pickUp;
    [SerializeField] TMP_Text waveProgres;
    int maxSpawns,endleesWaveNumber=0;
    bool isEndless;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        maxSpawns = spawnCount;
        if (EndLessTriger.endless == true)//for endless mode
        {
            waveProgres.text="0";
            isEndless = true;
            return;
        }
        waveProgres.text = $@"{spawnCount+  1}/{maxSpawns+1}";
    }
    public static bool SpawnEnemies()
    {
        if (instance.isEndless=false)
        {
            if (instance.spawnCount >= 0)
            {
                instance.spawnCount--;
                instance.waveProgres.text = $@"{instance.spawnCount + 1}/{instance.maxSpawns + 1}";
                instance.Spawn();
                return true;
            }
            instance.waveProgres.text = $@"{instance.spawnCount + 1}/{instance.maxSpawns + 1}";
            GM.ActivateBossFight();
            return false;
        }
        instance.Spawn();
        instance.endleesWaveNumber += 1;
        instance.waveProgres.text =$@"{instance.endleesWaveNumber}";
        return true;

    }
        private void Spawn()
    {
        pickUp[Random.Range(pickUp.Length - 1, 0)].SetActive(true);
        foreach (var enemy in enemysToSpawns)
        {
            for (int i = 0; i < enemy.enemyNumber+endleesWaveNumber; i++)
            {
                int index = Random.Range(0, spawnPoints.Length);
                Debug.Log($@"spawnig at index: {index}");
                Instantiate(enemy.enemyType, spawnPoints[index]);
                EnemiesManager.EnemiesAlive(+1);
            }
        }
    }

}

