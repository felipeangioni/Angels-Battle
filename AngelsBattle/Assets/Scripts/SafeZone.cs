using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public static float EdgeRelativeCenterDistanceSZ;
    public Vector3 EdgePosSZ;
    public Vector3 CenterPosSZ;

    public float ScaleSZ1;
    public float ScaleCenterSZ;

    public Vector3 SZ1Size;

    public Vector3 PositionPivotSZ1;
    public Vector3 PositionCentralSZ1;

    public Transform TransformPositionPivotSZ1;
    public Transform TransformPositionCentralSZ1;

    public float DistancePivotSZ1;


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

        //Getting the scaling of objects
        ScaleSZ1 = GameObject.FindWithTag("SZ1").transform.localScale.y;
        ScaleCenterSZ = GameObject.FindWithTag("SafeZoneCenter").transform.localScale.y;

        SZ1Size = GameObject.FindWithTag("SZ1").transform.localScale;

        if (ScaleCenterSZ > ScaleSZ1)
        {
            GameObject.FindWithTag("SafeZoneCenter").transform.localScale += new Vector3(-0.2f * (Time.deltaTime) * SZ1Size.x, -0.2f * (Time.deltaTime) * SZ1Size.y, 0f);
        }

        //Getting the distance of the pivot to center of safe zone

        TransformPositionCentralSZ1 = GameObject.FindWithTag("SafeZoneCenter").transform;
        TransformPositionPivotSZ1 = GameObject.FindWithTag("PivotSZ1").transform;

        DistancePivotSZ1 = Vector3.Distance(TransformPositionCentralSZ1.position, TransformPositionPivotSZ1.position);

        //Getting the position of the Vector3

        PositionCentralSZ1 = GameObject.FindWithTag("SafeZoneCenter").transform.position;
        PositionPivotSZ1 = GameObject.FindWithTag("PivotSZ1").transform.position;
        

        if(DistancePivotSZ1 > 0)
        {
            GameObject.FindWithTag("SafeZoneCenter").transform.position = Vector3.Lerp(PositionCentralSZ1, PositionPivotSZ1, 1.0f * Time.deltaTime);
        }

    }

    void OnGUI()
    {
        GUI.TextField(new Rect(10f, 10f, 130f, 20f), "EdgeToCenter:" + EdgeRelativeCenterDistanceSZ);
    }
}
