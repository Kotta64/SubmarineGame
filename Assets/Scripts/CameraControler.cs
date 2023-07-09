using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject playerObject;
    private float rotateSpeed = 2.0f;
    private float zoomSpeed = 15.0f;
    private float zoomMin = 10.0f;
    private float zoomMax = 60.0f;

    void Start()
    {
        mainCamera = Camera.main;
        playerObject = GameObject.FindGameObjectsWithTag("Player")[0];
    }


    void Update()
    {
        rotateCamera();
    }

    private void rotateCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        //mainCamera.transform.RotateAround(playerObject.transform.position, transform.right, angle.y);

        mainCamera.fieldOfView -= scroll * zoomSpeed;
        mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, zoomMin, zoomMax);
    }
}
