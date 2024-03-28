using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Bot_Homem1 : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;
    private bool shoot;
    private bool follow;
    private float enemyDistance;

    public GameObject Bullet;
    public Transform SpawnWeapon;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

        shoot = true;
        follow = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        //Getting the distance from Enemy
        enemyDistance = Vector3.Distance(transform.position, GameObject.FindWithTag("PivotPlayer").transform.position);

        //Follow the enemy
        if (enemyDistance > 10 && enemyDistance < 20)
        {
            follow = true;
            _agent.destination = GameObject.FindWithTag("PivotPlayer").transform.position;
        }
        else
        {
            follow = false;
        }

        //Shot the enemy
        if (enemyDistance < 10 )
        {
            shoot = true;
            Instantiate(Bullet, SpawnWeapon.transform.position, SpawnWeapon.transform.rotation);

            //To get our position relative to the player
            Vector3 relativePos = transform.position - GameObject.FindWithTag("PivotPlayer").transform.position;

            //Rotate to enemy
            Quaternion rotation = Quaternion.LookRotation(-relativePos, Vector3.up);
            transform.rotation = rotation;
        }
        else
        {
            shoot = false;
        }

        _animator.SetBool("follow", follow);
        _animator.SetBool("shoot", shoot);
    }
}
