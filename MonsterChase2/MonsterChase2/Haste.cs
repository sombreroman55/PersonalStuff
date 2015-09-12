using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterChase2
{
    class Haste : Component
    {
        int numTurns = 0;
        KeyboardControllerComponent k;
        public override void Initialize()
        {
            // http://computersciencevideos.org/CSharp-Generics
            k = Owner.GetComponent<KeyboardControllerComponent>();
            k.Speed = 3;
        }
        public override void Update()
        {
            numTurns++;
            if (numTurns == 5)
            {
                k.Speed = 1;
                Alive = false;
            }
        }
    }
}
