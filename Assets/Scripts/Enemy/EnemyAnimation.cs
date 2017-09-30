using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour {

    const float animationSmoothTime = 0.1f;

    Animator animator;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        float speedPercent = agent.velocity.magnitude / agent.speed;

        animator.SetFloat("speedPercent", speedPercent, animationSmoothTime, Time.deltaTime);

    }
}
