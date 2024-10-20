using UnityEngine;
using UnityEngine.SceneManagement;

public class FireCubeDeath : MonoBehaviour
{
    // Trigger function when something enters the fire cube's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player by tag
        if (other.CompareTag("Player"))
        {
            Die(); // Trigger the player's death
        }
    }

    // Player death method: Load the appropriate retry menu
    private void Die()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex; // Get current level

        int retryScene = GetRetryScene(currentScene); // Get the correct retry menu
        SceneManager.LoadScene(retryScene); // Load retry menu
    }

    // Determine the appropriate retry menu based on the current level
    private int GetRetryScene(int levelIndex)
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
