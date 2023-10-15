using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {

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
