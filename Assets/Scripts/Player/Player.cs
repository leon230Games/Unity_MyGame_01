using UnityEngine;

[RequireComponent(typeof(RelativeMovement))]
public class Player : MonoBehaviour {

    public GameObject inventoryUI;

    void Awake () {
        GameManager.instance.localPlayer = this;
	}

    private void Update()
    {
        if (inventoryUI.activeSelf)
        {
            GameManager.instance.DisableMovementAndCamera();
        }
        else
        {
            GameManager.instance.EnableMovementAndCamera();
        }
    }

}
