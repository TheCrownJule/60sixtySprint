using UnityEngine;

public class Obstacle : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obstacle"))
        {
            DestroyPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            DestroyPlayer();
        }
    }

    private void DestroyPlayer()
    {
        

        // Destroy the player GameObject
        Destroy(gameObject);
        Debug.Log("player died");
    }
}