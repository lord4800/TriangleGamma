using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {
	public Texture2D _tex;
        
        float timer = 3;
	void Update()
	{
		timer -= Time.deltaTime;
		if(timer < 1)
		{
			Application.LoadLevel("MineMenuVar2");
		} 
	}
	void OnGUI()
	{

        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), _tex);

	}
}
