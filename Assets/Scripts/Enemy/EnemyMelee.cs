using System.Collections;
using UnityEngine;
using FMODUnity;

public class EnemyMelee : MonoBehaviour
{
    //JEBA� KURWA TEN SKRYPT  �YGAM JU� NIM ZA D�UGO NA NIEGO ZESZ�O PIERDOLE TO WYCHODZE DZIA�A TO TU NIE WRACAM   
    private bool canAttack=true;
    [SerializeField]EnemyScriptableObject enemyStats;
    private int attackDelay;
    private int damage;
    private Transform playerPositon;
    private float maxDistans;
    [SerializeField]Animator animator;
    private void OnEnable()
    {
       attackDelay=enemyStats.attackDelay;
        damage=enemyStats.damage;
        playerPositon = PlayerGetTransform.playerTransform;
        maxDistans = enemyStats.stopingDistance;
    }
    private void Update()
    {
        //Debug.DrawRay(transform.position, playerPositon.position);
        
    }
    private void FixedUpdate()
    {
        if (canAttack)
        {
            //RaycastHit hit;
            //Ray ray = new Ray(transform.position, playerPositon.position);
            //Physics.Raycast(ray, out hit);

            //if (Physics.Raycast(ray, out hit, maxDistans))
            //{
            //    Debug.Log("Attacking");
            //    canAttack = false;
            //    StartCoroutine(Attack(hit.collider.gameObject));
            //}
            if (Vector3.Distance(transform.position,playerPositon.position)<=maxDistans)
            {
                Debug.Log("Attacking");
                canAttack = false;
                StartCoroutine(Attack(playerPositon.gameObject));
            }
        }

    }

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (canAttack)
    //    {
    //        Debug.Log("Attacking");
    //        StartCoroutine(Attack(collision.gameObject));
    //        canAttack=false;
    //    }
    //}


    IEnumerator Attack(GameObject target)
    {
        animator.SetTrigger("Attack");
        Debug.Log("atacking faze 2");
        target.gameObject.SendMessage("EnemyHit", damage, SendMessageOptions.DontRequireReceiver);
        AudioManager.instance.PlayOneShot(AudioManager.instance.EnemyMeleeSound, this.transform.position);
        yield return new WaitForSeconds(attackDelay);
        Debug.Log($@"cooldown stoped at {Time.time}");
        canAttack = true;
    }
}
