using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LMscript: MonoBehaviour
{

    public Image[] lifeSprites;

    private int remainingLives = 3;
    public bool noLivesLM = false;
    public static LMscript LMinstance;

    private void Awake()
    {
        LMinstance = this;
    }
    private void Start()
    {

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
                noLivesLM = true;

                GameOver.GOinstance.PlayerLose();
                Rating.Rinstance.SetRating(Timer.instance.currentTimeT, noLivesLM);
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


}
