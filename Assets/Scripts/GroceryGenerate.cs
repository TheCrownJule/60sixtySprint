using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class GroceryGenerate : MonoBehaviour
{
    public GroceryItem[] allGroceryItems; // Assign your Scriptable Objects in the Inspector
    public int itemsToDisplay = 5; // Number of items to display
    public TextMeshProUGUI[] displayTexts; // Assign UI Text components in the Inspector
    public SpriteRenderer spritePrefab;

    public List<GroceryItem> selectedItems = new List<GroceryItem>();
    public Vector3 scale = new Vector3(5f, 5f, 0.0f); // Set the desired scale



    private void Start()
    {

        SelectRandomItems();
        DisplaySelectedItems();
        SpawnSelectedItems();
    }

    void SelectRandomItems()
    {
        List<GroceryItem> allItems = new List<GroceryItem>(allGroceryItems);

        for (int i = 0; i < itemsToDisplay; i++)
        {
            if (allItems.Count == 0)
            {
                break; // Avoid infinite loop if there are fewer items than required
            }

            int randomIndex = Random.Range(0, allItems.Count);
            selectedItems.Add(allItems[randomIndex]);

            allItems.RemoveAt(randomIndex);
        }
    }


    void DisplaySelectedItems()
    {
        for (int i = 0; i < displayTexts.Length; i++)
        {
            if (i < selectedItems.Count)
            {
                displayTexts[i].text = selectedItems[i].itemNameID;
            }
            else
            {
                // Clear text for empty slots
                displayTexts[i].text = "";
            }
        }
    }

    void SpawnSelectedItems()
    {
        foreach (GroceryItem item in selectedItems)
        {
            // Instantiate the prefab from the Scriptable Object
            GameObject newItem = Instantiate(item.itemPrefab, item.position, item.rotation);
        }
    }
}
