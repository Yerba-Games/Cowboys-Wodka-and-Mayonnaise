using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]EnemyScriptableObject enemyScriptableObject;
    int health;
    float speed;
    bool canMove;
    // Start is called before the first frame update
    void Start()
    { 
        health = enemyScriptableObject.health;
        speed = enemyScriptableObject.speed;
        canMove = enemyScriptableObject.canMove;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
