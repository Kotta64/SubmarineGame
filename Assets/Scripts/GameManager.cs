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

    // Start is called before the first frame update
    void Start()
    {
        throttle = 0;
        ballastTank = 40.0F;
        radar = false;
        torpedoRange = 0.1F;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
