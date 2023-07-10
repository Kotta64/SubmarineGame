using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarUI : MonoBehaviour
{
    private GameObject icon;
    private GameObject pointer;
    private GameObject dentan;
    private bool oldState;

    // Start is called before the first frame update
    void Start()
    {
        icon = transform.Find("Icon").gameObject;
        pointer = transform.Find("Pointer").gameObject;
        dentan = GameObject.Find("Dentan").gameObject;
        oldState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(oldState != GameManager.instance.radar)
        {
            icon.SetActive(GameManager.instance.radar);
            pointer.SetActive(GameManager.instance.radar);
            oldState = GameManager.instance.radar;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.radar)
        {
            pointer.GetComponent<RectTransform>().Rotate(0, 0, -3);
            dentan.transform.Rotate(0, 3, 0, Space.Self);
        }
    }
}
