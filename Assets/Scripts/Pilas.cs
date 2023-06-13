using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Pila<T>
    {
        class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public Node(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
        }
        private Node Head;
        private Node Top;
        public int Count = 0;

        public void Push(T value)
        {
            if (Head == null)
            {
                Node newNode = new Node(value);
                Head = newNode;
                Top = newNode;
                Count++;
            }
            else
            {
                Node newNode = new Node(value);
                newNode.Previous = Top;
                Top.Next = newNode;
                Top = newNode;
                Count++;
            }
        }
        public void Pop()
        {
            if (Count == 0)
            {
                Debug.Log("La pila esta vacia");
            }
            else
            {
                Node tmp = Top.Previous;
                tmp.Next = null;
                Top.Previous = null;
                Top = tmp;
                Count--;
            }
        }
    }
