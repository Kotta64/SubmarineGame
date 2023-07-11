using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoController : MonoBehaviour
{
    public GameObject particleObject;
    public GameObject raiseki;
    private GameObject Obj;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 25.0f;
        GetComponent<CapsuleCollider>().enabled = false;
        Invoke("EnableCollider", 2.0f);
        Obj = (GameObject)Instantiate(raiseki, this.transform.position - transform.forward * 45, transform.rotation);
        Obj.transform.parent = transform;
    }

    private void EnableCollider()
    {
        GetComponent<CapsuleCollider>().enabled = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy") GameManager.instance.enemy_hp -= 25;
        Vector3 hitPos = other.contacts[0].point;
        Instantiate(particleObject, hitPos, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Vector3 now = transform.position;
        if(now.y < -1.0f) transform.position = new Vector3(now.x, now.y+0.02f, now.z);
    }
}
