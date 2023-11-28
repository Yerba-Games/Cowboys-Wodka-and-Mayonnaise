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
        rb.drag = 0;
        rb.velocity = bulletStats.speed * transform.forward;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (bulletStats.isPlayersBullet)
        {
            collision.gameObject.SendMessage("Hit", bulletStats.damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
            Debug.Log($@"{gameObject.name} hit");
            return;
        }
        if (!bulletStats.isPlayersBullet)
        {
            collision.gameObject.SendMessage("EnemyHit", bulletStats.damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
            Debug.Log($@"{gameObject.name} hit");
            return;
        }
    }
}
