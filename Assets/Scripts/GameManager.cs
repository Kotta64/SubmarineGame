using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int throttle;
    public int[] torpedo = new int[4] {0, 0, 0, 0};
    public float torpedoRange;
    public float ballastTank;
    public bool radar;
    public float battery;
    public int caveat;
    public int enemy_hp;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Reset_Data()
    {
        throttle = 0;
        ballastTank = 40.0F;
        radar = false;
        torpedoRange = 0.1F;
        battery = 100.0f;
        caveat = 0;
        enemy_hp = 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset_Data();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
