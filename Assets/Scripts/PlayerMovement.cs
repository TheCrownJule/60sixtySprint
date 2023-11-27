using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private Rigidbody2D rb2D;
    public float pickUpRange = 1f;
    public bool isStunned = false;

    IEnumerator StunCooldown()
    {

        yield return new WaitForSeconds(3f);
        isStunned = false;
    }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Stun();
    }

    private Vector2 IsometricDirection(Vector2 inputDirection)
    {
        float isoX = (inputDirection.x - inputDirection.y) * 0.5f;
        float isoY = (inputDirection.x + inputDirection.y) * 0.5f;
        return new Vector2(isoX, isoY);
    }

    public void Stun()
    {
        if (isStunned == true)
        {
            // play animation 
            StartCoroutine(StunCooldown());
        }
        else if (isStunned == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
            Vector2 isometricDirection = IsometricDirection(inputVector);
            Vector2 movement = isometricDirection * moveSpeed * Time.fixedDeltaTime;

            rb2D.MovePosition(rb2D.position + movement);
        }

        // Add logic to disable player movement or animations
    }
}


