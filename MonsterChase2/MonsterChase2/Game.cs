using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterChase2
{
    class Game
    {
        public int HalfBoard
        {
            get { return BoardSize / 2; }
        }
        int BoardSize { get; set; }
        int NumMonsters { get; set; }
        GameObject player;

        List<GameObject> gameObjects = new List<GameObject>();

        public void Initialize()
        {
            InitializeBoard();
            InitializePlayer();
            InitializePowerUps();
            foreach (GameObject g in gameObjects)
                g.Initialize();
        }

        void InitializePowerUps()
        {
            GameObject powerUp = new GameObject(this);
            powerUp.Position.X = 1;
            powerUp.Position.Y = 1;
            powerUp.AddComponent(new PowerUpTouchComponent(player, new Haste()));
            gameObjects.Add(powerUp);
        }

        void InitializeBoard()
        {
            Console.WriteLine("What size do you want your board?");
            BoardSize = int.Parse(Console.ReadLine());
        }

        void InitializePlayer()
        {
            player = new GameObject(this);
            player.AddComponent(new KeyboardControllerComponent());
            player.AddComponent(new KeepInBoundsComponent(HalfBoard));
            gameObjects.Add(player);
        }

        void DisplayBoard()
        {
            Console.WriteLine(new string('-', BoardSize));
            Point typewriter = new Point(-HalfBoard, HalfBoard);
            while (typewriter.Y >= -HalfBoard)
            {
                if (typewriter == player.Position)
                    Console.Write(player);
                else
                    Console.Write(' ');
                if (typewriter.X++ == HalfBoard)
                {
                    typewriter.X = -HalfBoard;
                    typewriter.Y--;
                    Console.WriteLine();
                }
            }
            Console.WriteLine(new string('-', BoardSize));
        }

        void SetupGameObjects()
        {
            player = new GameObject(this);
            player.AddComponent(new KeyboardControllerComponent());
            //player.AddComponent(new WrapAroundComponent(HalfBoard));
            player.AddComponent(new KeepInBoundsComponent(HalfBoard));
            player.AddComponent(new RenderComponent('X'));

            for (int i = 0; i < NumMonsters; i++)
            {
                GameObject monster = new GameObject(this);
                monster.AddComponent(new KeepInBoundsComponent(HalfBoard));
                //monster.AddComponent(new AiComponent());
                //monster.AddComponent(new KillOnContactComponent());
                monster.AddComponent(new RenderComponent('M'));
            }

            // Powerups
        }

        //public void Go()
        //{
        //    while (true) // Play loop
        //    {
        //        Console.WriteLine(player.X + ", " + player.Y);
        //        foreach (GameObject g in gameObjects)
        //            g.Update();
                //for (int i = 0; i < gameObjects.Count; i++)
                //    if (!gameObjects[i].Alive)
                //        gameObjects.RemoveAt(i--);
        //    }
        //}

        public void Go()
        {
            DisplayBoard();
            while (true)
            {
                Console.WriteLine(player.Position.X + ", " + player.Position.Y);
                foreach (GameObject g in gameObjects)
                    g.Update();
                for (int i = 0; i < gameObjects.Count; i++)
                    if (!gameObjects[i].Alive)
                        gameObjects.RemoveAt(i--);
                player.Update();
                DisplayBoard();
            }
        }
    }
}
