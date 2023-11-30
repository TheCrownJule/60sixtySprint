using UnityEngine;

public class RandomObjectActivation : MonoBehaviour
{
    public GameObject[] objectsToToggle;

    void Start()
    {
        // Call this method whenever you want to activate a random object
        ActivateRandomObject();
    }

    void ActivateRandomObject()
    {
        // Ensure there are objects in the array
        if (objectsToToggle.Length > 0)
        {
            // Deactivate all objects
            DeactivateAllObjects();

            // Select a random index
            int randomIndex = Random.Range(0, objectsToToggle.Length);

            // Activate the object at the random index
            objectsToToggle[randomIndex].SetActive(true);
        }
        else
        {
            Debug.LogWarning("No objects assigned to objectsToToggle array.");
        }
    }

    void DeactivateAllObjects()
    {
        // Deactivate all objects in the array
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(false);
        }
    }

    // Example: Call this method to trigger a new round
    public void TriggerNewRound()
    {
        ActivateRandomObject();
    }
}
