using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Rigidbody rb;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;



    // Use this for initialization
    void Start()
    {

    }

    public Transform player;
    public Vector3 offset;
    public float speed = 50f;

    bool left, right, forward, back;
    //offset = new Vector3(-10.0f, 10.0f, 10.0f);

    // Update is called once per frame
    void Update()
    {

      /*  yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        offset = (new Vector3((float) (10.0 * ((double)(Math.Sin(yaw) / 100))), (float) (10.0 * ((float)(Math.Sin(pitch) / 100))), (float) (10.0 * ((float)(Math.Cos(yaw) / 100)))));
        transform.position = player.position + offset;*/

        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(player.position);
        transform.position = player.position + offset;
    }
}
*/