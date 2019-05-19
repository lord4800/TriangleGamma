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
        extramoney
    }

    [SerializeField] private EffectBonusType bonusType;

    public override void AcceptBonus()
    {
        switch (bonusType)
        {
            case EffectBonusType.timeScaleDown:
                {
                    GameManager.Instance.TimeSlowDownEvent();
                    break;
                }
            case EffectBonusType.timeScaleUp:
                {
                    GameManager.Instance.TimeUpEvent();
                    break;
                }
        }
    }
}
