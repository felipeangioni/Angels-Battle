using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life20s : MonoBehaviour
{
    public float LifeTime;

    void Start()
    {
        
    }

    void Update()
    {
        LifeTime += Time.deltaTime;

        if(LifeTime > 30f)
        {
            Destroy(gameObject);
        }
    }

}
