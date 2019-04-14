using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {
    public static GameManager instance { get { return _instance; } }
    private static GameManager _instance;
    public enum GamesState
    {
        Menu,
        Game
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
        }
    }

    public event Action onIntoGameTranzitionEvent;
    public event Action onIntoMainMenuTranzitionEvent;

    private void Awake()
    {
        _instance = this;
    }
}
