using UnityEngine;
using System.Collections;

public class ButtonScr : MonoBehaviour {
	public Camera camera;
	public GameObject buttons;
	public GameObject fbButton;
	public GameObject playButton;
	public GameObject twitterButton;
	public GameObject gearButton;
	public GameObject medalButton;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Vector2 xyPos = camera.ScreenToWorldPoint(Input.mousePosition);
			//buttons.PlayButton();
		}
	}
}
