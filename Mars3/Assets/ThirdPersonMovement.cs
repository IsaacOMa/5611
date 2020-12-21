using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody rb;
    public Transform cam;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            rb.AddForce(moveDir * speed * Time.deltaTime, ForceMode.VelocityChange);
            //rb.AddForce(moveDir * speed * Time.deltaTime);
            // transform.Translate(playerMovement, Space.Self);
        }

        if (rb.position.y < -5f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
