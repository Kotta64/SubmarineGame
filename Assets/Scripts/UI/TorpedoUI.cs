using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorpedoUI : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject torpedoInd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<4; i++)
        {
            torpedoInd = transform.Find("Torpedo" + Convert.ToString(i+1)).gameObject;
            if (GameManager.instance.torpedo[i] == 0) torpedoInd.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            else torpedoInd.GetComponent<Image>().color = new Color32(255, 255, 255, 64);
        }
    }
}
