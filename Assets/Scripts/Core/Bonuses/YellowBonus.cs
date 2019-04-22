using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBonus : Bonus
{
    [SerializeField] private int coins;

    public override void AddCoins()
    {
        //TODO: add absorbate animation;
        ScoreCounter.instance.AddCounter(coins);
    }
}