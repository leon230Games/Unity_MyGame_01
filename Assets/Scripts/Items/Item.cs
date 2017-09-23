﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "Name";
    public Sprite icon = null;
    public bool isDefaultItem = false;

}
