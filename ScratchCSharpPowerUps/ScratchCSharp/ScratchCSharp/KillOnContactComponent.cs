using System;

class KillOnContactComponent : Component
{
    GameObject victim;
    public KillOnContactComponent(GameObject victim)
    {
        this.victim = victim;
    }
    public override void Update()
    {
        if (Owner.X == victim.X && Owner.Y == victim.Y)
        {
            victim.Alive = false;
        }
    }
}