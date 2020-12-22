using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catRotation : MonoBehaviour
{

    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    }
}
