using UnityEngine;
using System.Collections;

public class StarPlatformController : MonoBehaviour {
    float rotationCountDown = 5.0f;
    // Use this for initialization
    void Start () {
        
    }

    void RotatePlatform()
    {

        /*Quaternion newRotation = Quaternion.AngleAxis(90, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .05f);*/
        Vector3 newRotation = new Vector3(0, 360, 0);
        transform.Rotate(Vector3.Slerp(new Vector3(0, 0, 0), new Vector3(0, 360, 0), 0.3f * Time.deltaTime));

    }
	// Update is called once per frame
	void Update () {
        rotationCountDown -= Time.deltaTime;
        //Debug.Log(rotationCountDown);
        if (rotationCountDown <= 0)
        {
            RotatePlatform();
           if (rotationCountDown <= -1.0f)
            {
                rotationCountDown = 5.0f;
            }
            
        }
	}
}
