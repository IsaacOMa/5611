using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;


    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        CamControl();

    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;

        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}


/*


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    //public Rigidbody rb;
    // Start is called before the first frame update

    public float speed = 7f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float gravity = 10f;

    *//*  public float forwardForce = 5f;
      public float sidewaysForce = 5f;*//*

    void Start()
    {
        // rb.AddForce(0, 200, 500);
        // Debug.Log("Hello, World!");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            bool groundedPlayer = controller.isGrounded;


            if (groundedPlayer)
            {
                moveDir.y = 0f;
            }

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //Adds a forward force
        *//* if (Input.GetKey("w"))
         {
             rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
         }

         if (Input.GetKey("s"))
         {
             rb.AddForce(0, 0, -forwardForce * Time.deltaTime, ForceMode.VelocityChange);
         }
         // rb.AddForce(0, 0, forwardForce * Time.deltaTime);

         if (Input.GetKey("d"))
         {
             rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
         }

         if (Input.GetKey("a"))
         {
             rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
         }*//*
    }
}
*/