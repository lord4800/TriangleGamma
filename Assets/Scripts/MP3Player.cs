﻿using UnityEngine;
using System.Collections;

public class MP3Player : MonoBehaviour {
	public AudioSource pleer;
	int currentTrek = 0;
	int numberTrek;
	public AudioClip[] treks;
	
	void Awake () {
		numberTrek = treks.Length - 1;
	}
	
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z))
		{
			pleer.Play();
		}
		
		if (Input.GetKeyDown(KeyCode.X))
		{
			pleer.Pause();
		}
		
		if (Input.GetKeyDown(KeyCode.B))
		{
			if (currentTrek + 1 <= numberTrek)
			{
				currentTrek++;
				SelectTrek(currentTrek);
				pleer.Play();
			}
			else
			{
				currentTrek=0;
				SelectTrek(0);
				pleer.Play();
			}
		}
		else if(Input.GetKeyDown(KeyCode.V))
		{
			if (currentTrek - 1 >= 0)
			{
				currentTrek--;
				SelectTrek(currentTrek);
				pleer.Play();
			}
			else
			{
				currentTrek = numberTrek;
				SelectTrek(currentTrek);
			}
		}
	}
	
	void SelectTrek(int index)
	{
		for (int cnt = 0; cnt < treks.Length; cnt++)
		{
			if (cnt == index)
			{
				pleer.clip = treks[cnt];
			}
		}
	}
}

