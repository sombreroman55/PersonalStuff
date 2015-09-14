using System;

class Game
{
    Card[] playerHand = new Card[10];
    Card[] dealerHand = new Card[10];
    int playerHandCount = 0;
    int dealerHandCount = 0;
    int playerHandTotal = 0;
    int dealerHandTotal = 0;
    public bool Lost = false;
    public bool Won = false;
    public bool Draw = false;

    public void GameStart()
    { 
        while (playerHandCount < 2 && dealerHandCount < 2)
        {
            PlayerDeal();
            DealerDeal();
        }
    }

    public void Play()
    {
        PrintHands();
        PlayerMove();
        DealerMove();
        if (playerHandTotal > 21 || (dealerHandTotal <= 21 && dealerHandTotal > playerHandTotal))
            Lost = true;
        else if (dealerHandTotal > 21 || (playerHandTotal <= 21 && playerHandTotal > dealerHandTotal))
            Won = true;
        else
            Draw = true;
    }

    public void PlayerMove()
    {
        Console.WriteLine("Will you Hit(h) or Stay(s)?");
        char decision = Console.ReadLine().ToLower()[0];
        while (decision != 's')
            if (decision == 'h')
            {
                PlayerDeal();
            }
    }

    public void DealerMove()
    {
        while (dealerHandTotal < 17)
            DealerDeal();
    }

    void PlayerDeal()
    {
        playerHand[playerHandCount] = new Card();
        playerHandTotal += playerHand[playerHandCount].GetValue(playerHand[playerHandCount].value);
        playerHandCount++;
    }

    void DealerDeal()
    {
        dealerHand[dealerHandCount] = new Card();
        dealerHandTotal += dealerHand[dealerHandCount].GetValue(dealerHand[dealerHandCount].value);
        dealerHandCount++;
    }

    void PrintHands()
    {
        Console.WriteLine("The dealer is showing a " + dealerHand[1] + ".");
        Console.WriteLine("Your current hand total is " + playerHandTotal + ".");
        Console.WriteLine("You have a " + playerHand[0] + " and a " + playerHand[1] + ".");
    }


}