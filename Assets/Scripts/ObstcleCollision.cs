using Unity.Sentis.Layers;
using Unity.VisualScripting;
using UnityEngine;

public class ObstcleCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
       
            if (other.CompareTag("Player")) // Assuming the player has the "Player" tag
            {

                Debug.Log("triggered one");
                // Handle player collision and stun the player
                StunPlayer(other.gameObject);
                SFXManager.SFXinstance.PlaySound("CrashSound");
            }
   
    }
  

    void StunPlayer(GameObject player)
    {
        // Add logic to stun the player, for example:
        NewPlayerMovement newPlayerMovement = player.GetComponent<NewPlayerMovement>(); // Replace with your player controller script

        if (newPlayerMovement != null)
        {
            newPlayerMovement.isStunnedNew = true;
            newPlayerMovement.StunNew(); // Call a "Stun" method in your player controller script
        }
    }


}