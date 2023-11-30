using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject[] spritePrefabs; // Array of sprite prefabs
    public Transform[] spawnPoints;    // Array of spawn points
    public int numberOfSprites = 10;

    void Start()
    {
        SpawnSprites();
    }

    public void SpawnSprites()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned to the SpriteSpawner.");
            return;
        }

        for (int i = 0; i < numberOfSprites; i++)
        {
            // Randomly select a sprite from the array
            GameObject selectedPrefab = spritePrefabs[Random.Range(0, spritePrefabs.Length)];

            // Randomly select a spawn point from the array
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instantiate the selected sprite at the chosen spawn point
            Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
