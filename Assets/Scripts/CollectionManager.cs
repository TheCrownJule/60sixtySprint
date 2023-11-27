using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionManager : MonoBehaviour
{
    public float collectionTime = 60.0f;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI collectedItemsText;

    public List<string> collectedItems = new List<string>();

    private float timer;
    public bool isGameEnded = false;
    public static CollectionManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timer = collectionTime;
        UpdateTimerUI();
        UpdateCollectedItemsUI();
    }

    void Update()
    {
        if (isGameEnded)
        {
            return;
        }

        timer -= Time.deltaTime;
        UpdateTimerUI();

        if (timer <= 0)
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
            string itemName = other.name;
            Debug.Log(itemName + " is the item name");

            if (!collectedItems.Contains(itemName))
            {
                collectedItems.Add(itemName);
                UpdateCollectedItemsUI();

                // Disable or remove the collected item from the scene
                other.gameObject.SetActive(false);

                // Check if there are 0 items left to collect
                if (collectedItems.Count == 0)
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
            timerText.text = "Time Left: " + Mathf.Max(0, timer).ToString("F1");
        }
    }

    public void UpdateCollectedItemsUI()
    {
        if (collectedItemsText != null)
        {
            string collectedItemsDisplay = "Collected Items: " + string.Join(", ", collectedItems);
            collectedItemsText.text = collectedItemsDisplay;
        }
    }

    void HandleGameWin()
    {
        isGameEnded = true;
        GameOver.GOinstance.PlayerWin();
        Debug.Log("game won");
    }

    void HandleGameOver()
    {
        isGameEnded = true;
        GameOver.GOinstance.PlayerLose();
        Debug.Log("game over");
    }
}
