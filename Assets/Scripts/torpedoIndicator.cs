using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torpedoIndicator : MonoBehaviour
{
    private GameObject torpedo1;
    private GameObject torpedo2;
    private GameObject torpedo3;
    private GameObject torpedo4;

    // Start is called before the first frame update
    void Start()
    {
        torpedo1 = transform.Find("Point1").gameObject;
        torpedo2 = transform.Find("Point2").gameObject;
        torpedo3 = transform.Find("Point3").gameObject;
        torpedo4 = transform.Find("Point4").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        torpedo1.transform.localRotation = Quaternion.Euler(0.0f, -GameManager.instance.torpedoRange/3, 0.0f);
        torpedo2.transform.localRotation = Quaternion.Euler(0.0f, -GameManager.instance.torpedoRange, 0.0f);
        torpedo3.transform.localRotation = Quaternion.Euler(0.0f, GameManager.instance.torpedoRange/3, 0.0f);
        torpedo4.transform.localRotation = Quaternion.Euler(0.0f, GameManager.instance.torpedoRange, 0.0f);
    }
}
