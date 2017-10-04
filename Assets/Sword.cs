using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon {

    [SerializeField] Transform weaponPlaceholder;
    PlayerController playerController;

    public override void Start()
    {
        base.Start();
        //Attach weapon to placeholder
        transform.SetParent(weaponPlaceholder);
        playerController = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name != gameConstants.playerColliderName && playerController.getIsAttacking())
        {
            Debug.Log("Sword hitted " + collider.name);
        }
        
    }
}
