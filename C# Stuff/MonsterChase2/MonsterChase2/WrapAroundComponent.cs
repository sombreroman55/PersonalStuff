using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterChase2
{
    class WrapAroundComponent : Component
    {
        int halfSize;
        public WrapAroundComponent(int halfSize)
        {
            this.halfSize = halfSize;
        }
        public override void Update()
        {
            if (Owner.Position.Y > halfSize)
                Owner.Position.Y = -halfSize;
            if (Owner.Position.Y < -halfSize)
                Owner.Position.Y = halfSize;
            if (Owner.Position.X > halfSize)
                Owner.Position.X = -halfSize;
            if (Owner.Position.X < -halfSize)
                Owner.Position.X = halfSize;
        }
    }
}
