using UnityEngine;
using TMPro;

public class Timer: MonoBehaviour
{
    public float totalTime = 60f;
    public float currentTimeT;
    public static Timer instance;
    public TextMeshProUGUI timerTextT;
    public bool isGameEnded = false;
    private void Awake()
    {
       instance = this;
    }
    private void Start()
    {
        // Initialize the timer
        currentTimeT = totalTime;

        // Update the timer text
        UpdateTimerText();
    }

    private void Update()
    {
        if (isGameEnded)
        {
            return;
        }

        // Check if time is greater than 0 before counting down
        //if (currentTimeT > 0f)
        //{
        //    // Count down the timer
            currentTimeT -= Time.deltaTime;

            // Update the timer text
            UpdateTimerText();
        //}
        if (currentTimeT<=0)
        {
            isGameEnded = true;
            GameOver.GOinstance.PlayerLose();
            Rating.Rinstance.SetRating(currentTimeT, LMscript.LMinstance.noLivesLM);
            // Timer has reached zero, you can handle the end of the timer here
            Debug.Log("Timer has reached zero!");
        }
    }

    private void UpdateTimerText()
    {
        if (timerTextT != null)
        {
            timerTextT.text = "Time Left: " + Mathf.Max(0, currentTimeT).ToString("F1");
        }
    }
}
