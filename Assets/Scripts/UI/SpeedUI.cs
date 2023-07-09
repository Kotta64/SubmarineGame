using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUI : MonoBehaviour
{

    private double speed;
    private GameObject player;
    private Text speedText;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.0;
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        speedText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = player.GetComponent<Rigidbody>().velocity.magnitude * 1.94;
        string text_s = string.Format("{0:f1}", speed);
        speedText.text = "Speed(konts): " + $"{text_s, 4}";
    }
}
