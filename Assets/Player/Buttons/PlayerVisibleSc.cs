using UnityEngine;
using System.Collections;

public class PlayerVisibleSc : MonoBehaviour 
{
	public GameObject Pause;
	public GameObject GameOver;
	public GameObject Player;
	public PauseScr PS;
	public GameOverSc GOS; 
	bool IsPS;
	bool IsGOS;
	// Use this for initialization
	void Start () 
	{
		IsPS = Pause.GetComponent<PauseScr>().IsPaused;
		IsGOS = GameOverSc.GameOv;

	}
	
	// Update is called once per frame
	void Update () 
	{
		IsPS = Pause.GetComponent<PauseScr>().IsPaused;
		IsGOS = GameOverSc.GameOv;
		if (IsPS || IsGOS)
		{
			Player.GetComponent<Canvas>().enabled = true;
		}
		if (!IsPS && !IsGOS)
		{
			Player.GetComponent<Canvas>().enabled = false;
		}
	}
}
