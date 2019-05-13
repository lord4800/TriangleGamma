using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;
    private const float TIME_BEFORE_START = 1.5f;
    float timer;
    public enum GamesState
    {
        Menu,
        WaitForEffect,
        Game,
        GameOver
    }

    private GamesState gameState;

    public GamesState GameState
    {
        get { return gameState; }
        set
        {
            gameState = value;
            if (gameState == GamesState.Menu && onIntoMainMenuTranzitionEvent != null) onIntoMainMenuTranzitionEvent();
            if (gameState == GamesState.Game && onIntoGameTranzitionEvent != null) onIntoGameTranzitionEvent();
            if (gameState == GamesState.WaitForEffect && onIntoWaitForGameTranzitionEvent != null) onIntoWaitForGameTranzitionEvent();
            if (gameState == GamesState.GameOver && onIntoGameOverTranzitionEvent != null) onIntoGameOverTranzitionEvent();
        }
    }

    public event Action onIntoGameTranzitionEvent;
    public event Action onIntoMainMenuTranzitionEvent;
    public event Action onIntoWaitForGameTranzitionEvent;
    public event Action onIntoGameOverTranzitionEvent;

    private void Awake()
    {
        _instance = this;
        onIntoWaitForGameTranzitionEvent += StartGameEvent;
    }

    private void StartGameEvent()
    {
        StartCoroutine(BeforeEffectTime());
    }

    IEnumerator BeforeEffectTime ()
    {
        timer = TIME_BEFORE_START;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
            //indication
        }
        GameState = GamesState.Game;
    }
}
