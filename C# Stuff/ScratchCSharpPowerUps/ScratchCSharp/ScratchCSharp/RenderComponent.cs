using System;

class RenderComponent : Component
{
    public char Symbol { get; set; }
    public RenderComponent(char _symbol)
    {
        this.Symbol = _symbol;
    }
}