using UnityEngine;
using UnityEngine.SceneManagement; // To restart the game

public class FallDamage : MonoBehaviour
{
    private float startY; // To store the player's starting height
    private bool isFalling = false;
    private bool fallThresholdReached = false;

    // Set this to the fall distance that causes death (20 units)
    public float fallThreshold = 20.0f;

    void Update()
    {
        // Check if the player is falling
        if (isFalling)
        {
            float fallDistance = startY - transform.position.y;

            // Check if the fall distance exceeds the threshold (e.g. 20 units)
            if (fallDistance > fallThreshold)
            {
                fallThresholdReached = true; // Player has fallen far enough to die
            }
        }
        else
        {
            // If player is not falling, check if they are about to start falling
            if (GetComponent<Rigidbody>().velocity.y < -0.1f)
            {
                isFalling = true;
                startY = transform.position.y;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // If the player hits something after falling more than the threshold
        if (fallThresholdReached)
        {
            Die(); // Player dies when hitting something after falling > 20 units
        }

        // Reset fall detection after collision
        isFalling = false;
        fallThresholdReached = false;
    }

    void Die()
    {
        // Restart the game when the player dies
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
