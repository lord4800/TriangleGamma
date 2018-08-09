using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour 
{
	public GameObject PauseO;
	public GameObject GameOver;
	public PauseScr PS;
	public GameOverSc GOS; 
	bool IsPS;
	bool IsGOS;
	public AudioSource pleer;
    static public float musicValue = PlayerPrefs.GetFloat("musicValue", 0);
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
	private Vector2 butt1, butt2, butt3;
	private Vector2 buttEnd1, buttEnd2, buttEnd3;
	//create exemplar of playbutton class
	private PlayButton MBack;
	private PlayButton MForvard;
	private PlayButton Pauses;
	//create local centr of our buttons for mor easly use but maybe we dont need it
	private Vector2 localCentr1, localCentr2 , localCentr3;
	float radius = 30f;
	// Use this for initialization
	void Start () 
	{
        musicValue = pleer.volume;

        numberTrek = treks.Length - 1;
		Vector2 CentralPoint, leftUp1;
        // prepeir Sings
		//create central point for player
        CentralPoint.x = Screen.width / 2;
        CentralPoint.y = 0;
		int MinX = Screen.width / 64;
		int MinY = Screen.height / 36;
		if (Screen.width == 1024)
		{
			MinX = Screen.width / 56 ;
			MinY = Screen.height / 42;
		}

			leftUp1.x = 0 - 8*MinX;
			leftUp1.y = 0 - 8*MinY;
			
		//leftButton
			butt1.x = (int)(CentralPoint.x - 4 * MinX);
			butt1.y = CentralPoint.y + 3 * MinY;
			buttEnd1.x = 2 * MinX;
			buttEnd1.y = 2 * MinY;
			localCentr1.x = CentralPoint.x - 4 * MinX;
			localCentr1.y = CentralPoint.y + 4 * MinY;
			
		//centralButton
			butt2.x = (int)(CentralPoint.x - 1 * MinX);
			butt2.y = CentralPoint.y + 3 * MinY;
			buttEnd2.x = 2 * MinX;
			buttEnd2.y = 2 * MinY;
			/*localCentr2.x = CentralPoint.x - 5 * MinX;
			localCentr2.y = CentralPoint.y + 5 * MinY;*/
			localCentr2.x = CentralPoint.x;
			localCentr2.y = CentralPoint.y + 4 * MinY;
		//rightbutton
			butt3.x = (int)(CentralPoint.x + 2 * MinX);
			butt3.y = CentralPoint.y + 3 * MinY;
			buttEnd3.x = 2 * MinX;
			buttEnd3.y = 2 * MinY;
			/*localCentr3.x = CentralPoint.x - 5 * MinX;
			localCentr3.y = CentralPoint.y + 5 * MinY;*/
			localCentr3.x = CentralPoint.x + 4 * MinX;
			localCentr3.y = CentralPoint.y + 4 * MinY;
		// and now we initialait our buttons
		MBack = new PlayButton(butt1,buttEnd1, MusicBack[0], MusicBack[1], MusicBack[2], localCentr1, radius);
		MForvard = new PlayButton(butt3, buttEnd3, MusicForvard[0], MusicForvard[1], MusicForvard[2], localCentr3, radius);
		Pauses = new PlayButton(butt2, buttEnd2, Pause[0], Pause[1], Pause[2], localCentr2, radius);
	}
	
	// Update is called once per frame
	void Update () 
	{
        pleer.volume = musicValue;

        IsPS = PauseO.GetComponent<PauseScr>().IsPaused;
		IsGOS = GameOverSc.GameOv;

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
        if (IsPS || IsGOS)
        {
            if (MBack != null && MForvard != null && Pauses != null)
            {
                MBack.Draw();
                MForvard.Draw();
                Pauses.Draw();

            }
        }
        //GUI.Button( new Rect(butt4.x,butt4.y,buttEnd4.x,buttEnd4.x),Traengl);
    }
}