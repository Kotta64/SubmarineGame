using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScene : MonoBehaviour
{
    private float keisha = 0.1f;
    private GameObject EnemyObject;
    public GameObject exp;
    private bool key = true;
    private GameObject cnv;
    // Start is called before the first frame update
    void Start()
    {
        EnemyObject = GameObject.Find("Enemy");
        cnv = GameObject.Find("Canvas");
        cnv.SetActive(false);
    }

    private void FixedUpdate()
    {
        EnemyObject.transform.rotation = Quaternion.Euler(0, 0, keisha);
        if (keisha < 180) keisha += keisha / 100;
        else if (key)
        {
            Instantiate(exp, EnemyObject.transform.position, Quaternion.identity);
            key = false;
        }
        else if (EnemyObject.transform.position.y > -80.0f)
        {
            EnemyObject.transform.position = new Vector3(0, EnemyObject.transform.position.y - 0.1f, 0);
            cnv.SetActive(true);
        }else FadeManager.Instance.LoadScene("MenuScene", 1.0f);
        if (key) rotateCamera();
    }

    private void rotateCamera()
    {
        Camera useCamera = Camera.main;
        useCamera.transform.RotateAround(GameObject.Find("EnemyPoint").transform.position, Vector3.up, 0.25f);
    }
}
