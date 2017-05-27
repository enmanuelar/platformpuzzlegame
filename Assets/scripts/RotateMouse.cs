using UnityEngine;
using System.Collections;

public class RotateMouse : MonoBehaviour {
    public float speed = 50.0f;
    public bool useJoystick = false;
    public VirtualJoystick joystick;
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Input.GetAxis("Mouse Y"));
        if (useJoystick)
        {
            transform.Rotate(new Vector3(joystick.Horizontal(), 0, joystick.Vertical()) * Time.deltaTime * speed);
        }
        else
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y")) * Time.deltaTime * speed);
        }
    }
}
