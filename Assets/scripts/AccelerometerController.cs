using UnityEngine;

public class AccelerometerController : MonoBehaviour {
    public bool isFlat = true;
    //public float speed = 50f;
    private Rigidbody rigid;

	// Use this for initialization
	void Start () {
        //rigid = GetComponent<Rigidbody>();
    }
	
    public Vector3 rotatePlatform (float speed)
    {
        Vector3 tilt = Input.acceleration;
        //Debug.Log(tilt);
        return new Vector3(tilt.x, 0, tilt.y) * Time.deltaTime * speed;
    }

	// Update is called once per frame
	void Update () {
        /*Vector3 tilt = Input.acceleration;
        if (isFlat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }
        rigid.AddForce(tilt);
        Debug.DrawRay(transform.position + Vector3.up, tilt, Color.cyan);*/
        /*Vector3 tilt = Input.acceleration;
        transform.Rotate(new Vector3(tilt.x, 0, tilt.y) * Time.deltaTime * speed);
        Debug.DrawRay(transform.position + Vector3.up, tilt, Color.cyan);*/
    }
}
