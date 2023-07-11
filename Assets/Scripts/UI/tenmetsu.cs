using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tenmetsu : MonoBehaviour
{
    private float n;
    private bool up;
    // Start is called before the first frame update
    void Start()
    {
        n = 1.0f;
        up = false;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) FadeManager.Instance.LoadScene("InstructionsScene", 1.0f);
    }
    void FixedUpdate()
    {
        Text text = this.GetComponent<Text>();
        text.color = new Color(0.0f, 0.0f, 0.0f, n);
        if (n > 1.0f) up = false;
        if (n < 0f) up = true;
        if (up) n+=0.02f;
        else n -= 0.02f;
    }
}
