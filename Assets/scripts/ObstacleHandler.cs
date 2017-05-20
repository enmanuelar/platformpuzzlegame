using UnityEngine;
using System.Collections;

public class ObstacleHandler : MonoBehaviour {

    AudioSource audio;
    float minIntensity = 0.0f;
    public float maxIntensity = 8f;
    bool gotMax;
    bool partEnabled;
    Light light;
    GameObject particleObj;
    ParticleSystem particle;
    float countDownParticle = 1.0f;

    // Use this for initialization
    void Start () {
        partEnabled = false;
        gotMax = false;
        light = GetComponent<Light>();
        audio = GetComponent<AudioSource>();
        particleObj = GameObject.FindGameObjectWithTag("Particle");
        particle = particleObj.GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2.0f)
        {
            if(this.name == "Cylinder obst 1 (4)")
            {
                var em = particle.emission;
                em.enabled = true;
                partEnabled = true;
            }
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

    void StopParticles()
    {
        countDownParticle -= Time.deltaTime;
        if (countDownParticle <= 0)
        {
            var em = particle.emission;
            em.enabled = false;
            partEnabled = false;
            countDownParticle = 1.0f;
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
        if (partEnabled)
        {
            StopParticles();
        }
    }
}
