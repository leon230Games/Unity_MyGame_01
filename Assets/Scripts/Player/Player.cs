using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RelativeMovement))]
public class Player : MonoBehaviour {

	void Awake () {
        GameManager.instance.localPlayer = this;
	}

}
