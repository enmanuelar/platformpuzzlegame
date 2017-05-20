using UnityEngine;
using System.Collections;

public class FaceImgController : MonoBehaviour {

    GameObject face;
    bool trigger;
    float random;
    float counter = 10.0f;
    float disappear;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        trigger = false;
        disappear = 1.0f;
        counter += Random.Range(10.0f, 20.0f);
        face = GameObject.FindGameObjectWithTag("Face Img");
        face.SetActive(false);
        audio = face.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        counter -= Time.deltaTime;
        if (counter <= 0 && !trigger)
        {
            face.SetActive(true);
            audio.Play();
            trigger = true;
            disappear = 1.0f;
        }
        if (trigger)
        {
            disappear -= Time.deltaTime;
            if (disappear <= 0)
            {
                face.SetActive(false);
                trigger = false;
                counter = 10.0f + Random.Range(10.0f, 20.0f);
            }
        }
    }
}
