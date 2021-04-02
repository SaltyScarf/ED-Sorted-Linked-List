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

        public T this[int index]
        {
            get
            {
                return ReturnSearch(index).Data;
            }
            set
            {
                ReturnSearch(index).Data = value;
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
        
        public void RemoveDuplicate()
        {
            int howMuch = 0;
                
            Node<T> currentMatch = _head;
            bool matchRepeats = false;

            Node<T> currentNode = _head.NextNode;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(currentMatch.Data))
                {
                    matchRepeats = true;

                    if (currentNode == _tail)
                    {
                        currentMatch.NextNode = null;
                        _tail = currentMatch;

                        _count--;

                        break;
                    }

                    howMuch++;
                }
                else
                {
                    if (matchRepeats)
                    {
                        currentMatch.NextNode = currentNode;
                        
                        matchRepeats = false;
                    }

                    currentMatch = currentNode;
                }

                currentNode = currentNode.NextNode;
            }

            howMuch -= 1;
            _count -= howMuch;
        }
        
        public bool BoolSearch(T data)
        {
            Node<T> currentNode = _head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    return true;
                }

                currentNode = currentNode.NextNode;
            }

            return false;
        }
        
        public int IndexSearch(T data)
        {
            Node<T> currentNode = _head;
            int index = 0;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    return index;
                }

                currentNode = currentNode.NextNode;
                index++;
            }

            return -1;
        }
        
        public Node<T> ReturnSearch (int index)
        {
            Node<T> currentNode = _head;
            int tempInd = 0;

            while (currentNode != null)
            {
                if (tempInd == index)
                {
                    return currentNode;
                }

                currentNode = currentNode.NextNode;
                tempInd++;
            }

            return null;
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