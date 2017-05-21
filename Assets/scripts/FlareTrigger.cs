using UnityEngine;
using System.Collections;

public class FlareTrigger : MonoBehaviour
{
    GameObject flareObstacle;
    AudioSource sfx;

	// Use this for initialization
	void Start () {
        flareObstacle = GameObject.FindGameObjectWithTag("Flare Obstacle");
        sfx = GetComponent<AudioSource>();
	}
	
    void OnTriggerEnter(Collider collider)
    {
        flareObstacle.SetActive(false);
        sfx.Play();
    }

    void OnTriggerExit(Collider collider)
    {
        flareObstacle.SetActive(true);
    }
}
