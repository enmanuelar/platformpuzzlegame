using UnityEngine;
using System.Collections;

public class RotationTest : MonoBehaviour {

    public float speed = 100f;

	void Update () {
        Vector3 dir = Vector3.zero;
        dir.z = -Input.acceleration.z;

        dir.x = Input.acceleration.x;
        /*if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }
        dir *= Time.deltaTime;
        if (transform.rotation.eulerAngles.x > 30)
        {
            transform.rotation = Quaternion.Euler(30, 0, 0);
        }
        else if (transform.rotation.eulerAngles.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            //transform.Rotate(dir * speed);
        }*/
        transform.rotation = Quaternion.Euler(dir * speed * Time.smoothDeltaTime * 10);

    }
}
