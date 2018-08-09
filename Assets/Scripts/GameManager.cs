using UnityEngine;
using System.Collections;
using CompleteProject;

public class GameManager : MonoBehaviour {

	public Texture2D Travolta;
	public Texture2D Win;
	public Texture2D Win1;

    public GUIStyle Text;

    public ThemeScriptMM TSMM;
	public bool _showHide;
	[Header("Player")]
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

    [Header("Settings")]
	public bool _showRecord = false;
	public static bool setting_GM = false;
    public bool Theme_active = false;
    public bool Tutorial = false;
    public GUISkin b_exit_settings;
    public GUISkin tutor_skin_b;
    public GUISkin Horizontal_scroll;
    public GUIStyle customButton;
    public Texture2D peregorodka;
    public Texture2D background;
    public GUISkin buttons_p_s;
    public Purchaser Pur;
    [Header("ТЕМЫ")]
    public GUISkin Neon_theme_sprite;
	public GUISkin Standart_Theme;
    public GUISkin NULL_theme_sprite;
    public GUISkin Coming_soon_theme_sprite;

    public bool audioOFF;
    public bool musicOFF;
    public float tempAudioValue;
    public float tempMusicValue;
    [Header("END Settings")]

    public Texture2D SetTexture;
	public Texture2D _backTexture;

	public Texture2D[] Facebook;
	public Texture2D[] Twitter;
	public Texture2D[] Settings;
	public Texture2D[] Play;
	public Texture2D[] Record;
	public Texture2D[] Vk;
	public Texture2D[] Home;
	//public Texture2D Traengl;
		//,t2,t3,t4,t5;

	//25.09.2015 For centry position of subject

	private Vector2 butt1, butt2, butt3, butt4, butt5, butt6, butt7;
	private Vector2 buttEnd1, buttEnd2, buttEnd3, buttEnd4, buttEnd5, buttEnd6, buttEnd7;
	//public Texture2D[] t1;
	private FbButton ThemeButton;
	private FbButton TutorButton;
	private FbButton SettingsButton;
	private FbButton PlayButton;
	private FbButton RecordButton;
	private FbButton VkButton;
	private FbButton HomeButton;
	//private FbButton Traengl;
	private Vector2 localCentr1, localCentr2 , localCentr3 , localCentr4 , localCentr5 , localCentr6 , localCentr7  ;

		//, TutorButton, SettingsButton, PlayButton, RecordButton;

	// Use this for initialization
	void Start () 
	{
		numberTrek = treks.Length - 1;
		Vector2 ACentralPoint, AleftUp1;
		// prepeir Sings
		//create central point for player
		ACentralPoint.x = Screen.width / 2;
		ACentralPoint.y = 400*Screen.height / 500;
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
		Abutt1.x = (int)(ACentralPoint.x - 8 * AMinX);
		Abutt1.y = ACentralPoint.y + 3 * AMinY;
		AbuttEnd1.x = 2 * AMinX;
		AbuttEnd1.y = 2 * AMinY;
		AlocalCentr1.x = ACentralPoint.x - 8 * AMinX;
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
		Abutt3.x = (int)(ACentralPoint.x + 6 * AMinX);
		Abutt3.y = ACentralPoint.y + 3 * AMinY;
		AbuttEnd3.x = 2 * AMinX;
		AbuttEnd3.y = 2 * AMinY;
		/*localCentr3.x = CentralPoint.x - 5 * MinX;
			localCentr3.y = CentralPoint.y + 5 * MinY;*/
		AlocalCentr3.x = ACentralPoint.x + 6 * AMinX;
		AlocalCentr3.y = ACentralPoint.y + 4 * AMinY;
		// and now we initialait our buttons
		MBack = new PlayButton(Abutt1,AbuttEnd1, MusicBack[0], MusicBack[1], MusicBack[2], AlocalCentr1, radius);
		MForvard = new PlayButton(Abutt3, AbuttEnd3, MusicForvard[0], MusicForvard[1], MusicForvard[2], AlocalCentr3, radius);
		Pauses = new PlayButton(Abutt2, AbuttEnd2, Pause[0], Pause[1], Pause[2], AlocalCentr2, radius);




		//ThemeScriptMM TSMM = GetComponent<ThemeScriptMM>();
		ThemeScriptMM TSMM = GameObject.Find("TSMM").GetComponent<ThemeScriptMM>();
		TSMM.NumberOfTheme = 0;
		_showHide = true;
		Vector2 CentralPoint, leftUp1, leftUp2;
        // prepeir Sings

        CentralPoint.x = Screen.width / 2;
        CentralPoint.y = Screen.height / 2;
		int MinX = Screen.width / 64;
		int MinY = Screen.height / 36;

			leftUp1.x = 0 - 8*MinX;
			leftUp1.y = 0 - 8*MinY;
			leftUp2.x = 0 - 5*MinX;
			leftUp2.y = 0 - 5*MinY;
		//facebook button
			butt1.x = leftUp2.x + CentralPoint.x + 18 * MinX;
			butt1.y = leftUp2.y + CentralPoint.y - 11 * MinY;
			buttEnd1.x = 2 * leftUp2.x * (-1);
			buttEnd1.y = 2 * leftUp2.y * (-1);
			localCentr1.x = butt1.x - leftUp2.x; 
			localCentr1.y = butt1.y - leftUp2.y;
		//twitter button
			butt2.x = leftUp2.x + CentralPoint.x + 23 * MinX;
			butt2.y = leftUp2.y + CentralPoint.y;
			buttEnd2.x = 2 * leftUp2.x * (-1);
			buttEnd2.y = 2 * leftUp2.y * (-1);
			localCentr2.x = butt2.x - leftUp2.x; 
			localCentr2.y = butt2.y - leftUp2.y;
		//settings button
			butt3.x = leftUp2.x + CentralPoint.x - 18 * MinX;
			butt3.y = leftUp2.y + CentralPoint.y + 11 * MinY;
			buttEnd3.x = 2 * leftUp2.x * (-1);
			buttEnd3.y = 2 * leftUp2.y * (-1);
			localCentr3.x = butt3.x - leftUp2.x; 
			localCentr3.y = butt3.y - leftUp2.y;
		//play button
			butt4.x = leftUp1.x + CentralPoint.x;
			butt4.y = leftUp1.y + CentralPoint.y;
			buttEnd4.x = 2 * leftUp1.x * (-1);
			buttEnd4.y = 2 * leftUp1.y * (-1);
			localCentr4.x = butt4.x - leftUp1.x; 
			localCentr4.y = butt4.y - leftUp1.y;
		//record button
			butt5.x = leftUp2.x + CentralPoint.x - 18 * MinX;
			butt5.y = leftUp2.y + CentralPoint.y - 11 * MinY;
			buttEnd5.x = 2 * leftUp2.x * (-1);
			buttEnd5.y = 2 * leftUp2.y * (-1);
			localCentr5.x = butt5.x - leftUp2.x; 
			localCentr5.y = butt5.y - leftUp2.y;
		//vk button
			butt6.x = leftUp2.x + CentralPoint.x + 18 * MinX;
			butt6.y = leftUp2.y + CentralPoint.y + 11 * MinY;
			buttEnd6.x = 2 * leftUp2.x * (-1);
			buttEnd6.y = 2 * leftUp2.y * (-1);
			localCentr6.x = butt6.x - leftUp2.x; 
			localCentr6.y = butt6.y - leftUp2.y;
		//home button
			butt7.x = leftUp2.x + CentralPoint.x - 23 * MinX;
			butt7.y = leftUp2.y + CentralPoint.y;
			buttEnd7.x = 2 * leftUp2.x * (-1);
			buttEnd7.y = 2 * leftUp2.y * (-1);
			localCentr7.x = butt7.x - leftUp2.x; 
			localCentr7.y = butt7.y - leftUp2.y;

		if (Screen.width == 1024)
		{
			CentralPoint.x = Screen.width / 2;
			CentralPoint.y = Screen.height / 2;
			MinX = Screen.width / 56 ;
			MinY = Screen.height / 42;
			leftUp1.x = 0 - 9*MinX;
			leftUp1.y = 0 - 9*MinY;
			leftUp2.x = 0 - 6*MinX;
			leftUp2.y = 0 - 6*MinY;
			//facebook button
			butt1.x = leftUp2.x + CentralPoint.x + 14 * MinX;
			butt1.y = leftUp2.y + CentralPoint.y - 13 * MinY;
			buttEnd1.x = 2 * leftUp2.x * (-1);
			buttEnd1.y = 2 * leftUp2.y * (-1);
			localCentr1.x = butt1.x - leftUp2.x; 
			localCentr1.y = butt1.y - leftUp2.y;
			//twitter button
			butt2.x = leftUp2.x + CentralPoint.x + 20 * MinX;
			butt2.y = leftUp2.y + CentralPoint.y;
			buttEnd2.x = 2 * leftUp2.x * (-1);
			buttEnd2.y = 2 * leftUp2.y * (-1);
			localCentr2.x = butt2.x - leftUp2.x; 
			localCentr2.y = butt2.y - leftUp2.y;
			//settings button
			butt3.x = leftUp2.x + CentralPoint.x - 14 * MinX;
			butt3.y = leftUp2.y + CentralPoint.y + 13 * MinY;
			buttEnd3.x = 2 * leftUp2.x * (-1);
			buttEnd3.y = 2 * leftUp2.y * (-1);
			localCentr3.x = butt3.x - leftUp2.x; 
			localCentr3.y = butt3.y - leftUp2.y;
			//play button
			butt4.x = leftUp1.x + CentralPoint.x;
			butt4.y = leftUp1.y + CentralPoint.y;
			buttEnd4.x = 2 * leftUp1.x * (-1);
			buttEnd4.y = 2 * leftUp1.y * (-1);
			localCentr4.x = butt4.x - leftUp1.x; 
			localCentr4.y = butt4.y - leftUp1.y;
			//record button
			butt5.x = leftUp2.x + CentralPoint.x - 14 * MinX;
			butt5.y = leftUp2.y + CentralPoint.y - 13 * MinY;
			buttEnd5.x = 2 * leftUp2.x * (-1);
			buttEnd5.y = 2 * leftUp2.y * (-1);
			localCentr5.x = butt5.x - leftUp2.x; 
			localCentr5.y = butt5.y - leftUp2.y;
			//vk button
			butt6.x = leftUp2.x + CentralPoint.x + 14 * MinX;
			butt6.y = leftUp2.y + CentralPoint.y + 13 * MinY;
			buttEnd6.x = 2 * leftUp2.x * (-1);
			buttEnd6.y = 2 * leftUp2.y * (-1);
			localCentr6.x = butt6.x - leftUp2.x; 
			localCentr6.y = butt6.y - leftUp2.y;
			//home button
			butt7.x = leftUp2.x + CentralPoint.x - 20 * MinX;
			butt7.y = leftUp2.y + CentralPoint.y;
			buttEnd7.x = 2 * leftUp2.x * (-1);
			buttEnd7.y = 2 * leftUp2.y * (-1);
			localCentr7.x = butt7.x - leftUp2.x; 
			localCentr7.y = butt7.y - leftUp2.y;
//			GUI.Button( new Rect(butt4.x,butt4.y,buttEnd4.x,buttEnd4.x),Traengl);
		}
		/*localCentr1.x = butt1.x - leftUp2.x; 
		localCentr1.y = butt1.y - leftUp2.y;*/

		ThemeButton = new FbButton(butt1,buttEnd1, Facebook[0], Facebook[1], Facebook[2], localCentr1, leftUp2);
		TutorButton = new FbButton(butt2, buttEnd2, Twitter[0], Twitter[1], Twitter[2], localCentr2, leftUp2);
		SettingsButton = new FbButton(butt3, buttEnd3, Settings[0], Settings[1], Settings[2], localCentr3, leftUp2);
		PlayButton = new FbButton(butt4, buttEnd4, Play[0], Play[1], Play[2], localCentr4, leftUp1);
		RecordButton = new FbButton(butt5, buttEnd5, Record[0], Record[1], Record[2], localCentr5, leftUp2);
		VkButton = new FbButton(butt6, buttEnd6, Vk[0], Vk[1], Vk[2], localCentr6, leftUp2);
		HomeButton = new FbButton(butt7, buttEnd7, Home[0], Home[1], Home[2], localCentr7, leftUp2);
		/*ThemeButton = new FbButton(butt1,buttEnd1, Facebook[0], Facebook[1], Facebook[2], localCentr4, leftUp2);
		TutorButton = new FbButton(butt2, buttEnd2, Twitter[0], Twitter[1], Twitter[2], localCentr4, leftUp2);
		SettingsButton = new FbButton(butt3, buttEnd3, Settings[0], Settings[1], Settings[2], localCentr4, leftUp2);
		PlayButton = new FbButton(butt4, buttEnd4, Play[0], Play[1], Play[2], localCentr4, leftUp1);
		RecordButton = new FbButton(butt5, buttEnd5, Record[0], Record[1], Record[2], localCentr4, leftUp2);
		VkButton = new FbButton(butt6, buttEnd6, Vk[0], Vk[1], Vk[2], localCentr4, leftUp2);
		HomeButton = new FbButton(butt7, buttEnd7, Home[0], Home[1], Home[2], localCentr4, leftUp2);*/

	}
	
	// Update is called once per frame
	void Update () 
	{
		//ThemeScriptMM TSMM = GetComponent<ThemeScriptMM>();
		ThemeScriptMM TSMM = GameObject.Find("TSMM").GetComponent<ThemeScriptMM>();
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
						pleer.Play();
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





		Twitter = TSMM.Twitter;
		Facebook = TSMM.Facebook;
		Vk = TSMM.Vk;
		Record = TSMM.Record;
		Home = TSMM.Home;
		Settings = TSMM.Settings;
		Play = TSMM.Play;
		ThemeButton._texNormal = Facebook[0];
		ThemeButton._texHover = Facebook[1];
		ThemeButton._texActive = Facebook[2];

		TutorButton._texNormal = Twitter[0];
		TutorButton._texHover = Twitter[1];
		TutorButton._texActive = Twitter[2];

		SettingsButton._texNormal = Settings[0];
		SettingsButton._texHover = Settings[1];
		SettingsButton._texActive = Settings[2];

		PlayButton._texNormal = Play[0];
		PlayButton._texHover = Play[1];
		PlayButton._texActive = Play[2];

		RecordButton._texNormal = Record[0];
		RecordButton._texHover = Record[1];
		RecordButton._texActive = Record[2];

		VkButton._texNormal = Vk[0];
		VkButton._texHover = Vk[1];
		VkButton._texActive = Vk[2];

		HomeButton._texNormal = Home[0];
		HomeButton._texHover = Home[1];
		HomeButton._texActive = Home[2];

		if(_showHide && !setting_GM && !Theme_active && !Tutorial)
		if (ThemeButton != null && TutorButton != null && SettingsButton != null && PlayButton != null && RecordButton != null && VkButton != null && HomeButton != null && TutorButton != null)
		{
			if(ThemeButton.Update(Input.mousePosition, Input.GetMouseButton(0)))
			{
                    if (ThemeButton._state == ButtonState.Active)
                    {
                        Theme_active = true;
                    }
                }


			if(TutorButton.Update(Input.mousePosition, Input.GetMouseButton(0)))
			{
                    if (TutorButton._state == ButtonState.Active)
                    {
                        //Tutorial = true;
                        loading_level.Name_of_Scene = "Scene1";
                        Application.LoadLevel("Loading");
                        MAIN.TutorOn = true;
                    }
            }

                if (SettingsButton.Update(Input.mousePosition, Input.GetMouseButton(0)))
   			{            
                    if (SettingsButton._state == ButtonState.Active)
                    {
                        setting_GM = true;
                    }
            }

			if(PlayButton.Update(Input.mousePosition, Input.GetMouseButton(0)))
			{
				if (PlayButton._state == ButtonState.Active)
				{
                       //Application.LoadLevel("Scene1");
                       loading_level.Name_of_Scene = "Scene1";
                       Application.LoadLevel("Loading");
                }
			}

			if(RecordButton.Update(Input.mousePosition, Input.GetMouseButton(0)))
			{
				if (RecordButton._state == ButtonState.Active)
				{
					_showRecord = true;
				}
			}
			if(VkButton.Update(Input.mousePosition, Input.GetMouseButton(0)))
			{
				if (VkButton._state == ButtonState.Active)
				{
					_showHide = false;
				}
			}
			if(HomeButton.Update(Input.mousePosition, Input.GetMouseButton(0)))
			{
				if (HomeButton._state == ButtonState.Active)
				{
					Application.Quit();
				}
			}
		}
	}


    float Audio(float Temp2Audio)
    {
        float temp = PlayerPrefs.GetFloat("audioValue");
        if (Temp2Audio != 1f)
            temp = Temp2Audio;
        return temp;
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
		//ThemeScriptMM TSMM = GetComponent<ThemeScriptMM>();

        if (_showHide == false)
        {
            GUIStyle GS = new GUIStyle();
            GS.fontSize = (int)(Mathf.Round(Screen.width / 30));     //(Screen.height/400);
            GS.alignment = TextAnchor.UpperCenter;

			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Win);
            //GUI.DrawTexture(new Rect((Screen.width / 20) + (Screen.width / 14), (Screen.height / 6), (Screen.width / 2) + (Screen.width / 4), (Screen.height / 2) + (Screen.height / 4)), SetTexture);
            //GUI.TextField(new Rect((Screen.width / 4) + (Screen.width / 12), (Screen.height / 4) + (Screen.height / 12), (Screen.width / 3), (Screen.height / 2) - (Screen.height / 8)),"Triangle v.1.3.6\n\n\tDeveloper: Mentos Team\n\tDesign: Vasylenko Bogdan\n\tGame Programming: Yaroslav Vologin\n\tTechnologic Programming: Dima Terpil\n\tInterface Programming: Dima Stanishevskiy\n\tSound: Anton Ulyanov\n\n2016 Mentos Team");
            //new Rect((Screen.width / 20) + (Screen.width / 14), (Screen.height / 6), (Screen.width / 2) + (Screen.width / 4), (Screen.height / 2) + (Screen.height / 4))
			GUI.Label(new Rect((Screen.width / 20) + (Screen.width / 14), (Screen.height / 8), (Screen.width / 2) + (Screen.width / 4), (Screen.height / 2) + (Screen.height / 4.1f)), "\nTriangle Beta v.1.3.6", GS);
            GS.alignment = TextAnchor.MiddleCenter;
            GS.fontSize = (int)(Mathf.Round(Screen.width / 40));
			GUI.Label(new Rect((Screen.width / 20) + (Screen.width / 14), (Screen.height / 8), (Screen.width / 2) + (Screen.width / 4), (Screen.height / 2) + (Screen.height / 4.1f)), "Developer: Mentos Team\nDesign: Bogdan Vasylenko\nGame Programming: Yaroslav Vologin\nTechnologic Programming: Dmitriy Terpil\nInterface Programming: Dmitriy Stanishevskiy\nSound: Anton Ulyanov", GS);
            GS.alignment = TextAnchor.LowerCenter;
            GS.fontSize = (int)(Mathf.Round(Screen.width / 30));
            GUI.Label(new Rect((Screen.width / 20) + (Screen.width / 14), (Screen.height / 8), (Screen.width / 2) + (Screen.width / 4), (Screen.height / 2) + (Screen.height / 4.1f)), "Mentos Team 2016\n", GS);

            GUI.skin = b_exit_settings;
			if (GUI.Button(new Rect((Screen.width / 2)  - 1.4758f*(Screen.width / 4), Screen.height / 17.58f, (Screen.width / 16f), (Screen.width / 16f)), "  "))
            {
                _showHide = true;
            }
        }


		if (_showRecord == true)
		{
			
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Win);
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Travolta);       
            GUI.skin = b_exit_settings;

            GUIStyle GS = new GUIStyle();
            GS.fontSize = (int)(Mathf.Round(Screen.width / 37));   
            GUI.Label(new Rect(Screen.width / 2.2f, Screen.height / 3.9f, (Screen.width / 2) + (Screen.width / 4), Screen.height  ), " Woops! \n Unfortunately the highscore table \n is not working by now.\n It's coming in the next updates!", GS);


            Text.fontSize = (int)(Mathf.Round(Screen.width / 20));
            Text.alignment = TextAnchor.UpperCenter;
            GUI.Label(new Rect(0, Screen.height / 12.9f, Screen.width , (Screen.height / 2) + (Screen.height / 4)), "<color=#808080ff> Highscore </color>", Text);

            if (GUI.Button(new Rect((Screen.width / 2)  - 1.4758f*(Screen.width / 4), Screen.height / 17.58f, (Screen.width / 16f), (Screen.width / 16f)), "  "))
			{
				_showRecord = false;
			}
		}
        ////-------------------------------------------------TUTORIAL--------------------------------------------------------//

        //if (Tutorial == true)
        //{
        //    GUI.skin = tutor_skin_b;
        //    if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "  "))
        //    {
        //        Tutorial = false;
        //    }
        //}
        ////-------------------------------------------------END_TUTORIAL--------------------------------------------------------//


        //-------------------------------------------------SETTINGS--------------------------------------------------------//
        if (setting_GM == true)
        {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Win);
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Win1);
			      

            //exit
            GUI.skin = b_exit_settings;
			if (GUI.Button(new Rect((Screen.width / 2)  - 1.4758f*(Screen.width / 4), Screen.height / 17.58f, (Screen.width / 16f), (Screen.width / 16f)), "  "))
            {
                setting_GM = false;
            }
            //settings

            customButton.fontSize = Screen.width / 20;
            customButton.normal.textColor = Color.gray;
            GUI.Label(new Rect((Screen.width / 3f), (Screen.height / 14), (Screen.width / 2.5f), (Screen.height)), "SETTINGS", customButton);
            //show tutorial
            GUI.skin = buttons_p_s;
            buttons_p_s.button.fontSize = Screen.width / 28;
			if (GUI.Button(new Rect((Screen.width / 2) + (Screen.width / 24), 0.75f*((Screen.height / 4) + (Screen.height / 12)), (Screen.width / 3.5f), (Screen.height / 8)), " show \r\n tutorial "))
            {
                //Tutorial = true;
                setting_GM = false;
                loading_level.Name_of_Scene = "Scene1";
                Application.LoadLevel("Loading");
                MAIN.TutorOn = true;
            }
            //remove ADS           
			if (GUI.Button(new Rect((Screen.width / 2) + (Screen.width / 24), 0.80f*(Screen.height / 1.85f), (Screen.width / 3.5f), (Screen.height / 8)), " REMOVE \r\n ADS "))
            {
                if (AdMobPlugin.ADM == 0)
                {
                    Pur.BuyConsumable();
                }
            }
            //restore purchase
			if (GUI.Button(new Rect((Screen.width / 2) + (Screen.width / 36), 0.835f*(Screen.height / 1.35f), (Screen.width / 3f), (Screen.height / 8)), " RESTORE \r\n PURCHASES "))
            {
                Pur.RestorePurchases();
            }
            //музыка  
            GUI.skin = Horizontal_scroll;
            customButton.fontSize = Screen.width / 34;
            customButton.normal.textColor = Color.black;
			GUI.Label(new Rect(0.95f*(Screen.width / 4.0f), 0.70f*(Screen.height / 2.35f), (Screen.width / 6f), (Screen.height)), "MUSIC", customButton);
            //  musicOFF = GUI.Toggle((new Rect(Screen.width / 2 + Screen.width / 4, Screen.height / 2 + Screen.height / 12, (Screen.width / 6), Screen.height / 48)), musicOFF, " ");
            if (musicOFF == true)
                playerManager.musicValue = 0;
            tempMusicValue = playerManager.musicValue;
			tempMusicValue = GUI.HorizontalScrollbar(new Rect((Screen.width / 2) - (Screen.width / 3.2f), 0.70f*(Screen.height / 2), (Screen.width / 4), Screen.height / 48), playerManager.musicValue, 0, 0, 1f);
            playerManager.musicValue = Audio(tempMusicValue);
            PlayerPrefs.SetFloat("musicValue", playerManager.musicValue);

            // звуки игры    
            customButton.normal.textColor = Color.black;
			GUI.Label(new Rect(0.95f*(Screen.width / 4.0f), 0.95f*(Screen.height / 1.55f), (Screen.width / 6f), (Screen.height)), "SOUND", customButton);
            //  audioOFF = GUI.Toggle((new Rect((Screen.width / 2) + Screen.width / 4, (Screen.height / 2), (Screen.width / 6), Screen.height / 48)), audioOFF, " ");
            if (audioOFF == true)
                PauseScr.audioValue = 0;
			tempAudioValue = GUI.HorizontalScrollbar(new Rect((Screen.width / 2) - (Screen.width / 3.2f), 0.92f*Screen.height / 1.38f, (Screen.width / 4), Screen.height / 48), PauseScr.audioValue, 0, 0, 1f);
            PauseScr.audioValue = Audio(tempAudioValue);
            PlayerPrefs.SetFloat("audioValue", PauseScr.audioValue);

            customButton.normal.textColor = Color.black;
        }
        //-------------------------------------------------END_SETTINGS--------------------------------------------------------//



        //-------------------------------------------------THEME---------------------------------------------------------------//
        if (Theme_active == true)
        {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Win);

            //exit button
            GUI.skin = b_exit_settings;
			if (GUI.Button(new Rect((Screen.width / 2)  - 1.4758f*(Screen.width / 4), Screen.height / 17.58f, (Screen.width / 16f), (Screen.width / 16f)), "  "))
            {
                Theme_active = false;
            }
            customButton.fontSize = Screen.width / 28;
            customButton.normal.textColor = Color.gray;
			GUI.Label(new Rect((Screen.width / 3.6f), (Screen.height / 12), (Screen.width / 2.5f), (Screen.height)), "THEME SELECTOR", customButton);

            GUI.skin = Standart_Theme;
            if (GUI.Button(new Rect((Screen.width / 5.1f), 11*(Screen.height / 50f), (Screen.width / 3.8f), (Screen.height / 5.5f)), "  "))
            {
				ThemeScriptMM TSMM = GameObject.Find("TSMM").GetComponent<ThemeScriptMM>();
				TSMM.NumberOfTheme = 0;
				TSMM.IsChange = true;
				PlayerPrefs.SetInt("Theme", 0);
            }

            GUI.skin = NULL_theme_sprite;
            if (GUI.Button(new Rect((Screen.width / 5.1f), 22*(Screen.height / 50f), (Screen.width / 3.8f), (Screen.height / 5.5f)), "  "))
            {
            }

            GUI.skin = Neon_theme_sprite;
			if (GUI.Button(new Rect((Screen.width / 1.88f), 11*(Screen.height / 50f), (Screen.width / 3.8f), (Screen.height / 5.5f)), "  "))
            {
				ThemeScriptMM TSMM = GameObject.Find("TSMM").GetComponent<ThemeScriptMM>();
				TSMM.NumberOfTheme = 1;
				TSMM.IsChange = true;
				PlayerPrefs.SetInt("Theme", 1);
            }

            GUI.skin = NULL_theme_sprite;
			if (GUI.Button(new Rect((Screen.width / 1.88f),  22*(Screen.height / 50f), (Screen.width / 3.8f), (Screen.height / 5.5f)), "  "))
            {
            }

            GUI.skin = Coming_soon_theme_sprite;
            if (GUI.Button(new Rect((Screen.width / 4.2f), (Screen.height / 1.5f), (Screen.width / 1.945f), (Screen.height / 10.505f)), "  "))
            {
            }
        }
        //-------------------------------------------------END_THEME-----------------------------------------------------------//






        PlayerPrefs.Save();

		if (_showHide && !setting_GM && !Theme_active && !Tutorial && !_showRecord){
            if (ThemeButton != null && TutorButton != null && SettingsButton != null && PlayButton != null && RecordButton != null)
            {
                ThemeButton.Draw();
                TutorButton.Draw();
                SettingsButton.Draw();
                PlayButton.Draw();
                RecordButton.Draw();
                VkButton.Draw();
                HomeButton.Draw();
                //somesing do
            }
		}else
		{
		if (MBack != null && MForvard  != null && Pauses != null )
		{
				GUIStyle GS = new GUIStyle();
				GS.alignment = TextAnchor.MiddleCenter;
				GS.fontSize = (int)(Mathf.Round(Screen.width / 25));
				if (currentTrek == 0)
				{
					GUI.Label(new Rect((Screen.width / 3), (205*Screen.height / 300), (Screen.width / 3), (Screen.height/3)), "Prince of Denmark - Sublimation",GS);
				}
				if (currentTrek == 1)
				{
					GUI.Label(new Rect((Screen.width / 3), (205*Screen.height / 300), (Screen.width / 3), (Screen.height/3)), "Robert del Naja - DT3",GS);
				}
			MBack.Draw();
			MForvard.Draw();
			Pauses.Draw();

			}
		}
    }
}
