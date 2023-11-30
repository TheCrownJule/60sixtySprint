
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the "Player" tag
        {
            Debug.Log("triggered one");
            // Handle player collision and stun the player
            StunPlayer(other.gameObject);
        }

    }

    //private void OnCollisionEnter2D(Collision2D collison)
    //{
    //    if (collison.gameObject.CompareTag("Player")) // Assuming the player has the "Player" tag
    //    {
    //        Debug.Log("triggered"); 
    //        // Handle player collision and stun the player
    //        StunPlayer(collison.gameObject);
    //    }

    //}

    void StunPlayer(GameObject player)
    {
        // Add logic to stun the player, for example:
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>(); // Replace with your player controller script

        if (playerMovement!= null)
        {
            playerMovement.isStunned = true;
            playerMovement.Stun(); // Call a "Stun" method in your player controller script
        }
    }

   
}