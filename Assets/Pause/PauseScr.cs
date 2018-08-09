using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using CompleteProject;

public class PauseScr : MonoBehaviour
{
	public ThemeTriger TTM;
	public Texture2D Win;
	public Texture2D Win1;
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

    // buttons
    [Header("Skin's")]
    public GUISkin background_for_yes_no;
    public GUISkin Horizontal_scroll;
    public GUISkin buttons_p_s;
    public GUISkin b_exit_settings;
    public GUISkin tutor_skin_b;
    //
    public Triger TT;
    public Purchaser Pur;
    //
    [Header("Texture")]
    public Texture2D peregorodka; //перегородка в настройках 
    public Texture2D PauseTex;
    public Texture2D PauseSprite;
    public Texture2D background;
    public Texture2D background_yes_no;
    public Texture2D CurrentScore, HighScore;
    public Camera Cam;
    public BlurOptimized BO;
    public Grayscale G;
    public bool Tutorial = false;
    public bool IsPaused = false;
    bool menuRun = false;
    static public bool SettingsRun = false;
    bool go = false;
    bool exit = false;
    bool restart = false;
    bool pause_while_button_yes_no = false;

    [Header("Audio")]
    public AudioClip GOClip;
    public AudioClip SGSClip;
    public AudioClip SRClip;
    public AudioClip SREClip;
    public AudioClip SRSClip;
    public AudioClip SRFClip;

    public static float audioValue = PlayerPrefs.GetFloat("audioValue", 0);
    public bool audioOFF;
    public bool musicOFF;
    public float tempAudioValue;
    public float tempMusicValue;

    public static AudioSource SoundGO;
    public static AudioSource SoundGreenSlow;
    public static AudioSource SoundRepel;
    public static AudioSource SoundRedEvery;
    public static AudioSource SoundRedSlow;
    public static AudioSource SoundRedFast;

    // Use this for initialization
    void Start()
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





		ThemeTriger TTM = GameObject.Find("ThemeTriger").GetComponent<ThemeTriger>();
        Triger TT = GetComponent<Triger>();
        // МУЗЫКА
        if (SoundGO != null)
        {
            audioValue = SoundGO.volume;

            SoundGO.clip = GOClip;
            SoundGreenSlow.clip = SGSClip;
            SoundRepel.clip = SRClip;
            SoundRedEvery.clip = SREClip;
            SoundRedSlow.clip = SRSClip;
            SoundRedFast.clip = SRFClip;

            //    playerManager.musicValue = SoundGO.volume;
        }
        else
        {
            SoundGO = gameObject.AddComponent<AudioSource>();
            SoundGreenSlow = gameObject.AddComponent<AudioSource>();
            SoundRedEvery = gameObject.AddComponent<AudioSource>();
            SoundRedFast = gameObject.AddComponent<AudioSource>();
            SoundRedSlow = gameObject.AddComponent<AudioSource>();
            SoundRepel = gameObject.AddComponent<AudioSource>();

            audioValue = SoundGO.volume;
            //   playerManager.musicValue = SoundGO.volume;

            SoundGO.clip = GOClip;
            SoundGreenSlow.clip = SGSClip;
            SoundRepel.clip = SRClip;
            SoundRedEvery.clip = SREClip;
            SoundRedSlow.clip = SRSClip;
            SoundRedFast.clip = SRFClip;
        }
        // МУЗЫКА конец
    }

    // Update is called once per frame
    void Update()
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

        // тут настройка громкости музыки для использования в самой сцене
        playerManager.musicValue = PlayerPrefs.GetFloat("musicValue", 0);
        SoundGO.volume = audioValue;
        SoundGreenSlow.volume = audioValue;
        SoundRedEvery.volume = audioValue;
        SoundRedFast.volume = audioValue;
        SoundRedSlow.volume = audioValue;
        SoundRepel.volume = audioValue;
        //------
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Escape))
        {
            float MousePositionX = Input.mousePosition.x;
            float MousePositionY = Input.mousePosition.y;
            if ((MousePositionX < Screen.width - 10 && MousePositionX > Screen.width - 100 && MousePositionY < Screen.height - 10 && MousePositionY > Screen.height - 100) || Input.GetKeyDown(KeyCode.Escape))

            {
                if (!IsPaused)
                {

                    IsPaused = true;
                    Time.timeScale = 0;
                    IsPaused = true;
                    Cam.GetComponent<BlurOptimized>().enabled = true;
                    menuRun = true;
                    /*var ramp=0.5;
                do
                {
                    if(ramp>-0.19999f)
                    {
                        cameraUs.GetComponent(Grayscale).rampOffset = ramp;
                        cameraUs.GetComponent(Grayscale).enabled = true;
                        ramp -= 0.00001f;
                    }
                    else
                    {
                        ramp = -0.2f;
                    }
                }
                while (ramp == -0.2f);*/
                    //var rampoff : float = GetComponent(Grayscale).rampOffset;
                    //cameraUs.GetComponent(Grayscale).enabled = true;
                    for (var ramp = 0.5f; ramp >= -0.2f; ramp -= 0.1f)
                    {
                        //cameraUs.GetComponent(Grayscale).enabled = false;
                        //menuRun = false;
                        //break;
                        //rampoff = ramp;				
                        //menuRun = true;
                        //cameraUs.actualRenderingPath.GetComponent(Grayscale).rampOffset = ramp;
                        Cam.GetComponent<Grayscale>().rampOffset = ramp;
                        Cam.GetComponent<Grayscale>().enabled = true;
                    }
                }
                else
                {
                    if (go == true)
                    {
                        go = false;
                        menuRun = true;
                    }
                    else
                    {
                        if (exit == true)
                        {
                            exit = false;
                            menuRun = true;
                        }
                        else
                        {
                            Time.timeScale = 1;
                            IsPaused = false;
                            Cam.GetComponent<BlurOptimized>().enabled = false;
                            Cam.GetComponent<Grayscale>().enabled = false;
                            menuRun = false;
                            go = false;
                            exit = false;
                        }
                    }
                }
            }
        }
    }

    public GUIStyle customButton; // для настройки текста
    public GUIStyle customLabel_grey;

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
        tempAudioValue = GUI.HorizontalScrollbar(new Rect((Screen.width) + 100, (Screen.height), (Screen.width / 6), 20), audioValue, 0, 0, 1f);
        audioValue = Audio(tempAudioValue);

		if (!SettingsRun  && !menuRun && !pause_while_button_yes_no && !GameOverSc.GameOv && !Tutorial) GUI.DrawTexture(new Rect(Screen.width - 100, 20, 100, 100), PauseTex);
        if (TT.TPause)
            if (menuRun == true)
            {
                Cam.GetComponent<BlurOptimized>().enabled = true;
                // белый фон на паузе тут 
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Win);
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Win1);
			// GUI.DrawTexture(new Rect(Screen.width / 6.9f, (Screen.height / 1.6f), (Screen.width / 2.82f), (Screen.height / 400)), peregorodka);

                // меню настроек блять
                GUI.skin = buttons_p_s;
                float width_b = Screen.width / 4;
                float hight_b = Screen.height / 16;
                float menuX = Screen.width / 1.8f;
                customLabel_grey.normal.textColor = Color.grey;
                customLabel_grey.alignment = TextAnchor.UpperCenter; //выравнивание

                buttons_p_s.button.fontSize = Screen.width / 30;
                customLabel_grey.fontSize = Screen.width / 38;
                customButton.fontSize = customLabel_grey.fontSize;
                customButton.alignment = TextAnchor.UpperCenter;

                float x_c = (Screen.width / 2) - (Screen.width / 3) + (Screen.width / 86); // для удобства смещения 
                float y = - Screen.height / 24f;

               // GUI.DrawTexture(new Rect(Screen.width / 6.9f, (Screen.height / 1.61f) - y, (Screen.width / 2.82f), (Screen.height / 400)), peregorodka);
                // CURRENT              
			GUI.Label(new Rect(x_c, 0.9f*((Screen.height / 4) + (Screen.height / 16) + y), (Screen.width / 4), (Screen.height / 28)), "CURRENT ", customLabel_grey);

                if (PlayerPrefs.GetInt("Coins") == 0)
				GUI.Label(new Rect(x_c, 0.90f*((Screen.height / 4) + (Screen.height / 7) + y), (Screen.width / 4), (Screen.height / 20)), "COINS 0", customButton);
                else GUI.Label(new Rect(x_c, (Screen.height / 4) + (Screen.height / 7) + y, (Screen.width / 4), (Screen.height / 20)), "COINS " + PlayerPrefs.GetInt("Coins").ToString("#."), customButton);
                if (PlayerPrefs.GetInt("TempScore") == 0)
				GUI.Label(new Rect(x_c, 0.90f*((Screen.height / 4) + (Screen.height / 4.5f) + y), (Screen.width / 4), (Screen.height / 20)), "POINTS 0", customButton);
			else GUI.Label(new Rect(x_c, 0.90f*((Screen.height / 4) + (Screen.height / 4.5f) + y), (Screen.width / 4), (Screen.height / 20)), "POINTS " + PlayerPrefs.GetInt("TempScore").ToString("#."), customButton);

                // HIGHSCORE
                GUI.Label(new Rect((Screen.width / 4.5f), (Screen.height / 2) + (Screen.height / 10.5f) + y, (Screen.width / 6), (Screen.height / 28)), "HIGHSCORE ", customLabel_grey);

                if (PlayerPrefs.GetInt("MaxCoins") == 0)
                    GUI.Label(new Rect(x_c, (Screen.height / 2) + (Screen.height / 6f) + y, (Screen.width / 4), (Screen.height / 20)), "COINS 0", customButton);
                else GUI.Label(new Rect(x_c, (Screen.height / 2) + (Screen.height / 6f) + y, (Screen.width / 4), (Screen.height / 20)), "COINS " + PlayerPrefs.GetInt("MaxCoins").ToString("#."), customButton);
                if (PlayerPrefs.GetInt("MaxScore") == 0)
                    GUI.Label(new Rect(x_c, (Screen.height / 2) + (Screen.height / 4.8f) + (Screen.height / 28) + y, (Screen.width / 4), (Screen.height / 20)), "POINTS 0", customButton);
                else GUI.Label(new Rect(x_c, (Screen.height / 2) + (Screen.height / 4.8f) + (Screen.height / 28) + y, (Screen.width / 4), (Screen.height / 20)), "POINTS " + PlayerPrefs.GetInt("MaxScore").ToString("#."), customButton);

                // Pause menu
                // customLabel_grey.fontSize = buttons_p_s.button.fontSize;
                customLabel_grey.fontSize = Screen.width / 24;
			GUI.Label(new Rect((Screen.width / 2) - (Screen.width / 5), (Screen.height / 12), (Screen.width / 2.5f), (Screen.height)), " PAUSE ", customLabel_grey);


                if (GUI.Button(new Rect(menuX, (Screen.height / 4), width_b, hight_b), "RESUME"))
                {
                    menuRun = false;
                    IsPaused = false;
                    Time.timeScale = 1;
                    Cam.GetComponent<BlurOptimized>().enabled = false;
                    Cam.GetComponent<Grayscale>().enabled = false;
                }

			if (GUI.Button(new Rect(menuX, 6.2f*(Screen.height / 16), width_b, hight_b), "RESTART"))
                {
                    restart = true;
                    menuRun = false;
                }

			if (GUI.Button(new Rect(menuX, 8.6f*(Screen.height / 16), width_b, hight_b), "SETTINGS"))
                {
                    SettingsRun = true;
                    menuRun = false;
                }

			if (GUI.Button(new Rect(menuX - (Screen.width / 48), 5.4f*(Screen.height / 8), width_b + (Screen.width / 20), hight_b), "MAIN MENU"))
                {
                    go = true;
                    menuRun = false;
                }
                GUI.skin = null;
            }


        if (restart == true)
        {
            GUI.skin = buttons_p_s;
            customButton.alignment = TextAnchor.UpperCenter;
            customButton.fontSize = Screen.width / 38;
            customLabel_grey.fontSize = Screen.width / 48;
            pause_while_button_yes_no = true;
            GUI.DrawTexture(new Rect((Screen.width / 4) + (Screen.width / 12), (Screen.height / 4) + (Screen.height / 12), (Screen.width / 3), (Screen.height / 2) - (Screen.height / 8)), background_yes_no);
            GUI.Label(new Rect((Screen.width / 4) + (Screen.width / 9), (Screen.height / 4) + (Screen.height / 8), (Screen.width / 4) + (Screen.width / 32), (Screen.height / 20)), "REALLY RESTART?", customLabel_grey);
            if (GUI.Button(new Rect(Screen.width / 2.3f, (Screen.height / 2) - (Screen.height / 24) + (Screen.height / 36), (Screen.width / 8), (Screen.height / 14)), " YES "))
            {
                Time.timeScale = 1;
                Application.LoadLevel("Scene1");
                pause_while_button_yes_no = false;
                Cam.GetComponent<BlurOptimized>().enabled = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2.3f, (Screen.height / 2) + (Screen.height / 24) + (Screen.height / 24), (Screen.width / 8), (Screen.height / 14)), " NO "))
            {
                restart = false;
                menuRun = true;
                pause_while_button_yes_no = false;
                Cam.GetComponent<BlurOptimized>().enabled = false;
            }
        }

        if (go == true)
        {
            GUI.skin = buttons_p_s;
            customButton.alignment = TextAnchor.UpperCenter;
            customButton.fontSize = Screen.width / 38;
            customLabel_grey.fontSize = Screen.width / 48;
            GUI.DrawTexture(new Rect((Screen.width / 4) + (Screen.width / 12), (Screen.height / 4) + (Screen.height / 12), (Screen.width / 3), (Screen.height / 2) - (Screen.height / 8)), background_yes_no);
            GUI.Label(new Rect((Screen.width / 4) + (Screen.width / 8), (Screen.height / 4) + (Screen.height / 8), (Screen.width / 4), (Screen.height / 24)), "QUIT TO MENU?", customLabel_grey);
            pause_while_button_yes_no = true;
            if (GUI.Button(new Rect(Screen.width / 2.3f, (Screen.height / 2) - (Screen.height / 24) + (Screen.height / 36), (Screen.width / 8), (Screen.height / 14)), " YES "))
            {
                //   Time.timeScale = 1;
                // Application.LoadLevel("MineMenuVar2"); 31.05.2016
                loading_level.Name_of_Scene = "MineMenuVar2";
                Application.LoadLevel("Loading");
                //  pause_while_button_yes_no = false;
                //  Cam.GetComponent<BlurOptimized>().enabled = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2.3f, (Screen.height / 2) + (Screen.height / 24) + (Screen.height / 24), (Screen.width / 8), (Screen.height / 14)), " NO "))
            {
                go = false;
                menuRun = true;
                pause_while_button_yes_no = false;
                Cam.GetComponent<BlurOptimized>().enabled = false;
            }
        }

        if (SettingsRun == true)
        {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Win);
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Win1);


			//exit
			GUI.skin = b_exit_settings;
			if (GUI.Button(new Rect((Screen.width / 2)  - 1.4758f*(Screen.width / 4), Screen.height / 17.58f, (Screen.width / 16f), (Screen.width / 16f)), "  "))
			{
				SettingsRun = false;
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
				SettingsRun = false;
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
			/*
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Win);
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Win1); //exit
            GUI.skin = b_exit_settings;
            if (GUI.Button(new Rect((Screen.width / 2) - (Screen.width / 3) - (Screen.width / 25), (Screen.height / 5) - (Screen.height / 48), (Screen.width / 14.5f), (Screen.width / 14.5f)), "  "))
            {
                if (GameOverSc.GameOv_temp == true)
                {
                    SettingsRun = false;
                    GameOverSc.GameOv = true;
                    GameOverSc.settings = false;
                }
                else
                {
                    menuRun = true;
                    SettingsRun = false;
                    Cam.GetComponent<BlurOptimized>().enabled = false;
                }
            }

            //settings
            customButton.fontSize = Screen.width / 24;
            customButton.normal.textColor = Color.gray;
            GUI.Label(new Rect((Screen.width / 2) - (Screen.width / 5), (Screen.height / 5), (Screen.width / 2.5f), (Screen.height)), "SETTINGS", customButton);

            //show tutorial
            GUI.skin = buttons_p_s;
            buttons_p_s.button.fontSize = Screen.width / 28;
            if (GUI.Button(new Rect((Screen.width / 2) + (Screen.width / 24), (Screen.height / 4) + (Screen.height / 12), (Screen.width / 3.5f), (Screen.height / 8)), " show \r\n tutorial "))
            {
                //Tutorial = true;
                Application.LoadLevel("Scene1");
                MAIN.TutorOn = true;
            }

            //remove ADS           
            if (GUI.Button(new Rect((Screen.width / 2) + (Screen.width / 24), (Screen.height / 1.85f), (Screen.width / 3.5f), (Screen.height / 8)), " REMOVE \r\n ADS "))
            {
                if (AdMobPlugin.ADM == 0)
                {
                    Pur.BuyConsumable();
                }
            }


            //restore purchase
            if (GUI.Button(new Rect((Screen.width / 2) + (Screen.width / 36), (Screen.height / 1.35f), (Screen.width / 3f), (Screen.height / 8)), " RESTORE \r\n PURCHASES "))
            {
                Pur.RestorePurchases();
            }


            //музыка  
            GUI.skin = Horizontal_scroll;
            customButton.fontSize = Screen.width / 38;
            customButton.normal.textColor = Color.black;
            GUI.Label(new Rect((Screen.width / 4.4f), (Screen.height / 2.35f), (Screen.width / 6f), (Screen.height)), "MUSIC", customButton);
            //  musicOFF = GUI.Toggle((new Rect(Screen.width / 2 + Screen.width / 4, Screen.height / 2 + Screen.height / 12, (Screen.width / 6), Screen.height / 48)), musicOFF, " ");
            if (musicOFF == true)
                playerManager.musicValue = 0;
            tempMusicValue = playerManager.musicValue;
            tempMusicValue = GUI.HorizontalScrollbar(new Rect((Screen.width / 2) - (Screen.width / 3.2f), (Screen.height / 2), (Screen.width / 4), Screen.height / 48), playerManager.musicValue, 0, 0, 1f);
            playerManager.musicValue = Audio(tempMusicValue);
            PlayerPrefs.SetFloat("musicValue", playerManager.musicValue);

            // звуки игры    
            customButton.normal.textColor = Color.black;
            GUI.Label(new Rect((Screen.width / 4.4f), (Screen.height / 1.55f), (Screen.width / 6f), (Screen.height)), "SOUND", customButton);
            //  audioOFF = GUI.Toggle((new Rect((Screen.width / 2) + Screen.width / 4, (Screen.height / 2), (Screen.width / 6), Screen.height / 48)), audioOFF, " ");
            if (audioOFF == true)
                audioValue = 0;
            tempAudioValue = GUI.HorizontalScrollbar(new Rect((Screen.width / 2) - (Screen.width / 3.2f), Screen.height / 1.38f, (Screen.width / 4), Screen.height / 48), audioValue, 0, 0, 1f);
            audioValue = Audio(tempAudioValue);
            PlayerPrefs.SetFloat("audioValue", audioValue);

            customButton.normal.textColor = Color.black;*/
        }
        PlayerPrefs.Save();


		if (SettingsRun && menuRun) 
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
		else 
		{}
        //if (Tutorial == true)
        //{
        //    SettingsRun = false;
        //    GUI.skin = tutor_skin_b;
        //    if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "  "))
        //    {
        //        SettingsRun = true;
        //        Tutorial = false;
        //    }
        //}
    

}
}
