//Solution for McKay Roundy and Andrew Roberts

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterChase
{
    class Game
    {
        public int gridXLimit;
        public int gridYLimit;
        public int survivalCount;
        int monsterCount;
        public bool gameOver = false;
        public Player player;
        int turnCount = 1;
        char moveDirection;
        public Monster[] monsters;
        public PowerUp powerUp;
 
        public void initializeGame()
        {
            Console.Clear();
            Console.WriteLine("WELCOME TO MONSTER CHASE!");
            Console.WriteLine("Please configure the game:");
            //map size
            Console.WriteLine("How big do you want the map horizontally?");
            gridXLimit = int.Parse(Console.ReadLine());
            Console.WriteLine("How big do you want the map vertically?");
            gridYLimit = int.Parse(Console.ReadLine());
            //turns for survival
            Console.WriteLine("How many turns must you survive?");
            survivalCount = int.Parse(Console.ReadLine());
            //number of monsters
            Console.WriteLine("How many monsters do you want to run from?");
            monsterCount = int.Parse(Console.ReadLine());
            player = new Player();
            makeMonsters();
            Console.Clear();
        }

        public void makeMonsters()
        {
            monsters = new Monster[monsterCount];
            for (int i = 0; i < monsterCount; i++)
                monsters[i] = new Monster((-gridXLimit), (gridXLimit + 1), (-gridYLimit), (gridYLimit + 1));
        }

        public void Turn()
        {
            DrawMap();
            Console.WriteLine();
            Console.WriteLine("Turn " + turnCount);
            Console.WriteLine("Your position is (" + player.playerXPos + "," + player.playerYPos + ")");
            Console.WriteLine("There are monsters at positions:");
            for (int i = 0; i < monsterCount; i++)
                Console.WriteLine("Monster " + (i + 1) + "(" + monsters[i].monsterXPos + "," + monsters[i].monsterYPos + ")");
            Console.WriteLine("You must survive " + survivalCount + " more turn" + (survivalCount == 1 ? "." : "s."));
            Console.WriteLine("Where will you go next? Enter the letter of your choice.");
            Console.WriteLine("W: (" + player.playerXPos + "," + (player.playerYPos == gridYLimit ? (-player.playerYPos) : (player.playerYPos + 1)) + ")");
            Console.WriteLine("D: (" + (player.playerXPos == gridXLimit ? (-player.playerXPos) : (player.playerXPos + 1)) + "," + player.playerYPos + ")");
            Console.WriteLine("S: (" + player.playerXPos + "," + (player.playerYPos == -gridYLimit ? (-player.playerYPos) : (player.playerYPos - 1)) + ")");
            Console.WriteLine("A: (" + (player.playerXPos == -gridXLimit ? (-player.playerXPos) : (player.playerXPos - 1)) + "," + player.playerYPos + ")");
            moveDirection = Console.ReadLine().ToLower()[0];
            Console.Clear();

            if (player.hasSpeed == true)
                player.SpeedMove(moveDirection, (-gridXLimit), (gridXLimit), (-gridYLimit), (gridYLimit));
            else
                player.NormalMove(moveDirection, (-gridXLimit), (gridXLimit), (-gridYLimit), (gridYLimit));
            for (int i = 0; i < monsterCount; i++)
                monsters[i].Move(player);
            CheckGameOver();
            if (powerUp == null || powerUp.onField == false)
                generatePowerUp();
            CheckSpeed();
            survivalCount--;
            turnCount++;
        }

        public void DrawMap()
        {
            int xsize = ((gridXLimit * 2) + 1);
            int ysize = ((gridYLimit * 2) + 1);
            string[,] map = new string[ysize, xsize];
            for (int i = 0; i < ysize; i++)
            {
                for (int j = 0; j < xsize; j++)
                {
                    map[i, j] = "| |";
                    for (int k = 0; k < monsterCount; k++ )
                        if ((i == YTransform(monsters[k].monsterYPos)) & (j == XTransform(monsters[k].monsterXPos)))
                            map[i, j] = "|X|";
                    if ( powerUp != null && i == YTransform(powerUp.PUYPos) && j == XTransform(powerUp.PUXPos) )
                    {
                        if (powerUp.Name == "Freeze")
                            map[i, j] = "|F|";
                        else if (powerUp.Name == "Shield")
                            map[i, j] = "|S|";
                    }
                    if (i == YTransform(player.playerYPos) & j == XTransform(player.playerXPos))
                        map[i, j] = "|O|";
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("O = player; X = monster");
            if (powerUp != null)
            {
                if (powerUp.onField == true && powerUp.Name == "Freeze")
                    Console.WriteLine("F = Freeze; Freeze power-up at space (" + powerUp.PUXPos + "," + powerUp.PUYPos + ")!");
                else if (powerUp.onField == true && powerUp.Name == "Shield")
                    Console.WriteLine("S = Shield; Shield power-up at space (" + powerUp.PUXPos + "," + powerUp.PUYPos + ")!");
            }
        }

        private int XTransform(int currentX)
        {
            return currentX + ((gridXLimit * 2 + 1) / 2);
        }

        private int YTransform(int currentY)
        {
            return currentY + (gridYLimit + (-2 * currentY));
        }

        public void generatePowerUp()
        {
            int generate = new Random().Next() % 2;
            int choice = new Random().Next() % 2;
            if (generate == 0)
            {
                if (choice == 0)
                {
                    powerUp = new Speed((-gridXLimit), (gridXLimit + 1), (-gridYLimit), (gridYLimit + 1));
                    powerUp.onField = false;
                }
                else
                {
                    powerUp = new Freeze((-gridXLimit), (gridXLimit + 1), (-gridYLimit), (gridYLimit + 1));
                    powerUp.onField = false;
                }
            }
            else if (generate == 1)
            {
                if (choice == 0)
                {
                    powerUp = new Speed((-gridXLimit), (gridXLimit + 1), (-gridYLimit), (gridYLimit + 1));
                }
                else
                {
                    powerUp = new Freeze((-gridXLimit), (gridXLimit + 1), (-gridYLimit), (gridYLimit + 1));
                }
            }
        }

        public bool CheckGameOver()
        {
            for (int i = 0; i < monsterCount; i++)
                if (monsters[i].monsterXPos == player.playerXPos && monsters[i].monsterYPos == player.playerYPos)
                    gameOver = true;
                else
                    gameOver = false;
            return gameOver;
        }

        public bool CheckSpeed()
        {
            int count = 0;
            if (powerUp != null)
            {
                if ((powerUp.PUXPos == player.playerXPos && powerUp.PUYPos == player.playerYPos) && powerUp.onField == true && powerUp.Name == "Speed")
                {
                    player.hasSpeed = true;
                    powerUp.onField = false;
                }
                if (count == powerUp.durationOnField)
                    powerUp.onField = false;
                return player.hasSpeed;
            }

            return false;
        }

        public void Lose()
        {
            Console.Clear();
            Console.WriteLine(@",--.   ,--.,-----. ,--. ,--.    ,------.  ,--.,------.,------.");
            Console.WriteLine(@" \  `.'  /'  .-.  '|  | |  |    |  .-.  \ |  ||  .---'|  .-.  \");
            Console.WriteLine(@"  '.    / |  | |  ||  | |  |    |  |  \  :|  ||  `--, |  |  \  :");
            Console.WriteLine(@"    |  |  '  '-'  ''  '-'  '    |  '--'  /|  ||  `---.|  '--'  /");
            Console.WriteLine(@"    `--'   `-----'  `-----'     `-------' `--'`------'`-------'");
            Console.WriteLine(@" ,----.     ,---.  ,--.   ,--.,------.     ,-----.,--.   ,--.,------.,------.");
            Console.WriteLine(@"'  .-./    /  O  \ |   `.'   ||  .---'    '  .-.  '\  `.'  / |  .---'|  .--. '");
            Console.WriteLine(@"|  | .---.|  .-.  ||  |'.'|  ||  `--,     |  | |  | \     /  |  `--, |  '--'.'");
            Console.WriteLine(@"'  '--'  ||  | |  ||  |   |  ||  `---.    '  '-'  '  \   /   |  `---.|  |\  \");
            Console.WriteLine(@" `------' `--' `--'`--'   `--'`------'     `-----'    `-'    `------'`--' '--' ");
        }
        
        public void Win()
        {
            Console.Clear();
            Console.WriteLine(@",--.   ,--.,-----. ,--. ,--.    ,--.   ,--.,--.,--.  ,--.");
            Console.WriteLine(@" \  `.'  /'  .-.  '|  | |  |    |  |   |  ||  ||  ,'.|  |");
            Console.WriteLine(@"  '.    / |  | |  ||  | |  |    |  |.'.|  ||  ||  |' '  |");
            Console.WriteLine(@"    |  |  '  '-'  ''  '-'  '    |   ,'.   ||  ||  | `   |");
            Console.WriteLine(@"    `--'   `-----'  `-----'     '--'   '--'`--'`--'  `--'");
            Console.WriteLine(@" ,----.   ,------. ,------.  ,---. ,--------.         ,--. ,-----. ,-----.");
            Console.WriteLine(@"'  .-./   |  .--. '|  .---' /  O  \'--.  .--'         |  |'  .-.  '|  |) /_");
            Console.WriteLine(@"|  | .---.|  '--'.'|  `--, |  .-.  |  |  |       ,--. |  ||  | |  ||  .-.  \");
            Console.WriteLine(@"'  '--'  ||  |\  \ |  `---.|  | |  |  |  |       |  '-'  /'  '-'  '|  '--' / ");
            Console.WriteLine(@" `------' `--' '--'`------'`--' `--'  `--'        `-----'  `-----' `------'");
        }
    }


    class Player
    {
        public int playerXPos;
        public int playerYPos;
        public bool hasSpeed;
        public bool hasFreeze;

        public Player()
        {
            playerXPos = 0;
            playerYPos = 0;
            hasSpeed = false;
            hasFreeze = false;
        }

        public void NormalMove(char dir, int xlow, int xhigh, int ylow, int yhigh)
        {
            if (dir == 'w')
            {
                if (playerYPos == yhigh)
                    playerYPos = -playerYPos;
                else
                    playerYPos++;
            }
            else if (dir == 'd')
            {
                if (playerXPos == xhigh)
                    playerXPos = -playerXPos;
                else
                    playerXPos++;
            }
            else if (dir == 's')
            {
                if (playerYPos == ylow)
                    playerYPos = -playerYPos;
                else
                    playerYPos--;
            }
            else if (dir == 'a')
            {
                if (playerXPos == xlow)
                    playerXPos = -playerXPos;
                else
                    playerXPos--;
            }
        }

        public void SpeedMove(char dir, int xlow, int xhigh, int ylow, int yhigh)
        {
            if (dir == 'w')
            {
                if (playerYPos >= yhigh)
                    playerYPos = -playerYPos;
                else
                    playerYPos += 2;
            }
            else if (dir == 'd')
            {
                if (playerXPos >= xhigh)
                    playerXPos = -playerXPos;
                else
                    playerXPos += 2;
            }
            else if (dir == 's')
            {
                if (playerYPos <= ylow)
                    playerYPos = -playerYPos;
                else
                    playerYPos -= 2;
            }
            else if (dir == 'a')
            {
                if (playerXPos >= xlow)
                    playerXPos = -playerXPos;
                else
                    playerXPos -= 2;
            }
        }
    }

    class Monster
    {
        public int monsterXPos;
        public int monsterYPos;
        Random rnd = new Random();

        public Monster(int xlow, int xhigh, int ylow, int yhigh)
        {
            monsterXPos = rnd.Next(xlow, xhigh);
            monsterYPos = rnd.Next(ylow, yhigh);
        }

        public void Move(Player play)
        {
            if (play.playerXPos > monsterXPos)
                monsterXPos++;
            if (play.playerXPos < monsterXPos)
                monsterXPos--;
            if (play.playerYPos > monsterYPos)
                monsterYPos++;
            if (play.playerYPos < monsterYPos)
                monsterXPos--;
        }
    }

    abstract class PowerUp
    {
        public int durationOnField;
        public int durationOfUse;
        public int PUXPos;
        public int PUYPos;
        public string Name;
        public bool onField;
    }

    class Speed : PowerUp
    {
        public int durationOnField;
        public int durationOfUse;
        public int PUXPos;
        public int PUYPos;
        public string Name;
        public bool onField;

        public Speed(int puxmin, int puxmax, int puymin, int puymax)
        {
            Name = "Speed";
            durationOnField = 2;
            durationOfUse = 2;
            PUXPos = new Random().Next(puxmin, puxmax);
            PUYPos = new Random().Next(puymin, puymax);
            onField = true;
        }
    }

    class Freeze : PowerUp
    {
        public int durationOnField;
        public int durationOfUse;
        public int PUXPos;
        public int PUYPos;
        public string Name;
        public bool onField;

        public Freeze(int puxmin, int puxmax, int puymin, int puymax)
        {
            Name = "Freeze";
            durationOnField = 2;
            durationOfUse = 1;
            PUXPos = new Random().Next(puxmin, puxmax);
            PUYPos = new Random().Next(puymin, puymax);
            onField = true;
        }
    }

    class MainClass
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.initializeGame();
            while (game.survivalCount > 0 && game.gameOver == false)
            {
                game.Turn();
            }
            if (game.gameOver == true)
                game.Lose();
            else if (game.gameOver == false)
                game.Win();
        }
    }
}