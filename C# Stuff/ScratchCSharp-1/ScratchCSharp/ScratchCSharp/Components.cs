using System;
using System.Collections.Generic;

class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public Point(int x = 0, int y = 0)
    {
        X = x;
        Y = y;
    }
    public static bool operator==(Point left, Point right)
    {
        return left.X == right.X && left.Y == right.Y;
    }
    public static bool operator !=(Point left, Point right)
    {
        return !(left == right);
    }
}

class GameObject
{
    List<Component> components = new List<Component>();
    public Point Position { get; set; }
    public GameObject()
    {
        Position = new Point();
    }

    public void AddComponent(Component component)
    {
        component.Owner = this;
        components.Add(component);
    }

    public void Update()
    {
        foreach (Component c in components)
            c.Update();
    }

    public override string ToString()
    {
        RenderComponent r = GetComponent<RenderComponent>();
        if (r == null)
            return "?";
        else
            return r.Symbol.ToString();
    }

    public T GetComponent<T>() where T : class
    {
        foreach(Component c in components)
        {
            T t = c as T;
            if (t != null)
                return t;
        }
        return null;
    }
}

abstract class Component
{
    public GameObject Owner { get; set; }
    public virtual void Update() { }
}

class KeyboardMoverComponent : Component
{
    public override void Update()
    {
        // WASD
        char direction = char.ToLower(Console.ReadKey().KeyChar);
        if (direction == 'w')
            Owner.Position.Y++;
        if (direction == 's')
            Owner.Position.Y--;
        if (direction == 'a')
            Owner.Position.X--;
        if (direction == 'd')
            Owner.Position.X++;
    }
}

class WrapAroundComponent : Component
{
    int halfSize;
    public WrapAroundComponent(int halfSize)
    {
        this.halfSize = halfSize;
    }
    public override void Update()
    {
        if (Owner.Position.Y > halfSize)
            Owner.Position.Y = -halfSize;
        if (Owner.Position.Y < -halfSize)
            Owner.Position.Y = halfSize;
        if (Owner.Position.X > halfSize)
            Owner.Position.X = -halfSize;
        if (Owner.Position.X < -halfSize)
            Owner.Position.X = halfSize;
    }
}

class KeepInBoundsComponent : Component
{
    int halfSize;
    public KeepInBoundsComponent(int halfSize)
    {
        this.halfSize = halfSize;
    }

    public override void Update()
    {
        if (Owner.Position.X > halfSize)
            Owner.Position.X = halfSize;
        if (Owner.Position.X < -halfSize)
            Owner.Position.X = -halfSize;
        if (Owner.Position.Y > halfSize)
            Owner.Position.Y = halfSize;
        if (Owner.Position.Y < -halfSize)
            Owner.Position.Y = -halfSize;
    }
}

class RenderComponent : Component
{
    public char Symbol { get; set; }
    public RenderComponent(char _symbol)
    {
        this.Symbol = _symbol;
    }
}