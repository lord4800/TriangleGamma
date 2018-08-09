using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	public Texture2D _tex;
	public bool isTutor = false;
	// Use this for initialization
	void Start ()
	{
		isTutor = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown(KeyCode.W))
		{
			if (!isTutor)
			{
				Time.timeScale = 0;
				isTutor = true;
			}
			else
			{
				Time.timeScale = 1;
				isTutor = false;
			}

		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!isTutor)
			{
				Time.timeScale = 0;
				isTutor = true;
			}
			else
			{
				Time.timeScale = 1;
				isTutor = false;
			}
			
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (!isTutor)
			{
				Time.timeScale = 0;
				isTutor = true;
			}
			else
			{
				Time.timeScale = 1;
				isTutor = false;
			}
			
		}

	}
	void OnGUI()
	{
		if (isTutor == true)
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), _tex);
			//GUI.DrawTexture(new Rect(100,100,1000,1000), _tex);
		}
	}
}
