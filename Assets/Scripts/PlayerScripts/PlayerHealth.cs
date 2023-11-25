using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerHealth : MonoBehaviour
{
    //�ycie proste jest jak budowa T-55, bo jestem i�ynierem trzymam zaci�ni�t� pi��
    [SerializeField]int health=1000,lowhealt =25;
    [SerializeField] Animator animator;
    bool lowHealthNotPlyed = true;

    // Update is called once per frame
    private void Start()
    {
        UI.SetMaxHP(health);
        AudioManager.instance.PlayLoop(AudioManager.instance.WorldAmbient, new Vector2(0, 0));

    }
    public void EnemyHit(int damage)
    {
        health -= damage;
        UI.SetHealth(health);
        animator.SetTrigger("Hit");
        if (health <= lowhealt&&lowHealthNotPlyed!=true)
        {
            lowHealthNotPlyed=false;
            AudioManager.instance.PlayOneShot(AudioManager.instance.PlayerLowSound, this.transform.position);
        }
        if (health <= 0)
        {
            AudioManager.instance.PlayOneShot(AudioManager.instance.PlayerDeathSound, this.transform.position);
            animator.SetTrigger("Dead");
            gameObject.SetActive(false);
        }
        //I bang moge skurwysyn�w nokautowa� rozpierdalam czo�gi lekko ja i moja za�oga
    }
    public void AddHealth(int ammount)
    {
        health += ammount;
        UI.SetHealth(health);
        if (health >= lowhealt&& lowHealthNotPlyed != false)
        {
            lowHealthNotPlyed = true;
        }
    }
}
