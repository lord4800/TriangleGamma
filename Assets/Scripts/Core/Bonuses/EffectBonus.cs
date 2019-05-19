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

    public override void AcceptBonus()
    {
        GameManager.Instance.EffectBonusType = bonusType;
    }
}
