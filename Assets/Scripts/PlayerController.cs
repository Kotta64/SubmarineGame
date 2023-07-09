using System.Collections;
using System.Collections.Generic;
using NaughtyWaterBuoyancy;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject Screw_l;
    private GameObject Screw_r;
    private GameObject Radar;
    public GameObject prefabTorpedo;
    private float rotateSpeed;
    private float muki;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Screw_l = rb.transform.Find("Screw_L").gameObject;
        Screw_r = rb.transform.Find("Screw_R").gameObject;
        Radar = rb.transform.Find("Dentan").gameObject;
        rotateSpeed = 0.0F;
        muki = 0.0F;
    }

    void Update()
    {
        //スロットル調整
        if (Input.GetKeyDown(KeyCode.W)) GameManager.instance.throttle += 1;
        if (Input.GetKeyDown(KeyCode.S)) GameManager.instance.throttle -= 1;
        GameManager.instance.throttle = Mathf.Clamp(GameManager.instance.throttle, -1, 4);

        //旋回
        if (Input.GetKey(KeyCode.A)) muki -= 0.0001F;
        else if (Input.GetKey(KeyCode.D)) muki += 0.0001F;
        else if (muki != 0.0F) muki -= 0.0001F * muki / Mathf.Abs(muki);
        muki = Mathf.Clamp(muki, -0.02F, 0.02F);
        transform.Rotate(0, muki, 0, Space.Self);

        //プロペラ回転
        rotateSpeed = GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime * 150 * Mathf.Sign(GameManager.instance.throttle);
        Screw_l.transform.Rotate(0, rotateSpeed, 0, Space.Self);
        Screw_r.transform.Rotate(0, -rotateSpeed, 0, Space.Self);

        //前進後退
        rb.AddForce(rb.transform.right * GameManager.instance.throttle * -1500000);

        //バラストタンク
        if (Input.GetKey(KeyCode.UpArrow)) GameManager.instance.ballastTank += 0.03F;
        if (Input.GetKey(KeyCode.DownArrow)) GameManager.instance.ballastTank -= 0.02F;
        GameManager.instance.ballastTank = Mathf.Clamp(GameManager.instance.ballastTank, 0, 100);

        //深度調整
        float setPoint = GameManager.instance.ballastTank - 50;
        if (Mathf.Abs(setPoint+transform.position.y) < 0.1) GetComponent<FloatingObject>().density = 1.0F;
        else if(setPoint > -transform.position.y ) GetComponent<FloatingObject>().density = 1.1F;
        else GetComponent<FloatingObject>().density = 0.9F;

        //電探
        if (Input.GetKeyDown(KeyCode.L)) GameManager.instance.radar = !GameManager.instance.radar;
        if (transform.position.y < -7.5F) GameManager.instance.radar = false;
        if(GameManager.instance.radar) Radar.transform.Rotate(0, 1, 0, Space.Self);

        //魚雷
        if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.instance.torpedo[0] == 0 && transform.position.y > -15)
        {
            GameManager.instance.torpedo[0] = 4800;
            Instantiate(prefabTorpedo, new Vector3(transform.Find("Indicators/Point1").gameObject.transform.position.x, transform.position.y - 0.7f, transform.Find("Indicators/Point1").gameObject.transform.position.z), Quaternion.Euler(0.0f, -90.0f + transform.eulerAngles.y - GameManager.instance.torpedoRange, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.instance.torpedo[1] == 0 && transform.position.y > -15)
        {
            GameManager.instance.torpedo[1] = 4800;
            Instantiate(prefabTorpedo, new Vector3(transform.Find("Indicators/Point2").gameObject.transform.position.x, transform.position.y + 0.5f, transform.Find("Indicators/Point2").gameObject.transform.position.z), Quaternion.Euler(0.0f, -90.0f + transform.eulerAngles.y - GameManager.instance.torpedoRange/2, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && GameManager.instance.torpedo[2] == 0 && transform.position.y > -15)
        {
            GameManager.instance.torpedo[2] = 4800;
            Instantiate(prefabTorpedo, new Vector3(transform.Find("Indicators/Point3").gameObject.transform.position.x, transform.position.y - 0.7f, transform.Find("Indicators/Point3").gameObject.transform.position.z), Quaternion.Euler(0.0f, -90.0f + transform.eulerAngles.y + GameManager.instance.torpedoRange, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && GameManager.instance.torpedo[3] == 0 && transform.position.y > -15)
        {
            GameManager.instance.torpedo[3] = 4800;
            Instantiate(prefabTorpedo, new Vector3(transform.Find("Indicators/Point4").gameObject.transform.position.x, transform.position.y + 0.5f, transform.Find("Indicators/Point4").gameObject.transform.position.z), Quaternion.Euler(0.0f, -90.0f + transform.eulerAngles.y + GameManager.instance.torpedoRange/2, 0.0f));
        }
        for (int i = 0; i < 4; i++)
        {
            if(GameManager.instance.torpedo[i] > 0)
            {
                GameManager.instance.torpedo[i] -= 1;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)) GameManager.instance.torpedoRange -= 0.01F;
        if (Input.GetKey(KeyCode.RightArrow)) GameManager.instance.torpedoRange += 0.01F;
        GameManager.instance.torpedoRange = Mathf.Clamp(GameManager.instance.torpedoRange, 0.1F, 4.0F);


    }
}
