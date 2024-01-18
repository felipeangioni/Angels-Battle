using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAirDrop : MonoBehaviour
{
    public float PlaneTime;
    private int airDropCount;

    public GameObject AirDrop;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (50) * Time.deltaTime);

        PlaneTime += Time.deltaTime;

        if(PlaneTime > 50f && airDropCount == 0)
        {
            Instantiate(AirDrop, transform.position, transform.rotation);

            airDropCount = 1;
        }

        if(PlaneTime > 100f )
        {
            Destroy(gameObject);
        }
    }
}
