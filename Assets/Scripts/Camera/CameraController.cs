using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float damping;

    private float _rotY;
    private float _rotX;
    private Vector3 _offset;

    public float zoomSpeed = 4f;
    public float minZoom = 1f;
    public float maxZoom = 5f;
    private float currentZoom = 1f;

    public float xMouseSensitivity = 5f;
    public float yMouseSensitivity = 5f;

    private float yRotMin = -70f;
    private float yRotMax = 70f;

    Transform cameraLookTarget;
    Player localPlayer;
	
	void Awake () {
        GameManager.instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
	}

    private void Start()
    {
        _rotY = transform.eulerAngles.y;
        //_offset = cameraLookTarget.position - transform.position;
    }

    private void HandleOnLocalPlayerJoined(Player player)
    {
        localPlayer = player;
        cameraLookTarget = localPlayer.transform.Find(gameConstants.cameraLookTarget);

        if (cameraLookTarget == null)
        {
            cameraLookTarget = localPlayer.transform;
        }

        
    }

    void Update () {
        currentZoom -= Input.GetAxis(gameConstants.mouseScrollWheel) * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
	}
    private void LateUpdate()
    {
            _rotY += Helper.ClampAngle(Input.GetAxis("Mouse X") * yMouseSensitivity, yRotMin, yRotMax);
            _rotX -= Input.GetAxis("Mouse Y") * xMouseSensitivity;

            Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
            transform.position = cameraLookTarget.position - (rotation * cameraOffset) * currentZoom;
            //transform.LookAt (target.Find ("LookAt").gameObject.transform);
            transform.LookAt(cameraLookTarget);

            //transform.LookAt(transform.gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0.5f,0.5f,0f)));

    }
}
