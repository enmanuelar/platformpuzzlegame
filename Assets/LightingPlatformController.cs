using UnityEngine;
using System.Collections;

public class LightingPlatformController : MonoBehaviour {
    float intesity;
    public HoleCollider hole;
    BoardsHolder boards;

    // Use this for initialization
    void Start () {
        intesity = 1.0f;
        boards = GameObject.Find("BoardsHolder").GetComponent<BoardsHolder>();
        hole = boards.boards[2].GetComponentInChildren<HoleCollider>();
    }

    void ReduceAmbientIntensity (float intensity)
    {
        RenderSettings.ambientIntensity = intensity;
    }

	// Update is called once per frame
	void Update () {
        if (intesity >= 0)
        {
            intesity -= Time.deltaTime / 5;
            ReduceAmbientIntensity(intesity);
        }
        else
        {
            intesity = 0.0f;
        }
        if (hole.onCollider1 && hole.onCollider2)
        {
            intesity += Time.deltaTime / 5;
            ReduceAmbientIntensity(intesity);
        }
    }
}
