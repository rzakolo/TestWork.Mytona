using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    [SerializeField] private GameObject playerBase;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        playerBase = GameObject.FindWithTag("PlayerBase");
        Vector3 pos = playerBase.transform.position;
        pos.y = 20.0f;
        transform.position = pos;
        mousePos = transform.position;
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            mousePos.x -= Input.GetAxis("Mouse X") / 2;
            mousePos.z -= Input.GetAxis("Mouse Y") / 2;
            mousePos.y = transform.position.y;
        }
        float mWheel = Input.GetAxis("Mouse ScrollWheel") * 4;
        mousePos.y -= mWheel;
        mainCamera.transform.position = mousePos;
    }
}
