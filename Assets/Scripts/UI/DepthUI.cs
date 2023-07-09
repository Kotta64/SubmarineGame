using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthUI : MonoBehaviour
{
    private float depth;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        depth = 0.0F;
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        depth = -player.transform.position.y - 2.5F;
        GetComponent<Slider>().value = depth;
    }
}
