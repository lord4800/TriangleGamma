using UnityEngine;
using System.Collections;

public class ThemeScriptMM : MonoBehaviour {
	public int NumberOfTheme = 0;
	public Texture2D[] Facebook;
	public Texture2D[] Twitter;
	public Texture2D[] Settings;
	public Texture2D[] Play;
	public Texture2D[] Record;
	public Texture2D[] Vk;
	public Texture2D[] Home;
	public Sprite BackGroundT;
	public UniversalScript Green;
	public UniversalScript Red;
	public UniversalScript Yellow;
	Texture2D TB;


	public bool IsChange = false;
	public bool IsChangeDone = false;
	Object _obj;
	// Use this for initialization
	void Start () {
		UniversalScript Green = GameObject.Find("Green").GetComponent<UniversalScript>();
		UniversalScript Red = GameObject.Find("Blue").GetComponent<UniversalScript>();
		UniversalScript Yellow = GameObject.Find("Yellow").GetComponent<UniversalScript>();
		NumberOfTheme = PlayerPrefs.GetInt("Theme");
		if (NumberOfTheme == 0)
		{
			_obj = Resources.Load("Material_150/Green");
			TB = (Texture2D)_obj;
			Green.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));

			_obj = Resources.Load("Material_150/Red");
			TB = (Texture2D)_obj;
			Red.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));

			_obj = Resources.Load("Material_150/Coin");
			TB = (Texture2D)_obj;
			Yellow.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));

			_obj = Resources.Load("Buttons/01-Material/Original/Connect-1");
			Twitter[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pointed/Connect-2");
			Twitter[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pressed/Connect-3");
			Twitter[2] = (Texture2D)_obj;

			_obj = Resources.Load("Buttons/01-Material/Original/Theme-1");
			Facebook[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pointed/Theme-2");
			Facebook[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pressed/Theme-3");
			Facebook[2] = (Texture2D)_obj;

			_obj = Resources.Load("Buttons/01-Material/Original/info-1");
			Vk[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pointed/info-2");
			Vk[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pressed/info-3");
			Vk[2] = (Texture2D)_obj;

			_obj = Resources.Load("Buttons/01-Material/Original/medal-1");
			Record[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pointed/medal-2");
			Record[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pressed/medal-3");
			Record[2] = (Texture2D)_obj;

			_obj = Resources.Load("Buttons/01-Material/Original/Exit-1");
			Home[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pointed/Exit-2");
			Home[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pressed/Exit-3");
			Home[2] = (Texture2D)_obj;

			_obj = Resources.Load("Buttons/01-Material/Original/settings-1");
			Settings[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pointed/settings-2");
			Settings[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pressed/settings-3");
			Settings[2] = (Texture2D)_obj;

			_obj = Resources.Load("Buttons/01-Material/Original/Original_Triangle");
			Play[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pointed/Pointed_Triangle");
			Play[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/01-Material/Pressed/Pressed_Triangle");
			Play[2] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/Background_Dark");
			TB = (Texture2D)_obj;
			BackGroundT = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			IsChangeDone = true;
		}
		if (NumberOfTheme == 1)
		{
			_obj = Resources.Load("Neon_150/Green");
			TB = (Texture2D)_obj;
			Green.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));

			_obj = Resources.Load("Neon_150/Red");
			TB = (Texture2D)_obj;
			Red.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));

			_obj = Resources.Load("Neon_150/Coin");
			TB = (Texture2D)_obj;
			Yellow.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));


			_obj = Resources.Load("Buttons/02-Neon/Original/Connect-1");
			Twitter[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Pointed/Connect-2");
			Twitter[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Pressed/Connect-3");
			Twitter[2] = (Texture2D)_obj;

			_obj = Resources.Load("Buttons/02-Neon/Original/Theme-1");
			Facebook[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Pointed/Theme-2");
			Facebook[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Pressed/Theme-3");
			Facebook[2] = (Texture2D)_obj;

			_obj = Resources.Load("Buttons/02-Neon/Original/info-1");
			Vk[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Pointed/info-2");
			Vk[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Pressed/info-3");
			Vk[2] = (Texture2D)_obj;

			_obj = Resources.Load("Buttons/02-Neon/Original/medal-1");
			Record[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Pointed/medal-2");
			Record[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Pressed/medal-3");
			Record[2] = (Texture2D)_obj;

			_obj = Resources.Load("Buttons/02-Neon/Original/Exit-1");
			Home[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Pointed/Exit-2");
			Home[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Pressed/Exit-3");
			Home[2] = (Texture2D)_obj;

			_obj = Resources.Load("Buttons/02-Neon/Original/settings-1");
			Settings[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Pointed/settings-2");
			Settings[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Pressed/settings-3");
			Settings[2] = (Texture2D)_obj;

			_obj = Resources.Load("Buttons/02-Neon/Original/Neon Triangle");
			Play[0] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Original/Neon Triangle");
			Play[1] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/02-Neon/Original/Neon Triangle");
			Play[2] = (Texture2D)_obj;
			_obj = Resources.Load("Buttons/1px");
			TB = (Texture2D)_obj;
			BackGroundT = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			IsChangeDone = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (IsChangeDone) 
		{
			IsChangeDone = false;
			IsChange = false;
			//D:\багаж\тим лид\Unity\Beta_130_20_05_2016\Beta_130_20_05_2016\Assets\Resources\Buttons\01-Material\Original

		}

		if (IsChange){
			if (NumberOfTheme == 0)
			{
				_obj = Resources.Load("Material_150/Green");
				TB = (Texture2D)_obj;
				Green.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));

				_obj = Resources.Load("Material_150/Red");
				TB = (Texture2D)_obj;
				Red.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));

				_obj = Resources.Load("Material_150/Coin");
				TB = (Texture2D)_obj;
				Yellow.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));

				_obj = Resources.Load("Buttons/01-Material/Original/Connect-1");
				Twitter[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pointed/Connect-2");
				Twitter[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pressed/Connect-3");
				Twitter[2] = (Texture2D)_obj;

				_obj = Resources.Load("Buttons/01-Material/Original/Theme-1");
				Facebook[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pointed/Theme-2");
				Facebook[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pressed/Theme-3");
				Facebook[2] = (Texture2D)_obj;

				_obj = Resources.Load("Buttons/01-Material/Original/info-1");
				Vk[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pointed/info-2");
				Vk[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pressed/info-3");
				Vk[2] = (Texture2D)_obj;

				_obj = Resources.Load("Buttons/01-Material/Original/medal-1");
				Record[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pointed/medal-2");
				Record[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pressed/medal-3");
				Record[2] = (Texture2D)_obj;

				_obj = Resources.Load("Buttons/01-Material/Original/Exit-1");
				Home[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pointed/Exit-2");
				Home[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pressed/Exit-3");
				Home[2] = (Texture2D)_obj;

				_obj = Resources.Load("Buttons/01-Material/Original/settings-1");
				Settings[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pointed/settings-2");
				Settings[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pressed/settings-3");
				Settings[2] = (Texture2D)_obj;

				_obj = Resources.Load("Buttons/01-Material/Original/Original_Triangle");
				Play[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pointed/Pointed_Triangle");
				Play[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/01-Material/Pressed/Pressed_Triangle");
				Play[2] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/Background_Dark");
				TB = (Texture2D)_obj;
				BackGroundT = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
				IsChangeDone = true;
			}
			if (NumberOfTheme == 1)
			{
				_obj = Resources.Load("Neon_150/Green");
				TB = (Texture2D)_obj;
				Green.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));

				_obj = Resources.Load("Neon_150/Red");
				TB = (Texture2D)_obj;
				Red.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));

				_obj = Resources.Load("Neon_150/Coin");
				TB = (Texture2D)_obj;
				Yellow.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));

				_obj = Resources.Load("Buttons/02-Neon/Original/Connect-1");
				Twitter[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Pointed/Connect-2");
				Twitter[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Pressed/Connect-3");
				Twitter[2] = (Texture2D)_obj;

				_obj = Resources.Load("Buttons/02-Neon/Original/Theme-1");
				Facebook[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Pointed/Theme-2");
				Facebook[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Pressed/Theme-3");
				Facebook[2] = (Texture2D)_obj;

				_obj = Resources.Load("Buttons/02-Neon/Original/info-1");
				Vk[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Pointed/info-2");
				Vk[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Pressed/info-3");
				Vk[2] = (Texture2D)_obj;

				_obj = Resources.Load("Buttons/02-Neon/Original/medal-1");
				Record[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Pointed/medal-2");
				Record[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Pressed/medal-3");
				Record[2] = (Texture2D)_obj;

				_obj = Resources.Load("Buttons/02-Neon/Original/Exit-1");
				Home[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Pointed/Exit-2");
				Home[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Pressed/Exit-3");
				Home[2] = (Texture2D)_obj;

				_obj = Resources.Load("Buttons/02-Neon/Original/settings-1");
				Settings[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Pointed/settings-2");
				Settings[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Pressed/settings-3");
				Settings[2] = (Texture2D)_obj;

				_obj = Resources.Load("Buttons/02-Neon/Original/Neon Triangle");
				Play[0] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Original/Neon Triangle");
				Play[1] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/02-Neon/Original/Neon Triangle");
				Play[2] = (Texture2D)_obj;
				_obj = Resources.Load("Buttons/1px");
				TB = (Texture2D)_obj;
				BackGroundT = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
				IsChangeDone = true;
			}
		}
	}
}
