using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour {

    public Button button;
    public bool reset { get; set; }

    void Start()
    {
        reset = false;
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        reset = true;
    }
}
