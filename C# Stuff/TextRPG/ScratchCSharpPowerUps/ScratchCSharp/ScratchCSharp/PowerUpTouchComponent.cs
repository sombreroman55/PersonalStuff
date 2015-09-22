using System;

class PowerUpTouchComponent : Component
{
    GameObject victim;
    Component thePowerUp;
    public PowerUpTouchComponent(GameObject victim, Component thePowerUp)
    {
        this.victim = victim;
        this.thePowerUp = thePowerUp;
    }
    public override void Update()
    {
        if(Owner.X == victim.X && Owner.Y == victim.Y)
        {
            victim.AddComponent(thePowerUp);
            thePowerUp.Initialize();
            Owner.Alive = false;
        }
    }
}
