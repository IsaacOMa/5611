using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public PlayerMovement movement;
    // Called whenever the object collides with something
    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            // Debug.Log("We hit an obstacle");
        }
        // Debug.Log(collisionInfo.collider.name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
