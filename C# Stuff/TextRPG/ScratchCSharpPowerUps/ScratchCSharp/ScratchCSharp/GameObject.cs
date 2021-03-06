﻿using System.Collections.Generic;

class GameObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public Game TheGame { get; set; }
    public bool Alive { get; set; }
    public GameObject(Game theGame)
    {
        TheGame = theGame;
        Alive = true;
    }

    List<Component> components = new List<Component>();

    public void AddComponent(Component component)
    {
        component.Owner = this;
        components.Add(component);
    }

    public void RemoveComponent(Component component)
    {
        component.Owner = this;
        components.Remove(component);
    }

    public void Initialize()
    {
        foreach (Component c in components)
            c.Initialize();
    }

    public void Update()
    {
        foreach (Component component in components)
            component.Update();
        for (int i = 0; i < components.Count; i++)
            if (!components[i].Alive)
                components.RemoveAt(i--);
    }

    public T GetComponent<T>() where T : class
    {
        foreach(Component c in components)
        {
            T returnValue = c as T;
            if (returnValue != null)
                return returnValue;
        }
        return null;
    }

    public override string ToString()
    {
        RenderComponent r = GetComponent<RenderComponent>();
        if (r == null)
            return "?";
        else
            return r.Symbol.ToString();
    }
}
