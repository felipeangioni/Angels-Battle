using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life1s : MonoBehaviour
{
    public float LifeTime;

    void Start()
    {

    }

    void Update()
    {
        LifeTime += Time.deltaTime;

        if (LifeTime > 1f)
        {
            Destroy(gameObject);
        }
    }
}
