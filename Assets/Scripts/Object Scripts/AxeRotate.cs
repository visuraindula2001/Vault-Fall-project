using UnityEngine;

public class AxeRotate : MonoBehaviour

{
    public float rotationSpeed = 100f; // Adjust this to control rotation speed

    void Update()
    {
        // Rotate the hammer clockwise around the X-axis
        transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
    }
}


