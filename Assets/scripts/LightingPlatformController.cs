using UnityEngine;
using System.Collections;

public class LightingPlatformController : MonoBehaviour {
    float intesity;

    // Use this for initialization
    void Start () {
        intesity = 1.0f;
    }

    void ReduceAmbientIntensity (float intensity)
    {
        RenderSettings.ambientIntensity = intensity;
    }

	// Update is called once per frame
	void Update () {
        if (intesity >= 0)
        {
            intesity -= Time.deltaTime / 5;
            ReduceAmbientIntensity(intesity);
        }
        else
        {
            intesity = 0.0f;
        }
    }
}
