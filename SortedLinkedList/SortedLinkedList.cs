using System;

namespace SortedLinkedList
{
    public class SortedLinkedList<T> where T : IComparable<T>
    {
        private int _count;
        private Node<T> Head;
        private Node<T> Tail;
        
        public int Count { get{ return _count; }}
        
        public Node<T> _Head { get{ return Head; }}
        
        public Node<T> _Tail { get{ return Tail; }}

        public SortedLinkedList(params T[] items)
        {
            foreach (T item in items)
            {
                AddItem(item);
            }
        }
        
        public void AddItem(T data)
        {
            Node<T> temp = new Node<T>(data);

            if (Head == null)
            {
                Head = temp;
                Tail = Head;
            }
            else
            {
                Node<T> currentNode = Head;
                Node<T> previousNode = null;

                while (true)
                {
                    if (data.CompareTo(currentNode.Data) == 1)
                    {
                        if (currentNode.NextNode == null)
                        {
                            currentNode.NextNode = temp;
                            Tail = temp;
                            
                            break;
                        }

                        previousNode = currentNode;
                        currentNode = currentNode.NextNode;
                    }
                    else
                    {
                        if (previousNode == null)
                        {
                            Head = temp;
                            Head.NextNode = currentNode;
                            
                            break;
                        }

                        previousNode.NextNode = temp;
                        temp.NextNode = currentNode;
                        
                        break;
                    }
                }
            }
        }

        public void PrintList()
        {
            Node<T> currentNode = Head;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);

                currentNode = currentNode.NextNode;
            }
        }
    }
}