using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCombat))]
public class PlayerController : MonoBehaviour {

    PlayerCombat playerCombat;
    Animator animator;

    bool isAttacking = false;

    private void Start()
    {
        playerCombat = GetComponent<PlayerCombat>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update () {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Sword_slash"))
        {
            isAttacking = true;
        }
        else {
            isAttacking = false;
        }

        if (GameManager.instance.inputController.primaryAttack)
        {
            Debug.Log("Clicked left mouse button");
            playerCombat.Attack(null);
        }
	}

    public bool getIsAttacking()
    {
        return isAttacking;
    }

}
