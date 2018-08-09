using UnityEngine;
using System.Collections;

public class ThemeTriger : MonoBehaviour 
{
	public int NumberOfTheme = 1;
	private Texture2D TB;
	//public GameManager GM;

	public UniversalScript Green;
	public UniversalScript GreenSlow;
	public UniversalScript GreenClean;
	public UniversalScript Green2;
	public UniversalScript Green3;
	public UniversalScript Green5;
	public UniversalScript Green10;
	public UniversalScript Green15;
	public UniversalScript Yellow;
	public UniversalScript Yellow10;
	public UniversalScript Red;
	public UniversalScript RedBomb;
	public UniversalScript RedSlow;
	public UniversalScript RedFast;
	public UniversalScript RedSwap;
	public UniversalScript ESlowTime;
	public UniversalScript ENoBad;
	public UniversalScript ESpeedMinus;
	public UniversalScript ESpeedPlus;
	public UniversalScript EReverseControll;
	public UniversalScript AGreen;
	public UniversalScript AYellow;
	public UniversalScript ARed;
	public BackGScr1 BGS;
	//public Tex
	Object _obj;
	// Use this for initialization
	void Start () 
	{
		//PauseScr PS = GetComponent<PauseScr>();
		NumberOfTheme = PlayerPrefs.GetInt("Theme");
		//GameManager GM = GetComponent<GameManager>();
		UniversalScript Green = GameObject.Find("Green").GetComponent<UniversalScript>();
		UniversalScript GreenSlow = GameObject.Find("GreenSlow").GetComponent<UniversalScript>();
		UniversalScript GreenClean = GameObject.Find("GreenClean").GetComponent<UniversalScript>();
		UniversalScript Green2 = GameObject.Find("Green2").GetComponent<UniversalScript>();
		UniversalScript Green3 = GameObject.Find("Green3").GetComponent<UniversalScript>();
		UniversalScript Green5 = GameObject.Find("Green5").GetComponent<UniversalScript>();
		UniversalScript Green10 = GameObject.Find("Green10").GetComponent<UniversalScript>();
		UniversalScript Green15 = GameObject.Find("Green15").GetComponent<UniversalScript>();
		UniversalScript Yellow = GameObject.Find("Yellow").GetComponent<UniversalScript>();
		UniversalScript Yellow10 = GameObject.Find("Yellow10").GetComponent<UniversalScript>();
		UniversalScript Red = GameObject.Find("Red").GetComponent<UniversalScript>();
		UniversalScript RedBomb = GameObject.Find("RedBomb").GetComponent<UniversalScript>();
		UniversalScript RedSlow = GameObject.Find("RedSlow").GetComponent<UniversalScript>();
		UniversalScript RedFast = GameObject.Find("RedFast").GetComponent<UniversalScript>();
		UniversalScript RedSwap = GameObject.Find("RedSwap").GetComponent<UniversalScript>();
		UniversalScript ESlowTime = GameObject.Find("SlowTime").GetComponent<UniversalScript>();
		UniversalScript ENoBad =  GameObject.Find("NoBad").GetComponent<UniversalScript>();
		UniversalScript ESpeedMinus = GameObject.Find("SpeedMinus").GetComponent<UniversalScript>();
		UniversalScript ESpeedPlus = GameObject.Find("SpeedPlus").GetComponent<UniversalScript>();
		UniversalScript EReverseControll = GameObject.Find("ReverseControll").GetComponent<UniversalScript>();
		BackGScr1 BGS = GameObject.Find("New Sprite").GetComponent<BackGScr1>();//New Sprite
		//UniversalScript AGreen = GameObject.Find("SpeedMinus").GetComponent<UniversalScript>();
		//UniversalScript AYellow = GameObject.Find("SpeedMinus").GetComponent<UniversalScript>();
		//UniversalScript ARed = GameObject.Find("SpeedMinus").GetComponent<UniversalScript>();

		if (NumberOfTheme == 0)
		{
			//D:\багаж\тим лид\Beta_122_14_03_2016_22_11\Beta_122_14_03_2016__22_11\Assets\Resources\SpritesOfTimers
			_obj = Resources.Load("Material_150/Green");
			TB = (Texture2D)_obj;
			Green.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//NoBadTexture = 
			//2
			_obj = Resources.Load("Material_150/SlowTime");
			TB = (Texture2D)_obj;
			GreenSlow.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//3
			_obj = Resources.Load("Material_150/NoBad");
			TB = (Texture2D)_obj;
			GreenClean.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//4
			_obj = Resources.Load("Material_150/x2");
			TB = (Texture2D)_obj;
			Green2.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//5
			_obj = Resources.Load("Material_150/x3");
			TB = (Texture2D)_obj;
			Green3.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			///////////////////////////////////////////////////////////////////////////////////////////////
			/// 6
			_obj = Resources.Load("Material_150/x5");
			TB = (Texture2D)_obj;
			Green5.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//7	
			_obj = Resources.Load("Material_150/x10");
			TB = (Texture2D)_obj;
			Green10.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//8
			_obj = Resources.Load("Material_150/x15");
			TB = (Texture2D)_obj;
			Green15.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//9
			_obj = Resources.Load("Material_150/Coin");
			TB = (Texture2D)_obj;
			Yellow.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//10
			_obj = Resources.Load("Material_150/CoinsX10");
			TB = (Texture2D)_obj;
			Yellow10.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//11
			_obj = Resources.Load("Material_150/Red");
			TB = (Texture2D)_obj;
			Red.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//12
			_obj = Resources.Load("Material_150/Bomb");
			TB = (Texture2D)_obj;
			RedBomb.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			///////////////////////////////////////////////////////////////////////////////////////////////
			/// 13
			_obj = Resources.Load("Material_150/Speed_Minus");
			TB = (Texture2D)_obj;
			RedSlow.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//14
			_obj = Resources.Load("Material_150/Speed_Plus");
			TB = (Texture2D)_obj;
			RedFast.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//15
			_obj = Resources.Load("Material_150/ReverseControll");
			TB = (Texture2D)_obj;
			RedSwap.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//16
			_obj = Resources.Load("Material_150/SlowTime");
			TB = (Texture2D)_obj;
			ESlowTime.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//17
			_obj = Resources.Load("Material_150/NoBad");
			TB = (Texture2D)_obj;
			ENoBad.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//18
			_obj = Resources.Load("Material_150/Speed_Minus");
			TB = (Texture2D)_obj;
			ESpeedMinus.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//19
			_obj = Resources.Load("Material_150/Speed_Plus");
			TB = (Texture2D)_obj;
			ESpeedPlus.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//20
			_obj = Resources.Load("Material_150/ReverseControll");
			TB = (Texture2D)_obj;
			EReverseControll.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			/*//21
			_obj = Resources.Load("ANCHORS/Anch_Green");
			TB = (Texture2D)_obj;
			AGreen.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//22
			_obj = Resources.Load("ANCHORS/Anch_Yellow");
			TB = (Texture2D)_obj;
			AYellow.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//23
			_obj = Resources.Load("ANCHORS/Anch_Red");
			TB = (Texture2D)_obj;
			ARed.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			*/
			_obj = Resources.Load("Buttons/Background_Dark");
			TB = (Texture2D)_obj;
			//BGS._sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			BGS.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
		}
		if (NumberOfTheme == 1)
		{

			_obj = Resources.Load("Neon_150/Green");
			TB = (Texture2D)_obj;
			Green.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//NoBadTexture = 
			//2
			_obj = Resources.Load("Neon_150/SlowTime");
			TB = (Texture2D)_obj;
			GreenSlow.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//3
			_obj = Resources.Load("Neon_150/NoBad");
			TB = (Texture2D)_obj;
			GreenClean.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//4
			_obj = Resources.Load("Neon_150/x2");
			TB = (Texture2D)_obj;
			Green2.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//5
			_obj = Resources.Load("Neon_150/x3");
			TB = (Texture2D)_obj;
			Green3.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			///////////////////////////////////////////////////////////////////////////////////////////////
			/// 6
			_obj = Resources.Load("Neon_150/x5");
			TB = (Texture2D)_obj;
			Green5.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//7	
			_obj = Resources.Load("Neon_150/x10");
			TB = (Texture2D)_obj;
			Green10.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//8
			_obj = Resources.Load("Neon_150/x15");
			TB = (Texture2D)_obj;
			Green15.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//9
			_obj = Resources.Load("Neon_150/Coin");
			TB = (Texture2D)_obj;
			Yellow.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//10
			_obj = Resources.Load("Neon_150/CoinsX10");
			TB = (Texture2D)_obj;
			Yellow10.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//11
			_obj = Resources.Load("Neon_150/Red");
			TB = (Texture2D)_obj;
			Red.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//12
			_obj = Resources.Load("Neon_150/Bomb");
			TB = (Texture2D)_obj;
			RedBomb.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			///////////////////////////////////////////////////////////////////////////////////////////////
			/// 13
			_obj = Resources.Load("Neon_150/Speed_Minus");
			TB = (Texture2D)_obj;
			RedSlow.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//14
			_obj = Resources.Load("Neon_150/Speed_Plus");
			TB = (Texture2D)_obj;
			RedFast.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//15
			_obj = Resources.Load("Neon_150/ReverseControll");
			TB = (Texture2D)_obj;
			RedSwap.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//16
			_obj = Resources.Load("Neon_150/SlowTime");
			TB = (Texture2D)_obj;
			ESlowTime.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//17
			_obj = Resources.Load("Neon_150/NoBad");
			TB = (Texture2D)_obj;
			ENoBad.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//18
			_obj = Resources.Load("Neon_150/Speed_Minus");
			TB = (Texture2D)_obj;
			ESpeedMinus.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//19
			_obj = Resources.Load("Neon_150/Speed_Plus");
			TB = (Texture2D)_obj;
			ESpeedPlus.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//20
			_obj = Resources.Load("Neon_150/ReverseControll");
			TB = (Texture2D)_obj;
			EReverseControll.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//21
			/*_obj = Resources.Load("ANCHORS/Anch_Green");
			TB = (Texture2D)_obj;
			AGreen.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//22
			_obj = Resources.Load("ANCHORS/Anch_Yellow");
			TB = (Texture2D)_obj;
			AYellow.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			//23
			_obj = Resources.Load("ANCHORS/Anch_Red");
			TB = (Texture2D)_obj;
			ARed.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			*/
			_obj = Resources.Load("Buttons/1px");
			TB = (Texture2D)_obj;
			//BGS._sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
			BGS.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create (TB,new Rect(0,0,TB.width,TB.height),new Vector2(0.5f,0.5f));
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


}