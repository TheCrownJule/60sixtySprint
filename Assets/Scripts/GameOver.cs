using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI resultText; // Text element in the UI to display win or lose
    public GameObject inGamePanel;

    public static GameOver GOinstance;

    private void Awake()
    {
        GOinstance = this;
    }

    private void Start()
    {
        // Ensure that the initial state is set correctly
        ResetGame();
    }

    public void PlayerWin()
    {
        // Display the game over panel
        gameOverPanel.SetActive(true);

        // Set the result text to "You won"
        resultText.text = "You won";

        // Stop the game in the background (You may need to implement this)
        Time.timeScale = 0f;

        // Deactivate the in-game panel
        inGamePanel.SetActive(false);
    }

    public void PlayerLose()
    {
        // Display the game over panel
        gameOverPanel.SetActive(true);

        // Set the result text to "You lost"
        resultText.text = "You lost";

        // Stop the game in the background (You may need to implement this)
        Time.timeScale = 0f;

        // Deactivate the in-game panel
        inGamePanel.SetActive(false);
    }

    public void ResetGame()
    {
        // Reset the game state
        Time.timeScale = 1f; // Reset time scale to normal

        // Deactivate the game over panel
        gameOverPanel.SetActive(false);

        // Activate the in-game panel
        inGamePanel.SetActive(true);
    }
}
