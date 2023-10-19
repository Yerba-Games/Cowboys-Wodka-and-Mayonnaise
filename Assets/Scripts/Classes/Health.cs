using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public void Damage(int damage, int health)
    {
        health-=damage;
        if (health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Debug.Log("dead");
    }

}
