using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/GroceryItem", order = 1)]

public class GroceryItem : ScriptableObject
{
    public string itemName;
    public GameObject itemPrefab;
    public Vector3 position;
    public Quaternion rotation = Quaternion.identity;

}