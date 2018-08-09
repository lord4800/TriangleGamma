using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class GameOverSc : MonoBehaviour
{
    // buttons
    public GUIStyle customButton;
    public GUISkin button;
    public GUIStyle customLabel_grey;
    public GUISkin tutor_skin_b;
    //
    public Texture2D peregorodka; //перегородка в настройках 
    public Texture2D background, background_yes_no;
    public static bool GameOv = false;
    public static bool GameOv_temp = false;
    public GameObject _main;
    public GameObject _Cam;
    public BlurOptimized BO;
    public Grayscale G;
    public Texture2D Game_overTexture;
    bool menu = false;
    public static bool settings = false;
    public bool Tutorial = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameOv = _main.GetComponent<MAIN>().GameOver;
        if (GameOv == true)
        {
            _Cam.GetComponent<BlurOptimized>().enabled = true;
            _Cam.GetComponent<Grayscale>().enabled = true;
        }
        /*_Cam.GetComponent<BlurOptimized>().enabled = true;
		_Cam.GetComponent<Grayscale>().enabled = true;*/
        //
    }

    void OnGUI()
    {
        if (GameOv == true)
        {
            // белый фон на паузе тут 
            GUI.DrawTexture(new Rect((Screen.width / 20) + (Screen.width / 14), (Screen.height / 6), (Screen.width / 2) + (Screen.width / 4), (Screen.height / 2) + (Screen.height / 4)), background);
            GUI.DrawTexture(new Rect((Screen.width / 28) + (Screen.width / 5), (Screen.height / 6), (Screen.width / 2), (Screen.height / 20) + (Screen.height / 20)), Game_overTexture);
            customButton.normal.textColor =Color.black;
            customButton.fontSize = Screen.height / 24;
            GUI.Label(new Rect((Screen.width / 28) + (Screen.width / 5), (Screen.height / 3.7f), (Screen.width / 2), (Screen.height / 20) + (Screen.height / 20)), "Time is UP", customButton);
            customLabel_grey.normal.textColor = Color.grey;
            customLabel_grey.alignment = TextAnchor.UpperCenter; //выравнивание

            customLabel_grey.fontSize = Screen.width / 38;
            customButton.fontSize = customLabel_grey.fontSize;
            customButton.alignment = TextAnchor.UpperCenter;

            // SCORE
            float x_c = (Screen.width / 2) - (Screen.width / 3) + (Screen.width / 86); // для удобства смещения по x     
            float y = Screen.height / 28f;
            GUI.DrawTexture(new Rect(Screen.width / 2, (Screen.height / 3.25f), (Screen.width / 800), (Screen.height / 1.8f)), peregorodka);
            GUI.DrawTexture(new Rect(Screen.width / 6.9f, (Screen.height / 1.61f) - y, (Screen.width / 2.82f), (Screen.height / 400)), peregorodka);

            GUI.Label(new Rect(x_c, (Screen.height / 4) + (Screen.height / 16) + y, (Screen.width / 4), (Screen.height / 28)), "CURRENT ", customLabel_grey);

            if (PlayerPrefs.GetInt("Coins") == 0)
                GUI.Label(new Rect(x_c, (Screen.height / 4) + (Screen.height / 7) + y, (Screen.width / 4), (Screen.height / 20)), "COINS 0", customButton);
            else GUI.Label(new Rect(x_c, (Screen.height / 4) + (Screen.height / 7) + y, (Screen.width / 4), (Screen.height / 20)), "COINS " + PlayerPrefs.GetInt("Coins").ToString("#."), customButton);
            if (PlayerPrefs.GetInt("TempScore") == 0)
                GUI.Label(new Rect(x_c, (Screen.height / 4) + (Screen.height / 4.5f) + y, (Screen.width / 4), (Screen.height / 20)), "POINTS 0", customButton);
            else GUI.Label(new Rect(x_c, (Screen.height / 4) + (Screen.height / 4.5f) + y, (Screen.width / 4), (Screen.height / 20)), "POINTS " + PlayerPrefs.GetInt("TempScore").ToString("#."), customButton);


            // HIGHSCORE
            GUI.Label(new Rect((Screen.width / 4.5f), (Screen.height / 2) + (Screen.height / 10.5f) + y, (Screen.width / 6), (Screen.height / 28)), "HIGHSCORE ", customLabel_grey);

            if (PlayerPrefs.GetInt("MaxCoins") == 0)
                GUI.Label(new Rect(x_c, (Screen.height / 2) + (Screen.height / 6f) + y, (Screen.width / 4), (Screen.height / 20)), "COINS 0", customButton);
            else GUI.Label(new Rect(x_c, (Screen.height / 2) + (Screen.height / 6f) + y, (Screen.width / 4), (Screen.height / 20)), "COINS " + PlayerPrefs.GetInt("MaxCoins").ToString("#."), customButton);
            if (PlayerPrefs.GetInt("MaxScore") == 0)
                GUI.Label(new Rect(x_c, (Screen.height / 2) + (Screen.height / 4.8f) + (Screen.height / 28) + y, (Screen.width / 4), (Screen.height / 20)), "POINTS 0", customButton);
            else GUI.Label(new Rect(x_c, (Screen.height / 2) + (Screen.height / 4.8f) + (Screen.height / 28) + y, (Screen.width / 4), (Screen.height / 20)), "POINTS " + PlayerPrefs.GetInt("MaxScore").ToString("#."), customButton);

            float menuX = Screen.width / 1.8f;
            Time.timeScale = 0;
            GUI.skin = button;
            float width_b = Screen.width / 4;
            float hight_b = Screen.height / 16;
            button.button.fontSize = Screen.width / 30;
            if (GUI.Button(new Rect(menuX, (Screen.height / 2) - (Screen.height / 8), width_b, hight_b), "RESTART"))
            {
                GameOv = false;
                Time.timeScale = 1;
                Application.LoadLevel("Scene1");
            }

            if (GUI.Button(new Rect(menuX, (Screen.height / 2) + (Screen.height / 50), width_b, hight_b), "SETTINGS"))
            {                 
               settings = true;
               GameOv = false;
            }

            if (GUI.Button(new Rect(menuX - (Screen.width / 48), (Screen.height / 2) + (Screen.height / 6) - (Screen.height / 72), width_b + (Screen.width / 18), hight_b), "MAIN MENU"))
            {
                menu = true;
                GameOv = false;
            }

            //if (GUI.Button( new Rect((Screen.width/2)-100,(Screen.height/2)+180,200,60),"Exit")) 
            //{
            //	Application.Quit();
            //}
        }

        if(settings==true)
        {
            GameOv_temp = true;
            GameOv = false;
            PauseScr.SettingsRun = true;
        }

        if (menu == true)
        {
            GUI.skin = button;
            customButton.alignment = TextAnchor.UpperCenter;
            customButton.fontSize = Screen.width / 38;
            customLabel_grey.normal.textColor = Color.grey;
            customLabel_grey.alignment = TextAnchor.UpperCenter;
            customLabel_grey.fontSize = Screen.width / 48;

            GameOv = false;
            GUI.DrawTexture(new Rect((Screen.width / 4) + (Screen.width / 12), (Screen.height / 4) + (Screen.height / 12), (Screen.width / 3), (Screen.height / 2) - (Screen.height / 8)), background_yes_no);
            GUI.Label(new Rect((Screen.width / 4) + (Screen.width / 8), (Screen.height / 4) + (Screen.height / 8), (Screen.width / 4), (Screen.height / 24)), "QUIT TO MENU?", customLabel_grey);
            if (GUI.Button(new Rect(Screen.width / 2.3f, (Screen.height / 2) - (Screen.height / 24) + (Screen.height / 36), (Screen.width / 8), (Screen.height / 14)), " YES "))
            {
                Time.timeScale = 1;
                loading_level.Name_of_Scene = "MineMenuVar2";
                Application.LoadLevel("Loading");
            }
            if (GUI.Button(new Rect(Screen.width / 2.3f, (Screen.height / 2) + (Screen.height / 24) + (Screen.height / 24), (Screen.width / 8), (Screen.height / 14)), " NO "))
            {
                GameOv = true;
                menu = false;
            }
        }
    }
}