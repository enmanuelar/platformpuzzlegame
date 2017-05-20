using UnityEngine;
using System.Collections;

public class MakeItMove : MonoBehaviour {

    public float speed = 100f;
    // Use this for initialization
    void Start () {

    }


    // Update is called once per frame
    void Update() {
        Vector3 dir = Vector3.zero;
        dir.z = Input.acceleration.z;
        dir.x = -Input.acceleration.x;

        //dir.x = 1;
        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }
        dir *= Time.deltaTime;
        if (transform.rotation.eulerAngles.y > 135)
        {
            transform.rotation = Quaternion.Euler(0, 135, 90);
        }
        else if (transform.rotation.eulerAngles.y < 45)
        {
            transform.rotation = Quaternion.Euler(0, 45, 90);
        }
        else
        {
            Debug.Log(dir.x);
            transform.Rotate(dir * speed);
        }
       // Debug.Log(transform.rotation.eulerAngles.y);
       
    }
}
