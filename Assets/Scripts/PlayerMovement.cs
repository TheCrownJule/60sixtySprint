using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 Movement;
    private Rigidbody2D rb2D;
    public Animator animator;
    public float moveSpeed = 3.0f;

    public float pickUpRange = 1f;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        Movement = value.Get<Vector2>(); // get the value from the animator

        if (Movement.x != 0 || Movement.y != 0)
        {
            animator.SetFloat("X", Movement.x); // set the value of the animator
            animator.SetFloat("Y", Movement.y); // set the value of the animator

            animator.SetBool("isWalking", true); // set the value of the animator
            
        }
        else
        {
            animator.SetBool("isWalking", false); // set the value of the animator
        }
        
    } 


    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + Movement * moveSpeed * Time.fixedDeltaTime); // move the player

       
    }

  





    
}

