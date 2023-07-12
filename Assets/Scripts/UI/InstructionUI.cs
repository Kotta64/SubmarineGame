using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionUI : MonoBehaviour
{
    private int page;
    public Sprite[] page_list;
    private GameObject Image;

    // Start is called before the first frame update
    void Start()
    {
        Image = GameObject.Find("Image");
        page = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Image.GetComponent<Image>().sprite = page_list[page];
    }

    public void StartButton()
    {
        FadeManager.Instance.LoadScene("GameScene", 1.0f);
    }

    public void NextButton()
    {
        page += 1;
        page = Mathf.Clamp(page, 0, page_list.Length-1);
    }

    public void BackButton()
    {
        page -= 1;
        page = Mathf.Clamp(page, 0, page_list.Length-1);
    }
}
