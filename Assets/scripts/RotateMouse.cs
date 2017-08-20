using UnityEngine;
using System.Collections;

public class RotateMouse : MonoBehaviour {
    public bool useJoystick = false;
    public bool useGyro = true;
    public VirtualJoystick joystick;
    Vector3 joystickVector;
    Vector3 gyroVector;
    Vector3 mouseVector;

    public RotateMouse ()
    {

    }

    public Vector3 GetVector ()
    {
        if (useJoystick)
        {
            joystickVector = new Vector3(joystick.Horizontal(), 0, joystick.Vertical());
            return joystickVector;
        }
        else if (useGyro && Input.gyro.enabled)
        {
            gyroVector = new Vector3(Input.gyro.rotationRateUnbiased.y, 0, Input.gyro.rotationRateUnbiased.x * -1);
            return gyroVector;
        }
        else
        {
            mouseVector = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
            return mouseVector;
        }
    }
}
