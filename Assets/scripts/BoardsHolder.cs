using UnityEngine;
using System.Collections;

public class BoardsHolder : MonoBehaviour {

    public GameObject[] boards;


	// Use this for initialization
	void Start ()
    {
	    foreach (GameObject board in boards){
            board.SetActive(false);
        }    
	}
	
}
