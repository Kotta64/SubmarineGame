using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveatUI : MonoBehaviour
{
    private Text caveatText;
    private GameObject CaveatObject;
    // Start is called before the first frame update
    void Start()
    {
        CaveatObject = transform.Find("Caveat").gameObject;
        caveatText = transform.Find("Caveat/Text").gameObject.GetComponent<Text>();
        CaveatObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int cv = GameManager.instance.caveat;
        switch (cv)
        {
            case 0:
                CaveatObject.gameObject.SetActive(false);
                break;
            case 1:
                CaveatObject.gameObject.SetActive(true);
                caveatText.text = "発見される可能性があります!!\n潜望鏡深度まで潜航してください";
                break;
            case 2:
                CaveatObject.gameObject.SetActive(true);
                caveatText.text = "発見される可能性があります!!\n潜航してください";
                break;
        }
    }
}
