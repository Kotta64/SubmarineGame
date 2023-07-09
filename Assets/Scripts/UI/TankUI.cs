using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankUI : MonoBehaviour
{
    private Text label;
    private GameObject tank;
    private float oldTank;

    // Start is called before the first frame update
    void Start()
    {
        oldTank = -1.0F;
        tank = transform.Find("Tank").gameObject;
        label = transform.Find("Label").gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oldTank != GameManager.instance.ballastTank)
        {
            tank.GetComponent<Slider>().value = GameManager.instance.ballastTank;
            label.text = (int)GameManager.instance.ballastTank + "%";
            oldTank = GameManager.instance.ballastTank;
        }
    }
}
