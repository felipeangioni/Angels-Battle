using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDrop : MonoBehaviour
{
    public GameObject Parachute;
    public GameObject BlueSmoke;

    void Start()
    {
        BlueSmoke.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Parachute.SetActive(false);
        BlueSmoke.SetActive(true);
    }
}
