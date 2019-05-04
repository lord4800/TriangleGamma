using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    const int LIFES = 3;

    static LifeManager _instance;

    public static LifeManager Instance { get { return _instance; } }
    

    [SerializeField] private List<GameObject> lifeIndication;

    private int lifes;

    private void Awake()
    {
        _instance = this;

        lifes = LIFES;
    }

    private void UpdateIndication()
    {
        for (int i = 0; i < lifeIndication.Count; i++)
        {
            GameObject indicator = (GameObject)lifeIndication[i];
            if (i < lifes)
            {
                indicator.SetActive(true);
            }
            else indicator.SetActive(false);
        }
    }

    public void Death()
    {
        lifes--;
        UpdateIndication();
        if (lifes == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("<<GAME OVER>>");
    }
}
