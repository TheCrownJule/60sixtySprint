using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private Rigidbody2D rb2D;
    public float pickUpRange = 1f;
    public bool isStunned = false;

    public SFXManager sfxManager; // Reference to the SFXManager script

    IEnumerator StunCooldown()
    {
        yield return new WaitForSeconds(7f);
        isStunned = false;
    }

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        sfxManager = SFXManager.SFXinstance; // Assuming SFXManager is a singleton
    }

    void FixedUpdate()
    {
        Stun();
    }

    public void Stun()
    {
        if (isStunned)
        {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movement.Normalize(); // Ensure diagonal movement isn't faster

            rb2D.velocity = movement * moveSpeed * 0;

            // Play the stun sound
            sfxManager.PlaySound("StunSound");

            StartCoroutine(StunCooldown());
        }
        else
        {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movement.Normalize(); // Ensure diagonal movement isn't faster

            rb2D.velocity = movement * moveSpeed;

            // Stop the stun sound if the player is not stunned
            sfxManager.StopSound("StunSound");
        }

        // Add logic to disable player movement or animation



    }
}



