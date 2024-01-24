using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public static float RelativeCenterDistanceSZ;
    public Vector3 EdgePosSZ;
    public Vector3 CenterPosSZ;
    void Start()
    {
        
    }

    
    void Update()
    {
        EdgePosSZ = transform.position;
        CenterPosSZ = GameObject.FindWithTag("SafeZoneCenter").transform.position;

        if(EdgePosSZ.x < 0)
        {
            EdgePosSZ.x = -EdgePosSZ.x;
        }

        if(EdgePosSZ.z < 0)
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
    }
}
