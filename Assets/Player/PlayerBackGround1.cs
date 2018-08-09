using UnityEngine;
using System.Collections;

public class PlayerBackGround1 : MonoBehaviour {
	private bool IsVisible;
	public Texture2D Tex;
	public PauseScr PSC;
	public GameOverSc GOS; 
	// Use this for initialization
	void Start () 
	{
		IsVisible = false;
		PauseScr PSC = GetComponent<PauseScr>();
		GameOverSc GOS = GetComponent<GameOverSc>();
	}

	// Update is called once per frame
	void Update () 
	{
		if(PSC.IsPaused == true || GameOverSc.GameOv == true)
		{
			IsVisible = true;	
		}
		else 
		{
			IsVisible = false;	
		}
	}
	void OnGUI ()
	{
		if (IsVisible == true) 
		{
            //GUI.DrawTexture(new Rect(Screen.width/2 - 269, 0,538,110), Tex);
            GUI.DrawTexture(new Rect((Screen.width / 2)- (Screen.width / 4), (Screen.height / 20)- (Screen.height / 10), (Screen.width / 2), (Screen.height / 4)- (Screen.height / 29)), Tex);
        }
	}
}
