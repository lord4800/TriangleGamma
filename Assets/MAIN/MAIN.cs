using UnityEngine; //New
using System.Collections;
public class MAIN : MonoBehaviour
{
    public Triger TT;

    static int NumberOfObject = 15;
    static int MaxScore = 0;
    static public int MaxCoins = 0;
    /*static int MaxScore = PlayerPrefs.GetInt("MaxScore", 0);
    static public int MaxCoins = PlayerPrefs.GetInt("MaxCoins", 0);*/
    int[] SwitchValue = new int[NumberOfObject + 1];
    int Coins;
    int Coins1;
    int Score;
    int Score1;
    int SwitchTutor = 0;
    int TempScore;
    short[] PositionEffect = new short[5];
    short Dir;
    short StackToStop = 0;
    short SideOfTriangle;
    short SwitchRed = 1;
    float[] MAXTimeOfEffect = new float[5];
    float[] TimeOfEffect = new float[5];
    float Border;
    float BorderControllerLeft = 0.45f * Screen.width;
    float BorderControllerRight = 0.55f * Screen.width;
    float BorderControllerUp = 0.7f * Screen.height;
    float ChangedRotation = 1f;
    float Dif;
    float MoveSpeed = 15f;
    float offset;
    float PositionBonus;
    float PositionStart = 30f;
    float RadiusBonus = 0.8f;
    float DiameterBonus = 1.6f;
    float Random1;
    float Rot;
    float RotationLine = 1f;
    float RotationTriangle = 0;
    float RotationVoidBonus;
    float RotLineSpeed = 0.03f;
    float RotSpeed = 90f;
    float RotTime;
    float StepTimeToGo = 2.5f;
    float StopingTriangle = 1f;
    float Timer;
    float TimeToGo = 0;
    bool[] Touches = new bool[2];
    bool[] Activated = new bool[NumberOfObject];
    bool[] ActiveEffect = new bool[5];
    bool[] RunAway = new bool[NumberOfObject];
    [Header("BOOL")]
    public bool GameOver = false;
    public bool ReasonOfDeath;
    static public bool TutorOn = false;
    bool Pausekey = false;
    bool UnRed = false;
    bool UnX = false;
    Vector3 TimeV3;
    public Texture2D ButtomNext;
    public Texture2D ButtomNextDown;
    public Texture2D LeftROTATE;
    public Texture2D RightROTATE;
    public Texture2D LineForController;
    [Header("Textures")]
    public Texture2D TextureGreen;
    public Texture2D TextureGreenSlow;
    public Texture2D TextureGreenClean;
    public Texture2D TextureGreen2;
    public Texture2D TextureGreen3;
    public Texture2D TextureGreen5;
    public Texture2D TextureGreen10;
    public Texture2D TextureGreen15;
    public Texture2D TextureYellow;
    public Texture2D TextureYellow10;
    public Texture2D TextureRed;
    public Texture2D TextureRedBomb;
    public Texture2D TextureRedSlow;
    public Texture2D TextureRedFast;
    public Texture2D TextureRedSwap;
    [Header("Sprite")]
    public GameObject SpriteGreen;
    public GameObject SpriteGreenSlow;
    public GameObject SpriteGreenClean;
    public GameObject SpriteGreen2;
    public GameObject SpriteGreen3;
    public GameObject SpriteGreen5;
    public GameObject SpriteGreen10;
    public GameObject SpriteGreen15;
    public GameObject SpriteYellow;
    public GameObject SpriteYellow10;
    public GameObject SpriteRed;
    public GameObject SpriteRedBomb;
    public GameObject SpriteRedSlow;
    public GameObject SpriteRedFast;
    public GameObject SpriteRedSwap;
    [Header("Object")]
    public GameObject Green;
    public GameObject GreenSlow;
    public GameObject GreenClean;
    public GameObject Green2;
    public GameObject Green3;
    public GameObject Green5;
    public GameObject Green10;
    public GameObject Green15;
    public GameObject Yellow;
    public GameObject Yellow10;
    public GameObject Red;
    public GameObject RedBomb;
    public GameObject RedSlow;
    public GameObject RedFast;
    public GameObject RedSwap;
    [Header("Void Object")]
    public GameObject VoidGreen;
    public GameObject VoidGreenSlow;
    public GameObject VoidGreenClean;
    public GameObject VoidGreen2;
    public GameObject VoidGreen3;
    public GameObject VoidGreen5;
    public GameObject VoidGreen10;
    public GameObject VoidGreen15;
    public GameObject VoidYellow;
    public GameObject VoidYellow10;
    public GameObject VoidRed;
    public GameObject VoidRedBomb;
    public GameObject VoidRedSlow;
    public GameObject VoidRedFast;
    public GameObject VoidRedSwap;
    public GameObject Timer0;
    public GameObject Timer1;
    public GameObject Timer2;
    public GameObject Timer3;
    public GameObject Timer4;
    public GameObject Sprite0;
    public GameObject Sprite1;
    public GameObject Sprite2;
    public GameObject Sprite3;
    public GameObject Sprite4;
    public GameObject GreenRadar;
    public GameObject YellowRadar;
    public GameObject RedRadar;
    public GameObject Line;
    public GameObject OutLine;
    public GameObject PauseS;
    public Transform Triangle;
    short GetEffect(GameObject Spriteee, GameObject Timerrr, int n)
    {
        if (TimeOfEffect[n] == 0)
        {
            short m = 5;
            for (short i = 0; i < m; i++) if (ActiveEffect[i] == false) m = i;
            ActiveEffect[m] = true;
            Timerrr.transform.position = new Vector3(-5.4f + 2.7f * m, -13.2f, 0);
            Spriteee.transform.position = new Vector3(-5.4f + 2.7f * m, -11.7f, 0);
            Timerrr.SetActive(true);
            Spriteee.SetActive(true);
            TimeOfEffect[n] = MAXTimeOfEffect[n];
            return m;
        }
        else
        {
            TimeOfEffect[n] = MAXTimeOfEffect[n];
            return PositionEffect[n];
        }
    }
    void ContEffect(GameObject Timerrr, int n)
    {
        Timerrr.transform.localScale = new Vector3(TimeOfEffect[n] / MAXTimeOfEffect[n], 1, 1);
        TimeOfEffect[n] -= Time.deltaTime;
    }
    void ContEffectAll()
    {
        if (TimeOfEffect[0] > 0.1) ContEffect(Timer0, 0);
        if (TimeOfEffect[1] > 0.1) ContEffect(Timer1, 1);
        if (TimeOfEffect[2] > 0.1) ContEffect(Timer2, 2);
        if (TimeOfEffect[3] > 0.1) ContEffect(Timer3, 3);
        if (TimeOfEffect[4] > 0.1) ContEffect(Timer4, 4);
    }
    void StopEffect(GameObject Spriteee, GameObject Timerrr, int m)
    {
        Timerrr.SetActive(false);
        Spriteee.SetActive(false);
        ActiveEffect[m] = false;
    }
    void StopEffectAll()
    {
        if (TimeOfEffect[0] < 0.1f && TimeOfEffect[0] > 0)
        {
            Time.timeScale = 1f;
            TimeOfEffect[0] = 0;
            StopEffect(Sprite0, Timer0, PositionEffect[0]);
        }
        if (TimeOfEffect[1] < 0.1f && TimeOfEffect[1] > 0)
        {
            UnRed = false;
            SwitchRed = 1;
            TimeOfEffect[1] = 0;
            StopEffect(Sprite1, Timer1, PositionEffect[1]);
        }
        if (TimeOfEffect[2] < 0.1f && TimeOfEffect[2] > 0)
        {
            ChangedRotation = ChangedRotation / 0.6f;
            TimeOfEffect[2] = 0;
            StopEffect(Sprite2, Timer2, PositionEffect[2]);
        }
        if (TimeOfEffect[3] < 0.1f && TimeOfEffect[3] > 0)
        {
            ChangedRotation = ChangedRotation / 5f;
            TimeOfEffect[3] = 0;
            StopEffect(Sprite3, Timer3, PositionEffect[3]);
        }
        if (TimeOfEffect[4] < 0.1f && TimeOfEffect[4] > 0)
        {
            ChangedRotation = ChangedRotation * -1;
            TimeOfEffect[4] = 0;
            StopEffect(Sprite4, Timer4, PositionEffect[4]);
        }
    }
    void M_Score()
    {
        if (MaxScore < Score) MaxScore = Score;
    }
    void M_coints()
    {
        if (MaxCoins < Coins) MaxCoins = Coins;
    }
    void T_score()
    {
        if (TempScore < Score) TempScore = Score;
    }
    void DeleteMaxCoins()
    {
        MaxCoins = 0;
    }
    void DeleteMaxScore()
    {
        MaxScore = 0;
    }
    void MoveObj(Transform Triangle, GameObject VoidBonus, GameObject Bonus, GameObject Sprite, int NoB)
    {
        PositionBonus = Bonus.transform.localPosition.y;
        RotationVoidBonus = VoidBonus.transform.rotation.eulerAngles.z;
        if (RotationVoidBonus < 0) RotationVoidBonus += 360f;
        RotationTriangle = Triangle.transform.rotation.eulerAngles.z;
        Dif = RotationVoidBonus - RotationTriangle;
        SideOfTriangle = 0;
        if (Dif < -60) Dif += 360f;
        while (Dif > 60)
        {
            Dif -= 120f;
            SideOfTriangle += 1;
            if (SideOfTriangle == 3) SideOfTriangle = 0;
        }
        Border = 1.4f * Mathf.Abs((1.325f + RadiusBonus) / Mathf.Cos(Dif * 0.0174532925f));

        if (PositionBonus > 12.5 && RunAway[NoB] == false && ((RotationVoidBonus < 45) || (RotationVoidBonus > 135 && RotationVoidBonus < 225) || (RotationVoidBonus > 315)))
        {
            if (NoB < 8)
            {
                GreenRadar.SetActive(true);
                GreenRadar.transform.rotation = Quaternion.Euler(0, 0, RotationVoidBonus);
            }
            if (NoB == 8 || NoB == 9)
            {
                YellowRadar.SetActive(true);
                YellowRadar.transform.rotation = Quaternion.Euler(0, 0, RotationVoidBonus);
            }
            if (NoB > 9)
            {
                RedRadar.SetActive(true);
                RedRadar.transform.rotation = Quaternion.Euler(0, 0, RotationVoidBonus);
            }
        }
        else
        {
            GreenRadar.SetActive(false);
            YellowRadar.SetActive(false);
            RedRadar.SetActive(false);
        }

        if (PositionBonus > Border && RunAway[NoB] == false)
        {
            Bonus.transform.Translate(new Vector3(0, -1, 0) * MoveSpeed * Time.deltaTime);
            PositionBonus = Bonus.transform.position.y;
        }
        else
        {
            if (RunAway[NoB] == false)
            {
                switch (SideOfTriangle)
                {
                    case 0:
                        {
                            if (NoB == 0)
                            {
                                Score += 1;
                            }
                            if (NoB == 1)
                            {
                                Score += 1;
                                if (TimeOfEffect[0] == 0) Time.timeScale = 0.5f;
                                PauseScr.SoundGreenSlow.Stop();
                                PauseScr.SoundGreenSlow.Play();
                                PositionEffect[0] = GetEffect(Sprite0, Timer0, 0);
                            }
                            if (NoB == 2)
                            {
                                Score += 1;
                                if (TimeOfEffect[1] == 0)
                                {
                                    UnRed = true;
                                    SwitchRed = 0;
                                }
                                PositionEffect[1] = GetEffect(Sprite1, Timer1, 1);
                            }
                            if (NoB == 3)
                            {
                                Score += 2;
                            }
                            if (NoB == 4)
                            {
                                Score += 3;
                            }
                            if (NoB == 5)
                            {
                                Score += 5;
                            }
                            if (NoB == 6)
                            {
                                Score += 10;
                            }
                            if (NoB == 7)
                            {
                                Score += 15;
                            }
                            if (NoB == 8)
                            {
                                RotationLine = 1;
                                Line.transform.localScale = new Vector3(RotationLine, 1, 1);
                            }
                            if (NoB == 9)
                            {
                                RotationLine = 1;
                                Line.transform.localScale = new Vector3(RotationLine, 1, 1);
                            }
                            if (NoB == 10)
                            {
                                Score -= 1;
                                PauseScr.SoundRedEvery.Stop();
                                PauseScr.SoundRedEvery.Play();
                            }
                            if (NoB == 11)
                            {
                                Score -= 10;
                                PauseScr.SoundRedEvery.Stop();
                                PauseScr.SoundRedEvery.Play();
                                Triangle.transform.rotation = Quaternion.Euler(0, 0, Triangle.transform.rotation.eulerAngles.z + Random.Range(-50, 50));
                            }
                            if (NoB == 12)
                            {
                                Score -= 1;
                                PauseScr.SoundRedEvery.Stop();
                                PauseScr.SoundRedEvery.Play();
                                PauseScr.SoundRedSlow.Stop();
                                PauseScr.SoundRedSlow.Play();
                                if (TimeOfEffect[2] == 0) ChangedRotation = ChangedRotation * 0.6f;
                                PositionEffect[2] = GetEffect(Sprite2, Timer2, 2);
                            }
                            if (NoB == 13)
                            {
                                Score -= 1;
                                PauseScr.SoundRedEvery.Stop();
                                PauseScr.SoundRedFast.Stop();
                                PauseScr.SoundRedEvery.Play();
                                PauseScr.SoundRedFast.Play();
                                if (TimeOfEffect[3] == 0) ChangedRotation = ChangedRotation * 5f;
                                PositionEffect[3] = GetEffect(Sprite3, Timer3, 3);
                            }
                            if (NoB == 14)
                            {
                                Score -= 1;
                                PauseScr.SoundRedEvery.Stop();
                                PauseScr.SoundRedEvery.Play();
                                if (TimeOfEffect[4] == 0) ChangedRotation = ChangedRotation * -1f;
                                PositionEffect[4] = GetEffect(Sprite4, Timer4, 4);
                            }
                            Bonus.transform.localPosition = new Vector3(0, PositionStart, 0);
                            VoidBonus.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                            Sprite.transform.rotation = Quaternion.Euler(0, 0, VoidBonus.transform.rotation.z - 360);

                            Activated[NoB] = false;
                            break;
                        }
                    case 2:
                        {
                            if (NoB == 0)
                            {
                                RotationLine = 1;
                                Line.transform.localScale = new Vector3(RotationLine, 1, 1);
                            }
                            if (NoB == 1)
                            {
                                RotationLine = 1;
                                Line.transform.localScale = new Vector3(RotationLine, 1, 1);
                            }
                            if (NoB == 2)
                            {
                                RotationLine = 1;
                                Line.transform.localScale = new Vector3(RotationLine, 1, 1);
                            }
                            if (NoB == 3)
                            {
                                RotationLine = 1;
                                Line.transform.localScale = new Vector3(RotationLine, 1, 1);
                            }
                            if (NoB == 4)
                            {
                                RotationLine = 1;
                                Line.transform.localScale = new Vector3(RotationLine, 1, 1);
                            }
                            if (NoB == 5)
                            {
                                RotationLine = 1;
                                Line.transform.localScale = new Vector3(RotationLine, 1, 1);
                            }
                            if (NoB == 6)
                            {
                                RotationLine = 1;
                                Line.transform.localScale = new Vector3(RotationLine, 1, 1);
                            }
                            if (NoB == 7)
                            {
                                RotationLine = 1;
                                Line.transform.localScale = new Vector3(RotationLine, 1, 1);
                            }
                            if (NoB == 8)
                            {
                                Score += 1;
                                Coins += 1;
                            }
                            if (NoB == 9)
                            {
                                Score += 1;
                                Coins += 10;
                            }
                            if (NoB == 10)
                            {
                                Score -= 1;
                                PauseScr.SoundRedEvery.Stop();
                                PauseScr.SoundRedEvery.Play();
                            }
                            if (NoB == 11)
                            {
                                Score -= 10;
                                PauseScr.SoundRedEvery.Stop();
                                PauseScr.SoundRedEvery.Play();
                                Triangle.transform.rotation = Quaternion.Euler(0, 0, Triangle.transform.rotation.eulerAngles.z + Random.Range(-50, 50));
                            }
                            if (NoB == 12)
                            {
                                Score -= 1;
                                PauseScr.SoundRedSlow.Stop();
                                PauseScr.SoundRedSlow.Play();
                                PauseScr.SoundRedEvery.Stop();
                                PauseScr.SoundRedEvery.Play();
                                if (TimeOfEffect[2] == 0) ChangedRotation = ChangedRotation * 0.6f;
                                PositionEffect[2] = GetEffect(Sprite2, Timer2, 2);
                            }
                            if (NoB == 13)
                            {
                                Score -= 1;
                                PauseScr.SoundRedEvery.Stop();
                                PauseScr.SoundRedEvery.Play();
                                PauseScr.SoundRedFast.Stop();
                                PauseScr.SoundRedFast.Play();
                                if (TimeOfEffect[3] == 0) ChangedRotation = ChangedRotation * 5f;
                                PositionEffect[3] = GetEffect(Sprite3, Timer3, 3);
                            }
                            if (NoB == 14)
                            {
                                Score -= 1;
                                PauseScr.SoundRedEvery.Stop();
                                PauseScr.SoundRedEvery.Play();
                                if (TimeOfEffect[4] == 0) ChangedRotation = ChangedRotation * -1f;
                                PositionEffect[4] = GetEffect(Sprite4, Timer4, 4);
                            }
                            Bonus.transform.localPosition = new Vector3(0, PositionStart, 0);

                            VoidBonus.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                            Sprite.transform.rotation = Quaternion.Euler(0, 0, VoidBonus.transform.rotation.z - 360);

                            Activated[NoB] = false;
                            break;
                        }
                    case 1:
                        {
                            PauseScr.SoundRepel.Stop();
                            PauseScr.SoundRepel.Play();
                            RunAway[NoB] = true;
                            TimeV3 = Bonus.transform.position;
                            Bonus.transform.position = new Vector3(0, 0, 0);
                            VoidBonus.transform.position = TimeV3;
                            VoidBonus.transform.rotation = Quaternion.Euler(0, 0, (VoidBonus.transform.rotation.eulerAngles.z - 2 * Dif));
                            break;
                        }
                }
            }
            else
            {
                if (PositionBonus < PositionStart)
                {
                    Bonus.transform.Translate(new Vector3(0, 1, 0) * 5 * MoveSpeed * Time.deltaTime);
                    PositionBonus = Bonus.transform.position.y;
                }
                else
                {
                    RunAway[NoB] = false;
                    VoidBonus.transform.position = new Vector3(0, 0, 0);
                    VoidBonus.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                    Sprite.transform.rotation = Quaternion.Euler(0, 0, VoidBonus.transform.rotation.z - 360);

                    Activated[NoB] = false;
                }

            }
        }
    }
    void MoveALL()
    {
        if (Activated[0] == true) MoveObj(Triangle, VoidGreen, Green, SpriteGreen, 0);
        if (Activated[1] == true) MoveObj(Triangle, VoidGreenSlow, GreenSlow, SpriteGreenSlow, 1);
        if (Activated[2] == true) MoveObj(Triangle, VoidGreenClean, GreenClean, SpriteGreenClean, 2);
        if (Activated[3] == true) MoveObj(Triangle, VoidGreen2, Green2, SpriteGreen2, 3);
        if (Activated[4] == true) MoveObj(Triangle, VoidGreen3, Green3, SpriteGreen3, 4);
        if (Activated[5] == true) MoveObj(Triangle, VoidGreen5, Green5, SpriteGreen5, 5);
        if (Activated[6] == true) MoveObj(Triangle, VoidGreen10, Green10, SpriteGreen10, 6);
        if (Activated[7] == true) MoveObj(Triangle, VoidGreen15, Green15, SpriteGreen15, 7);
        if (Activated[8] == true) MoveObj(Triangle, VoidYellow, Yellow, SpriteYellow, 8);
        if (Activated[9] == true) MoveObj(Triangle, VoidYellow10, Yellow10, SpriteYellow10, 9);
        if (Activated[10] == true) MoveObj(Triangle, VoidRed, Red, SpriteRed, 10);
        if (Activated[11] == true) MoveObj(Triangle, VoidRedBomb, RedBomb, SpriteRedBomb, 11);
        if (Activated[12] == true) MoveObj(Triangle, VoidRedSlow, RedSlow, SpriteRedSlow, 12);
        if (Activated[13] == true) MoveObj(Triangle, VoidRedFast, RedFast, SpriteRedFast, 13);
        if (Activated[14] == true) MoveObj(Triangle, VoidRedSwap, RedSwap, SpriteRedSwap, 14);
    }
    void RotateTriangle()
    {
        if ((Input.GetMouseButton(0) && Input.mousePosition.x < BorderControllerLeft && Input.mousePosition.y < BorderControllerUp) || Input.GetKey("left"))
        {
            Touches[0] = true;
        }
        if ((Input.GetMouseButton(0) && Input.mousePosition.x > BorderControllerRight && Input.mousePosition.y < BorderControllerUp) || Input.GetKey("right"))
        {
            Touches[1] = true;
        }
        if ((Input.GetMouseButtonDown(0) && Input.mousePosition.x < BorderControllerLeft && Input.mousePosition.y < BorderControllerUp) || Input.GetKeyDown("left"))
        {
            Touches[0] = true;
            Dir = 1;
            RotTime = 0;
        }
        if ((Input.GetMouseButtonDown(0) && Input.mousePosition.x > BorderControllerRight && Input.mousePosition.y < BorderControllerUp) || Input.GetKeyDown("right"))
        {
            Touches[1] = true;
            Dir = -1;
            RotTime = 0;
        }
        if (Touches[0] == true && Touches[1] == false && Dir == -1) { RotTime = 0; Dir = 1; }
        if (Touches[1] == true && Touches[0] == false && Dir == 1) { RotTime = 0; Dir = -1; }

        if (Touches[0] == true || Touches[1] == true)
        {
            if (RotTime <= 20) RotTime += 100 * Time.deltaTime;
        }
        if (RotTime > 0)
        {
            RotTime = RotTime - StopingTriangle * 50 * Time.deltaTime;
            Rot = ChangedRotation * Dir * 0.05f * RotTime;
            Vector3 rotate = new Vector3(0f, 0f, Rot * 10);
            Triangle.rotation = Quaternion.Slerp(Triangle.rotation, Triangle.rotation * Quaternion.Euler(rotate), Time.deltaTime * RotSpeed);
        }
        if (RotTime <= 0.1)
        {
            Dir = 0;
            RotTime = 0;
        }
        Touches[0] = false;
        Touches[1] = false;
    }
    void TimeToFly()
    {
        TimeToGo += StepTimeToGo;
        StackToStop = 0;
        while (StackToStop < 4)
        {
            if (UnRed == true || SwitchRed > 2) Random1 = Random.Range(SwitchValue[0], SwitchValue[NumberOfObject-5]);
            else Random1 = Random.Range(SwitchValue[0], SwitchValue[NumberOfObject]);
            for (int i = 0; i < NumberOfObject; i++)
            {
                if (Random1 >= SwitchValue[i] && Random1 <= SwitchValue[i + 1])
                {
                    if (Activated[i] == false)
                    {
                        if (Random1 > SwitchValue[NumberOfObject - 5]) SwitchRed++;
                        if (Random1 < SwitchValue[NumberOfObject - 5]) SwitchRed = 0;
                        Activated[i] = true;
                        StackToStop = 4;
                    }
                    else StackToStop++;
                    i = NumberOfObject;
                }
            }
        }
    }
    void Start()
    {
        RotSpeed = 90;
        Score = 0;
        PauseScr.SoundGO.Stop();
        PauseScr.SoundGreenSlow.Stop();
        PauseScr.SoundRepel.Stop();
        PauseScr.SoundRedEvery.Stop();
        PauseScr.SoundRedSlow.Stop();
        PauseScr.SoundRedFast.Stop();

        SpriteGreen.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteGreenSlow.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteGreenClean.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteGreen2.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteGreen3.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteGreen5.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteGreen10.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteGreen15.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteYellow.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteYellow10.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteRed.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteRedBomb.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteRedSlow.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteRedFast.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);
        SpriteRedSwap.transform.localScale = new Vector3(DiameterBonus, DiameterBonus, 0);

        MAXTimeOfEffect[0] = 5f;
        MAXTimeOfEffect[1] = 10f;
        MAXTimeOfEffect[2] = 15f;
        MAXTimeOfEffect[3] = 15f;
        MAXTimeOfEffect[4] = 10f;
        
        GreenRadar.SetActive(false);
        YellowRadar.SetActive(false);
        RedRadar.SetActive(false);

        Timer0.SetActive(false);
        Timer1.SetActive(false);
        Timer2.SetActive(false);
        Timer3.SetActive(false);
        Timer4.SetActive(false);

        Sprite0.SetActive(false);
        Sprite1.SetActive(false);
        Sprite2.SetActive(false);
        Sprite3.SetActive(false);
        Sprite4.SetActive(false);

        ActiveEffect[0] = false;
        ActiveEffect[1] = false;
        ActiveEffect[2] = false;
        ActiveEffect[3] = false;
        ActiveEffect[4] = false;

        OutLine.SetActive(true);
        Line.SetActive(true);
        PauseS.SetActive(true);
        
        SwitchValue[0] = 0;

        SwitchValue[1] = SwitchValue[0] + 1398; //Green
        SwitchValue[2] = SwitchValue[1] + 200; //Slow
        SwitchValue[3] = SwitchValue[2] + 200; //Clean
        SwitchValue[4] = SwitchValue[3] + 100; //2
        SwitchValue[5] = SwitchValue[4] + 60; //3
        SwitchValue[6] = SwitchValue[5] + 30; //5
        SwitchValue[7] = SwitchValue[6] + 10; //10
        SwitchValue[8] = SwitchValue[7] + 2; //15
        
        SwitchValue[9] = SwitchValue[8] + 3960; //x1
        SwitchValue[10] = SwitchValue[9] + 40; //x10

        SwitchValue[11] = SwitchValue[10] + 1720; //Red
        SwitchValue[12] = SwitchValue[11] + 1200; //Bomb
        SwitchValue[13] = SwitchValue[12] + 600; //Slow
        SwitchValue[14] = SwitchValue[13] + 280; //Fast
        SwitchValue[15] = SwitchValue[14] + 200; //Swap

        Time.timeScale = 1f;
        VoidGreen.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidGreenSlow.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidGreenClean.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidGreen2.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidGreen3.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidGreen5.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidGreen10.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidGreen15.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidYellow.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidYellow10.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidRed.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidRedBomb.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidRedSlow.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidRedFast.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        VoidRedSwap.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

        Green.transform.localPosition = new Vector3(0, PositionStart, 0);
        GreenSlow.transform.localPosition = new Vector3(0, PositionStart, 0);
        GreenClean.transform.localPosition = new Vector3(0, PositionStart, 0);
        Green2.transform.localPosition = new Vector3(0, PositionStart, 0);
        Green3.transform.localPosition = new Vector3(0, PositionStart, 0);
        Green5.transform.localPosition = new Vector3(0, PositionStart, 0);
        Green10.transform.localPosition = new Vector3(0, PositionStart, 0);
        Green15.transform.localPosition = new Vector3(0, PositionStart, 0);
        Yellow.transform.localPosition = new Vector3(0, PositionStart, 0);
        Yellow10.transform.localPosition = new Vector3(0, PositionStart, 0);
        Red.transform.localPosition = new Vector3(0, PositionStart, 0);
        RedBomb.transform.localPosition = new Vector3(0, PositionStart, 0);
        RedSlow.transform.localPosition = new Vector3(0, PositionStart, 0);
        RedFast.transform.localPosition = new Vector3(0, PositionStart, 0);
        RedSwap.transform.localPosition = new Vector3(0, PositionStart, 0);

        SpriteGreen.transform.rotation = Quaternion.Euler(0, 0, VoidGreen.transform.rotation.z - 360);
        SpriteGreenSlow.transform.rotation = Quaternion.Euler(0, 0, VoidGreenSlow.transform.rotation.z - 360);
        SpriteGreenClean.transform.rotation = Quaternion.Euler(0, 0, VoidGreenClean.transform.rotation.z - 360);
        SpriteGreen2.transform.rotation = Quaternion.Euler(0, 0, VoidGreen2.transform.rotation.z - 360);
        SpriteGreen3.transform.rotation = Quaternion.Euler(0, 0, VoidGreen3.transform.rotation.z - 360);
        SpriteGreen5.transform.rotation = Quaternion.Euler(0, 0, VoidGreen5.transform.rotation.z - 360);
        SpriteGreen10.transform.rotation = Quaternion.Euler(0, 0, VoidGreen10.transform.rotation.z - 360);
        SpriteGreen15.transform.rotation = Quaternion.Euler(0, 0, VoidGreen15.transform.rotation.z - 360);
        SpriteYellow.transform.rotation = Quaternion.Euler(0, 0, VoidYellow.transform.rotation.z - 360);
        SpriteYellow10.transform.rotation = Quaternion.Euler(0, 0, VoidYellow10.transform.rotation.z - 360);
        SpriteRed.transform.rotation = Quaternion.Euler(0, 0, VoidRed.transform.rotation.z - 360);
        SpriteRedBomb.transform.rotation = Quaternion.Euler(0, 0, VoidRedBomb.transform.rotation.z - 360);
        SpriteRedSlow.transform.rotation = Quaternion.Euler(0, 0, VoidRedSlow.transform.rotation.z - 360);
        SpriteRedFast.transform.rotation = Quaternion.Euler(0, 0, VoidRedFast.transform.rotation.z - 360);
        SpriteRedSwap.transform.rotation = Quaternion.Euler(0, 0, VoidRedSwap.transform.rotation.z - 360);

        for (int i = 0; i < NumberOfObject; i++)
        {
            RunAway[i] = false;
            Activated[i] = false;
        }
    }
    void Update()
    {
        Triger TT = GetComponent<Triger>();
        if (Pausekey == false)
        {
            if (TutorOn == false)
            {
                if (Input.GetKeyDown("t") == true) { TutorOn = true; SwitchTutor = 0; }
                Timer += Time.deltaTime;
                if (Score < 0 && GameOver == false)
                {
                    PauseScr.SoundRedEvery.Stop();
                    PauseScr.SoundGO.Play();
                    GameOver = true;
                    ReasonOfDeath = false;
                }
                ContEffectAll();
                StopEffectAll();
                if (Score1 > Score) Score1 = Score;
                if (Score1 < Score)
                {
                    Score1 = Score;
                    RotationLine = 1;
                    Line.transform.localScale = new Vector3(RotationLine, 1, 1);
                    if (MoveSpeed < 20) MoveSpeed += 0.045f;
                    RotSpeed += 0.7f;
                    if (StepTimeToGo > 1.5) StepTimeToGo -= 0.05f;
                    if (RotLineSpeed < 0.15f) RotLineSpeed += 0.003f;
                }
                else
                {
                    RotationLine -= RotLineSpeed * Time.deltaTime;
                    Line.transform.localScale = new Vector3(RotationLine, 1, 1);
                }
                if (RotationLine < 0.001)
                {
                    PauseScr.SoundGO.Play();
                    GameOver = true;
                    ReasonOfDeath = true;
                }
                RotateTriangle();
                M_coints();
                M_Score();
                T_score();
                if (Timer > TimeToGo)
                {
                    TimeToFly();
                }
                MoveALL();
                PlayerPrefs.SetInt("Score", Score);
                PlayerPrefs.SetInt("TempScore", TempScore);
                PlayerPrefs.SetInt("MaxScore", MaxScore);
                PlayerPrefs.SetInt("Coins", Coins);
                PlayerPrefs.SetInt("MaxCoins", MaxCoins);
                PlayerPrefs.Save();
            }
        }
    }
    public GUIStyle TutorText = new GUIStyle(GUI.skin.button);
    void OnGUI()
    {
        if (TutorOn == true)
        {
            TutorText.fontSize = (int)Screen.height / 15;
            TutorText.alignment = TextAnchor.UpperCenter;
            if (SwitchTutor == 0)
            {
                offset = Screen.width;
                Start();
                OutLine.SetActive(false);
                Line.SetActive(false);
                PauseS.SetActive(false);
                Triangle.transform.localScale = new Vector3(0, 0, 1);
                Triangle.transform.rotation = Quaternion.Euler(0, 0, -120 * 1.7f);
                SwitchTutor = 1;
            }
            if (SwitchTutor == 1)
            {
                if (Triangle.transform.localScale.x < 1.7)
                {
                    Triangle.transform.localScale = new Vector3(Triangle.transform.localScale.x + 2f * Time.deltaTime, Triangle.transform.localScale.y + 2f * Time.deltaTime, 1);
                    Triangle.transform.rotation = Quaternion.Euler(0, 0, Triangle.transform.rotation.eulerAngles.z + 120 * 2f * Time.deltaTime);
                }
                else
                {
                    SwitchTutor = 2;
                    Triangle.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            if (SwitchTutor == 2)
            {
                if (Triangle.transform.localScale.x > 1.4)
                {
                    Triangle.transform.localScale = new Vector3(Triangle.transform.localScale.x - 0.8f * Time.deltaTime, Triangle.transform.localScale.y - Time.deltaTime, 1);
                }
                else SwitchTutor = 3;
            }
            if (SwitchTutor == 3)
            {
                TutorText.normal.textColor = Color.white;
                TutorText.fontSize = (int)Screen.height / 15;
                GUI.Label(new Rect(offset, Screen.height / 18, Screen.width, Screen.height), "WELCOME TO TRIANGLE", TutorText);
                TutorText.fontSize = (int)Screen.height / 10;
                GUI.Label(new Rect(offset, Screen.height / 5, Screen.width, Screen.height), "TUTORIAL", TutorText);
                if (offset > 0) offset -= 0.8f * Screen.width * Time.deltaTime;
                else
                {
                    SwitchTutor = 4;
                    offset = Screen.height;
                }
            }
            if (SwitchTutor == 4)
            {
                TutorText.fontSize = (int)Screen.height / 15;
                GUI.Label(new Rect(0, Screen.height / 18, Screen.width, Screen.height), "WELCOME TO TRIANGLE", TutorText);
                TutorText.fontSize = (int)Screen.height / 10;
                GUI.Label(new Rect(0, Screen.height / 5, Screen.width, Screen.height), "TUTORIAL", TutorText);
                if (offset > 3 * Screen.height / 4)
                {
                    offset -= 0.5f * Screen.height * Time.deltaTime;
                    GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 20, offset, Screen.width / 10, Screen.width / 10), ButtomNext);
                }
                else
                {
                    if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 3 && Input.mousePosition.x < 2 * Screen.width / 3 && Input.mousePosition.y < Screen.height / 4)
                    {
                        GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 20, 3 * Screen.height / 4, Screen.width / 10, Screen.width / 10), ButtomNextDown);
                    }
                    else
                    {
                        GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 20, 3 * Screen.height / 4, Screen.width / 10, Screen.width / 10), ButtomNext);
                    }
                    if (Input.GetMouseButtonUp(0) && Input.mousePosition.x > Screen.width / 3 && Input.mousePosition.x < 2 * Screen.width / 3 && Input.mousePosition.y < Screen.height / 4)
                    {
                        SwitchTutor = 5;
                        offset = 0;
                    }
                }
            }
            if (SwitchTutor == 5)
            {
                if (offset < Screen.width)
                {
                    offset += Screen.width * Time.deltaTime;
                    GUI.Label(new Rect(0 - offset, Screen.height / 18, Screen.width, Screen.height), "WELCOME TO TRIANGLE", TutorText);
                    GUI.Label(new Rect(0 - offset, Screen.height / 4, Screen.width, Screen.height), "TUTORIAL", TutorText);
                    GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 20, 3 * Screen.height / 4 + offset, Screen.width / 10, Screen.width / 10), ButtomNext);
                    Triangle.transform.rotation = Quaternion.Euler(0, 0, 120 * offset / Screen.width);
                }
                else
                {
                    SwitchTutor = 6;
                    Triangle.transform.rotation = Quaternion.Euler(0, 0, 120);
                    offset = 0;
                } 
            }
            if (SwitchTutor == 6)
            {
                if (offset <= 0.5f)
                {
                    offset += Time.deltaTime;
                    TutorText.fontSize = (int)Screen.height / 8;
                    TutorText.normal.textColor = Color.white;
                    GUI.Label(new Rect(0, Screen.height * (-19f / 50f + 4f / 5f * offset), Screen.width, Screen.height), "sides", TutorText);
                    TutorText.fontSize = (int)Screen.height / 16;
                    TutorText.normal.textColor = Color.yellow;
                    GUI.Label(new Rect(0, Screen.height * (-1f / 5f + 4f / 5f * offset), Screen.width, Screen.height), "yellow side", TutorText);
                    GUI.Label(new Rect(0, Screen.height * (-1f / 5f + 4f / 5f * offset) + TutorText.fontSize, Screen.width, Screen.height), "collects coins", TutorText);
                    TutorText.normal.textColor = Color.green;
                    GUI.Label(new Rect(Screen.width * (-1f / 4f + 1f / 2f * offset), Screen.height * (1f - 6f / 7f * offset), Screen.width / 2, Screen.height / 2), "green side", TutorText);
                    GUI.Label(new Rect(Screen.width * (-1f / 4f + 1f / 2f * offset), Screen.height * (1f - 6f / 7f * offset) + TutorText.fontSize, Screen.width / 2, Screen.height / 2), "collects", TutorText);
                    GUI.Label(new Rect(Screen.width * (-1f / 4f + 1f / 2f * offset), Screen.height * (1f - 6f / 7f * offset) + 2 * TutorText.fontSize, Screen.width / 2, Screen.height / 2), "green figures", TutorText);
                    TutorText.normal.textColor = Color.red;
                    GUI.Label(new Rect(Screen.width * (3f / 4f - 1f / 2f * offset), Screen.height * (1f - 6f / 7f * offset), Screen.width / 2, Screen.height / 2), "red side", TutorText);
                    GUI.Label(new Rect(Screen.width * (3f / 4f - 1f / 2f * offset), Screen.height * (1f - 6f / 7f * offset) + TutorText.fontSize, Screen.width / 2, Screen.height / 2), "deflect all", TutorText);
                    GUI.Label(new Rect(Screen.width * (3f / 4f - 1f / 2f * offset), Screen.height * (1f - 6f / 7f * offset) + 2 * TutorText.fontSize, Screen.width / 2, Screen.height / 2), "the figures", TutorText);
                }
                else
                {
                    SwitchTutor = 7;
                }
                
            }
            if (SwitchTutor == 7)
            {
                TutorText.fontSize = (int)Screen.height / 8;
                TutorText.normal.textColor = Color.white;
                GUI.Label(new Rect(0, Screen.height / 50, Screen.width, Screen.height), "sides", TutorText);
                TutorText.fontSize = (int)Screen.height / 16;
                TutorText.normal.textColor = Color.yellow;
                GUI.Label(new Rect(0, Screen.height / 5, Screen.width, Screen.height), "yellow side", TutorText);
                GUI.Label(new Rect(0, Screen.height / 5 + TutorText.fontSize, Screen.width, Screen.height), "collects coins", TutorText);
                TutorText.normal.textColor = Color.green;
                GUI.Label(new Rect(0, Screen.height * 4 / 7, Screen.width / 2, Screen.height / 2), "green side", TutorText);
                GUI.Label(new Rect(0, Screen.height * 4 / 7 + TutorText.fontSize, Screen.width / 2, Screen.height / 2), "collects", TutorText);
                GUI.Label(new Rect(0, Screen.height * 4 / 7 + 2 * TutorText.fontSize, Screen.width / 2, Screen.height / 2), "green figures", TutorText);
                TutorText.normal.textColor = Color.red;
                GUI.Label(new Rect(Screen.width / 2, Screen.height * 4 / 7, Screen.width / 2, Screen.height / 2), "red side", TutorText);
                GUI.Label(new Rect(Screen.width / 2, Screen.height * 4 / 7 + TutorText.fontSize, Screen.width / 2, Screen.height / 2), "deflect all", TutorText);
                GUI.Label(new Rect(Screen.width / 2, Screen.height * 4 / 7 + 2 * TutorText.fontSize, Screen.width / 2, Screen.height / 2), "the figures", TutorText);
                if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 3 && Input.mousePosition.x < 2 * Screen.width / 3 && Input.mousePosition.y < Screen.height / 4)
                {
                    GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 20, 8.8f * Screen.height / 10 - Screen.width / 20, Screen.width / 10, Screen.width / 10), ButtomNextDown);
                }
                else
                {
                    GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 20, 8.8f * Screen.height / 10 - Screen.width / 20, Screen.width / 10, Screen.width / 10), ButtomNext);
                }
                if (Input.GetMouseButtonUp(0) && Input.mousePosition.x > Screen.width / 3 && Input.mousePosition.x < 2 * Screen.width / 3 && Input.mousePosition.y < Screen.height / 4)
                {
                    SwitchTutor = 8;
                    offset = 0;
                    RotSpeed = 30;
                    TutorText.normal.textColor = Color.black;
                }
            }
            if (SwitchTutor == 8)
            {
                TutorText.fontSize = (int)Screen.height / 20;
                RotateTriangle();
                if (offset < 0.5f)
                {
                    offset += Time.deltaTime;
                    GUI.DrawTexture(new Rect(Screen.width * (0.5f - offset), 0, 2 * offset * Screen.width, Screen.height / 100), LineForController);
                    GUI.DrawTexture(new Rect(Screen.width * (0.5f - offset), Screen.height - Screen.height / 100, 2 * offset * Screen.width, Screen.height / 100), LineForController);
                    GUI.DrawTexture(new Rect(0, Screen.height * (0.5f - offset), Screen.height / 100, 2 * offset * Screen.height), LineForController);
                    GUI.DrawTexture(new Rect(Screen.width - Screen.height / 100, Screen.height * (0.5f - offset), Screen.height / 100, 2 * offset * Screen.height), LineForController);
                    GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.height / 100 / 2, Screen.height * (0.5f - offset), Screen.height / 100, 2 * offset * Screen.height), LineForController);
                }
                else
                {
                    GUI.DrawTexture(new Rect(Screen.width / 4 - 3 * Screen.height / 10, 3 * Screen.height / 10, 3 * Screen.height / 5, 3 * Screen.height / 5), LeftROTATE);
                    GUI.DrawTexture(new Rect(3 * Screen.width / 4 - 3 * Screen.height / 10, 3 * Screen.height / 10, 3 * Screen.height / 5, 3 * Screen.height / 5), RightROTATE);
                    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height / 100), LineForController);
                    GUI.DrawTexture(new Rect(0, Screen.height - Screen.height / 100, Screen.width, Screen.height / 100), LineForController);
                    GUI.DrawTexture(new Rect(0, 0, Screen.height / 100, Screen.height), LineForController);
                    GUI.DrawTexture(new Rect(Screen.width - Screen.height / 100, 0, Screen.height / 100, Screen.height), LineForController);
                    GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.height / 100 / 2, 0, Screen.height / 100, Screen.height), LineForController);
                    GUI.Label(new Rect(0, 3 * Screen.height / 40, Screen.width / 2, Screen.height / 8), "counter-clockwise", TutorText);
                    GUI.Label(new Rect(0, 7 * Screen.height / 40, Screen.width / 2, Screen.height / 8), "rotation", TutorText);
                    GUI.Label(new Rect(Screen.width / 2, 3 * Screen.height / 40, Screen.width / 2, Screen.height / 8), "clockwise", TutorText);
                    GUI.Label(new Rect(Screen.width / 2, 7 * Screen.height / 40, Screen.width / 2, Screen.height / 8), "rotation", TutorText);

                    if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 3 && Input.mousePosition.x < 2 * Screen.width / 3 && Input.mousePosition.y < Screen.height / 4)
                    {
                        GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 20, 3 * Screen.height / 4, Screen.width / 10, Screen.width / 10), ButtomNextDown);
                    }
                    else
                    {
                        GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 20, 3 * Screen.height / 4, Screen.width / 10, Screen.width / 10), ButtomNext);
                    }
                    if (Input.GetMouseButtonUp(0) && Input.mousePosition.x > Screen.width / 3 && Input.mousePosition.x < 2 * Screen.width / 3 && Input.mousePosition.y < Screen.height / 4)
                    {
                        SwitchTutor = 9;
                        offset = 0;
                        RotSpeed = 90;
                    }
                }
            }
            if (SwitchTutor == 9)
            {
                TutorText.fontSize = (int)Screen.height / 15;
                TutorText.normal.textColor = Color.green;
                ChangedRotation = 0.4f;
                GUI.Label(new Rect(0, Screen.height / 4, Screen.width, Screen.height), "Catch GREEN", TutorText);
                RotateTriangle();
                Activated[0] = true;
                PositionBonus = Green.transform.localPosition.y;
                VoidGreen.transform.rotation = Quaternion.Euler(0, 0, 90);
                SpriteGreen.transform.rotation = Quaternion.Euler(0, 0, VoidGreen.transform.rotation.z - 360);
                RotationVoidBonus = VoidGreen.transform.rotation.eulerAngles.z;
                if (RotationVoidBonus < 0) RotationVoidBonus += 360f;
                RotationTriangle = Triangle.transform.rotation.eulerAngles.z;
                Dif = RotationVoidBonus - RotationTriangle;
                SideOfTriangle = 0;
                if (Dif < -60) Dif += 360f;
                while (Dif > 60)
                {
                    Dif -= 120f;
                    SideOfTriangle += 1;
                    if (SideOfTriangle == 3) SideOfTriangle = 0;
                }
                if (PositionBonus < 15 && SideOfTriangle != 0)
                {
                    Activated[0] = false;
                    GUI.Label(new Rect(0, Screen.height / 3, Screen.width, Screen.height), "Catch it with a green side!", TutorText);
                }
                if (Activated[0] == true)
                {
                    MoveSpeed = 5f;
                    MoveObj(Triangle, VoidGreen, Green, SpriteGreen, 0);
                    MoveSpeed = 15f;
                }
                if (Score == 1)
                {
                    Score = 0;
                    Coins = 0;
                    SwitchTutor = 10;
                    TutorText.normal.textColor = Color.yellow;
                } 
            }
            if (SwitchTutor == 10)
            {
                GUI.Label(new Rect(0, Screen.height / 4, Screen.width, Screen.height), "Catch YELLOW", TutorText);
                RotateTriangle();
                Activated[8] = true;
                PositionBonus = Yellow.transform.localPosition.y;
                VoidYellow.transform.rotation = Quaternion.Euler(0, 0, 90);
                SpriteYellow.transform.rotation = Quaternion.Euler(0, 0, VoidYellow.transform.rotation.z - 360);
                RotationVoidBonus = VoidYellow.transform.rotation.eulerAngles.z;
                if (RotationVoidBonus < 0) RotationVoidBonus += 360f;
                RotationTriangle = Triangle.transform.rotation.eulerAngles.z;
                Dif = RotationVoidBonus - RotationTriangle;
                SideOfTriangle = 0;
                if (Dif < -60) Dif += 360f;
                while (Dif > 60)
                {
                    Dif -= 120f;
                    SideOfTriangle += 1;
                    if (SideOfTriangle == 3) SideOfTriangle = 0;
                }
                if (PositionBonus < 15 && SideOfTriangle != 2)
                {
                    Activated[8] = false;
                    GUI.Label(new Rect(0, Screen.height / 3, Screen.width, Screen.height), "Catch it with a yellow side!", TutorText);
                }
                if (Activated[8] == true)
                {
                    MoveSpeed = 5f;
                    MoveObj(Triangle, VoidYellow, Yellow, SpriteYellow, 8);
                    MoveSpeed = 15f;
                }
                if (Coins == 1)
                {
                    SwitchTutor = 11;
                    offset = 0.7f;
                    TutorText.normal.textColor = Color.red;
                    Score = 0;
                    VoidRed.transform.rotation = Quaternion.Euler(0, 0, 90);
                    SpriteRed.transform.rotation = Quaternion.Euler(0, 0, VoidRed.transform.rotation.z - 360);
                }
            }
            if (SwitchTutor == 11)
            {
                GUI.Label(new Rect(0, Screen.height / 4, Screen.width, Screen.height), "Deflect RED", TutorText);
                RotateTriangle();
                Activated[10] = true;
                PositionBonus = Red.transform.localPosition.y;
                RotationVoidBonus = VoidRed.transform.rotation.eulerAngles.z;
                if (RotationVoidBonus < 0) RotationVoidBonus += 360f;
                RotationTriangle = Triangle.transform.rotation.eulerAngles.z;
                Dif = RotationVoidBonus - RotationTriangle;
                SideOfTriangle = 0;
                if (Dif < -60) Dif += 360f;
                while (Dif > 60)
                {
                    Dif -= 120f;
                    SideOfTriangle += 1;
                    if (SideOfTriangle == 3) SideOfTriangle = 0;
                }
                if (PositionBonus < 15 && SideOfTriangle != 1)
                {
                    Activated[10] = false;
                    GUI.Label(new Rect(0, Screen.height / 3, Screen.width, Screen.height), "Deflect it with a red side!", TutorText);
                }
                if (Activated[10] == true)
                {
                    MoveSpeed = 5f;
                    MoveObj(Triangle, VoidRed, Red, SpriteRed, 10);
                }
                if (RunAway[10] == true)
                {
                    ChangedRotation = 1f;
                    offset -= Time.deltaTime;                    
                }
                if (offset <= 0)
                {
                    offset = 0;
                    MoveSpeed = 15f;
                    SwitchTutor = 12;
                    Start();
                    Triangle.transform.rotation = Quaternion.Euler(0, 0, 120);
                    VoidRed.transform.position = new Vector3(0, 0, 0);
                    VoidRed.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                    SpriteRed.transform.rotation = Quaternion.Euler(0, 0, VoidRed.transform.rotation.z - 360);
                }
            }
            if (SwitchTutor == 12)
            {
                GUI.DrawTexture(new Rect(Screen.width / 18, 3 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureGreen);
                GUI.DrawTexture(new Rect(Screen.width / 18, 5 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureGreen2);
                GUI.DrawTexture(new Rect(Screen.width / 18, 7 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureGreen3);
                GUI.DrawTexture(new Rect(Screen.width / 18, 9 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureGreen5);
                GUI.DrawTexture(new Rect(Screen.width / 18, 11 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureGreen10);
                GUI.DrawTexture(new Rect(Screen.width / 18, 13 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureGreen15);
                GUI.DrawTexture(new Rect(Screen.width / 18, 15 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureGreenSlow);
                GUI.DrawTexture(new Rect(Screen.width / 18, 17 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureGreenClean);
                TutorText.alignment = TextAnchor.UpperCenter;
                TutorText.fontSize = (int)Screen.height / 20;
                TutorText.normal.textColor = Color.green;
                GUI.Label(new Rect(0, Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 3, Screen.height / 10), "green", TutorText);
                TutorText.alignment = TextAnchor.UpperLeft;
                TutorText.fontSize = (int)Screen.height / 32;
                TutorText.normal.textColor = Color.green;
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 3.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "+1 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 5.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "+2 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 7.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "+3 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 9.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "+5 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 11.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "+10 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 13.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "+15 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 15.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "time slowdown", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 17.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "without bad", TutorText);
                if (offset < 0.75f) offset += Time.deltaTime;
                else
                {
                    SwitchTutor = 13;
                    offset = 0;
                }
            }
            if (SwitchTutor == 13)
            {
                GUI.DrawTexture(new Rect(Screen.width / 18, 3 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen);
                GUI.DrawTexture(new Rect(Screen.width / 18, 5 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen2);
                GUI.DrawTexture(new Rect(Screen.width / 18, 7 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen3);
                GUI.DrawTexture(new Rect(Screen.width / 18, 9 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen5);
                GUI.DrawTexture(new Rect(Screen.width / 18, 11 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen10);
                GUI.DrawTexture(new Rect(Screen.width / 18, 13 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen15);
                GUI.DrawTexture(new Rect(Screen.width / 18, 15 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreenSlow);
                GUI.DrawTexture(new Rect(Screen.width / 18, 17 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreenClean);
                TutorText.alignment = TextAnchor.UpperCenter;
                TutorText.fontSize = (int)Screen.height / 20;
                TutorText.normal.textColor = Color.green;
                GUI.Label(new Rect(0 * Screen.width / 3, Screen.height / 20, Screen.width / 3, Screen.height / 10), "green", TutorText);
                TutorText.alignment = TextAnchor.UpperLeft;
                TutorText.fontSize = (int)Screen.height / 32;
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 3.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+1 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 5.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+2 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 7.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+3 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 9.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+5 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 11.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+10 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 13.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+15 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 15.3f * Screen.height / 20, Screen.width / 6, Screen.height), "time slowdown", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 17.3f * Screen.height / 20, Screen.width / 6, Screen.height), "without bad", TutorText);

                GUI.DrawTexture(new Rect(7 * Screen.width / 18, 3 * Screen.height / 20 - Screen.height * (0.5f - offset * 2f), Screen.height / 15, Screen.height / 15), TextureYellow);
                GUI.DrawTexture(new Rect(7 * Screen.width / 18, 5 * Screen.height / 20 - Screen.height * (0.5f - offset * 2f), Screen.height / 15, Screen.height / 15), TextureYellow10);
                TutorText.alignment = TextAnchor.UpperCenter;
                TutorText.fontSize = (int)Screen.height / 20;
                TutorText.normal.textColor = Color.yellow;
                GUI.Label(new Rect(1 * Screen.width / 3, Screen.height / 20 - Screen.height * (0.5f - offset * 2f), Screen.width / 3, Screen.height / 10), "yellow", TutorText);
                TutorText.alignment = TextAnchor.UpperLeft;
                TutorText.fontSize = (int)Screen.height / 32;
                GUI.Label(new Rect(7 * Screen.width / 18 + Screen.height / 10, 3.3f * Screen.height / 20 - Screen.height * (0.5f - offset * 2f), Screen.width / 6, Screen.height), "+1 Coin", TutorText);
                GUI.Label(new Rect(7 * Screen.width / 18 + Screen.height / 10, 5.3f * Screen.height / 20 - Screen.height * (0.5f - offset * 2f), Screen.width / 6, Screen.height), "+10 Coin", TutorText);
                if (offset < 0.25f) offset += Time.deltaTime;
                else
                {
                    SwitchTutor = 14;
                    offset = 0;
                }
            }
            if (SwitchTutor == 14)
            {
                GUI.DrawTexture(new Rect(Screen.width / 18, 3 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen);
                GUI.DrawTexture(new Rect(Screen.width / 18, 5 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen2);
                GUI.DrawTexture(new Rect(Screen.width / 18, 7 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen3);
                GUI.DrawTexture(new Rect(Screen.width / 18, 9 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen5);
                GUI.DrawTexture(new Rect(Screen.width / 18, 11 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen10);
                GUI.DrawTexture(new Rect(Screen.width / 18, 13 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen15);
                GUI.DrawTexture(new Rect(Screen.width / 18, 15 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreenSlow);
                GUI.DrawTexture(new Rect(Screen.width / 18, 17 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreenClean);
                GUI.DrawTexture(new Rect(7 * Screen.width / 18, 3 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureYellow);
                GUI.DrawTexture(new Rect(7 * Screen.width / 18, 5 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureYellow10);
                TutorText.alignment = TextAnchor.UpperCenter;
                TutorText.fontSize = (int)Screen.height / 20;
                TutorText.normal.textColor = Color.green;
                GUI.Label(new Rect(0 * Screen.width / 3, Screen.height / 20, Screen.width / 3, Screen.height / 10), "green", TutorText);
                TutorText.normal.textColor = Color.yellow;
                GUI.Label(new Rect(1 * Screen.width / 3, Screen.height / 20, Screen.width / 3, Screen.height / 10), "yellow", TutorText);
                TutorText.alignment = TextAnchor.UpperLeft;
                TutorText.fontSize = (int)Screen.height / 32;
                TutorText.normal.textColor = Color.green;
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 3.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+1 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 5.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+2 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 7.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+3 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 9.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+5 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 11.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+10 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 13.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+15 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 15.3f * Screen.height / 20, Screen.width / 6, Screen.height), "time slowdown", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 17.3f * Screen.height / 20, Screen.width / 6, Screen.height), "without bad", TutorText);
                TutorText.normal.textColor = Color.yellow;
                GUI.Label(new Rect(7 * Screen.width / 18 + Screen.height / 10, 3.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+1 Coin", TutorText);
                GUI.Label(new Rect(7 * Screen.width / 18 + Screen.height / 10, 5.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+10 Coin", TutorText);

                GUI.DrawTexture(new Rect(12 * Screen.width / 18, 3 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureRed);
                GUI.DrawTexture(new Rect(12 * Screen.width / 18, 5 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureRedBomb);
                GUI.DrawTexture(new Rect(12 * Screen.width / 18, 7 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureRedSlow);
                GUI.DrawTexture(new Rect(12 * Screen.width / 18, 9 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureRedFast);
                GUI.DrawTexture(new Rect(12 * Screen.width / 18, 11 * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.height / 15, Screen.height / 15), TextureRedSwap);
                TutorText.normal.textColor = Color.red;
                TutorText.alignment = TextAnchor.UpperCenter;
                TutorText.fontSize = (int)Screen.height / 20;
                GUI.Label(new Rect(2 * Screen.width / 3, Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 3, Screen.height / 10), "red", TutorText);
                TutorText.alignment = TextAnchor.UpperLeft;
                TutorText.fontSize = (int)Screen.height / 32;
                GUI.Label(new Rect(12 * Screen.width / 18 + Screen.height / 10, 3.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "-1 Score", TutorText);
                GUI.Label(new Rect(12 * Screen.width / 18 + Screen.height / 10, 5.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "- 10 score", TutorText);
                GUI.Label(new Rect(12 * Screen.width / 18 + Screen.height / 10, 7.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "slow rotation", TutorText);
                GUI.Label(new Rect(12 * Screen.width / 18 + Screen.height / 10, 9.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "fast rotation", TutorText);
                GUI.Label(new Rect(12 * Screen.width / 18 + Screen.height / 10, 11.3f * Screen.height / 20 - Screen.height * (1 - offset * 4f / 3f), Screen.width / 6, Screen.height), "reverse controll", TutorText); if (offset < 0.75f) offset += Time.deltaTime;
                else
                {
                    SwitchTutor = 15;
                    offset = 0;
                }
            }
            if (SwitchTutor == 15)
            {
                GUI.DrawTexture(new Rect(Screen.width / 18, 3 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen);
                GUI.DrawTexture(new Rect(Screen.width / 18, 5 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen2);
                GUI.DrawTexture(new Rect(Screen.width / 18, 7 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen3);
                GUI.DrawTexture(new Rect(Screen.width / 18, 9 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen5);
                GUI.DrawTexture(new Rect(Screen.width / 18, 11 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen10);
                GUI.DrawTexture(new Rect(Screen.width / 18, 13 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreen15);
                GUI.DrawTexture(new Rect(Screen.width / 18, 15 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreenSlow);
                GUI.DrawTexture(new Rect(Screen.width / 18, 17 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureGreenClean);

                GUI.DrawTexture(new Rect(7 * Screen.width / 18, 3 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureYellow);
                GUI.DrawTexture(new Rect(7 * Screen.width / 18, 5 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureYellow10);

                GUI.DrawTexture(new Rect(12 * Screen.width / 18, 3 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureRed);
                GUI.DrawTexture(new Rect(12 * Screen.width / 18, 5 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureRedBomb);
                GUI.DrawTexture(new Rect(12 * Screen.width / 18, 7 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureRedSlow);
                GUI.DrawTexture(new Rect(12 * Screen.width / 18, 9 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureRedFast);
                GUI.DrawTexture(new Rect(12 * Screen.width / 18, 11 * Screen.height / 20, Screen.height / 15, Screen.height / 15), TextureRedSwap);


                TutorText.alignment = TextAnchor.UpperCenter;
                TutorText.fontSize = (int)Screen.height / 20;
                TutorText.normal.textColor = Color.green;
                GUI.Label(new Rect(0 * Screen.width / 3, Screen.height / 20, Screen.width / 3, Screen.height / 10), "green", TutorText);
                TutorText.normal.textColor = Color.yellow;
                GUI.Label(new Rect(1 * Screen.width / 3, Screen.height / 20, Screen.width / 3, Screen.height / 10), "yellow", TutorText);
                TutorText.normal.textColor = Color.red;
                GUI.Label(new Rect(2 * Screen.width / 3, Screen.height / 20, Screen.width / 3, Screen.height / 10), "red", TutorText);

                TutorText.alignment = TextAnchor.UpperLeft;
                TutorText.fontSize = (int)Screen.height / 32;
                TutorText.normal.textColor = Color.green;
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 3.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+1 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 5.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+2 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 7.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+3 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 9.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+5 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 11.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+10 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 13.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+15 Score", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 15.3f * Screen.height / 20, Screen.width / 6, Screen.height), "time slowdown", TutorText);
                GUI.Label(new Rect(Screen.width / 18 + Screen.height / 10, 17.3f * Screen.height / 20, Screen.width / 6, Screen.height), "without bad", TutorText);

                TutorText.normal.textColor = Color.yellow;
                GUI.Label(new Rect(7 * Screen.width / 18 + Screen.height / 10, 3.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+1 Coin", TutorText);
                GUI.Label(new Rect(7 * Screen.width / 18 + Screen.height / 10, 5.3f * Screen.height / 20, Screen.width / 6, Screen.height), "+10 Coin", TutorText);

                TutorText.normal.textColor = Color.red;
                GUI.Label(new Rect(12 * Screen.width / 18 + Screen.height / 10, 3.3f * Screen.height / 20, Screen.width / 6, Screen.height), "-1 Score", TutorText);
                GUI.Label(new Rect(12 * Screen.width / 18 + Screen.height / 10, 5.3f * Screen.height / 20, Screen.width / 6, Screen.height), "- 10 score", TutorText);
                GUI.Label(new Rect(12 * Screen.width / 18 + Screen.height / 10, 7.3f * Screen.height / 20, Screen.width / 6, Screen.height), "slow rotation", TutorText);
                GUI.Label(new Rect(12 * Screen.width / 18 + Screen.height / 10, 9.3f * Screen.height / 20, Screen.width / 6, Screen.height), "fast rotation", TutorText);
                GUI.Label(new Rect(12 * Screen.width / 18 + Screen.height / 10, 11.3f * Screen.height / 20, Screen.width / 6, Screen.height), "reverse controll", TutorText);

                TutorText.normal.textColor = Color.black;
                GUI.Label(new Rect(9.3f * Screen.width / 20, 16f * Screen.height / 20, Screen.width / 6, Screen.height), "Timer", TutorText);

                if (Input.GetMouseButton(0) && Input.mousePosition.x > 4 * Screen.width / 5 - Screen.width / 10 && Input.mousePosition.x < 4 * Screen.width / 5 + Screen.width / 10 && Input.mousePosition.y < Screen.height / 4)
                {
                    GUI.DrawTexture(new Rect(5 * Screen.width / 6 - Screen.width / 20, 3 * Screen.height / 4, Screen.width / 10, Screen.width / 10), ButtomNextDown);
                }
                else
                {
                    GUI.DrawTexture(new Rect(5 * Screen.width / 6 - Screen.width / 20, 3 * Screen.height / 4, Screen.width / 10, Screen.width / 10), ButtomNext);
                }
                if (Input.GetMouseButtonUp(0) && Input.mousePosition.x > 5 * Screen.width / 6 - Screen.width / 10 && Input.mousePosition.x < 5 * Screen.width / 6 + Screen.width / 10 && Input.mousePosition.y < Screen.height / 4)
                {
                    SwitchTutor = 99;
                }
            }
            if (SwitchTutor == 99)
            {
                TutorOn = false;
                SwitchTutor = 0;
                Start();
            }
        }

        if (TutorOn == false)
        {            
            if (Timer < 5)
            {
                GUI.DrawTexture(new Rect(Screen.width * 1 / 5 - Screen.height / 12, Screen.height * 3 / 4, Screen.height / 6, Screen.height / 6), LeftROTATE);
                GUI.DrawTexture(new Rect(Screen.width * 4 / 5 - Screen.height / 12, Screen.height * 3 / 4, Screen.height / 6, Screen.height / 6), RightROTATE);
            }
            if (Timer > 5 && Timer < 6)
            {
                GUI.DrawTexture(new Rect(Screen.width * (1f / 5f - 1f / 2f * (Timer - 5)) - Screen.height / 12, Screen.height * 3 / 4, Screen.height / 6, Screen.height / 6), LeftROTATE);
                GUI.DrawTexture(new Rect(Screen.width * (4f / 5f + 1f / 2f * (Timer - 5)) - Screen.height / 12, Screen.height * 3 / 4, Screen.height / 6, Screen.height / 6), RightROTATE);
            }
            GUIStyle styleTime1 = new GUIStyle();
            styleTime1.alignment = TextAnchor.MiddleCenter;            
            if (Score < 100) styleTime1.fontSize = (int)Screen.height / 15;
            if (Score >= 100 && Score < 1000) styleTime1.fontSize = (int)Screen.height / 18;
            if (Score >= 1000 && Score < 10000) styleTime1.fontSize = (int)Screen.height / 20;
            if (Score == 0) GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "0", styleTime1);
            else GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "" + Score, styleTime1);
            GUIStyle styleTime = new GUIStyle();
            styleTime.fontSize = (int)Screen.height / 15;
            styleTime.alignment = TextAnchor.MiddleLeft;
            if (Coins == 0) GUI.Label(new Rect((Screen.width / 25), (Screen.height / 8), 0, 0), "Coins 0", styleTime);
            else GUI.Label(new Rect((Screen.width / 25), (Screen.height / 8), 0, 0), "Coins " + Coins.ToString("#."), styleTime);
            if (MaxScore == 0) GUI.Label(new Rect((Screen.width / 25), (Screen.height / 20), 0, 0), "Max score 0", styleTime);
            else GUI.Label(new Rect((Screen.width / 25), (Screen.height / 20), 0, 0), "Max score " + MaxScore.ToString("#."), styleTime);
        }
    }
}