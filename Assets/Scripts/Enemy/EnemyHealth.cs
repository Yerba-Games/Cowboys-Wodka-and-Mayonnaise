using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]EnemyScriptableObject enemyScriptableObject;
    [ProgressBar("Health", 100, EColor.Red)][ShowNonSerializedField] int health;
    [SerializeField] Animator animator;
    GameObject model;

    // Start is called before the first frame update
    void Start()
    { 
        health = enemyScriptableObject.health;
        //speed = enemyScriptableObject.speed;
        //canMove = enemyScriptableObject.canMove;
        //model = enemyScriptableObject.enemyModel;
        //GameObject TempModel;
        //Animator modelAnimator;
        //TempModel =Instantiate(model, transform);
        //TempModel.transform.localScale = new Vector3(0.25f,0.25f,0.25f);
        //animator=TempModel.AddComponent<Animator>();
        //animator.avatar = avatar;
        //animator.runtimeAnimatorController = animatorController;
        //GetComponent<EnemyHealth>().animator = animator;
        //GetComponent<EnemyNavigationScript>().animator = animator;
        //if (gameObject.GetComponentInChildren<EnemyGun>()!=null)
        //{
        //    gameObject.GetComponentInChildren<EnemyGun>().animator = animator;
        //}
        //if (TryGetComponent<EnemyMelee>(out EnemyMelee component1))
        //{
        //    component1.animator = animator;
        //}
        

        //enemyModel.transform.SetParent(transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hit");
        AudioManager.instance.PlayOneShot(AudioManager.instance.EnemyHitSound, this.transform.position);
        if (health <= 0)
        {
            animator.SetTrigger("Dead");
            AudioManager.instance.PlayOneShot(AudioManager.instance.EnemyDeathSound, this.transform.position);
            EnemiesManager.EnemyDies();
            Destroy(gameObject);
        }
    }
}
