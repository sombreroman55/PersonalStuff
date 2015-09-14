using System;
class KeyboardControllerComponent : Component
{
    public int Speed { get; set; }
    public KeyboardControllerComponent()
    {
        Speed = 1;
    }
    public override void Update()
    {
        Console.WriteLine("Where will you go next? (w - up, a - left, s - down, d - right)");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine();
        switch(choice)
        {
            case 'w':
                Owner.Y += Speed;
                break;
            case 's':
                Owner.Y -= Speed;
                break;
            case'a':
                Owner.X -= Speed;
                break;
            case 'd':
                Owner.X += Speed;
                break;
        }
    }
}
