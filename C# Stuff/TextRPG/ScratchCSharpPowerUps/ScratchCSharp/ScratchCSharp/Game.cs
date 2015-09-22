using System;
using System.Collections.Generic;

class Game
{
    public int BoardWidth { get; set; }
    public int BoardHeight { get; set; }
    public int survivalCount { get; set; }
    public int turnCount { get; set; }
    public int monsterCount { get; set; }
    public GameObject player;
    public List<GameObject> runners = new List<GameObject>();
    public List<GameObject> powerUps = new List<GameObject>();

    public void Initialize()
    {
        InitializeGame();
        InitializePlayer();
        InitializePowerUps();
        InitializeMonsters();
        foreach (GameObject p in powerUps)
            p.Initialize();
        foreach (GameObject m in runners)
            m.Initialize();
    }

    void InitializePowerUps()
    {
        GameObject powerUp = new GameObject(this);
        powerUp.X = new Random().Next(-BoardWidth, BoardWidth + 1);
        powerUp.Y = new Random().Next(-BoardHeight, BoardHeight + 1);
        powerUp.AddComponent(new PowerUpTouchComponent(player, new Haste()));
        powerUp.AddComponent(new RenderComponent('H'));
        powerUps.Add(powerUp);
    }

    void InitializeMonsters()
    {
        for (int i = 0; i < monsterCount; i++)
        {
            GameObject monster = new GameObject(this);
            monster.X = new Random().Next(-BoardWidth, BoardWidth+1);
            monster.Y = new Random().Next(-BoardHeight, BoardHeight);
            monster.AddComponent(new KeepInBoundsComponent());
            monster.AddComponent(new KillOnContactComponent(player));
            monster.AddComponent(new AIComponent(player));
            monster.AddComponent(new RenderComponent('M'));
            runners.Add(monster);
        }
    }

    void InitializeGame()
    {
        Console.WriteLine("How wide horizontally do you want your board?");
        BoardWidth = int.Parse(Console.ReadLine());
        Console.WriteLine("How long vertically do you want your board?");
        BoardHeight = int.Parse(Console.ReadLine());
        Console.WriteLine("How many turns do you want to survive for?");
        survivalCount = int.Parse(Console.ReadLine());
        Console.WriteLine("How many monsters do you want to run from?");
        monsterCount = int.Parse(Console.ReadLine());
        turnCount = 1;
    }

    void InitializePlayer()
    {
        player = new GameObject(this);
        player.AddComponent(new KeyboardControllerComponent());
        player.AddComponent(new WrapAroundComponent());
        player.AddComponent(new RenderComponent('O'));
        runners.Add(player);
    }

    public void Go()
    {
        while (turnCount <= survivalCount && player.Alive == true ) // Play loop
        {
            DisplayBoard();
            Console.WriteLine("Turn " + turnCount);
            Console.WriteLine(player.X + ", " + player.Y);
            Console.WriteLine("You must survive for " + survivalCount + " turns.");
            foreach (GameObject r in runners)
                r.Update();
            for (int i = 0; i < runners.Count; i++)
                if (!runners[i].Alive)
                    runners.RemoveAt(i--);
            turnCount++;
            Console.Clear();
        }
        if (player.Alive == false)
            GameOver();
        else
            Win();
    }

    void DisplayBoard()
    {
        int drawWidth = (BoardWidth * 2 + 1);
        int drawHeight = (BoardHeight * 2 + 1);

        Console.WriteLine(new string('-', drawWidth));
        for (int i = 0; i < drawHeight; i++)
        {
            for (int j = 0; j < drawHeight; j++)
            {
                Console.Write(' ');
                foreach (GameObject r in runners)
                {
                    if (i == YTransform(r.Y) && j == XTransform(r.X))
                        Console.Write(r);
                }

                foreach (GameObject p in powerUps)
                {
                    if (i == YTransform(p.Y) && j == XTransform(p.X))
                        Console.Write(p);
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine(new string('-', drawHeight));
    }

    private int XTransform(int currentX)
    {
        return currentX + ((BoardWidth * 2 + 1) / 2);
    }

    private int YTransform(int currentY)
    {
        return currentY + (BoardHeight + (-2 * currentY));
    }

    void GameOver()
    {
        Console.Clear();
        Console.WriteLine("YOU DIED.");
        Console.WriteLine("GAME OVER.");
        Console.ReadLine();
    }

    void Win()
    {
        Console.Clear();
        Console.WriteLine("YOU WIN!");
        Console.WriteLine("CONGRATULATIONS!");
        Console.ReadLine();
    }
}