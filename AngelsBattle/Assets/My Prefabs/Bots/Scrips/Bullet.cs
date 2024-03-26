using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletVelocity;

    void Start()
    {
          gameObject.GetComponent<Rigidbody>().velocity = transform.forward * bulletVelocity;
    }


    void Update()
    {
        
    }
}
