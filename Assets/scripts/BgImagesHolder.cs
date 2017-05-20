using UnityEngine;
using System.Collections;

public class BgImagesHolder : MonoBehaviour {

    public GameObject[] bgImages;

    // Use this for initialization
    void Start()
    {
        foreach (GameObject image in bgImages)
        {
            image.SetActive(false);
        }
    }
}
