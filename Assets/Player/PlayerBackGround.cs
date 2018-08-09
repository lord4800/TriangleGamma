using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class PlayerBackGround : MonoBehaviour {
	//private Camera _Camera;

	public GameObject otherGameObject;
	
	public  GameObject MainCam;
	private PlayButton MBack;
	//private BlurOptimized MBack1;
	//private BlurOptimized anotherScript;
	//private YetAnotherScript yetAnotherScript;
	private BoxCollider boxCol;
	// Use this for initialization
	void Start () 
	{
	//	anotherScript = MainCam.GetComponent<BlurOptimize>();
		/*
		 * 
		 * 
		 * 
		 * 
		 * MainCam.gameObject.GetComponent<BlurOptimize>().enabled = true;
		MainCam1 = GetComponent<BlurOptimized> ();
		MainCam.enable = false;*/
		/*
		_Camera = GameObject.Find("Main Camera").GetComponent<BlurOptimized>();
		_Camera.enabled = false;*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
