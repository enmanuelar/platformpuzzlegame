using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HoleCollider : MonoBehaviour {
    public bool onCollider1;
    public bool onCollider2;



    void CheckCollision(string values)
    {
       
        string[] val = values.Split('/');
        if (val[0] == "Hole Collider 1")
        {
            onCollider1 = System.Convert.ToBoolean(val[1]);
        }
        else if (val[0] == "Hole Collider 2")
        {
            onCollider2 = System.Convert.ToBoolean(val[1]);
        }
    }


}

