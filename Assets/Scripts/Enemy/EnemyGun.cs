using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    private bool canAttack = true;
    bool aimToY = false;
    [SerializeField]GameObject bullet, gunEnd;
    int magazine = 6, relodeTime = 2;
    [ShowNonSerializedField] private int currentMagazine;
    [SerializeField] EnemyScriptableObject enemyStats;
    private int attackDelay;
    private float maxDistans;
    Vector3 aim;
    private bool isReloding;
    Transform playerPositon;
    // Start is called before the first frame update
    void Start()
    {
        playerPositon = PlayerGetTransform.playerTransform;
        attackDelay=enemyStats.attackDelay;
        magazine = enemyStats.magazine;
        relodeTime=enemyStats.relodeTime;
        maxDistans = enemyStats.maxShootingDistans;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Aim();
        if (canAttack)
        {
            //Ray ray = new Ray(transform.position, playerPositon.position);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, maxDistans))
            //{
            //    Debug.Log("Attacking");
            //    Shoot();
            //}
            if (Vector3.Distance(transform.position, playerPositon.position) <= maxDistans) 
            {
                Debug.Log("Attacking");
                Shoot();
            }

        }
    }
    private void Aim()
    {
        //Calculate the direction
       aim = playerPositon.position - transform.position;
        //Ignore the height difference.
        if (!aimToY) { aim.y = 0; }
        transform.forward = aim;
    }
    void Shoot()
    {
        if (!isReloding)
        {
            Debug.Log("piu");
            AudioManager.instance.PlayOneShot(AudioManager.instance.EnemyShotSound, this.transform.position);
            Instantiate(bullet, gunEnd.transform.position, gunEnd.transform.rotation);
            //tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward*bulletSpeed, ForceMode.Impulse);
            Relode();
            canAttack = false;
            StartCoroutine(AttackDelay());
        }
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;

    }

    
    #region Reloding
    private void Relode()
    {
        currentMagazine--;
        if (currentMagazine <= 0)
        {
            isReloding = true;
            StartCoroutine(Reloding());
        }
    }
    IEnumerator Reloding()
    {
        yield return new WaitForSeconds(relodeTime);
        currentMagazine = magazine;
        isReloding = false;
    }
    #endregion
}
