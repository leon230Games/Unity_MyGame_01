﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot eqSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        //Equip item
        EquipmentManager.instance.Equip(this);
        //Remove from inventory
        RemoveFromInventory();

    }

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet}
//public enum EquipmentMeshRegion { Legs, Arms, Torso}
public enum EquipmentMeshRegion {Chest, LegsUpper }
