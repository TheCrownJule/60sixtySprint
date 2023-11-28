using UnityEngine;
using UnityEngine.UI;

public class ToggleGroceryList : MonoBehaviour
{
    public Image groceryListImage;

    void Start()
    {
        if (groceryListImage == null)
        {
            Debug.LogError("Grocery List Image is not assigned in the Inspector!");
        }
        else
        {
            groceryListImage.gameObject.SetActive(false); // Initially, set the image to inactive
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleImageVisibility();
        }
    }

    void ToggleImageVisibility()
    {
        bool isImageActive = groceryListImage.gameObject.activeSelf;
        groceryListImage.gameObject.SetActive(!isImageActive);
    }
}
