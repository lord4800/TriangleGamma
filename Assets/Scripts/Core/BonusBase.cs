using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBase : MonoBehaviour
{
    private const float REFLECTION_SPEED_INCREASE = 2.5f;

    public ColorType type;
    public float speed = 1f;
    public BounsGenerator generator { set { _generator = value; } }

    [SerializeField] private float range = 10f;
    private Vector3 moveVector;

    protected BounsGenerator _generator;

    void Start () {
        initPos();
	}

    public virtual void initPos()
    {
        float angle = Random.Range(0, 360);
        transform.position = GetRestartPos(angle);
        gameObject.SetActive(true);
        moveVector = SetCurrentVector();
    }

    Vector3 GetRestartPos(float angle)
    {
        float x = range * Mathf.Cos(Mathf.Deg2Rad * angle);
        float y = range * Mathf.Sin(Mathf.Deg2Rad * angle);
        return new Vector3(x,y,0);
    }

    void Update () {
        MoveInc();
	}

    void MoveInc()
    {
        transform.position += moveVector * speed * Time.smoothDeltaTime;
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
        if (contact == _generator.greenSideCollider)
            return ColorType.green;
        else if (contact == _generator.yellowSideCollider)
            return ColorType.yellow;
        else 
            return ColorType.red;
    }

    public virtual void ContactReaction(Collision2D collision)
    {
        ColorType color = getSideType(collision.collider);
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
                    NegativeReaction(); 
                else if (type == ColorType.green)
                    PositiveReaction(); 
                gameObject.SetActive(false);
                break;
            }
            case ColorType.yellow:
            {
                if (type == ColorType.yellow)
                    PositiveReaction(); 
                else if (type == ColorType.red)
                    NegativeReaction(); 
                gameObject.SetActive(false);
                break;
            }
        }
    }

    public virtual void ReflectionReaction(Vector3 normal)
    {
        moveVector = Vector3.Reflect(moveVector*3, normal);
    }

    public virtual void PositiveReaction()
    {
        ScoreCounter.instance.AddCounter();
    }

    public virtual void NegativeReaction()
    {
        ScoreCounter.instance.NegCounter();
    }

    Vector3 SetCurrentVector()
    {
        return (Vector3.zero - transform.position).normalized;
    }
}
