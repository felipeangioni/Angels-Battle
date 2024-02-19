using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life10s : MonoBehaviour
{
    public float LifeTime;

    void Start()
    {
        
    }

    void Update()
    {
        LifeTime += Time.deltaTime;

        if(LifeTime > 10f)
        {
            Destroy(gameObject);
        }
    }



}
