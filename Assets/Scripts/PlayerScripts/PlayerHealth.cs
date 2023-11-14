using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerHealth : MonoBehaviour
{
    //�ycie proste jest jak budowa T-55, bo jestem i�ynierem trzymam zaci�ni�t� pi��
    [SerializeField][ProgressBar("Health", 100, EColor.Red)]int health=1000;

    // Update is called once per frame
    private void Start()
    {
        UI.SetMaxHP(health);
    }
    public void EnemyHit(int damage)
    {
        health -= damage;
        UI.SetHealth(health);
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        //I bang moge skurwysyn�w nokautowa� rozpierdalam czo�gi lekko ja i moja za�oga
    }
}
