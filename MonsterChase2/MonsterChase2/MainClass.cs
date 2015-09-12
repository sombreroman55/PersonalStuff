using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterChase2
{
    class MainClass
    {
        //static Func<Func<>> GiveMeFoo()
        //{
        //    return GiveMeFoo;
        //}

        static void Main()
        {
            Game game = new Game();
            game.Initialize();
            game.Go();
        }
    }
}
