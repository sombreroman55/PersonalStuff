using System;
using System.Collections.Generic;
class Game
{
    GameObject player;
    List<GameObject> monsters = new List<GameObject>();
    public void Initialize()
    {
        GetPlayerPreferences();
        SetupGameObjects();

    }

    public void Go()
    {
        DisplayBoard(); 
        while (true)
        {
            player.Update();
            DisplayBoard();
        }
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
        player = new GameObject();
        player.AddComponent(new KeyboardMoverComponent());
        //player.AddComponent(new WrapAroundComponent(HalfBoard));
        player.AddComponent(new KeepInBoundsComponent(HalfBoard));
        player.AddComponent(new RenderComponent('X'));

        for(int i = 0; i < NumMonsters; i++)
        {
            GameObject monster = new GameObject();
            monster.AddComponent(new KeepInBoundsComponent(HalfBoard));
            //monster.AddComponent(new AiComponent());
            //monster.AddComponent(new KillOnContactComponent());
            monster.AddComponent(new RenderComponent('M'));
        }

        // Powerups
    }


    void GetPlayerPreferences()
    {
        BoardSize = 5;
        NumMonsters = 1;
        // Set number of turns
        // Set number of monsters
    }

    public int HalfBoard
    {
        get { return BoardSize / 2; }
    }
    int BoardSize { get; set; }
    int NumMonsters { get; set; }
}

class MainClass
{
    static void Main()
    {
        Game game = new Game();
        game.Initialize();
        game.Go();
    }
}