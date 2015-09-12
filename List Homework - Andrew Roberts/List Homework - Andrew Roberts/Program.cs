using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace List_Homework___Andrew_Roberts
{
    //Solutions for Andrew Roberts
    //March 9, 2015
    //uNID: u0597321

    class MainClass
    {
        static void Main(string[] args)
        {
            //Test Lists ✓
            List meList1 = new List();
            List meList2 = new List();
            List meList3 = new List();

            //Append Tests ✓
            meList1.Append(4);
            Debug.Assert(meList1[0] == 4);
            meList1.Append(1);
            Debug.Assert(meList1[1] == 1);
            meList1.Append(22);
            Debug.Assert(meList1[2] == 22);
            meList1.Append(6);
            Debug.Assert(meList1[3] == 6);
            meList1.Append(3);
            Debug.Assert(meList1[4] == 3);
            meList1.Append(6);
            Debug.Assert(meList1[5] == 6);
            meList1.Append(5);
            Debug.Assert(meList1[6] == 5);
            meList1.Append(9);
            Debug.Assert(meList1[7] == 9);

            //Contains Tests ✓
            Debug.Assert(meList1.Contains(4));
            Debug.Assert(meList1.Contains(6));
            Debug.Assert(meList1.Contains(100) == false);
            Debug.Assert(meList1.Contains(-33) == false);

            //Remove Tests ✓
            Debug.Assert(meList1.Remove(6) == true);
            Debug.Assert(meList1[3] == 3);
            Debug.Assert(meList1.Remove(9) == true);
            Debug.Assert(meList1[6] == 0);
            Debug.Assert(meList1.Remove(400) == false); //should do nothing

            //Reverse Tests ✓
            meList2.Append(0);
            meList2.Append(1);
            meList2.Append(2);
            meList2.Append(3);
            meList2.Append(4);
            meList2.Append(5);
            meList2.Append(6);
            meList2.Append(7);
            meList2.Append(8);
            meList2.Append(9);
            meList2.Reverse();
            for (int i = 0; i < meList2.Count; i++)
            {
                Debug.Assert(meList2[i] == (meList2.Count - 1) - i);
            }

            //CopyTo Tests ✓
            int[] copyTest = new int[20];
            meList1.CopyTo(copyTest);
            for (int i = 0; i < meList1.Count; i++)
            {
                Debug.Assert(meList1[i] == copyTest[i]);
            }

            meList3.Append(0);
            meList3.Append(1);
            meList3.Append(2);
            meList3.Append(3);
            meList3.Append(4);
            meList3.Append(5);
            meList3.Append(6);
            meList3.Append(7);
            meList3.Append(8);
            meList3.Append(9);

            //IndexOf Tests ✓
            Debug.Assert(meList3.IndexOf(4) == 4);
            Debug.Assert(meList3.IndexOf(0) == 0);
            Debug.Assert(meList3.IndexOf(8) == 8);
            Debug.Assert(meList3.IndexOf(-44) == -1);

            //Insert Tests ✓
            meList2.Insert(5, 33);
            Debug.Assert(meList2[5] == 33);
            meList2.Insert(1, 245);
            Debug.Assert(meList2[1] == 245);
            meList2.Insert(9, -9);
            Debug.Assert(meList2[9] == -9);

            //Sort Tests ✓
            meList2.Sort();
            for (int i = 0; i < meList2.Count - 1; i++)
            {
                Debug.Assert(meList2[i] <= meList2[i + 1]);
            }


            //BinarySearch Tests ✓
            Debug.Assert(meList3.BinarySearch(0) == 0);
            Debug.Assert(meList3.BinarySearch(8) == 8);
            Debug.Assert(meList3.BinarySearch(400) == -1);

            //Clear Tests ✓
            meList1.Clear();
            Debug.Assert(meList1[0] == 0);
            Debug.Assert(meList1[1] == 0);
            Debug.Assert(meList1[2] == 0);
            Debug.Assert(meList1[3] == 0);
            Debug.Assert(meList1.Count == 0);


        }
    }


    class List
    {
        int[] arr = new int[4];
        int count = 0;

        // Returns the number of items in the list.
        public int Count { get { return count; } }
        public int this[int index] { get { return arr[index]; } set { arr[index] = value; } }

        // Adds an item to the end of the list
        public void Append(int value)
        {
            growIfNecessary();
            arr[count] = value;
            count++;
        }

        // Returns the index of the given item. List must
        // be sorted to call this function.
        public int BinarySearch(int value)
        {
            Sort();
            int first = 0;
            int mid = 0;
            int last = count;
            while (first <= last)
            {
                mid = (first + last) / 2;
                if (value > arr[mid])
                    first = mid + 1;
                else if (value < arr[mid])
                    last = mid - 1;
                else
                    return mid;
            }
            return -1;
        }

        // Clears the entire list
        public void Clear()
        {
            arr = new int[4];
            count = 0;
        }

        // Returns true if the list contains the value.
        public bool Contains(int value)
        {
            for (int i = 0; i < count; i++)
                if (arr[i] == value)
                    return true;
            return false;
        }

        // Copies the entire list contents to the given array.
        public void CopyTo(int[] array)
        {
            for (int i = 0; i < arr.Length; i++)
                array[i] = arr[i];
        }

        // Returns the index of the given value.
        public int IndexOf(int value)
        {
            for (int i = 0; i < count; i++)
                if (arr[i] == value)
                    return i;
            return -1;                      // returns -1 if value not found.
        }

        // Inserts the given value at the index.
        public void Insert(int index, int value)
        {
            if (index > count || index < 0)
                throw new Exception("Please enter a valid index value.");
            else
            {
                growIfNecessary();
                for (int i = count; i >= index; i--)
                    arr[i + 1] = arr[i];
                arr[index] = value;
                count++;
            }
        }

        // Removes the given value
        public bool Remove(int value)
        {
            for (int i = 0; i < count; i++)
            {
                if (arr[i] == value)
                {
                    for (int j = i; j < count; j++)
                    {
                        arr[j] = arr[j+1];
                    }
                    count--;
                    return true;
                }
            }
            return false;
        }

        // Reverses the contents of the list
        public void Reverse()
        {
            if (arr.Length % 2 == 0)
            {
                for (int i = 0; i < count / 2; i++)
                {
                    int temp = arr[i];
                    arr[i] = arr[(count - 1) - i];
                    arr[(count - 1) - i] = temp;
                }
            }
            else
            {
                for (int i = 0; i <= count / 2; i++)
                {
                    int temp = arr[i];
                    arr[i] = arr[(count - 1) - i];
                    arr[(count - 1) - i] = temp;
                }
            }
        }

        // Sorts the contents of the list
        public void Sort()
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        private void growIfNecessary()
        {
            if (count + 1 == arr.Length)
            {
                int[] twiceArr = new int[(arr.Length * 2)];
                for (int i = 0; i < arr.Length; i++)
                    twiceArr[i] = arr[i];
                arr = twiceArr;
            }
        }
    }
}