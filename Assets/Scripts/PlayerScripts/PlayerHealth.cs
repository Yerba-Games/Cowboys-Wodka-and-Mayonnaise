using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerHealth : MonoBehaviour
{
    //�ycie proste jest jak budowa T-55, bo jestem i�ynierem trzymam zaci�ni�t� pi��
    [SerializeField][ProgressBar("Health", 100, EColor.Red)]int health=1000;
    [SerializeField] private EventReference playerDeathSound;
    [SerializeField] private EventReference playerHitSound;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyHit(int damage)
    {
        health -= damage;
        AudioManager.instance.PlayOneShot(playerHitSound, this.transform.position); 
        if (health <= 0)
        {
            AudioManager.instance.PlayOneShot(playerDeathSound, this.transform.position); 
            gameObject.SetActive(false);
        }
        //I bang moge skurwysyn�w nokautowa� rozpierdalam czo�gi lekko ja i moja za�oga
    }
}
