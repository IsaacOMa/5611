using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    // Start is called before the first frame update

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    void Start()
    {
        // rb.AddForce(0, 200, 500);
        // Debug.Log("Hello, World!");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Adds a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
