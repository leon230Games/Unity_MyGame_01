using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    EnemyCombat combat;
    bool canAttack = false;

	void Start () {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<EnemyCombat>();
	}
	
	
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            FaceTarget();
        }

        if (distance <= agent.stoppingDistance)
        {
            //Attack the target
            CharacterStats targetStats = target.GetComponent<CharacterStats>();

            //canAttack = true;

            //if (targetStats != null)
            //{
            if (agent.velocity.sqrMagnitude <= 0f)
            {
                combat.Attack(targetStats);
            }
            //}

            FaceTarget();
        }
        else
        {
            //canAttack = false;
        }
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

    public bool getCanAttack()
    {
        return canAttack;
    }


}
