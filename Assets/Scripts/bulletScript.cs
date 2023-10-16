using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class bulletScript : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;
    [ShowNonSerializedField]private float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = PlayerWeapon.bulletSingletonSpeed;
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 force = bulletSpeed*transform.forward*Time.deltaTime;
        rb.AddForce(force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Debug.Log($@"{gameObject.name} hit");
    }
}
