using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management
using System.Collections; // Needed for coroutines

public class ChestInteraction : MonoBehaviour
{
    public GameObject closedChest;  // Reference to the closed chest model
    public GameObject openChest;    // Reference to the open chest model
    public float transitionDelay = 1.0f;  // Delay in seconds before loading Victory Scene

    void Start()
    {
        // Ensure the closed chest is active at the start
        closedChest.SetActive(true);
        openChest.SetActive(false);
    }

    // Trigger event when player interacts with the chest
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the chest
        if (other.CompareTag("Player"))
        {
            // Open the chest by switching the models
            closedChest.SetActive(false);
            openChest.SetActive(true);

            // Start the scene transition after a delay
            StartCoroutine(TransitionToVictoryScene());
        }
    }

    // Coroutine to wait before switching to the Victory Scene
    private IEnumerator TransitionToVictoryScene()
    {
        yield return new WaitForSeconds(transitionDelay); // Wait for the transition delay

        int currentScene = SceneManager.GetActiveScene().buildIndex; // Get current level index
        int victoryScene = GetVictoryScene(currentScene); // Get the correct victory menu

        SceneManager.LoadScene(victoryScene); // Load the victory menu
    }

    // Determine the appropriate victory menu based on the current level
    private int GetVictoryScene(int levelIndex)
    {
        switch (levelIndex)
        {
            case 1: return 2; // Level 1 -> Victory menu 2
            case 4: return 5; // Level 2 -> Victory menu 5
            case 7: return 8; // Level 3 -> Victory menu 8
            default: return 2; // Default fallback to victory menu 2
        }
    }
}
