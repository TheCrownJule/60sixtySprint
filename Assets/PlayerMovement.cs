using UnityEngine;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f; 
    private Rigidbody2D rb2D;
    private List<GameObject> inventory = new List<GameObject>();
    public float pickUpRange = 1f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        Vector2 isometricDirection = IsometricDirection(inputVector);
        Vector2 movement = isometricDirection * moveSpeed * Time.fixedDeltaTime;

        rb2D.MovePosition(rb2D.position + movement);
    }

    private Vector2 IsometricDirection(Vector2 inputDirection)
    {
        float isoX = (inputDirection.x - inputDirection.y) * 0.5f;
        float isoY = (inputDirection.x + inputDirection.y) * 0.5f;
        return new Vector2(isoX, isoY); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup"))
        {
            // Add the object to the inventory
            inventory.Add(other.gameObject);
            Debug.Log("item added");

            // Disable the object (you can also destroy it if needed)
            other.gameObject.SetActive(false);
        }
    }

    // Example method to remove an item from the inventory
    public void RemoveFromInventory(GameObject item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            // Optionally, you can enable the item if needed.
            item.SetActive(true);
        }
    }

    // Example method to check if an item is in the inventory
    public bool IsInInventory(GameObject item)
    {
        return inventory.Contains(item);
    }
}

