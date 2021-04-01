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
    }
}