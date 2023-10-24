using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyScriptableObject",menuName ="EnemyStats")]
public class EnemyScriptableObject : ScriptableObject
{
    public int health;
    [Range(1, 100)]public int damage;
    [Range(3,20)]public float speed=3.5f;
    [Range(3,10)]public float stopingDistance = 3f;
    public bool canMove;
    public int attackDelay;
    public GameObject enemyModel;
}
