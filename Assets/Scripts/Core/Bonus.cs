using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private const float reflectionSpeedIncrease = 2.5f;
    public BonusType type;
    public float speed = 1f;
    [SerializeField]
    float range = 10f;
    protected BounsGenerator _generator;
    public BounsGenerator generator { set { _generator = value; } }
    private Vector3 moveVector;
    

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

    SideType getSideType(Collider2D contact)
    {
        if (contact == _generator.greenSideCollider)
            return SideType.green;
        else if (contact == _generator.yellowSideCollider)
            return SideType.yellow;
        else 
            return SideType.red;
    }

    public virtual void ContactReaction(Collision2D collision)
    {
        SideType side = getSideType(collision.collider);
        switch (side)
        {
            case SideType.red:
            {
                ReflectionReaction(collision.contacts[0].normal);
                break;
            }
            case SideType.green:
            {
                if (type == BonusType.negative)
                    NegativeReaction(); //ScoreCounter.instance.NegCounter();
                else if (type == BonusType.positive)
                    PositiveReaction(); //ScoreCounter.instance.AddCounter();
                gameObject.SetActive(false);
                break;
            }
            case SideType.yellow:
            {
                if (type == BonusType.money)
                    PositiveReaction(); //ScoreCounter.instance.AddCounter();
                else if (type == BonusType.negative)
                    NegativeReaction(); //ScoreCounter.instance.NegCounter();
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
