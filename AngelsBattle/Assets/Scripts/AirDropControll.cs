using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDropControll : MonoBehaviour
{
    public GameObject Plane;

    public Transform SpawnA;
    public Transform SpawnB;
    public Transform SpawnC;
    public Transform SpawnD;
    public Transform SpawnE;

    public float SpawnTime;
    public float RandomizeSpawn;

    void Start()
    {
        
    }
    
    void Update()
    {
        SpawnTime += Time.deltaTime;

        if(!GameObject.FindWithTag("PlaneAirDrop"))
        {
            if (SpawnTime > 5)
            {
                RandomizeSpawn = Random.value;
                if (RandomizeSpawn >= 0 && RandomizeSpawn < 0.16)
                {
                    Instantiate(Plane, SpawnA.position, SpawnA.rotation);
                }
                if (RandomizeSpawn >= 0.16 && RandomizeSpawn < 0.32)
                {
                    Instantiate(Plane, SpawnB.position, SpawnB.rotation);
                }
                if (RandomizeSpawn >= 0.32 && RandomizeSpawn < 0.48)
                {
                    Instantiate(Plane, SpawnC.position, SpawnC.rotation);
                }
                if (RandomizeSpawn >= 0.48 && RandomizeSpawn < 0.64)
                {
                    Instantiate(Plane, SpawnD.position, SpawnD.rotation);
                }
                if (RandomizeSpawn >= 0.64)
                {
                    Instantiate(Plane, SpawnE.position, SpawnE.rotation);
                }
            }
        }

        if(SpawnTime > 5.1)
        {
            SpawnTime = 0;
        }

    }
}
