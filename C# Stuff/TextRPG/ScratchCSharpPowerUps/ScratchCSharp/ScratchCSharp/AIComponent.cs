using System;

class AIComponent : Component
{
    GameObject target;
    public AIComponent(GameObject target)
    {
        this.target = target;
    }
    public override void Update()
    {
        if (target.X > Owner.X)
            Owner.X++;
        if (target.X < Owner.X)
            Owner.X--;
        if (target.Y > Owner.Y)
            Owner.Y++;
        if (target.Y < Owner.Y)
            Owner.Y--;
    }
}