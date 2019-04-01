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
	
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Vector2 xyPos = camera.ScreenToWorldPoint(Input.mousePosition);
		}
	}
}
