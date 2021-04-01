using System;

namespace SortedLinkedList
{
    internal class Program
    {
        public static void Main()
        {
            SortedLinkedList<int> newList = new SortedLinkedList<int>(4, 7, 1, 8, 9, 5);

            Console.WriteLine(newList.BoolSearch(1));
        }
    }
}