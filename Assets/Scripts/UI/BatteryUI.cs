using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    private float battery;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        battery = GameManager.instance.battery;
        GetComponent<Slider>().value = battery;
    }
}
