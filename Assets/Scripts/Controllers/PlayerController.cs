using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCombat))]
public class PlayerController : MonoBehaviour {

    PlayerCombat playerCombat;

    private void Start()
    {
        playerCombat = GetComponent<PlayerCombat>();
    }

    void Update () {

        if (GameManager.instance.inputController.primaryAttack)
        {
            Debug.Log("Clicked left mouse button");
            playerCombat.Attack(null);
        }
	}
}
