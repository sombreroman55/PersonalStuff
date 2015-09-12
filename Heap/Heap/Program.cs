// Solution for Andrew Roberts
// Assignment 10 - Heaps

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            // myHeap1 for Sort test
            Heap myHeap1 = new Heap();
            myHeap1.Insert(20);
            myHeap1.Insert(32);
            myHeap1.Insert(2);
            myHeap1.Insert(25);
            myHeap1.Insert(35);
            myHeap1.Insert(814);
            myHeap1.Insert(-5);
            myHeap1.Insert(0);
            myHeap1.Insert(16);
            myHeap1.Insert(77);

            myHeap1.Sort();
            for (int i = 0; i < myHeap1.heapIndex; i++)
                Debug.Assert(myHeap1[i] < myHeap1[i + 1]);

            // myHeap2 Insert and RemoveMax tests
            Heap myHeap2 = new Heap();
            myHeap2.Insert(65);
            myHeap2.Insert(35);
            myHeap2.Insert(9);
            myHeap2.Insert(272);
            myHeap2.Insert(6245);
            myHeap2.Insert(30);
            myHeap2.Insert(918);
            myHeap2.Insert(4);
            myHeap2.Insert(-6);
            myHeap2.Insert(1);

            int currRemoval = myHeap2.RemoveMax();
            while (myHeap2.heapIndex > 1)
            {
                int lastRemoval = currRemoval;
                currRemoval = myHeap2.RemoveMax();
                Debug.Assert(lastRemoval > currRemoval);
            }
        }
    }
 
    class Heap
    {
        public int[] heap;
        public int heapIndex;
        public int sortIndex;
        public Heap()
        {
            heap = new int[10];
            heapIndex = 1;
            sortIndex = 1;
        }

        public int this[int index]
        {
            get { return heap[index + 1]; }
        }
 
        public void Insert(int value)
        {
            growIfNecessary();
            heap[heapIndex] = value;
            Swim();
            heapIndex++;
        }
 
        public void Swap(int id1, int id2)
        {
            int temp = heap[id1];
            heap[id1] = heap[id2];
            heap[id2] = temp;
        }
 
        public int RemoveMax()
        {
            int result = heap[1];
            Sink();
            heapIndex--;
            return result;
        }
 
        public void Sort()
        {
            while (heapIndex-1 > 0)
            {
                RemoveMax();
                sortIndex++;
            }
        }

        public void buildHeap()
        {
            while (sortIndex-1 > 0)
            {
                Insert(heap[heapIndex]);
                sortIndex--;
            }
        }

        private void Swim()
        {
            int count = heapIndex;
            while (count > 1 && heap[count] > heap[count / 2])
            {
                Swap(count, (count / 2));
                count = count / 2;
            }
        }

        private void Sink()
        {
            Swap(1, (heapIndex - 1));
            int count = 1;
            if ( (heapIndex - 1) == 3)
            {
                if (heap[count] < heap[count * 2])
                    Swap(count, count * 2);
            }
            else
            {
                while ((count * 2) < (heapIndex - 2) && (heap[count] < heap[count * 2] || heap[count] < heap[count *2 +1]))
                {
                    if (heap[count * 2] > heap[count * 2 + 1])
                    {
                        Swap(count, (count * 2));
                        count = count * 2;
                    }
                    else if (heap[count * 2] < heap[count * 2 + 1])
                    {
                        Swap(count, (count * 2 + 1));
                        count = (count * 2 + 1);
                    }
                }
            }
        }

        private void growIfNecessary()
        {
            if (heapIndex + 1 == heap.Length)
            {
                int[] twiceHeap = new int[(heap.Length * 2)];
                for (int i = 0; i < heap.Length; i++)
                    twiceHeap[i] = heap[i];
                heap = twiceHeap;
            }
        }
    }
}
 
/* a heap is a type of binary tree that is considered "full".
 * in a heap, the biggest value is always on top
 * a heap is stored as an array!
 * ref makes the computer pass references rather than copying values
 */