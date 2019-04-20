using UnityEngine;

public class Bonus : BonusBase {
    [SerializeField] private SpriteRenderer bonusSprite;
    [SerializeField] private Sprite green;
    [SerializeField] private Sprite gold;
    [SerializeField] private Sprite red;

    public override void initPos()
    {
        base.initPos();
        GenerateType(); 
        switch (type)
        {
            case ColorType.green: { bonusSprite.sprite = green; break; }
            case ColorType.yellow: { bonusSprite.sprite = gold; break; }
            case ColorType.red: { bonusSprite.sprite = red; break; }
        }
    }

    public override void ReflectionReaction(Vector3 normal)
    {
        base.ReflectionReaction(normal);
        SpawnParticle();
    }

    public override void AddCoins()
    {
        //TODO: add absorbate animation;
        base.AddCoins();
    }

    public override void Death()
    {
        SpawnParticle();
        base.Death();
    }

    void GenerateType()
    {
        float chance = Random.Range(0f, 1f);
        if (chance < _generator.generateGreenChance)
        {
            type = ColorType.green;
        }
        else if (chance < _generator.generateGreenChance + _generator.generateYellowChance)
        {
            type = ColorType.yellow;
        }
        else
        {
            type = ColorType.red;
        }
    }

    void SpawnParticle()
    {
        ParticleManager.instance.SetParticle(transform.position, type);
    }

}
