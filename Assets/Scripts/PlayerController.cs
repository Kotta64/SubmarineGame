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
    private GameObject enemy;
    private float rotateSpeed;
    private float muki;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Screw_l = rb.transform.Find("Screw_L").gameObject;
        Screw_r = rb.transform.Find("Screw_R").gameObject;
        Radar = rb.transform.Find("Dentan").gameObject;
        enemy = GameObject.Find("Enemy");
        rotateSpeed = 0.0F;
        muki = 0.0F;
    }

    void Update()
    {
        //スロットル調整N
        if (Input.GetKeyDown(KeyCode.W)) GameManager.instance.throttle += 1;
        if (Input.GetKeyDown(KeyCode.S)) GameManager.instance.throttle -= 1;
        GameManager.instance.throttle = Mathf.Clamp(GameManager.instance.throttle, -1, 4);

        //深度調整N
        float setPoint = GameManager.instance.ballastTank - 50;
        if (Mathf.Abs(setPoint+transform.position.y) < 0.1) GetComponent<FloatingObject>().density = 1.0F;
        else if(setPoint > -transform.position.y ) GetComponent<FloatingObject>().density = 1.1F;
        else GetComponent<FloatingObject>().density = 0.9F;

        //電探N
        if (Input.GetKeyDown(KeyCode.L)) GameManager.instance.radar = !GameManager.instance.radar;
        if (transform.position.y < -7.8F) GameManager.instance.radar = false;

        //魚雷生成N
        if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.instance.torpedo[0] == 0)
        {
            GameManager.instance.torpedo[0] = 1000;
            Instantiate(prefabTorpedo, new Vector3(transform.Find("Indicators/Point1").gameObject.transform.position.x, transform.position.y - 0.7f, transform.Find("Indicators/Point1").gameObject.transform.position.z), Quaternion.Euler(0.0f, -90.0f + transform.eulerAngles.y - GameManager.instance.torpedoRange, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.instance.torpedo[1] == 0)
        {
            GameManager.instance.torpedo[1] = 1000;
            Instantiate(prefabTorpedo, new Vector3(transform.Find("Indicators/Point2").gameObject.transform.position.x, transform.position.y + 0.5f, transform.Find("Indicators/Point2").gameObject.transform.position.z), Quaternion.Euler(0.0f, -90.0f + transform.eulerAngles.y - GameManager.instance.torpedoRange/3, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && GameManager.instance.torpedo[2] == 0)
        {
            GameManager.instance.torpedo[2] = 1000;
            Instantiate(prefabTorpedo, new Vector3(transform.Find("Indicators/Point3").gameObject.transform.position.x, transform.position.y - 0.7f, transform.Find("Indicators/Point3").gameObject.transform.position.z), Quaternion.Euler(0.0f, -90.0f + transform.eulerAngles.y + GameManager.instance.torpedoRange, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && GameManager.instance.torpedo[3] == 0)
        {
            GameManager.instance.torpedo[3] = 1000;
            Instantiate(prefabTorpedo, new Vector3(transform.Find("Indicators/Point4").gameObject.transform.position.x, transform.position.y + 0.5f, transform.Find("Indicators/Point4").gameObject.transform.position.z), Quaternion.Euler(0.0f, -90.0f + transform.eulerAngles.y + GameManager.instance.torpedoRange/3, 0.0f));
        }

        //発見
        float dis = Vector3.Distance(transform.position, enemy.transform.position);
        if (dis < 2000f && dis > 1000f && transform.position.y > -6.5f) GameManager.instance.caveat = 1;
        else if (dis < 1500f && transform.position.y > -10f) GameManager.instance.caveat = 2;
        else GameManager.instance.caveat = 0;
    }

    private void FixedUpdate()
    {
        //プロペラ回転F
        rotateSpeed = GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime * 150 * Mathf.Sign(GameManager.instance.throttle);
        Screw_l.transform.Rotate(0, rotateSpeed, 0, Space.Self);
        Screw_r.transform.Rotate(0, -rotateSpeed, 0, Space.Self);

        //前進後退F
        rb.AddForce(rb.transform.right * GameManager.instance.throttle * -4000000);

        //バラストタンクF
        if (Input.GetKey(KeyCode.UpArrow)) GameManager.instance.ballastTank += 0.1F;
        if (Input.GetKey(KeyCode.DownArrow)) GameManager.instance.ballastTank -= 0.06F;
        GameManager.instance.ballastTank = Mathf.Clamp(GameManager.instance.ballastTank, 0, 100);

        //バッテリーF
        if (transform.position.y < -7.8f)
        {
            GameManager.instance.battery -= (Mathf.Abs(GameManager.instance.throttle) + 1.0f) / 200;
        }
        else
        {
            GameManager.instance.battery += 0.03f;
        }
        if (GameManager.instance.battery < 0.0f) GameManager.instance.throttle = 0;
        GameManager.instance.battery = Mathf.Clamp(GameManager.instance.battery, 0.0f, 100.0f);

        //旋回F
        if (Input.GetKey(KeyCode.A)) muki -= 0.005F;
        else if (Input.GetKey(KeyCode.D)) muki += 0.005F;
        else if (muki != 0.0F) muki -= 0.005F * muki / Mathf.Abs(muki);
        muki = Mathf.Clamp(muki, -0.02F, 0.02F);
        transform.Rotate(0, muki, 0, Space.Self);

        //魚雷クールタイム
        for (int i = 0; i < 4; i++)
        {
            if (GameManager.instance.torpedo[i] > 0)
            {
                GameManager.instance.torpedo[i] -= 1;
            }
        }
        //魚雷散布界
        if (Input.GetKey(KeyCode.LeftArrow)) GameManager.instance.torpedoRange -= 0.05F;
        if (Input.GetKey(KeyCode.RightArrow)) GameManager.instance.torpedoRange += 0.05F;
        GameManager.instance.torpedoRange = Mathf.Clamp(GameManager.instance.torpedoRange, 0.1F, 4.0F);
    }
}
