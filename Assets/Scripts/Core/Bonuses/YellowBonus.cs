using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBonus : Bonus
{
    public enum YellowBonusType
    {
        Gold5 = 5,
        Gold10 = 10
    }

    [SerializeField] private int coins;
    private YellowBonusType bonusType;

    public override void initPos()
    {
        if (Random.Range(0f, 1f) < 0.7f)
            bonusType = YellowBonusType.Gold5;
        else
            bonusType = YellowBonusType.Gold10;

        coins = (int)bonusType;

        base.initPos();
    }

    public override void AddCoins()
    {
        //TODO: add absorbate animation;
        ScoreCounter.Instance.AddCounter(coins);
    }
}