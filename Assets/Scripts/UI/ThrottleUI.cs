using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrottleUI : MonoBehaviour
{
    private GameObject lever;
    private GameObject now;
    private int oldThrottle;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        lever = transform.Find("Slider").gameObject;
        now = transform.Find("Now").gameObject;
        oldThrottle = -2;
    }

    // Update is called once per frame
    void Update()
    {
        if(oldThrottle != GameManager.instance.throttle)
        {
            lever.GetComponent<Slider>().value = GameManager.instance.throttle;
            now.GetComponent<RectTransform>().localPosition = new Vector3(100, -115 + GameManager.instance.throttle * 76, 0);
            oldThrottle = GameManager.instance.throttle;
            GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }
}
