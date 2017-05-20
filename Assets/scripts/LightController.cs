using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightController : MonoBehaviour
{
    public float minIntensity = 4f;
    public float maxIntensity = 8f;

    bool gotMax = false;
    float random;
    float variation;
    Light light;
    public float duration = 1.0f;

    void Start()
    {
        light = GetComponent<Light>();
        random = Random.Range(2.0f, 4.0f);

    }

    void Update()
    {
        //Debug.Log(light.intensity);
        //float noise = Mathf.PerlinNoise(random, Time.time);
        //light.intensity = Mathf.Lerp(minIntensity, maxIntensity, 0.1f);
        if (gotMax)
        {
            light.intensity -= (1.0f * random) * Time.deltaTime;
            if (light.intensity <= minIntensity)
            {
                gotMax = false;
            }
        }
    }
}
