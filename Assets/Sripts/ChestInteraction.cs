using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject closedChest;  // Reference to the closed chest model
    public GameObject openChest;    // Reference to the open chest model

    void Start()
    {
        // Make sure only the closed chest is active initially
        closedChest.SetActive(true);
        openChest.SetActive(false);
    }

    // This method is called when another collider enters this object's trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the chest
        if (other.CompareTag("Player"))
        {
            // Open the chest by switching the models
            closedChest.SetActive(false);
            openChest.SetActive(true);

            // You can also add additional functionality here, such as playing sound or animations
        }
    }
}
