using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public GameObject player;
    private float minClamp = -45;
    private float maxClamp = 45;
    [HideInInspector]
    public Vector2 rotation;
    private Vector2 currentLockRot;
    private Vector2 rotationV = new Vector2(0, 0);

    public float lookSensivity = 2;
    public float lookSmoothDamp = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
    }

    void Update()
    {
        rotation.y = rotation.y + Input.GetAxis("Mouse Y") * lookSensivity;
        rotation.y = Mathf.Clamp(rotation.y, minClamp, maxClamp);
        player.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * lookSensivity);
        currentLockRot.y = Mathf.SmoothDamp(currentLockRot.y, rotation.y, ref rotationV.y, lookSmoothDamp);

        transform.localEulerAngles = new Vector3(-currentLockRot.y, 0, 0);

    }
}