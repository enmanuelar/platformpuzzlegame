using UnityEngine;
using System.Collections;

public class ObstacleParticleController : MonoBehaviour
{
    bool particleEnabled;
    GameObject particleObj;
    ParticleSystem particle;
    float countDownParticle;

    // Use this for initialization
    void Start()
    {
        particleEnabled = false;
        countDownParticle = 1.0f;
        particleObj = GameObject.FindGameObjectWithTag("Particle");
        particle = particleObj.GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2.0f)
        {
            var emission = particle.emission;
            emission.enabled = true;
            particleEnabled = true;
        }
    }

    void StopParticles()
    {
        countDownParticle -= Time.deltaTime;
        if (countDownParticle <= 0)
        {
            var em = particle.emission;
            em.enabled = false;
            particleEnabled = false;
            countDownParticle = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (particleEnabled)
        {
            StopParticles();
        }
    }
}
