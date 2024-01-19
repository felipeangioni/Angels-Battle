using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDropControll : MonoBehaviour
{
    public GameObject DragonDropper;

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

        if(!GameObject.FindWithTag("DragonAirDrop"))
        {
            if (SpawnTime > 5)
            {
                RandomizeSpawn = Random.value;
                if (RandomizeSpawn >= 0 && RandomizeSpawn < 0.16)
                {
                    Instantiate(DragonDropper, SpawnA.position, SpawnA.rotation);
                }
                if (RandomizeSpawn >= 0.16 && RandomizeSpawn < 0.32)
                {
                    Instantiate(DragonDropper, SpawnB.position, SpawnB.rotation);
                }
                if (RandomizeSpawn >= 0.32 && RandomizeSpawn < 0.48)
                {
                    Instantiate(DragonDropper, SpawnC.position, SpawnC.rotation);
                }
                if (RandomizeSpawn >= 0.48 && RandomizeSpawn < 0.64)
                {
                    Instantiate(DragonDropper, SpawnD.position, SpawnD.rotation);
                }
                if (RandomizeSpawn >= 0.64)
                {
                    Instantiate(DragonDropper, SpawnE.position, SpawnE.rotation);
                }
            }
        }

        if(SpawnTime > 5.1)
        {
            SpawnTime = 0;
        }

    }
}
