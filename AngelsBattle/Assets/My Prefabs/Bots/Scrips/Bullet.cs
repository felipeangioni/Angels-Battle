using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletVelocity = 2000.0f;

    void Start()
    {
          gameObject.GetComponent<Rigidbody>().velocity = transform.forward * (bulletVelocity) * Time.deltaTime;
    }


    void Update()
    {
        
    }
}
