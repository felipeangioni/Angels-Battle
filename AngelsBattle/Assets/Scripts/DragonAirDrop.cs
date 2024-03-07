using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAirDrop : MonoBehaviour
{
    public float DragonTime;
    private int airDropCount;

    public GameObject AirDrop;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * 20 * Time.deltaTime);

        DragonTime += Time.deltaTime;

        if(DragonTime > 20f && airDropCount == 0)
        {
            Instantiate(AirDrop, transform.position, transform.rotation);

            airDropCount = 1;
        }

        if(DragonTime > 60f )
        {
            Destroy(gameObject);
        }
    }
}
