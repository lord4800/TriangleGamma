using UnityEngine;
using System.Collections;
public class MainForMineMenuVar2 : MonoBehaviour {
	int Score;                                          //Очки
	int Score1;                                         //Очки 
	short StackToStop = 0;                              //Стаки для выхода из цикла рандома
	short SideOfBonus;                                  //Сторона треугольника куда летит объект
	float RotSpeed = 70f;                               //Скорость вращения треугольника
	float MoveSpeed = 10f;                            //Скорость полёта бонусов
	float Timer;                                        //Счётчик времени    
	float PositionStart = 30f;                          //Начальная позиция
	float RadiusBonus = 0.6f;                           //Радиус картинки объекта
	float RotationVoidBonus;                            //Угол вращения пустого объекта
	float PositionBonus;                                //Расстояния от пустого объекта до картинки объекта
	float RotationTriangle=0;                           //Угол поворота треугольника	
	float TimeToGo = 0;                                 //Время активации цикла рандома
	float StepTimeToGo = 2f;                          //Промежуток времени между активациями
	float Dif;                                          //Разница в угле между пустым объектом и трегольником
	float Random1;                                       //Рандомное число что определит какой объект сделать активным
	float Border;                                       //Расстояние между пустым объектом и его картинкой, на котором должно произойти взаимодействией
	bool Pausekey = false;
	bool[,] Ar = new bool[3, 2];
	
	/*
    зеленый синий желтый
    0       0     0     куда летит. 0=в центр, 1=от центра
    0       0     0     активен ли бонус, 0=нет, 1=да
    */
	
	Vector3 TimeV3;
	
	public GameObject BonusGreen;                       //Объекты
	public GameObject BonusBlue;
	public GameObject BonusYellow;
	public GameObject VoidBonusGreen;
	public GameObject VoidBonusBlue;
	public GameObject VoidBonusYellow;
	public Transform Triangle;
	
	float RotationLine;
	public GameObject Line;
	
	void MoveObj(Transform Triangle, GameObject VoidBonus, GameObject Bonus, int NoB)               //определение функции движения объектов, подсчёта очков
	{
		PositionBonus = Bonus.transform.localPosition.y;                                            //получаем расстояние от объекта до центра координат
		RotationVoidBonus = VoidBonus.transform.rotation.eulerAngles.z;                             //получаем угол поворота траектории движения бонуса
		if (RotationVoidBonus < 0) RotationVoidBonus += 360f;                                       //из-за ебнутости юнити мы делаем угол сто пудово положительным
		RotationTriangle = Triangle.transform.rotation.eulerAngles.z;                               //получаем угол вращения треугольника
		Dif = RotationVoidBonus - RotationTriangle;                                                 //разница углов вращения треугольника и объекта
		SideOfBonus = 0;                                                                            //задаём начальную сторону приземления зелёной        
		if (Dif < -60) Dif += 360f;                                                                 //Делаю эту разницу больше чем -60, плюсуя 360
		while (Dif > 60)                                                                            //пока эта разница больше 60
		{
			Dif -= 120f;                                                                            //минусую из неё 120
			SideOfBonus += 1;                                                                       //переключаюсь на следующую сторону
			if (SideOfBonus == 3) SideOfBonus = 0;                                                  //делаю проверку что бы с 3 переключалось на 0
		}
		Border = Mathf.Abs((1.325f + RadiusBonus) / Mathf.Cos(Dif * 0.0174532925f));       //определяю расстояние от центра координат, на котором должен исчезнуть объект
		
		if (PositionBonus > Border && Ar[NoB, 0] == false)                                             //если бонус дальше чем координата исчезновения и он не улетает от треугольника
		{
			Bonus.transform.Translate(new Vector3(0,-1,0) * MoveSpeed * Time.deltaTime);            //Объект летит к центру
			PositionBonus = Bonus.transform.position.y;                                             //присваиваю новую координату
		}
		else                                                                                        //если бонус достиг координаты исчезновения или улетает
		{
			if (Ar[NoB, 0] == false)                                                                //если бонус не улетает (тобишь он достиг координаты исчезновения)
			{
				switch (SideOfBonus)                                                                //проверка на какую сторону он попал
				{
				case 0:                                                                         //на зелёную
				{               
					if (NoB == 0) Score += 1;                                               //если это зелёный, то +1 к очкам
					if (NoB == 1) Score -= 1;                                               //если это синий, то -1 к очкам
					if (NoB == 2) Score -= 1;                                               //если это жёлтый, то -1 к очкам
					Bonus.transform.localPosition = new Vector3(0, PositionStart, 0);       //присваиваю новую координату объекту
					VoidBonus.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360)); //поворачиваю траекторию на новый угол
					Ar[NoB, 1] = false;                                                     //он становится неактивным
					break;
				}
				case 2:                                                                         //на жёлтую, аналогично
				{
					if (NoB == 0) Score -= 1;
					if (NoB == 1) Score -= 1;
					if (NoB == 2) Score += 1;
					Bonus.transform.localPosition = new Vector3(0, PositionStart, 0);
					VoidBonus.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
					Ar[NoB, 1] = false;
					break;
				}
				case 1:                                                                         //на синюю
				{
					Ar[NoB, 0] = true;                                                      //объект теперь улетает
					TimeV3 = Bonus.transform.position;                                      //временная переменная - ГЛОБАЛЬНАЯ координата объекта
					Bonus.transform.position = new Vector3(0, 0, 0);                   //локальную координату отправлюю в 0,0,0
					VoidBonus.transform.position = TimeV3;                                  //пустой объект перемещаю в координатывременной переменной
					VoidBonus.transform.rotation = Quaternion.Euler(0, 0, VoidBonus.transform.rotation.eulerAngles.z - 2 * Dif);//имитирую изменения гла в результате отражения (кароч как свет от зеркала)
					break;
				}
				}
			}
			else                                                                                    //если бонус всё же улетает
			{
				if (PositionBonus < PositionStart)                                            //если его координата меньше чем координата старта-25 (так надо, в разработке)
				{             
					Bonus.transform.Translate(new Vector3(0, 1, 0) * 5 * MoveSpeed * Time.deltaTime);//бонус улетает с х5 скоростью
					PositionBonus = Bonus.transform.position.y;                                     //присваиваю новую координату
				}
				else                                                                                //если он достиг координаты старта-25
				{
					Ar[NoB, 0] = false;                                                             //он перестаёт улетать
					VoidBonus.transform.position = new Vector3(0, 0, 0);                            //пустой объект обратно в 0,0,0
					VoidBonus.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));    //задаю ему новый рандомный угол
					Ar[NoB, 1] = false;                                                             //он становится неактивным
				}
				
			}
		}
	}
	
	void Start (){//Задаю начальные координаты и начальный поворот от -10 до 10 градусов
		//начальный поворот = угол полета бонуса 
		VoidBonusGreen.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-60, 60));
		VoidBonusBlue.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-60, 60));
		VoidBonusYellow.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-60, 60));
		//63 113 163
		// начальная позиция бонуса
		BonusGreen.transform.localPosition = new Vector3(0, PositionStart, 0);
		BonusBlue.transform.localPosition = new Vector3(0, PositionStart, 0);
		BonusYellow.transform.localPosition = new Vector3(0, PositionStart, 0);
		
		Ar[0, 0] = false;
		Ar[1, 0] = false;
		Ar[2, 0] = false;
		Ar[0, 1] = false;
		Ar[1, 1] = false;
		Ar[2, 1] = false;
		
	}
	
	/*--------------------------------------------------------------------------------------------------------------*/
	/*----------------------------------------------------UPDATE----------------------------------------------------*/
	/*--------------------------------------------------------------------------------------------------------------*/
	
	void Update(){
		if (Pausekey == false){                                                                     //если не пауза
			Timer += Time.deltaTime;                                                                //счётчик времени
			/*
            if (Score1 < Score)
            {
                Score1 = Score;
                RotationLine = 0;
                Line.transform.rotation = Quaternion.Euler(0, RotationLine, 0);
                MoveSpeed += 0.005f;
                RotSpeed += 0.5f;
            }
            else
            {
                RotationLine += 40 * Time.deltaTime;
                Line.transform.rotation = Quaternion.Euler(0, RotationLine, 0);
            }
            */
			//ВРАЩЕНИЕ ТРЕУГОЛЬНИКА
			float Rot = Input.GetAxis("Rotate");
			if (Rot != 0)
			{
				Vector3 rotate = new Vector3(0f, 0f, Rot * 10);
				//метод вращения треугольника, возможно использует инерцию
				Triangle.rotation = Quaternion.Slerp(Triangle.rotation, Triangle.rotation * Quaternion.Euler(rotate), Time.deltaTime * RotSpeed);
			}
			
			//ВРАЩЕНИЕ ТРЕУГОЛЬНИКА END
			
			if (Timer > TimeToGo)
			{
				TimeToGo += StepTimeToGo;
				StackToStop = 0;
				while (StackToStop < 2)
				{
					Random1 = Random.Range(-1, 6);
					if (Random1 <= 2)
					{
						if (Ar[0, 1] == false)
						{
							Ar[0, 1] = true;
							StackToStop = 2;
						}
						else StackToStop++;
					}
					if (Random1 > 2 && Random1 <= 4)
					{
						if (Ar[1, 1] == false)
						{
							Ar[1, 1] = true;
							StackToStop = 2;
						}
						else StackToStop++;
					}
					if (Random1 > 4)
					{
						if (Ar[2, 1] == false)
						{
							Ar[2, 1] = true;
							StackToStop = 2;
						}
						else StackToStop++;
					}
				}
				
			}
			
			
			
			//рандом для процентов вероятности выпадание бонуса 
			
			if (Ar[0, 1] == true) MoveObj(Triangle, VoidBonusGreen, BonusGreen, 0);
			if (Ar[1, 1] == true) MoveObj(Triangle, VoidBonusBlue, BonusBlue, 1);
			if (Ar[2, 1] == true) MoveObj(Triangle, VoidBonusYellow, BonusYellow, 2);
			
		}//проверки паузы
	}//апдейта
        /*-------------------------------------------------------------------------------------------------------------------*/
        /*----------------------------------------------------UPDATE(END)----------------------------------------------------*/
        /*-------------------------------------------------------------------------------------------------------------------*/
    void OnGUI(){
		GUIStyle styleTime = new GUIStyle();
		styleTime.fontSize = 40;
		styleTime.alignment = TextAnchor.MiddleCenter;
		//GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "" + Score, styleTime);
		styleTime.alignment = TextAnchor.MiddleLeft;
		//GUI.Label(new Rect(10, 10, 150, 20), "Time  " + float.Parse(Timer.ToString("#.")), styleTime);
	}
}