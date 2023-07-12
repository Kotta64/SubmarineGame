using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    private GameObject player;
    private GameObject enemy;
    private GameObject icon;
    private bool key = true;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = transform.Find("Enemy").gameObject;
        icon = transform.Find("Enemy/Icon").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dis = Vector3.Distance(player.transform.position, enemy.transform.position);
        if (dis < 3300 && GameManager.instance.radar) icon.SetActive(true);
        else icon.SetActive(false);
        transform.Rotate(0, 0.002F, 0, Space.Self);
    }

    private void clearScene()
    {
        FadeManager.Instance.LoadScene("ClearScene", 1.0f);
    }

    private void Update()
    {
        if(GameManager.instance.enemy_hp <= 0 && key)
        {
            Invoke("clearScene", 2.0f);
            key = false;
        }
    }
}
