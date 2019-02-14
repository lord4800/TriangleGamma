using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosBonus : Bonus {
    [SerializeField]
    SpriteRenderer _sprite;
    [SerializeField]
    Sprite green;
    [SerializeField]
    Sprite gold;
    [SerializeField]
    Sprite red;

    public override void initPos()
    {
        base.initPos();
        GenerateType(); 
        switch (type)
        {
            case BonusType.positive: { _sprite.sprite = green; break; }
            case BonusType.money: { _sprite.sprite = gold; break; }
            case BonusType.negative: { _sprite.sprite = red; break; }
        }

    }

    void GenerateType()
    {
        float chance = Random.Range(0f,1f);
        if (chance < _generator.generateGreenChance)
        {
            type = BonusType.positive;
        }
        else if (chance < _generator.generateGreenChance + _generator.generateYellowChance)
        {
            type = BonusType.money;
        } else
        {
            type = BonusType.negative;
        }
    }

    public override void ReflectionReaction(Vector3 normal)
    {
        base.ReflectionReaction(normal);
        SpawnParticle();
        SpawnParticle();
    }

    public override void PositiveReaction()
    {
        //TODO: add absorbate animation;
        base.PositiveReaction();
    }

    public override void NegativeReaction()
    {
        SpawnParticle();

        base.NegativeReaction();
    }

    void SpawnParticle()
    {
        if (ParticleManagerScr.instance != null)
            ParticleManagerScr.instance.SetParticle(transform.position, type);
    }

}
