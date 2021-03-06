﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator animator;
    private PlayerCombat playerCombat;

	// Use this for initialization
	void Awake () {
        animator = GetComponentInChildren<Animator>();
        playerCombat = GetComponent<PlayerCombat>();
	}

    private void Start()
    {
        playerCombat.onAttack += AttackTrigger;
    }

    // Update is called once per frame
    void Update () {
        animator.SetFloat(gameConstants.vertical, GameManager.instance.inputController.Vertical);
        animator.SetFloat(gameConstants.horizontal, GameManager.instance.inputController.Horizontal);

        animator.SetBool(gameConstants.isWalking, GameManager.instance.inputController.isWalking);
        animator.SetBool(gameConstants.isSprinting, GameManager.instance.inputController.isSprinting);
        animator.SetBool(gameConstants.isCrouching, GameManager.instance.inputController.isCrouched);

    }

    void AttackTrigger()
    {
        animator.SetTrigger("Attack");
    }




}
