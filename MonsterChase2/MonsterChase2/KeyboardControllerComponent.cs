using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterChase2
{
    class KeyboardControllerComponent : Component
    {
        public int Speed { get; set; }
        public KeyboardControllerComponent()
        {
            Speed = 1;
        }
        public override void Update()
        {
            Console.WriteLine("Wut do? (wasd)");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (choice)
            {
                case 'w':
                    Owner.Position.Y += Speed;
                    break;
                case 's':
                    Owner.Position.Y -= Speed;
                    break;
                case 'a':
                    Owner.Position.X -= Speed;
                    break;
                case 'd':
                    Owner.Position.X += Speed;
                    break;
            }
        }
    }
}
