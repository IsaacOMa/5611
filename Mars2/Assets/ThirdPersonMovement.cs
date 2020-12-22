using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    Animator animator;

    public float speed = 10f;
    public float maxSpeed = 500f;
    const float locomationAnimationSmoothTime = .1f;
    //public Rigidbody rb;
    public Transform cam;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
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
        Vector3 direction = new Vector3(-horizontal, -9.8f, -vertical).normalized;
        Quaternion rotate = Quaternion.Euler(0f, 45f, 0f);
        direction = rotate * direction;

        Vector3 move = new Vector3(horizontal, 0f, vertical);

        float curSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            curSpeed = maxSpeed;
        }


        if (move.magnitude >= 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetFloat("speedPercent", 1f, locomationAnimationSmoothTime, Time.deltaTime);
            }
            else
            {
                animator.SetFloat("speedPercent", 0.5f, locomationAnimationSmoothTime, Time.deltaTime);
            }


            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;


            //transform.rotation = Quaternion.Euler(0f, (targetAngle + 180) % 360, 0f) * Vector3.forward; // trying to add * Vector3.forward
            var moveDir = Quaternion.Euler(0f, (targetAngle + 270) % 360, 0f);
            var newDir = moveDir * Vector3.forward;
            transform.rotation = newDir;

            controller.Move(transform.rotation * curSpeed * Time.deltaTime);

            /*Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            rb.AddForce(moveDir * speed * Time.deltaTime, ForceMode.VelocityChange);
            //rb.AddForce(moveDir * speed * Time.deltaTime);
            // transform.Translate(playerMovement, Space.Self);
            transform.Translate(moveDir * speed * Time.deltaTime, Space.Self);

            //transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);*/

        } else
        {
            animator.SetFloat("speedPercent", 0f);
        }

        /*if (rb.position.y < -5f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }*/
    }

}
