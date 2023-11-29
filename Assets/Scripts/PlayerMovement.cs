using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private Rigidbody2D rb2D;
    public float pickUpRange = 1f;
    public bool isStunned = false;
  //  private Animator animator;
    IEnumerator StunCooldown()
    {

        yield return new WaitForSeconds(7f);
        isStunned = false;
       
    }
    private void Awake()
    {
       // animator = GetComponent<Animator>();
    }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
       
    }
    
    void FixedUpdate()
    {
        Stun();
    }

   

    public void Stun()
    {
        if (isStunned == true)
        {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movement.Normalize(); // Ensure diagonal movement isn't faster

            rb2D.velocity = movement * moveSpeed*0 ;
            //if(movement.x ==0 || movement.y ==0)
            //{
            //    animator.SetFloat("X", movement.x);
            //    animator.SetFloat("Y", movement.y);
            //    animator.SetBool("isWalking", false);
            //}
            //else
            //{
            //    animator.SetBool("isWalking", true);
            //}
            // play animation 
            StartCoroutine(StunCooldown());
            
        }
        else if (isStunned == false)
        {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movement.Normalize(); // Ensure diagonal movement isn't faster

            rb2D.velocity = movement * moveSpeed ;



            
        }

        // Add logic to disable player movement or animations
    }


    
}


