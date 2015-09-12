using System;

class Card
{
    String[] Suits = { "Diamonds", "Hearts", "Clubs", "Spades" };
    String[] Values = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
                       "Nine", "Ten", "Jack", "Queen", "King"};
    public String suit;
    public String value;
    Random rnd = new Random();

    public Card()
    {
        suit = Suits[(rnd.Next(Suits.Length))];
        value = Values[(rnd.Next(Values.Length))];
    }

    public int GetValue(String str)
    {
        int val = 0;
        if (str == "Ace")
            val = 11;
        else if (str == "Two")
            val = 2;
        else if (str == "Three")
            val = 3;
        else if (str == "Four")
            val = 4;
        else if (str == "Five")
            val = 5;
        else if (str == "Six")
            val = 6;
        else if (str == "Seven")
            val = 7;
        else if (str == "Eight")
            val = 8;
        else if (str == "Nine")
            val = 9;
        else if (str == "Ten")
            val = 10;
        else if (str == "Jack")
            val = 10;
        else if (str == "Queen")
            val = 10;
        else if (str == "King")
            val = 10;
        return val;
    }

    public override string ToString()
    {
        return value + " of " + suit;
    }
}