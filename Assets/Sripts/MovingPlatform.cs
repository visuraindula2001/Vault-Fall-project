using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;
    private bool movingToB = true;

    void Update()
    {
        if (movingToB)
            transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, pointA, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, pointB) < 0.1f)
            movingToB = false;
        else if (Vector3.Distance(transform.position, pointA) < 0.1f)
            movingToB = true;
    }
}
