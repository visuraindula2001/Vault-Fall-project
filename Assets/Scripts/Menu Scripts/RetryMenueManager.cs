using UnityEngine;

public class RetryMenuManager : MonoBehaviour
{
    void Start()
    {
        // Unlock the cursor and make it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
