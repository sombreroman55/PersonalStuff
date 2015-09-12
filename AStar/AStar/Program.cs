/*Write the A* algorithm.

- Prompt the user for the start node.
- Prompt the user for the end node.
- Display the (mostly) shortest path found by your A* algorithm.
- Use all of nodes in the map associated with this assignment. The location data is at the bottom of this file.
- Also, don't use ints. Use floats instead.

Solutions for Andrew Roberts
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{

    class Node
    {
        public string id;
        public float x;
        public float y;
        public Node[] targets;
        public Node(string id, float x, float y, int numTargets)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            targets = new Node[numTargets];
        }
    }

    class Program
    {
        static Node[] nodes;
        static Node start;
        static Node end;
        static void Main()
        {
            InitializeMap();
            GetEndpoints();
            RunAStar();
            PrintPath();
        }

        private static void PrintPath()
        {
            throw new System.NotImplementedException();
        }

        private static void RunAStar()
        {
            throw new System.NotImplementedException();
        }

        private static void GetEndpoints()
        {
            Console.WriteLine("Where do you want to start?");
            char s = Console.ReadLine()[0];
            Console.WriteLine("Where do you want to end?");
            char e = Console.ReadLine()[0];
            start = nodes[s - 'a'];
            end = nodes[e - 'a'];
        }

        private static void InitializeMap()
        {
            Node a = new Node("A", -19, 11, 2);
            Node b = new Node("B", -13, 13, 2);
            Node c = new Node("C", 4, 14, 3);
            Node d = new Node("D", -4, 12, 3);
            Node e = new Node("E", -8, 3, 6);
            Node f = new Node("F", -18, 1, 2);
            Node g = new Node("G", -12, -8, 3);
            Node h = new Node("H", 12, -9, 2);
            Node i = new Node("I", -18, -11, 2);
            Node j = new Node("J", -4, -11, 4);
            Node k = new Node("K", -12, -14, 3);
            Node l = new Node("L", 2, -18, 3);
            Node m = new Node("M", 18, -13, 3);
            Node n = new Node("N", 4, -9, 2);
            Node o = new Node("O", 22, 11, 2);
            Node p = new Node("P", 18, 3, 4);

            //nodes connected to a (2)
            a.targets[0] = b;
            a.targets[1] = e;

            //nodes connected to b (2)
            b.targets[0] = a;
            b.targets[1] = d;

            //nodes connected to c (3)
            c.targets[0] = d;
            c.targets[1] = e;
            c.targets[2] = p;

            //nodes connected to d (3)
            d.targets[0] = b;
            d.targets[1] = e;
            d.targets[2] = c;

            //nodes connected to e (6)
            e.targets[0] = a;
            e.targets[1] = c;
            e.targets[2] = d;
            e.targets[3] = g;
            e.targets[4] = j;
            e.targets[5] = n;

            //nodes connected to f (2)
            f.targets[0] = g;
            f.targets[1] = i;

            //nodes connected to g (3)
            g.targets[0] = e;
            g.targets[1] = f;
            g.targets[2] = j;

            //nodes connected to h (2)
            h.targets[0] = n;
            h.targets[1] = p;

            //nodes connected to i (2)
            i.targets[0] = f;
            i.targets[1] = k;

            //nodes connected to j (4)
            j.targets[0] = e;
            j.targets[1] = g;
            j.targets[2] = k;
            j.targets[3] = l;

            //nodes connected to k (3)
            k.targets[0] = i;
            k.targets[1] = j;
            k.targets[2] = l;

            //nodes connected to l (3)
            l.targets[0] = j;
            l.targets[1] = k;
            l.targets[2] = m;

            //nodes connected to m (3)
            m.targets[0] = l;
            m.targets[1] = o;
            m.targets[2] = p;

            //nodes connected to n (2)
            n.targets[0] = e;
            n.targets[1] = h;

            //nodes connected to o (2)
            o.targets[0] = m;
            o.targets[1] = p;

            //nodes connected to p (4)
            p.targets[0] = c;
            p.targets[1] = h;
            p.targets[2] = m;
            p.targets[3] = o;

            nodes = new Node[] { a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p };
        }
    }
}

//A: -19, 11
//B: -13, 13
//C: 4, 14
//D: -4, 12
//E: -8, 3
//F: -18, 1
//G: -12, -8
//H: 12, -9
//I: -18, -11
//J: -4, -11
//K: -12, -14
//L: 2, -18
//M: 18, -13
//N: 4, -9
//O: 22, 11
//P: 18, 3