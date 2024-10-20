using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 180f; // 3 minutes in seconds
    public TextMeshProUGUI timerText; // Optional: Assign UI Text to display the timer
    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            timeLimit -= Time.deltaTime;

            if (timerText != null) // Update UI text if available
            {
                int minutes = Mathf.FloorToInt(timeLimit / 60f);
                int seconds = Mathf.FloorToInt(timeLimit % 60f);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }

            if (timeLimit <= 0)
            {
                GameOver(); // Time's up, trigger game over
            }
        }
    }

    public void AddTime(float extraTime)
    {
        timeLimit += extraTime; // Add extra time when an energy pack is collected
    }

    void GameOver()
    {
        isGameOver = true;

        int currentScene = SceneManager.GetActiveScene().buildIndex; // Get current level index
        int retryScene = GetRetryScene(currentScene); // Get the correct retry menu

        SceneManager.LoadScene(retryScene); // Load the retry menu
    }

    // Determine the appropriate retry menu based on the current level
    int GetRetryScene(int levelIndex)
    {
        switch (levelIndex)
        {
            case 1: return 3; // Level 1 -> Retry menu 3
            case 4: return 6; // Level 2 -> Retry menu 6
            case 7: return 9; // Level 3 -> Retry menu 9
            default: return 3; // Default fallback to retry menu 3
        }
    }
}
