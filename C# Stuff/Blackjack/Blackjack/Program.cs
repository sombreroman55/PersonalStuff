using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.GameStart();
            game.Play();
            if (game.Lost)
                Console.WriteLine("You lose! Too bad!");
            if (game.Won)
                Console.WriteLine("You win! Nice going!");
            if (game.Draw)
                Console.WriteLine("It's a draw! Oh well.");
            Console.ReadLine();
        }
    }
}
