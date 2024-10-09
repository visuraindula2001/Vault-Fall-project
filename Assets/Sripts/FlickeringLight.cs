using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour
{
    public Light flickerLight;
    public float minTime = 0.2f;
    public float maxTime = 0.5f;

    void Start()
    {
        if (flickerLight == null)
            flickerLight = GetComponent<Light>();

        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            flickerLight.enabled = !flickerLight.enabled;
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
}
