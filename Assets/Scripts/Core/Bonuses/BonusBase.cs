﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BonusBase : MonoBehaviour
{
    public Action OnDeath;
    
    private const float REFLECTION_SPEED_INCREASE = 2.5f;
    private const float DELETE_BONUS_DISTANCE = 0.1f;
    private const float GENERATION_ANGLE = 30f;
    private const float SPEED = 4f;
    private const float RANGE = 10f;

    public ColorType type;

    private Vector3 moveVector;

    void Start () {
        initPos();
	}

    public virtual void initPos()
    {
        float angle = GetAngle();
        transform.position = GetRestartPos(angle);
        gameObject.SetActive(true);
        moveVector = SetCurrentVector();
    }

    private static float GetAngle()
    {
        int sector = UnityEngine.Random.Range(1,5);
        switch (sector)
        {
            case 1:
                return UnityEngine.Random.Range(0f, GENERATION_ANGLE);
            case 2:
                return UnityEngine.Random.Range(180f - GENERATION_ANGLE, 180f);
            case 3:
                return UnityEngine.Random.Range(180f, 180f + GENERATION_ANGLE);
            case 4:
                return UnityEngine.Random.Range(360f - GENERATION_ANGLE, 360f);
        }
        return UnityEngine.Random.Range(0f, 360f);
    }

    Vector3 GetRestartPos(float angle)
    {
        float x = RANGE * Mathf.Cos(Mathf.Deg2Rad * angle);
        float y = RANGE * Mathf.Sin(Mathf.Deg2Rad * angle);
        return new Vector3(x,y,0);
    }

    void Update ()
    {
        MoveInc();
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) < DELETE_BONUS_DISTANCE)
        {
            Death();
            gameObject.SetActive(false);
        }
    }

    void MoveInc()
    {
        transform.position += moveVector * SPEED * Time.smoothDeltaTime * GameManager.Instance.TimeScale;
    } 

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider != null)
        {
            Contact(other);
        }
    }

    public void Contact(Collision2D collision)
    {
        ContactReaction(collision);
    }

    ColorType getSideType(Collider2D contact)
    {
        if (contact == BounsGenerator.Instance.greenSideCollider)
            return ColorType.green;
        else if (contact == BounsGenerator.Instance.yellowSideCollider)
            return ColorType.yellow;
        else 
            return ColorType.red;
    }

    public virtual void ContactReaction(Collision2D collision)
    {
        ColorType color = getSideType(collision.collider);
        if (GameManager.Instance.GameState == GameManager.GamesState.WaitForEffect)
        {
            ReflectionReaction(collision.contacts[0].normal);
            return;
        }

        switch (color)
        {
            case ColorType.red:
            {
                ReflectionReaction(collision.contacts[0].normal);
                break;
            }
            case ColorType.green:
            {
                    if (type == ColorType.red)
                        AcceptBonus();
                    else if (type == ColorType.green)
                        AcceptBonus();
                    else if (type == ColorType.yellow)
                        Death();
                gameObject.SetActive(false);
                break;
            }
            case ColorType.yellow:
            {
                    if (type == ColorType.yellow)
                        AddCoins();
                    else if (type == ColorType.red)
                        Death();
                    else if (type == ColorType.green)
                        Death();
                gameObject.SetActive(false);
                break;
            }
        }
    }

    public virtual void ReflectionReaction(Vector3 normal)
    {
        moveVector = Vector3.Reflect(moveVector*3, normal);
    }

    public virtual void AddCoins()
    {
       
    }

    public virtual void AcceptBonus()
    {

    }

    public virtual void Death()
    {
        if (OnDeath != null && GameManager.Instance.GameState == GameManager.GamesState.Game)
        {
            OnDeath();
            Debug.Log("Death");
        }
    }

    Vector3 SetCurrentVector()
    {
        return (Vector3.zero - transform.position).normalized;
    }
}
