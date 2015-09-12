using System;

class Shield : Component
{
    int numTurns = 0;
    public override void Initialize()
    {
        foreach (GameObject m in TheGame.monsters)
            m.RemoveComponent(KillOnContactComponent(TheGame.player));
    }
    public override void Update()
    {
        numTurns++;
        if (numTurns == 3)
        {
            foreach (GameObject m in TheGame.monsters)
                m.AddComponent(KillOnContactComponent(TheGame.player));
            Alive = false;
        }
    }
}