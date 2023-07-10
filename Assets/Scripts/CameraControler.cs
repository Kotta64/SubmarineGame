using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject subCamera;
    private GameObject playerObject;
    private float rotateSpeed = 2.0f;
    private float zoomSpeed = 15.0f;
    private float zoomMin = 10.0f;
    private float zoomMax = 60.0f;
    private bool now = true;

    void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
        subCamera = GameObject.Find("SubCamera");
        playerObject = GameObject.FindGameObjectsWithTag("Player")[0];

        subCamera.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (now)
            {
                subCamera.SetActive(true);
                mainCamera.SetActive(false);
                now = false;
            }
            else
            {
                mainCamera.SetActive(true);
                subCamera.SetActive(false);
                now = true;
            }
        }
        if(now) rotateCamera();

    }

    private void rotateCamera()
    {
        Camera useCamera = Camera.main;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        useCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        //mainCamera.transform.RotateAround(playerObject.transform.position, transform.right, angle.y);
        useCamera.fieldOfView -= scroll * zoomSpeed;
        useCamera.fieldOfView = Mathf.Clamp(mainCamera.GetComponent<Camera>().fieldOfView, zoomMin, zoomMax);
    }
}
