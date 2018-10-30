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
        
        switch (type)
        {
            case BonusType.positive: { _sprite.sprite = green; break; }
            case BonusType.money: { _sprite.sprite = gold; break; }
            case BonusType.negative: { _sprite.sprite = red; break; }
        }

    }
}
