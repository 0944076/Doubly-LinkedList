using System;
using System.Collections.Generic;

namespace linkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class linkedList<T> where T:IComparable
    {
        public Node<T> Head;

        linkedList()
        {
            Head = null;
        }

        public void insert(T value)
        {
            var newNode = new Node<T>(value);
            if(Head == null || Head.Data.CompareTo(value) == 0)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }
            var currentnode = Head;
            while (currentnode.Next != null && currentnode.Next.Data.CompareTo(value) <= 0)
            {
                currentnode = currentnode.Next;
            }
            newNode.Next = currentnode.Next;
            currentnode.Next = newNode;
        }

        public void Delete(T value)
        {
            if(Head == null || Head.Data.CompareTo(value) == 0)
            {
                return;
            }
            else if (Head.Data.Equals(value))
            {
                Head = Head.Next;
            }

            var currentnode = Head;
            while(currentnode != null && currentnode.Next.Data.CompareTo(value) <= 0)
            {
                if(currentnode.Next.Data.Equals(value))
                {
                    currentnode.Next = currentnode.Next.Next;
                    return;
                }
                currentnode = currentnode.Next;
            }
            return;
        }

        public Node<T> Search(T value)
        {
            var currentnode = Head;
            while(!currentnode.Data.Equals(value) && currentnode != null)
            {
                currentnode = currentnode.Next;
            }
            return currentnode;
        }
    }

    public class Node<T> where T:IComparable
    {
        public Node<T> Next;
        public T Data;

        public Node(T data)
        {
            this.Data = data;
        }
    }
}

