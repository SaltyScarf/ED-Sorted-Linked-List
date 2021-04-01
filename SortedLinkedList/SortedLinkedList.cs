using System;

namespace SortedLinkedList
{
    public class SortedLinkedList<T> where T : IComparable<T>
    {
        private int _count;
        private Node<T> _head;
        private Node<T> _tail;
        
        public int Count { get{ return _count; }}
        
        public Node<T> Head { get{ return _head; }}
        
        public Node<T> Tail { get{ return _tail; }}

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

            if (_head == null)
            {
                _head = temp;
                _tail = _head;
            }
            else
            {
                Node<T> currentNode = _head;
                Node<T> previousNode = null;

                while (true)
                {
                    if (data.CompareTo(currentNode.Data) == 1)
                    {
                        if (currentNode.NextNode == null)
                        {
                            currentNode.NextNode = temp;
                            _tail = temp;
                            
                            break;
                        }

                        previousNode = currentNode;
                        currentNode = currentNode.NextNode;
                    }
                    else
                    {
                        if (previousNode == null)
                        {
                            _head = temp;
                            _head.NextNode = currentNode;
                            
                            break;
                        }

                        previousNode.NextNode = temp;
                        temp.NextNode = currentNode;
                        
                        break;
                    }
                }

                _count++;
            }
        }

        public bool RemoveItem(T data)
        {
            bool status = false;

            Node<T> currentNode = _head;
            Node<T> previousNode = null;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    status = true;
                    
                    if (previousNode != null)
                    {
                        previousNode.NextNode = currentNode.NextNode;

                        if (currentNode.NextNode == null)
                        {
                            _tail = previousNode;
                        }
                    }
                    else
                    {
                        _head = currentNode.NextNode;

                        if (currentNode.NextNode == null)
                        {
                            _tail = null;
                        }
                    }

                    _count--;
                    
                    break;
                }
                
                previousNode = currentNode;
                currentNode = currentNode.NextNode;
            }

            return status;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void PrintList()
        {
            Node<T> currentNode = _head;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);

                currentNode = currentNode.NextNode;
            }
        }
    }
}