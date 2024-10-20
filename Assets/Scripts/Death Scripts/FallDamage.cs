using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDamage : MonoBehaviour
{
    private float startY;
    private bool isFalling = false;
    private bool fallThresholdReached = false;

    public float fallThreshold = 20.0f; // Fall distance that causes death

    void Update()
    {
        if (isFalling)
        {
            float fallDistance = startY - transform.position.y;

            if (fallDistance > fallThreshold)
            {
                fallThresholdReached = true; // Player fell far enough to trigger death
            }
        }
        else if (GetComponent<Rigidbody>().velocity.y < -0.1f)
        {
            isFalling = true;
            startY = transform.position.y;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (fallThresholdReached)
        {
            Die(); // Trigger death and load the correct retry menu
        }

        // Reset fall detection
        isFalling = false;
        fallThresholdReached = false;
    }

    void Die()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex; // Get current level

        int retryScene = GetRetryScene(currentScene); // Get the correct retry menu
        SceneManager.LoadScene(retryScene); // Load retry menu
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
