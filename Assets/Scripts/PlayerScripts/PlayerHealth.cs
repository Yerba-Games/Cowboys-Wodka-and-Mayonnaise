using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerHealth : MonoBehaviour
{
    //�ycie proste jest jak budowa T-55, bo jestem i�ynierem trzymam zaci�ni�t� pi��
    [SerializeField][ProgressBar("Health", 100, EColor.Red)]int health=1000;
    [SerializeField] Animator animator;

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
        //if (health <=25)
        //{
        //    AudioManager.instance.PlayOneShot(AudioManager.instance.PlayerLowSound, this.transform.position);
        //}
        if (health <= 0)
        {
            AudioManager.instance.PlayOneShot(AudioManager.instance.PlayerDeathSound, this.transform.position);
            animator.SetTrigger("Dead");
            gameObject.SetActive(false);
        }
        //I bang moge skurwysyn�w nokautowa� rozpierdalam czo�gi lekko ja i moja za�oga
    }
}
