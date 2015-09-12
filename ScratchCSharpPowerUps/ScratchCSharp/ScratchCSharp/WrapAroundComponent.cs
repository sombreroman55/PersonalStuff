using System;

class WrapAroundComponent : Component
{
    public override void Update()
    {
        if (Owner.X > Owner.TheGame.BoardWidth)
            Owner.X = -Owner.TheGame.BoardWidth;
        if (Owner.X < -Owner.TheGame.BoardWidth)
            Owner.X = Owner.TheGame.BoardWidth;
        if (Owner.Y > Owner.TheGame.BoardHeight)
            Owner.Y = -Owner.TheGame.BoardHeight;
        if (Owner.Y < -Owner.TheGame.BoardHeight)
            Owner.Y = Owner.TheGame.BoardHeight;
    }
}