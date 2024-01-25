using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float RelativeCenterDistanceSZ;
    public Vector3 EdgePosSZ;
    public Vector3 CenterPosSZ;
    public float Life;
    void Start()
    {
        Life = 100f;
    }

    void Update()
    {
        EdgePosSZ = transform.position;
        CenterPosSZ = GameObject.FindWithTag("SafeZoneCenter").transform.position;

        if (EdgePosSZ.x < 0)
        {
            EdgePosSZ.x = -EdgePosSZ.x;
        }

        if (EdgePosSZ.z < 0)
        {
            EdgePosSZ.z = -EdgePosSZ.z;
        }

        if (CenterPosSZ.x < 0)
        {
            CenterPosSZ.x = -CenterPosSZ.x;
        }

        if (CenterPosSZ.z < 0)
        {
            CenterPosSZ.z = -CenterPosSZ.z;
        }

        RelativeCenterDistanceSZ = Vector3.Distance(EdgePosSZ, CenterPosSZ);

        if(RelativeCenterDistanceSZ > SafeZone.RelativeCenterDistanceSZ)
        {
            Life -= 1 * Time.deltaTime;
        }
    } 

    void OnGUI()
    {
        GUI.TextField(new Rect(10f, 30f, 130f, 20f), "Distance:" + RelativeCenterDistanceSZ);
        GUI.TextField(new Rect(200f, 700f, 130f, 20f), "Life:" + RelativeCenterDistanceSZ);
    }
}
