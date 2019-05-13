using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    const int LIFES = 3;

    static LifeManager _instance;

    public static LifeManager Instance { get { return _instance; } }
    

    [SerializeField] private List<GameObject> lifeIndication;
    [SerializeField] private GameObject lifeBackground;

    private int lifes;

    private void Awake()
    {
        _instance = this;

        lifeBackground.SetActive(false);
        foreach (GameObject heart in lifeIndication)
        {
            heart.SetActive(false);
        }

        
    }

    private void Start()
    {
        GameManager.Instance.onIntoGameTranzitionEvent += Init;
    }

    private void Init()
    {
        lifes = LIFES;
        Debug.Log("Init");
        lifeBackground.SetActive(true);

        foreach (GameObject heart in lifeIndication)
        {
            heart.SetActive(true);
        }
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
        if (GameManager.Instance.GameState != GameManager.GamesState.Game)
            return;
        lifes--;
        UpdateIndication();
        if (lifes == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        lifeBackground.SetActive(false);
        GameManager.Instance.GameState = GameManager.GamesState.GameOver;
        Debug.Log("<<GAME OVER>>");
    }
}
