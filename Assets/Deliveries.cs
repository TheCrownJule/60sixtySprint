using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the tag 'Deliver'
        if (other.CompareTag("Deliver"))
        {
            // Perform actions when the player collides with a building tagged 'Deliver'
            Debug.Log("Player delivered at building!");

            // You can access the specific building GameObject if needed
            GameObject deliverBuilding = other.gameObject;

            // Add your custom logic here, such as delivering an item, scoring points, etc.
        }
    }
}
