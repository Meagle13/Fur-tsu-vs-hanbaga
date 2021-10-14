using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodProjectiles : MonoBehaviour
{
    Rigidbody rb = null;
    Vector3 dir = Vector3.zero;
    public GameObject player = null;
    public float speed = 50;
    public float velocity = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        dir = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(dir * speed + Vector3.up * velocity);
    }
}
