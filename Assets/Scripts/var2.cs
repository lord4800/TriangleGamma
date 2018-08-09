/*using UnityEngine;
using System.Collections;

public class var2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public class FbButton
	{
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
		
		public Rect Rectangle
		{
			get;
			private set;
		}
		
		private Texture2D _texNormal;//without mouse
		private Texture2D _texHover;//with mouse
		private Texture2D _texActive;//mouse clik 
		
		public ButtonState _state = ButtonState.Normal; //State of our button
		public Vector2 _Centr;
		public int _Radius;
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
	public FbButton (Vector2 pos, Vector2 size, Texture2D tNormal, Texture2D tHover, Texture2D tActive, Vector2 Centr, int Radius)
	}
	// Update is called once per frame
	void Update () {
		int Radius = 100;
		Vector2 centr;
		centr.x = 100;
		centr.y = 100;
		Vector2 MousePosition = Input.mousePosition;
		if ( Mathf.Sqrt( Mathf.Pow(MousePosition.x - centr.x,2) + Mathf.Pow(MousePosition.y - centr.y,2) ) < Radius )
		{

		}
	}
}*/
