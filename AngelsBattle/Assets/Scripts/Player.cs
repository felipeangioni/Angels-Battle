using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float PlayerRelativeCenterDistanceSZ;
    public Vector3 EdgePosSZ;
    public Vector3 CenterPosSZ;
    public float Life;
    void Start()
    {
        Life = 100f;
    }

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

        if (EdgePosSZ.y < 0)
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
        EdgePosSZ.z = 0;
        CenterPosSZ.y = 0;

        //Getting distance from Edge position to center position
        PlayerRelativeCenterDistanceSZ = Vector3.Distance(EdgePosSZ, CenterPosSZ);

        if(PlayerRelativeCenterDistanceSZ > SafeZone.RelativeCenterDistanceSZ)
        {
            Life -= 1 * Time.deltaTime;
        }
    } 

    void OnGUI()
    {
        GUI.TextField(new Rect(10f, 30f, 130f, 20f), "Player distance:" + PlayerRelativeCenterDistanceSZ);
        GUI.TextField(new Rect(200f, 700f, 130f, 20f), "Life:" + Life);
    }
}
