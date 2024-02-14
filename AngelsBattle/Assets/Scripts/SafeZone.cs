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

    public float DistancePivotSZ1;

    public float TimeSZ;
    public int ControllSZ;

    public GameObject SZ1;

    void Start()
    {
        TimeSZ = 4;
        ControllSZ = 0;
    }

    void Update()
    {
        //Getting Edge and Center positions
        EdgePosSZ = transform.position;
        CenterPosSZ = GameObject.FindWithTag("SafeZoneCenter").transform.position;

        //Locking negatives values for Edge
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

        //Set the Up axes aways in zero, cause i dont need to change this axes; 
        EdgePosSZ.y = 0;
        CenterPosSZ.y = 0;

        //Getting distance from Edge position to center position
        EdgeRelativeCenterDistanceSZ = Vector3.Distance(EdgePosSZ, CenterPosSZ);

        //*-------------------------------------------------------------------------------*//
        //*-------------------------------------------------------------------------------*//
        //SAFE ZONE SYSTEM

        if (GameObject.FindWithTag("PivotSZ1"))

        {
                //Getting the scaling of objects
                ScaleSZ1 = GameObject.FindWithTag("PivotSZ1").transform.localScale.y;
                ScaleCenterSZ = GameObject.FindWithTag("SafeZoneCenter").transform.localScale.y;

                SZ1Size = GameObject.FindWithTag("PivotSZ1").transform.localScale;

                if (ScaleCenterSZ > ScaleSZ1)
                {
                    GameObject.FindWithTag("SafeZoneCenter").transform.localScale += new Vector3(-0.2f * (Time.deltaTime) * SZ1Size.x, -0.2f * (Time.deltaTime) * SZ1Size.y, 0f);
                }

                //*-------------------------------------------------------------------------------*//
                //*-------------------------------------------------------------------------------*//

                //Getting the position of the Pivot and Safe zone

                PositionCentralSZ1 = GameObject.FindWithTag("SafeZoneCenter").transform.position;
                PositionPivotSZ1 = GameObject.FindWithTag("PivotSZ1").transform.position;

                //Getting the distance from pivot to center of safe zone
                DistancePivotSZ1 = Vector3.Distance(PositionCentralSZ1, PositionPivotSZ1);


                if (DistancePivotSZ1 > 0)
                {
                    GameObject.FindWithTag("SafeZoneCenter").transform.position = Vector3.Lerp(PositionCentralSZ1, PositionPivotSZ1, 1.0f * Time.deltaTime);
                }

        }

        //Safe zone chain

        TimeSZ -= 0.03f * Time.deltaTime;

        if (TimeSZ < 3)
        {
            if(!GameObject.FindWithTag("PivotSZ1") && ControllSZ == 0)
            {
                Instantiate(SZ1, GameObject.FindWithTag("SafeZoneCenter").transform.position, GameObject.FindWithTag("SafeZoneCenter").transform.rotation);
                ControllSZ = 1;
            }
        }

    }

    void OnGUI()
    {
        GUI.TextField(new Rect(10f, 10f, 130f, 20f), "EdgeToCenter:" + EdgeRelativeCenterDistanceSZ);
        GUI.TextField(new Rect(500f, 10f, 130f, 20f), "TimeSZ:" + TimeSZ);
    }
}
