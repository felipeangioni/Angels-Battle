using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletVelocity = 2000.0f;

    public GameObject BloodEffect;

    void Start()
    {
          gameObject.GetComponent<Rigidbody>().velocity = transform.forward * (bulletVelocity) * Time.deltaTime;
    }


    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(BloodEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}
