using System;

class Component
{
    public GameObject Owner { get; set; }
    public Game TheGame { get; set; }
    public bool Alive { get; set; }
    public Component()
    {
        Alive = true;
    }
    public virtual void Initialize() { }
    public virtual void Update(){}
}
