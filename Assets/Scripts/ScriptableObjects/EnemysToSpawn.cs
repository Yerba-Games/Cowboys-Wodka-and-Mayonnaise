using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "SpawnEnemy")]
public class EnemysToSpawn : ScriptableObject
{
    public int enemyNumber;
    public GameObject enemyType;

}
