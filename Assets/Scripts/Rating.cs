using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rating : MonoBehaviour
{
    public Image[] ratingImages; // Array of UI images representing the rating
    public TextMeshProUGUI ratingText; // Text to display the rating as text
    public static Rating Rinstance;

    public void Awake()
    {
        Rinstance = this;
    }

    public void SetRating(float completionTime, bool playerLostAllLives)
    {
        // Set the rating based on completion time and player's lives
        int rating = CalculateRating(completionTime, playerLostAllLives);

        // Display the rating in the UI
        UpdateUI(rating);
    }

    private int CalculateRating(float completionTime, bool playerLostAllLives)
    {
        // If the player has lost all their lives, set the rating to 1
        if (playerLostAllLives)
        {
            return 1;
        }

        float targetTime = 60.0f; // Target completion time
        float timeDifference = Mathf.Abs(completionTime - targetTime);

        // Adjust the thresholds based on your rating criteria
        if (timeDifference <= 10.0f)
        {
            return 5;
        }
        else if (timeDifference <= 20.0f)
        {
            return 4;
        }
        else if (timeDifference <= 30.0f)
        {
            return 3;
        }
        else if (timeDifference <= 40.0f)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    private void UpdateUI(int rating)
    {
        SFXManager.SFXinstance.PlaySound("RatingSound");
        // Display the rating text
        if (ratingText != null)
        {
            ratingText.text = "Rating: " + rating + "/5";
        }

        // Activate the corresponding number of rating images
        for (int i = 0; i < ratingImages.Length; i++)
        {
            ratingImages[i].gameObject.SetActive(i < rating);
        }
    }
}
