﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;

    Transform target;
    //NavMeshAgent agent;

	void Start () {
        target = PlayerManager.instance.player.transform;
        //agent = GetComponent<NavMeshAgent>();
	}
	
	
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            //agent.SetDestination(target.position);

            FaceTarget();
        }

        //if (distance <= agent.stoppingDistance)
        //{
        //    //Attack the target

            //FaceTarget();
            

        //}
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);


    }
}