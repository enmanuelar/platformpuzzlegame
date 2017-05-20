using UnityEngine;
using System.Collections;

public class HoleController : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        //CheckCollision(this.name, true);
        gameObject.SendMessageUpwards("CheckCollision", this.name + '/' + "true");
    }

    void OnTriggerExit(Collider hole1)
    {
        //CheckCollision(this.name, false);
        gameObject.SendMessageUpwards("CheckCollision", this.name + '/' + "false");
    }
}
