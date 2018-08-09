using UnityEngine;
using System.Collections;

public class BackGScr : MonoBehaviour {

	private GameObject player;
	public ThemeScriptMM TSMM;
	// Use this for initialization
	void Start () 
	{
		ThemeScriptMM TSMM = GameObject.Find("TSMM").GetComponent<ThemeScriptMM>();
		//ThemeTriger TT = GetComponent<ThemeTriger>();
		player = (GameObject)this.gameObject;
	}

	// Update is called once per frame
	void Update () 
	{

		gameObject.GetComponent<SpriteRenderer>().sprite = TSMM.BackGroundT;
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
}
