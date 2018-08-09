using UnityEngine;
//using System.Collections;

public class FbButton
{
	public bool _Work;
	public Vector2 Position
	{
		get;
		private set;
	}

	public Vector2 Size
	{
		get;
		private set;
	}
	public Rect Rectangle1
	{
		get;
		private set;
	}
	public Rect Rectangle
	{
		get;
		private set;
	}

	private float Distance;//distance betwen old and new centr
	private double angle = 15;
	private float Timer;     
	private Vector2 LocalCentr;
	private Vector2 OldCentr;
	public Texture2D _texNormal;//without mouse
	public Texture2D _texHover;//with mouse
	public Texture2D _texActive;//mouse clik 
	private bool agree = true ;
	public ButtonState _state = ButtonState.Normal; //State of our button
	public Vector2 _Centr;
	public Vector2 _Radius;
	//usual GETer with switch
	private Texture2D CurrentTextur
	{
		get
		{
			switch (_state)
			{
			case ButtonState.Normal:
				return _texNormal;
			case ButtonState.Hover:
				return _texHover;
			case ButtonState.Active:
				return _texActive;
			default: return _texActive;
			}
		}
	}
	//public FbButton (Vector2 pos, Vector2 size, Texture2D tNormal, Texture2D tActive)
	public FbButton (Vector2 pos, Vector2 size, Texture2D tNormal, Texture2D tHover, Texture2D tActive, Vector2 Centr, Vector2 Radius)
	//public FbButton (Vector2 pos, Vector2 size, Texture2D tNormal, Texture2D tActive)
	{
		SetPosition(pos);
		SetSize(size);
		_texNormal = tNormal;
		_texHover = tHover;
		_texActive = tActive;
		_state = ButtonState.Normal;
		_Centr = Centr;
		_Radius = Radius;
		OldCentr.x = Centr.x;
		OldCentr.y = Centr.y;

	}
	public void getLocalCentr()
	{
		/*float Distance;//distance betwen old and new centr
		double angle;*/
		int RadiusForSwim = 30;
		//Random.Range(0, RadiusForSwim);
		while(true)
		{
			Distance = Random.Range(0,2*RadiusForSwim);
			angle = Random.Range(0,360);
			LocalCentr.x = (int)(Distance * Mathf.Cos((float)(Mathf.PI/180*angle)));
			LocalCentr.y = (int)(Distance * Mathf.Sin((float)(Mathf.PI/180*angle)));
			if ((Mathf.Pow(LocalCentr.x,2) + Mathf.Pow(LocalCentr.y,2)) <= Mathf.Pow(RadiusForSwim,2))
			{
				break;
			}
		}
		LocalCentr += _Centr;

	}
	/*Method SetSize with overrun for size, and for XY variable*/
	public void SetSize (Vector2 size) 
	{
		Size = size;
		Rectangle = new Rect(Position.x, Position.y, Size.x, Size.y);
	}

	public void SetSize (int width, int height) 
	{
		/*Time.timeScale = 0;
		Time.timeSinceLevelLoad = 1;*/
		Size = new Vector2(width, height);
		Rectangle = new Rect(Position.x, Position.y, Size.x, Size.y);
	}

	/*Method SetPosition with overrun for pos, and for XY variable*/
	public void SetPosition (Vector2 pos)
	{
		Position = pos;
		Rectangle = new Rect(Position.x, Position.y, Size.x, Size.y);
	}

	public void SetPosition (int x, int y)
	//public void SetPosition (float x, float y)
	{
		Position = new Vector2(x, y);
		Rectangle = new Rect(Position.x, Position.y, Size.x, Size.y);
	}

	/*mousePos is mouse Position
	  pressed is are left mouse button is pressed
	  return return TRUE if pressed was*/
	public bool Update (Vector2 mousePos, bool pressed)
	{
		/*Distance = Random.Range(0,20);
		angle = Random.Range(0,360);
		LocalCentr.x = Distance * Mathf.Cos((float)(Mathf.PI/180*angle));
		LocalCentr.y = Distance * Mathf.Sin((float)(Mathf.PI/180*angle));*/
		if (agree)
		{
			getLocalCentr();
		}
		agree = false;
		Rectangle1 = new Rect(OldCentr.x + _Radius.x, OldCentr.y + _Radius.y,  -2*_Radius.x, -2*(_Radius.y));
			//Rectangle = new Rect(_Centr.x + _Radius, _Centr.y  + _Radius, _Centr.x  - _Radius, _Centr.y - _Radius);
		/*OldCentr.x = OldCentr.x - 0.001f * Mathf.Cos((float)(Mathf.PI/180*angle));
		OldCentr.y = OldCentr.y - 0.001f * Mathf.Cos((float)(Mathf.PI/180*angle));*/	
		OldCentr.x = OldCentr.x + 0.2f * Mathf.Cos((float)(Mathf.PI/180*angle)) ;
		OldCentr.y = OldCentr.y + 0.2f * Mathf.Sin((float)(Mathf.PI/180*angle));
		//if ((int)OldCentr.x == (int)LocalCentr.x && (int)OldCentr.y == (int)LocalCentr.y)
		if (Mathf.Sqrt(Mathf.Pow(OldCentr.x - LocalCentr.x,2) + Mathf.Pow(OldCentr.y - LocalCentr.y,2)) < 25f)
		{
			/*OldCentr.x = LocalCentr.x;
			OldCentr.y = LocalCentr.y;*/
			agree = true;
		}
		/*OldCentr.x = OldCentr.x - 0.01f  ;
		OldCentr.y = OldCentr.y - 0.01f ;*/
			/*if (OldCentr == LocalCentr)
			{
				OldCentr = LocalCentr;
				getLocalCentr(20);
			}*/
		//Rectangle1 = new Rect(_Centr.x + _Radius.x, _Centr.y + _Radius.y, _Centr.x - _Radius.x, _Centr.y + - _Radius.y);
		float MousePositionX = Input.mousePosition.x;
		float MousePositionY = Input.mousePosition.y;
		mousePos = new Vector2(mousePos.x, Screen.height - mousePos.y);//becous its our local cordinate
		if ((Mathf.Pow((mousePos.x - OldCentr.x),2) + Mathf.Pow((mousePos.y - OldCentr.y),2)) <= (Mathf.Pow(_Radius.x,2)))
		{
			/*if(_state = ButtonState.Normal)
			{
				ButtonState oldState = _state;
				//_state = pressed ? ButtonState.Active:ButtonState.Hover;
				_state = ButtonState.Hover;
			}*/
			ButtonState oldState = _state;
			_state = pressed ? ButtonState.Active:ButtonState.Hover;
			//float a = CurrentTextur.GetPixel((int)mousePos.x, (int)(Position.y + Size.y - mousePos.y)).a;
			//float a = CurrentTextur.GetPixel(mousePos.x, (Position.y + Size.y - mousePos.y)).a;
			//if (a != 0)*/
			/*if (Input.GetKeyDown(KeyCode.Mouse0))
			{*/

				//if (_state == ButtonState.Active)
				if (oldState == ButtonState.Hover && _state == ButtonState.Active)
				{
					_state = ButtonState.Active;
					//Application.LoadLevel("Scene1");
					return true;
					/*if(PlayButton.Update(Input.mousePosition, Input.GetMouseButton(0)))
					{
						Application.LoadLevel("Scene1");
						//Log("PlayButton click");
						/*if (FbButton._state == ButtonState.Active)
				{
					Application.LoadLevel("Scene1");
				}
					}*/
				}

				return true;
			//}
		}
		/*if (Rectangle.Contains(mousePos))
		{
			float a = CurrentTextur.GetPixel((int)mousePos.x, (int)(Position.y + Size.y - mousePos.y)).a;
			//float a = CurrentTextur.GetPixel(mousePos.x, (Position.y + Size.y - mousePos.y)).a;
			if (a != 0)
			//if ((Mathf.Pow(((int)mousePos.x + (int)_Centr.x),2) + Mathf.Pow(((int)mousePos.y + (int)_Centr.y),2)) <= (Mathf.Pow(_Radius,2)))
			{
				ButtonState oldState = _state;
				_state = pressed ? ButtonState.Active:ButtonState.Hover;
				//if (_state == ButtonState.Active)
				if (oldState == ButtonState.Hover && _state == ButtonState.Active)
				{
					//_state = ButtonState.Active;
					//Application.LoadLevel("Scene1");
					return true;
					/*if(PlayButton.Update(Input.mousePosition, Input.GetMouseButton(0)))
					{
						Application.LoadLevel("Scene1");
						//Log("PlayButton click");
						/*if (FbButton._state == ButtonState.Active)
				{
					Application.LoadLevel("Scene1");
				}
					}*/
		/*		}
				return true;
			}
		}*/
		//_state = ButtonState.Active;
		_state = ButtonState.Normal;
		return false;
		//transform.position = Vector3.Lerp(start.position, end.position, Mathf.PingPong(Time.time/arriveTime, 1f));
	}
	public void Draw()
	{
		/*double _X = Rectangle.x;
		double _Y = Rectangle.y;
		double _sizeX = Rectangle.size.x;
		double _sizeY = Rectangle.size.y;*/
		//Rectangle = new Rect(OldCentr.x + _Centr.x + _Radius, Position.y + _Centr.y + _Radius, OldCentr.x + _Centr.x - _Radius, Position.y + _Centr.y - _Radius);
		//Rectangle1 = new Rect(OldCentr.x + _Radius.x, OldCentr.y + _Radius.y,  -2*_Radius.x, -2*(_Radius.y));
		GUI.DrawTexture(Rectangle1, CurrentTextur);
		/*getLocalCentr(20);
//try here
		while(true)
		{
			Timer += Time.deltaTime;     
			Rectangle = new Rect(OldCentr.x + _Centr.x - _Radius, Position.y + _Centr.y - _Radius, OldCentr.x + _Centr.x + _Radius, Position.y + _Centr.y + _Radius);
			GUI.DrawTexture(Rectangle, CurrentTextur);
			OldCentr.x = OldCentr.x - 0.001f * Mathf.Cos((float)(Mathf.PI/180*angle));
			OldCentr.y = OldCentr.y - 0.001f * Mathf.Cos((float)(Mathf.PI/180*angle));
			if (OldCentr == LocalCentr)
			{
				OldCentr = LocalCentr;
				getLocalCentr(20);
			}
		}*/

	}
}
/*
public class FbButtonSc : MonoBehaviour 
{
	public Texture2D _textureButton;
	void OnGUI()
	{
		if (GUI.Button(new Rect(0,0,150,150), _textureButton))
		{
			//open somesing
		}
	}
}
*/