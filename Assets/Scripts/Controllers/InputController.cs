using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;
    public bool fire1;
    public bool reload;
    public bool isWalking;
    public bool isSprinting;
    public bool isCrouched;
	
	
	void Update () {
		Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        fire1 = Input.GetButton("Fire1");
        reload = Input.GetKey(KeyCode.R);

        isWalking = Input.GetKey(KeyCode.LeftAlt);
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        isCrouched = Input.GetKey(KeyCode.C);

	}
}
