using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;
    private const float TIME_BEFORE_START = 1.5f;
    private const float SLOWDOWN_TIMESCALE = 0.5f;
    private const float UP_TIMESCALE = 1.2f;
    private const float EFFECT_TIMER = 5f;

    public event Action onIntoGameTranzitionEvent;
    public event Action onIntoMainMenuTranzitionEvent;
    public event Action onIntoWaitForGameTranzitionEvent;
    public event Action onIntoGameOverTranzitionEvent;

    private float timer;
    private Coroutine effectCorotine;

    public enum GamesState
    {
        Menu,
        WaitForEffect,
        Game,
        GameOver
    }

    private EffectBonus.EffectBonusType effectBonusType;

    public EffectBonus.EffectBonusType EffectBonusType
    {
        get
        {
            return effectBonusType;
        }
        set
        {
            switch (value)
            {
                case EffectBonus.EffectBonusType.timeScaleDown:
                    timeScale = SLOWDOWN_TIMESCALE;
                    StartEffectTimer();
                    break;
                case EffectBonus.EffectBonusType.timeScaleUp:
                    timeScale = UP_TIMESCALE;
                    StartEffectTimer();
                    break;
                case EffectBonus.EffectBonusType.extramoney:
                        
                    break;
                case EffectBonus.EffectBonusType.revertControl:
                    isRevertControl = !isRevertControl;
                    break;
            }
            effectBonusType = value;
        }
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

    private float timeScale = 1f;

    public float TimeScale
    {
        get
        {
            return timeScale;
        }
    }

    private bool isRevertControl;

    public bool IsRevertControl
    {
        get {
            return isRevertControl;
        }
    }

    private void Awake()
    {
        _instance = this;
        onIntoWaitForGameTranzitionEvent += StartGameEvent;
    }

    private void StartGameEvent()
    {
        StartCoroutine(BeforeEffectTime());
    }

    IEnumerator BeforeEffectTime()
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

    private IEnumerator TimeScaleWait()
    {
        yield return new WaitForSeconds(EFFECT_TIMER);
        timeScale = 1f;
    }

    private void StartEffectTimer()
    {
        if (effectCorotine != null)
            StopCoroutine(effectCorotine);
        effectCorotine = StartCoroutine(TimeScaleWait());
    }

    private void StopEffect()
    {
        switch (EffectBonusType)
        {
            case EffectBonus.EffectBonusType.timeScaleDown:
            case EffectBonus.EffectBonusType.timeScaleUp:
                timeScale = 1f;
                break;
            case EffectBonus.EffectBonusType.extramoney:
                
                break;
            case EffectBonus.EffectBonusType.revertControl:
                isRevertControl = false;
                break;
        }
        EffectBonusType = EffectBonus.EffectBonusType.none;
    }
}
