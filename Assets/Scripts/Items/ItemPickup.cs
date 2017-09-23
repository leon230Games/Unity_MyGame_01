﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picking up items...." + item.name);
        //Add to inv
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
        {
            hasInteracted = true;
            Destroy(gameObject);
        }
        
    }
}
