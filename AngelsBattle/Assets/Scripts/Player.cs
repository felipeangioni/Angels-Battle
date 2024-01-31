using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float PlayerRelativeCenterDistanceSZ;
    public Vector3 PlayerPosSZ;
    public Vector3 CenterPosSZ;
    public float Life;
    public GameObject BloodScreen;


    private void Awake()
    {
        PlayerRelativeCenterDistanceSZ = 0f;
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        //Getting positions
        PlayerPosSZ = transform.position;
        CenterPosSZ = GameObject.FindWithTag("SafeZoneCenter").transform.position;

        //Locking negatives values
        if (PlayerPosSZ.x < 0)
        {
            PlayerPosSZ.x = -PlayerPosSZ.x;
        }

        if (PlayerPosSZ.y < 0)
        {
            PlayerPosSZ.y = -PlayerPosSZ.y;
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
        PlayerPosSZ.y = 0;
        CenterPosSZ.y = 0;

        //Getting distance from Player position to center position
        PlayerRelativeCenterDistanceSZ = Vector3.Distance(PlayerPosSZ, CenterPosSZ);

        if (PlayerRelativeCenterDistanceSZ > SafeZone.EdgeRelativeCenterDistanceSZ)
        {
            Life -= 1 * Time.deltaTime;

            BloodScreen.SetActive(true);
        }
        else
        {
            BloodScreen.SetActive(false);
        }
    }

    void OnGUI()
    {
        GUI.TextField(new Rect(10f, 30f, 130f, 20f), "Player distance:" + PlayerRelativeCenterDistanceSZ);
        GUI.TextField(new Rect(200f, 700f, 130f, 20f), "Life:" + Life);
    }
}
