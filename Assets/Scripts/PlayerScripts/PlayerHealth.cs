using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //�ycie proste jest jak budowa T-55, bo jestem i�ynierem trzymam zaci�ni�t� pi��
    [SerializeField][ProgressBar("Health", 100, EColor.Red)]int health=100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        //I bang moge skurwysyn�w nokautowa� rozpierdalam czo�gi lekko ja i moja za�oga
    }
}
