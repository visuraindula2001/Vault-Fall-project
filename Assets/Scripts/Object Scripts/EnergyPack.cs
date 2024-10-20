using UnityEngine;

public class EnergyPack : MonoBehaviour
{
    public float extraTime = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameTimer timer = FindObjectOfType<GameTimer>();
            if (timer != null)
            {
                timer.AddTime(extraTime);
            }
            Destroy(gameObject); // Remove the energy pack after use
        }
    }
}
