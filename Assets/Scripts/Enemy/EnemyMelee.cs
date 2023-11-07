using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    //JEBAÆ KURWA TEN SKRYPT  ¯YGAM JU¯ NIM ZA D£UGO NA NIEGO ZESZ£O PIERDOLE TO WYCHODZE DZIA£A TO TU NIE WRACAM   
    private bool canAttack=true;
    [SerializeField]EnemyScriptableObject enemyStats;
    private int attackDelay;
    private int damage;
    private Transform playerPositon;
    private float maxDistans;
    private void OnEnable()
    {
       attackDelay=enemyStats.attackDelay;
        damage=enemyStats.damage;
        playerPositon = PlayerGetTransform.playerTransform;
        maxDistans = enemyStats.stopingDistance+1.5f;
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, playerPositon.position);
        
    }
    private void FixedUpdate()
    {
        if (canAttack)
        {
            RaycastHit hit;
            Ray ray= new Ray(transform.position, playerPositon.position);
            Physics.Raycast(ray, out hit);

            //if (Physics.Raycast(ray,out hit,maxDistans)) 
            //{
            //    Debug.Log("Attacking");
            //    canAttack = false;
            //    StartCoroutine(Attack(hit.collider.gameObject));
            //}
            if (transform.position.x - playerPositon.position.x <= maxDistans
           || playerPositon.position.x - transform.position.x <= maxDistans
           || playerPositon.position.z - transform.position.z <= maxDistans
           || transform.position.z - playerPositon.position.z <= maxDistans)
            {
                Debug.Log("Attacking");
                StartCoroutine(Attack(hit.collider.gameObject));
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
        Debug.Log("atacking faze 2");
        target.gameObject.SendMessage("EnemyHit", damage, SendMessageOptions.DontRequireReceiver);
        yield return new WaitForSeconds(attackDelay);
        Debug.Log($@"cooldown stoped at {Time.time}");
        canAttack = true;
    }
}
