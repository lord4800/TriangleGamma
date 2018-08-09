using UnityEngine;
using System.Collections;

public class UniversalScript : MonoBehaviour {
	//public ThemeTriger ThemeT;
	//public int WhatSpriteTake;
	private Sprite _sprite;
	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		//ThemeTriger ThemeT = GetComponent<ThemeTriger>();
		player = (GameObject)this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.GetComponent<SpriteRenderer>().sprite = ThemeT.Buffer;
	}
}
