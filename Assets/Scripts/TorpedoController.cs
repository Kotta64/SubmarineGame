using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 25.0f;
        GetComponent<CapsuleCollider>().enabled = false;
        Invoke("EnableCollider", 2.0f);
    }

    private void EnableCollider()
    {
        GetComponent<CapsuleCollider>().enabled = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall") Destroy(gameObject);
        if (other.gameObject.tag == "Enemy") Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().velocity = transform.forward * 10.0f;
    }
}
