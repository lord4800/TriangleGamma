using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

    public BonusType type;
    public float speed = 1f;
    [SerializeField]
    float range = 10f;
    BounsGenerator _generator;
    public BounsGenerator generator { set { _generator = value; } }

    void Start () {
        initPos();
	}

    public virtual void initPos()
    {
        float angle = Random.Range(0, 360);
        transform.position = GetRestartPos(angle);
        gameObject.SetActive(true);
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
        transform.position += GetVectorTotriangle() * speed * Time.smoothDeltaTime;
    } 

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider != null)
        {
            Contact();
        }
    }

    public void Contact()
    {
        if (_generator != null)
            _generator.Generate();
        gameObject.SetActive(false);
    }

    Vector3 GetVectorTotriangle()
    {
        return (Vector3.zero - transform.position).normalized;
    }
}
