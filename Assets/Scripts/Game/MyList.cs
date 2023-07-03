using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GenericList<T>
{
    class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }
    Node Head { get; set; }
    public int Count = 0;
    public void AddNoteAtStart(T value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
            Count = Count + 1;
        }
        else
        {
            Node tmp = Head;
            Head = newNode;
            Head.Next = tmp;
            Count = Count + 1;
        }
    }
    public void AddNodeAtEnd(T value)
    {
        if (Head == null)
        {
            AddNoteAtStart(value);
        }
        else if (Head != null)
        {
            Node tmp = Head;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            Node newNode = new Node(value);
            tmp.Next = newNode;
            Count = Count + 1;
        }
    }
    public void AddNodeAtPosition(T value, int position)
    {
        if (position == 0)
        {
            AddNoteAtStart(value);
        }
        else if (position == Count)
        {
            AddNodeAtEnd(value);
        }
        else if (position > Count)
        {
            Debug.Log("Eso no se puede hacer");
        }
        else
        {
            int currentPosition = 0;
            Node tmp = Head;
            while (currentPosition < position - 1)
            {
                tmp = tmp.Next;
                currentPosition = currentPosition + 1;
            }
            Node nodeAtPosition = tmp.Next;
            Node newNode = new Node(value);
            tmp.Next = newNode;
            newNode.Next = nodeAtPosition;
            Count = Count + 1;
        }
    }
    public void ModifyAtStart(T value)
    {
        if (Head == null)
        {
            Debug.Log("Eso no se puede hacer");
        }
        else
        {
            Head.Value = value;
        }
    }
    public void ModifyAtEnd(T value)
    {
        Node tmp = Head;
        while (tmp.Next != null)
        {
            tmp = tmp.Next;
        }
        tmp.Value = value;
    }
    public void ModifyAtPosition(T value, int position)
    {
        if (position == 0)
        {
            ModifyAtStart(value);
        }
        else if (position == Count - 1)
        {
            ModifyAtEnd(value);
        }
        else if (position > Count)
        {
            Debug.Log("Eso no se puede");
        }
        else
        {
            int iterator = 0;
            Node tmp = Head;
            while (iterator < Count - 2)
            {
                iterator = iterator + 1;
                tmp = tmp.Next;
            }
            tmp.Value = value;
        }
    }
    public void PrintAllNodes()
    {
        Node tmp = Head;
        while (tmp != null)
        {
            Debug.Log(tmp.Value + " ");
            tmp = tmp.Next;
        }
    }
    public T GetNodeAtStart()
    {
        if (Head == null)
        {
            throw new ExitGUIException();
        }
        else
        {
            return Head.Value;
        }
    }
    public T GetNodeAtEnd()
    {
        if (Head == null)
        {
            throw new ExitGUIException();
        }
        else
        {
            Node tmp = Head;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            return tmp.Value;
        }
    }
    public T GetNodeAtPosition(int position)
    {
        if (position == 0)
        {
            return GetNodeAtStart();
        }
        else if (position == Count - 1)
        {
            return GetNodeAtEnd();
        }
        else if (position > Count)
        {
            throw new ExitGUIException();
        }
        else
        {
            int iterator = 0;
            Node tmp = Head;
            while (iterator < position)
            {
                tmp = tmp.Next;
                iterator = iterator + 1;
            }
            return tmp.Value;
        }
    }
    public void RemoveAtStart()
    {
        if (Head == null)
        {
            Debug.Log("Eso no se puede hacer");
        }
        else
        {
            Node newHead = Head.Next;
            Head.Next = null;
            Head = null;
            Head = newHead;
            Count = Count - 1;
        }
    }
    public void RemoveAtEnd()
    {
        Node tmp = Head;
        while (tmp.Next.Next != null)
        {
            tmp = tmp.Next;
        }
        Node finalNode = tmp.Next;
        finalNode = null;
        tmp.Next = null;
        Count = Count - 1;
    }
    public void RemoveNodeAtPosition(int position)
    {
        if (position == 0)
        {
            RemoveAtStart();
        }
        else if (position == Count - 1)
        {
            RemoveAtEnd();
        }
        else if (position > Count)
        {
            Debug.Log("Eso no se puede hacer");
        }
        else
        {
            int iterator = 0;
            Node previousNode = Head;
            while (iterator < position - 1)
            {
                previousNode = previousNode.Next;
                iterator = iterator + 1;
            }
            Node currentNode = previousNode.Next;
            Node nextNode = currentNode.Next;

            currentNode.Next = null;
            currentNode = null;

            previousNode.Next = null;

            previousNode.Next = nextNode;
            Count = Count - 1;
        }
    }
}
