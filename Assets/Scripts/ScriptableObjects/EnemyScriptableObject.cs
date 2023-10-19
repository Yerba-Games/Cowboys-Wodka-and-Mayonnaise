using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyScriptableObject",menuName ="EnemyStats")]
public class EnemyScriptableObject : ScriptableObject
{
    public int health;
    [Range(1,100)]public int damage;
    public float speed;
    public bool canMove;
}
