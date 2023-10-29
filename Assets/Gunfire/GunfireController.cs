using UnityEngine;

public class GunfireLightFlickerTwoIntensities : MonoBehaviour
{
    public float flickerFrequency = 0.1f;  // Adjust to control the flicker speed
    public float intensity1 = 0.0f;       // First intensity value
    public float intensity2 = 1.0f;       // Second intensity value

    private Light spotLight;
    private float flickerTimer;
    private bool useIntensity1;

    void Start()
    {
        spotLight = GetComponent<Light>();
        useIntensity1 = true; // Start with the first intensity
    }

    void Update()
    {
        flickerTimer += Time.deltaTime;

        if (flickerTimer >= flickerFrequency)
        {
            flickerTimer = 0;
            if (useIntensity1)
            {
                spotLight.intensity = intensity2;
            }
            else
            {
                spotLight.intensity = intensity1;
            }

            useIntensity1 = !useIntensity1; // Toggle between intensities
        }
    }
}
