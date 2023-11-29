using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    private Rigidbody2D newPlayer;
    [SerializeField] private float speed;
    public float pickUpRangeNew = 1f;
    public bool isStunnedNew = false;

    private SpriteRenderer playerRenderer;
    private Animator anim;

    IEnumerator StunCooldown()
    {
       
        yield return new WaitForSeconds(5f);
        isStunnedNew = false;

    }
    
    void Start()
    {
        newPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
       
    }

    void FixedUpdate()
    {

        StunNew();


    }

    public void StunNew()
    {
        if (isStunnedNew == true)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput * speed, verticalInput * speed); // Set the movement vector to the input vector times the speed
            newPlayer.velocity = movement * 0; // Set the Driver's velocity to the movement vector

            anim.SetFloat("X", newPlayer.velocity.x); // Set the MoveX parameter to the Driver's x velocity
            anim.SetFloat("Y", newPlayer.velocity.y); // Set the MoveY parameter to the Driver's y velocity
                                                      // StartCoroutine(FlashPlayer());
            StartCoroutine(StunCooldown());


        }
        else if (isStunnedNew == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput * speed, verticalInput * speed); // Set the movement vector to the input vector times the speed
            newPlayer.velocity = movement ; // Set the Driver's velocity to the movement vector

            anim.SetFloat("X", newPlayer.velocity.x); // Set the MoveX parameter to the Driver's x velocity
            anim.SetFloat("Y", newPlayer.velocity.y); // Set the MoveY parameter to the Driver's y velocity
            




        }
       
        // Add logic to disable player movement or animations
    }

}
