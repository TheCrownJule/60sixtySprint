using UnityEngine;

public class SpriteCollisionHandler : MonoBehaviour
{
    public SpriteSpawner spriteSpawner;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Destroy the sprite
            Destroy(gameObject);

            // Optionally, you can spawn a new sprite to replace the destroyed one
            spriteSpawner.SpawnSprites();
        }
    }
}
