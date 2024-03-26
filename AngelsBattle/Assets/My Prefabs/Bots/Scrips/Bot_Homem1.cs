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
        shoot = true;
        follow = false;
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("follow", follow);
        _animator.SetBool("shoot", shoot);

        //Getting the distance from Enemy
        enemyDistance = Vector3.Distance(transform.position, GameObject.FindWithTag("PivotPlayer").transform.position);

        //Follow the enemy
        if (enemyDistance > 10 && enemyDistance < 20)
        {
            follow = true;
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
        }
        else
        {
            shoot = false;
        }
    }
}
