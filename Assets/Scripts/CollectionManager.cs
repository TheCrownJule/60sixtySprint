using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionManager : MonoBehaviour
{
    public float collectionTime = 60.0f;
    public TextMeshProUGUI timerText;

    // Use an array of TextMeshProUGUI for multiple labels
    public TextMeshProUGUI[] collectedItemsLabels;

    public List<string> collectedItems = new List<string>();

    public float timerCM;
    public bool isGameEnded = false;
    public static CollectionManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

        timerCM = collectionTime;
        UpdateTimerUI();
        UpdateCollectedItemsUI();
    }

    void Update()
    {
        if (isGameEnded)
        {
            return;
        }

        timerCM -= Time.deltaTime;
        UpdateTimerUI();

        if (timerCM <= 0)
        {
            HandleGameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isGameEnded)
        {

            return;
        }

        if (other.CompareTag("Pickup"))
        {
            SFXManager.SFXinstance.PlaySound("CollectionSound");
            string itemName = other.name; // how do i change this to get the ScO name 


            if (!collectedItems.Contains(itemName))
            {
                collectedItems.Add(itemName);
                UpdateCollectedItemsUI();

                // Disable or remove the collected item from the scene
                other.gameObject.SetActive(false);

                // Check if there are 0 items left to collect
                if (collectedItems.Count == 5)
                {
                    HandleGameWin();
                }
            }
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time Left: " + Mathf.Max(0, timerCM).ToString("F1");
        }
    }

    void UpdateCollectedItemsUI()
    {
        // Update each label individually based on collected items
        for (int i = 0; i < collectedItemsLabels.Length; i++)
        {
            // Only activate the label if it's displaying an item
            bool isActive = i < collectedItems.Count;
            collectedItemsLabels[i].gameObject.SetActive(isActive);

            // Set the text of the label if it's active and there's an item to display
            if (isActive)
            {
                collectedItemsLabels[i].text = collectedItems[i];
            }
        }
    }

    void HandleGameWin()
    {
        isGameEnded = true;

        GameOver.GOinstance.PlayerWin();
        Rating.Rinstance.SetRating(timerCM, LivesManager.LMinstance.noLives);
        Debug.Log("game won");

    }

    void HandleGameOver()
    {
        isGameEnded = true;

        GameOver.GOinstance.PlayerLose();
        Rating.Rinstance.SetRating(timerCM, LivesManager.LMinstance.noLives);
        Debug.Log("game over");
    }
}
