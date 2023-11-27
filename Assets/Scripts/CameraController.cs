using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The target to follow
    public float smoothing; // Dampening effect

    public Vector2 maxPos;
    public Vector2 minPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target.position) // If the camera's position is not equal to the target's position
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z); // Set the target position to the target's position

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPos.x, maxPos.x); // Clamp the target's x position to the min and max x positions
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPos.y, maxPos.y); // Clamp the target's y position to the min and max y positions

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); // Smoothly move the camera to the target position
        }
       
    }
}
