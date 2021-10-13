using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{

    public GameObject projectile = null;
    public float launchVelocity = 700f;
    public GameObject player = null;

    Vector3 dir = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        dir = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(0, launchVelocity, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ball = Instantiate(projectile, transform.position,
                                                        transform.rotation);

            ball.GetComponent<Rigidbody>().AddForce(dir + velocity);

        }
        
    }
}
