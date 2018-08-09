using UnityEngine;
using System.Collections;

public class Triger : MonoBehaviour {
	/// <summary>
	/// Here we gona make triger script for all our scene
	/// </summary>

	public PauseScr PS; //Script of pause scr
	public Tutorial T; //Script of tutorial
	public GameOverSc GOScr; //Script of gameover
	public PlayerBackGround1 PBG1; //Scripts of music player (1 - background 2 - buttons)
	public playerManager PM; 
	public MAIN M; //Script of game
	//make our state mark
	public int Status;
	public bool TPause = false;
	public bool Tutorial = false;
	public bool TGameOver = false;
	public bool TPlayer = false;
	public bool TMain = false;


	// Use this for initialization
	void Start () 
	{
		PauseScr PS = GetComponent<PauseScr>();
		Tutorial T = GetComponent<Tutorial>();
		GameOverSc GOScr = GetComponent<GameOverSc>();
		PlayerBackGround1 PBG1 = GetComponent<PlayerBackGround1>();
		playerManager PM = GetComponent<playerManager>();
		MAIN M = GetComponent<MAIN>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        
		// for seen timer and points
		// 
		if (PS.IsPaused || T.isTutor || GameOverSc.GameOv) 
		{
			TMain = false;
		}
		else
		{
			TMain = true;
		}
		// for seen pause sprite
		if ((!T.isTutor && !GameOverSc.GameOv) && (PS.IsPaused))
		{
				Debug.Log("<<<<<True in Tutor>>>>>"); 
				TPause = true;
		}
		else 
		{
				Debug.Log("<<<<<False in Tutor>>>>>"); 
				TPause = false;
		}
		// for seen player
		if (PS.IsPaused || T.isTutor || GameOverSc.GameOv)  
		{
			TPlayer = true;
		}
		else 
		{
			TPlayer = false;
		}
	}
}
