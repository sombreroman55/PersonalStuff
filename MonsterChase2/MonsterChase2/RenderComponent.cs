using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterChase2
{
    class RenderComponent : Component
    {
        public char Symbol { get; set; }
        public RenderComponent(char symbol)
        {
            this.Symbol = symbol;
        }
    }
}
