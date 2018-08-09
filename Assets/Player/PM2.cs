using UnityEngine;
using System.Collections;

public class PM2 : MonoBehaviour {
	
	public AudioSource pleer;
	int currentTrek = 0;
	int numberTrek;
	public AudioClip[] treks;
	bool PausePlay = true;
	bool isOneClock = false;
	//create our taxture
	public Texture2D[] MusicBack;
	public Texture2D[] MusicForvard;
	public Texture2D[] Pause;
	int PlayPause;
	//create location and size for our player
	private Vector2 Abutt1, Abutt2, Abutt3;
	private Vector2 AbuttEnd1, AbuttEnd2, AbuttEnd3;
	//create exemplar of playbutton class
	private PlayButton MBack;
	private PlayButton MForvard;
	private PlayButton Pauses;
	//create local centr of our buttons for mor easly use but maybe we dont need it
	private Vector2 AlocalCentr1, AlocalCentr2 , AlocalCentr3;
	float radius = 30f;
	// Use this for initialization
	void Start () 
	{
		numberTrek = treks.Length - 1;
		Vector2 ACentralPoint, AleftUp1;
		// prepeir Sings
		//create central point for player
		ACentralPoint.x = Screen.width / 2;
		ACentralPoint.y = 405*Screen.height / 500;
		int AMinX = Screen.width / 64;
		int AMinY = Screen.height / 36;
		if (Screen.width == 1024)
		{
			AMinX = Screen.width / 56 ;
			AMinY = Screen.height / 42;
		}

		AleftUp1.x = 0 - 8*AMinX;
		AleftUp1.y = 0 - 8*AMinY;

		//leftButton
		Abutt1.x = (int)(ACentralPoint.x - 4 * AMinX);
		Abutt1.y = ACentralPoint.y + 3 * AMinY;
		AbuttEnd1.x = 2 * AMinX;
		AbuttEnd1.y = 2 * AMinY;
		AlocalCentr1.x = ACentralPoint.x - 4 * AMinX;
		AlocalCentr1.y = ACentralPoint.y + 4 * AMinY;

		//centralButton
		Abutt2.x = (int)(ACentralPoint.x - 1 * AMinX);
		Abutt2.y = ACentralPoint.y + 3 * AMinY;
		AbuttEnd2.x = 2 * AMinX;
		AbuttEnd2.y = 2 * AMinY;
		/*localCentr2.x = CentralPoint.x - 5 * MinX;
			localCentr2.y = CentralPoint.y + 5 * MinY;*/
		AlocalCentr2.x = ACentralPoint.x;
		AlocalCentr2.y = ACentralPoint.y + 4 * AMinY;
		//rightbutton
		Abutt3.x = (int)(ACentralPoint.x + 2 * AMinX);
		Abutt3.y = ACentralPoint.y + 3 * AMinY;
		AbuttEnd3.x = 2 * AMinX;
		AbuttEnd3.y = 2 * AMinY;
		/*localCentr3.x = CentralPoint.x - 5 * MinX;
			localCentr3.y = CentralPoint.y + 5 * MinY;*/
		AlocalCentr3.x = ACentralPoint.x + 4 * AMinX;
		AlocalCentr3.y = ACentralPoint.y + 4 * AMinY;
		// and now we initialait our buttons
		MBack = new PlayButton(Abutt1,AbuttEnd1, MusicBack[0], MusicBack[1], MusicBack[2], AlocalCentr1, radius);
		MForvard = new PlayButton(Abutt3, AbuttEnd3, MusicForvard[0], MusicForvard[1], MusicForvard[2], AlocalCentr3, radius);
		Pauses = new PlayButton(Abutt2, AbuttEnd2, Pause[0], Pause[1], Pause[2], AlocalCentr2, radius);
	}

	// Update is called once per frame
	void Update () 
	{
		
		if (MBack != null && MForvard  != null && Pauses != null )
		{

			//if(MBack.Update(Input.mousePosition, Input.GetMouseButton(0)))
			if(MBack.Update(Input.mousePosition, Input.GetKeyDown(KeyCode.Mouse0)))
			{
				if(Input.GetKeyUp (KeyCode.Mouse0)){
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
				//Log("FacebookButton click");
			}

			if(MForvard.Update(Input.mousePosition, Input.GetKeyDown(KeyCode.Mouse0)))
			{
				if(Input.GetKeyUp (KeyCode.Mouse0)){
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
				//Log("TwitterButton click");
			}

			if(Pauses.Update(Input.mousePosition, Input.GetKeyDown(KeyCode.Mouse0)))
			{
				if(Input.GetKeyUp (KeyCode.Mouse0)){
					if(PausePlay)
					{
						pleer.Pause();
						PausePlay = false;
					}
					else
					{
						pleer.Play();
						PausePlay = true;
					}
				}
				//Log("SettingsButton click");
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
	void OnGUI()
	{
		
			if (MBack != null && MForvard  != null && Pauses != null )
			{
				MBack.Draw();
				MForvard.Draw();
				Pauses.Draw();

			}

		//GUI.Button( new Rect(butt4.x,butt4.y,buttEnd4.x,buttEnd4.x),Traengl);
	}
}