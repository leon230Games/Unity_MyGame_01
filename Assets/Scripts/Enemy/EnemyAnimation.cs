using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyController))]
public class EnemyAnimation : MonoBehaviour {

    const float animationSmoothTime = 0.1f;

    Animator animator;
    NavMeshAgent agent;
    EnemyCombat enemyCombat;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();

        enemyCombat = GetComponent<EnemyCombat>();
        enemyCombat.onAttack += AttackAnimation;
    }

    void Update() {
        float speedPercent = agent.velocity.magnitude / agent.speed;

        animator.SetFloat("speedPercent", speedPercent, animationSmoothTime, Time.deltaTime);
    }

    void AttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    //bool CheckIfAgentPathing()
    //{
    //    // Check if we've reached the destination
    //    if (!agent.pathPending)
    //    {
    //        if (agent.remainingDistance <= agent.stoppingDistance)
    //        {
    //            //if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
    //            //{
    //            return true;
    //            //}
    //        }
    //    }

    //    return true;
    //}




}
