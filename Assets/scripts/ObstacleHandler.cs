using UnityEngine;
using System.Collections;

public class ObstacleHandler : MonoBehaviour {

    AudioSource audio;
    float minIntensity = 0.0f;
    public float maxIntensity = 8f;
    bool gotMax;
    Light light;

    // Use this for initialization
    void Start () {
        gotMax = false;
        light = GetComponent<Light>();
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2.0f)
        {
            light.intensity = Mathf.Lerp(minIntensity, maxIntensity, 2.0f);
            audio.Play();
        }
    }

    void ReduceIntensity()
    {
        light.intensity -= 3.0f * Time.deltaTime;
        if (light.intensity <= 0.0f)
        {
            gotMax = false;
        }
    }

    void Update()
    {
        if (light.intensity >= maxIntensity)
        {
            gotMax = true;
        }
        if (gotMax)
        {
            ReduceIntensity();
        }
    }
}
