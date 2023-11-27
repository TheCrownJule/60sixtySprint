using UnityEngine;
using UnityEngine.UI;

public class GameOver: MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;
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
        // Display the win panel
        winPanel.SetActive(true);

        // Stop the game in the background (You may need to implement this)
        Time.timeScale = 0f;

        // Deactivate the in-game panel
        inGamePanel.SetActive(false);
    }

    public void PlayerLose()
    {
        // Display the lose panel
        losePanel.SetActive(true);

        // Stop the game in the background (You may need to implement this)
        Time.timeScale = 0f;

        // Deactivate the in-game panel
        inGamePanel.SetActive(false);
    }

    public void ResetGame()
    {
        // Reset the game state
        Time.timeScale = 1f; // Reset time scale to normal

        // Deactivate both win and lose panels
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        // Activate the in-game panel
        inGamePanel.SetActive(true);
    }

    // asdad
}
