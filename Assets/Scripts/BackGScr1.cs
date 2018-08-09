using UnityEngine;
using System.Collections;

public class BackGScr1 : MonoBehaviour {
	public Sprite _sprite;
	private GameObject player;
	public ThemeTriger TSMM;
	// Use this for initialization
	void Start () 
	{
		player = (GameObject)this.gameObject;
		ThemeTriger TSMM = GameObject.Find("ThemeTriger").GetComponent<ThemeTriger>();
		//gameObject.GetComponent<SpriteRenderer>().sprite = spritesPeople[numberOfSprite];
		//ThemeTriger TT = GetComponent<ThemeTriger>();

		if (TSMM.NumberOfTheme == 0)
		{
			Vector3 _scale = new Vector3(10,10,1);
			player.transform.localScale = _scale;
		}
		if (TSMM.NumberOfTheme == 1)
		{
			Vector3 _scale = new Vector3(6000,4000,1);
			player.transform.localScale = _scale;
		}
	}

	// Update is called once per frame
	void Update () 
	{



	}
}
