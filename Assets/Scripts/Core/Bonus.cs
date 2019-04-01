using UnityEngine;

public class Bonus : BonusBase {
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
            case ColorType.green: { _sprite.sprite = green; break; }
            case ColorType.yellow: { _sprite.sprite = gold; break; }
            case ColorType.red: { _sprite.sprite = red; break; }
        }

    }

    void GenerateType()
    {
        float chance = Random.Range(0f,1f);
        if (chance < _generator.generateGreenChance)
        {
            type = ColorType.green;
        }
        else if (chance < _generator.generateGreenChance + _generator.generateYellowChance)
        {
            type = ColorType.yellow;
        } else
        {
            type = ColorType.red;
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
