using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterChase2
{
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
        public virtual void Update() { }
    }

    //abstract class Component
    //{
    //    public GameObject Owner { get; set; }
    //    public virtual void Update() { }
    //}
}
