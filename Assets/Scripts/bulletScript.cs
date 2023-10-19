using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;
    [SerializeField] private BulletScriptableObject bulletStats;
    private float speed;
    private int damage;
    bool isPlayersBullet;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        speed=bulletStats.speed;
        damage=bulletStats.damage;
        isPlayersBullet = bulletStats.isPlayersBullet;
    }
    void Update()
    { 
        Vector3 force = speed*transform.forward*Time.deltaTime;
        rb.AddForce(force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isPlayersBullet)
        {
            collision.gameObject.SendMessage("Hit", damage, 0);
            Destroy(gameObject);
            Debug.Log($@"{gameObject.name} hit");
            return;
        }
        if (!isPlayersBullet)
        {
            collision.gameObject.SendMessage("EnemyHit", damage, 0);
            Destroy(gameObject);
            Debug.Log($@"{gameObject.name} hit");
            return;
        }
    }
}
