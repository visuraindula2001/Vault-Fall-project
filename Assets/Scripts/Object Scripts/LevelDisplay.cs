using UnityEngine;
using TMPro;  // Ensure TextMeshPro is used
using System.Collections;  // Required for IEnumerator

public class LevelDisplay : MonoBehaviour
{
    public float displayDuration = 3f;  // Time to show the text
    private TextMeshProUGUI levelText;  // Reference to the text component

    void Start()
    {
        // Get the TextMeshPro component attached to this GameObject
        levelText = GetComponent<TextMeshProUGUI>();

        // Start the coroutine to display the level text
        StartCoroutine(ShowLevelText());
    }

    private IEnumerator ShowLevelText()
    {
        // Ensure the text is visible initially
        levelText.enabled = true;

        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        // Hide the text after the duration
        levelText.enabled = false;
    }
}
