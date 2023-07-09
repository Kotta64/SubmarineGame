using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarUI : MonoBehaviour
{
    private GameObject icon;
    private GameObject pointer;
    private bool oldState;
    private float timeS;

    // Start is called before the first frame update
    void Start()
    {
        icon = transform.Find("Icon").gameObject;
        pointer = transform.Find("Pointer").gameObject;
        oldState = true;
        timeS = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeS += Time.deltaTime;
        if (oldState != GameManager.instance.radar)
        {
            icon.SetActive(GameManager.instance.radar);
            pointer.SetActive(GameManager.instance.radar);
            oldState = GameManager.instance.radar;
        }
        if (GameManager.instance.radar && timeS > 0.001f)
        {
            pointer.GetComponent<RectTransform>().Rotate(0, 0, -1);
            timeS = 0.0f;
        }
    }
}
