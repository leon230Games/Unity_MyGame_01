using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for simple mesh attached to hand

public class HandSimpleWeapon : Weapon {

    [SerializeField] Transform weaponPlaceholder;

    public override void Start()
    {
        base.Start();
        //Attach weapon to placeholder
        transform.SetParent(weaponPlaceholder);
    }


    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Hitted " + collider.name);
    }
}
