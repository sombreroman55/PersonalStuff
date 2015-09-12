using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterChase2
{
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
            if (Owner.Position.X == victim.Position.X && Owner.Position.Y == victim.Position.Y)
            {
                victim.AddComponent(thePowerUp);
                thePowerUp.Initialize();
                Owner.Alive = false;
            }
        }
    }
}
