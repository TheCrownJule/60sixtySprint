using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LivesManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Image[] lifeSprites;

    private int remainingLives = 3;

    private void Start()
    {
        gameOverText.enabled = false;
        UpdateLifeUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obstacle"))
        {
            Debug.Log(" lives manager collision ");
            // Player has been hit by an obstacle
            remainingLives--;

            if (remainingLives <= 0)
            {
                GameOver();
            }
            else
            {
                UpdateLifeUI();
            }
        }
    }

    private void UpdateLifeUI()
    {
        // Disable the sprite images for lost lives
        for (int i = 0; i < lifeSprites.Length; i++)
        {
            lifeSprites[i].enabled = i < remainingLives;
        }
    }

    private void GameOver()
    {
        // Display "Game Over" text
        gameOverText.enabled = true;

        // Optionally, you can restart the level or perform other actions here
    }
}
