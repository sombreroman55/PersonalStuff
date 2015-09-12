using System;

class Haste : Component
{
    int numTurns = 0;
    KeyboardControllerComponent k;
    public override void Initialize()
    {
        k = Owner.GetComponent<KeyboardControllerComponent>();
        k.Speed = 3;
    }
    public override void Update()
    {
        numTurns++;
        if(numTurns == 5)
        {
            k.Speed = 1;
            Alive = false;
        }
    }
}