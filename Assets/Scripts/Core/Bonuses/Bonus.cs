using UnityEngine;

public class Bonus : BonusBase {

    public override void initPos()
    {
        base.initPos();
    }

    public override void ReflectionReaction(Vector3 normal)
    {
        base.ReflectionReaction(normal);
        SpawnParticle();
    }

    public override void Death()
    {
        SpawnParticle();
        base.Death();
    }

    void SpawnParticle()
    {
        ParticleManager.instance.SetParticle(transform.position, type);
    }

}
