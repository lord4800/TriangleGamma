using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour {
    private Text fpsText;

    void Start () {
        fpsText = GetComponent<Text>();
	}

    void Update () {
        fpsText.text = (1 / Time.deltaTime).ToString();
	}
}
