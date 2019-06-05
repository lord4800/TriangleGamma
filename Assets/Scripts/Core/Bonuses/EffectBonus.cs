using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBonus : Bonus
{
    public enum EffectBonusType
    {
        timeScaleDown,
        timeScaleUp,
        revertControl,
        extramoney,
        none
    }

    [SerializeField] private EffectBonusType bonusType;
    private SpriteRenderer sprite;

    public override void initPos()
    {
        float random = Random.Range(0f, 1f);
        if (random < 0.3f)
            bonusType = EffectBonusType.timeScaleDown;
        else if (random < 0.6f)
            bonusType = EffectBonusType.timeScaleUp;
        else
            bonusType = EffectBonusType.revertControl;

        //TODO GetImage
        sprite = GetComponent<SpriteRenderer>();
        
        sprite.sprite = GameManager.Instance.EffectImage(bonusType);

        base.initPos();
    }

    public override void AcceptBonus()
    {
        GameManager.Instance.EffectBonusType = bonusType;
    }
}
