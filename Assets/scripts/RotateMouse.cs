using UnityEngine;
using System.Collections;

public class RotateMouse : MonoBehaviour {
    public float speed = 50.0f;
    public bool useJoystick = false;
    public bool useGyro = false;
    public VirtualJoystick joystick;
    GyroController gyroController = new GyroController();
    private Gyroscope gyro;
    Vector3 gyroVector;
    void Start ()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Debug.Log("Support gyro");
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(Input.GetAxis("Mouse Y"));
        if (useJoystick)
        {
            transform.Rotate(new Vector3(joystick.Horizontal(), 0, joystick.Vertical()) * Time.deltaTime * speed);
        }
        else if (useGyro && Input.gyro.enabled) 
        {
            gyroVector = new Vector3(Input.gyro.rotationRateUnbiased.y, 0, Input.gyro.rotationRateUnbiased.x * -1);
            Debug.Log(gyroVector);
            transform.Rotate(gyroVector * Time.deltaTime * speed);
        }
        else
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y")) * Time.deltaTime * speed);
        }
    }
}
