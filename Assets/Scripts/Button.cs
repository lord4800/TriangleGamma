using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	//GameObject GO;
	public Texture2D[] Textur;
	public bool State = true;
	public int X;
	public int Y;
	public int XSize;
	public int YSize;
	// Use this for initialization
	void Start () {

	}
	void OnGUI()
	{
		//X = transform.TransformPoint();
		Rect Rectangle = new Rect(Screen.width/2 - X + XSize/2, Screen.height/2 - Y + YSize/2, XSize, YSize);
		//Rect Rectangle = new Rect(transform.localPosition.x,transform.localPosition.z,50,50);
		//Rect Rectangle = new Rect(X, Y, XSize, YSize);
		if (!State)
		{
			GUI.DrawTexture(Rectangle, Textur[0]);
		}
		else
		{
			GUI.DrawTexture(Rectangle, Textur[1]);
		}
	}
	// Update is called once per frame
	/*void Update () {
		Rect Rectangle = new Rect(X, Y, XSize, YSize);
		if (!State)
		{
			GUI.DrawTexture(Rectangle, Textur[0]);
		}
		else
		{
			GUI.DrawTexture(Rectangle, Textur[1]);
		}
	}*/
}
