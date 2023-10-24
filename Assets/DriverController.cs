using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverController : MonoBehaviour
{
    private Rigidbody2D Driver;
    [SerializeField] private float speed;

    private Animator anim;

    void Start()
    {
        Driver = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput * speed, verticalInput * speed); // Set the movement vector to the input vector times the speed
        Driver.velocity = movement; // Set the Driver's velocity to the movement vector

        anim.SetFloat("MoveX", Driver.velocity.x); // Set the MoveX parameter to the Driver's x velocity
        anim.SetFloat("MoveY", Driver.velocity.y); // Set the MoveY parameter to the Driver's y velocity


    }
}

