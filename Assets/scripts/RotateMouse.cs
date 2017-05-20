using UnityEngine;
using System.Collections;

public class RotateMouse : MonoBehaviour {
    public float speed = 50.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Input.GetAxis("Mouse Y"));
        transform.Rotate(new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y")) * Time.deltaTime * speed);
	}
}
