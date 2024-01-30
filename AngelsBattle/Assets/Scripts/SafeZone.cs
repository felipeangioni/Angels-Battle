using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public static float EdgeRelativeCenterDistanceSZ;
    public Vector3 EdgePosSZ;
    public Vector3 CenterPosSZ;

    void Update()
    {
        //Getting positions
        EdgePosSZ = transform.position;
        CenterPosSZ = GameObject.FindWithTag("SafeZoneCenter").transform.position;

        //Locking negatives values
        if (EdgePosSZ.x < 0)
        {
            EdgePosSZ.x = -EdgePosSZ.x;
        }

        if(EdgePosSZ.y < 0)
        {
            EdgePosSZ.y = -EdgePosSZ.y;
        }

        if (CenterPosSZ.x < 0)
        {
            CenterPosSZ.x = -CenterPosSZ.x;
        }

        if (CenterPosSZ.z < 0)
        {
            CenterPosSZ.z = -CenterPosSZ.z;
        }

        //Set the Up axes aways in zero; 
        EdgePosSZ.y = 0;
        CenterPosSZ.y = 0;

        //Getting distance from Edge position to center position
        EdgeRelativeCenterDistanceSZ = Vector3.Distance(EdgePosSZ, CenterPosSZ);
    }

    void OnGUI()
    {
        GUI.TextField(new Rect(10f, 10f, 130f, 20f), "EdgeToCenter:" + EdgeRelativeCenterDistanceSZ);
    }
}
