using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    class DoubleCircularNode<T>
    {
        public class Node
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
        public int count;
        public Node tmp1;
        public Node GetLastNode()
        {
            while (tmp1.Next != Head)
            {
                tmp1 = tmp1.Next;
            }
            return tmp1;
        }
    public Node GetHead()
    {
        tmp1 = Head;
        return tmp1;
    }
    public Node NexNode()
    {
        tmp1 = tmp1.Next;
        return tmp1;
    } 
    public Node PreviousNode()
    {
        tmp1 = tmp1.Previous;
        return tmp1;
    }
    public void InsertNodeAtStart(T value)
        {
            if(Head == null)
            {
                Node newNode= new Node(value);
                newNode.Next = newNode;
                newNode.Previous = newNode;
                Head = newNode;
                count++;
            }
            else
            {
                Node lastNode = GetLastNode();
                Node newNode=new Node(value);
                newNode.Next=Head;
                Head.Previous=newNode;
                newNode.Previous=lastNode;
                lastNode.Next=newNode;
                Head = newNode;
                count++;
            }
        }
        public void InsertNodeAtEnd(T value)
        {
            if(Head == null)
            {
                InsertNodeAtStart(value);
            }
            else
            {
                Node lastNode=GetLastNode();
                Node newNode=new Node(value);
                newNode.Previous = lastNode;
                lastNode.Next=newNode;
                newNode.Next = Head;
                Head.Previous=newNode;
                count++;
            }
        }
        public void InsertNodeAtPosition(T value, int position)
        {
            if (position == 0)
            {
                InsertNodeAtStart(value);
            }
            else if (position == count - 1)
            {
                InsertNodeAtEnd(value);
            }
            else if (position >= count || position < 0)
            {
                Debug.Log("Acceso denegado rufian");
            }
            else
            {
                Node previousPosition = Head;
                int iterator = 0;
                while (iterator < position - 1)
                {
                    previousPosition = previousPosition.Next;
                    iterator = iterator + 1;
                }
                Node newNode = new Node(value);
                newNode.Next = previousPosition.Next;
                previousPosition.Next.Previous=newNode;
                previousPosition.Next = newNode;
                newNode.Previous = previousPosition;
                count++;
            }
        }
        public void ModifyAtStart(T value)
        {
            if (Head == null)
            {
                Debug.Log("Acceso denegado rufian");
            }
            else
            {
                Head.Value = value;
            }
        }
        public void ModifyAtEnd(T value)
        {
            if (Head == null)
            {
                Debug.Log("Acceso denegado rufian");
            }
            else
            {
                Node node = GetLastNode();
                node.Value = value;
            }
        }
        public void ModifyAtPosition(T value, int position)
        {
            if (position == 0)
            {
                ModifyAtStart(value);
            }
            else if (position == count - 1)
            {
                ModifyAtEnd(value);
            }
            else
            {
                Node tmp = Head;
                int iterator = 0;
                while (iterator > position)
                {
                    tmp = tmp.Next;
                    iterator++;
                }
                tmp.Value = value;
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
                return GetLastNode().Value;
            }
        }
        public T GetNodeAtPosition(int position)
        {
            if (position == 0)
            {
                return GetNodeAtStart();
            }
            else if (position == count - 1)
            {
                return GetNodeAtEnd();
            }
            else if (position >= count || position < 0)
            {
                throw new ExitGUIException();
            }
            else
            {
                Node tmp = Head;
                int iterator = 0;
                while (iterator < position)
                {
                    tmp = tmp.Next;
                    iterator++;
                }
                return tmp.Value;
            }
        }
        public void DeleteAtStart()
        {
            if(Head == null)
            {
                Debug.Log("Acceso denegado rufian");
            }
            else
            {
                Node lastNode=GetLastNode();
                Node newHead = Head.Next;
                lastNode.Next = newHead;
                newHead.Previous = lastNode;
                Head.Next = null;
                Head.Previous = null;
                Head = newHead;
                count--;
            }
        }
        public void DeleteAtEnd()
        {
            if(Head == null)
            {
                Debug.Log("Acceso denegado rufian");
            }
            else
            {
                Node lastNode = GetLastNode();
                Node newLastNode = lastNode.Previous;
                lastNode.Next=null;
                lastNode.Previous = null;
                newLastNode.Next = Head;
                Head.Previous = newLastNode;
                count--;
            }
        }
        public void DeleteAtPosition(int position)
        {
            if (position == 0)
            {
                DeleteAtStart();
            }
            else if (position == count - 1)
            {
                DeleteAtEnd();
            }
            else if (position >= count || position < 0)
            {
                Debug.Log("Acceso denegado rufian");
            }
            else
            {
                Node ActualNode = Head;
                int iterator = 0;
                while (iterator < position)
                {
                    iterator++;
                    ActualNode = ActualNode.Next;
                }
                Node newNodePrevious= ActualNode.Previous;//--1
                Node newNodeNext= ActualNode.Next;//--3
                newNodePrevious.Next = newNodeNext;//1->3
                newNodeNext.Previous = newNodePrevious;//1<-3
                ActualNode.Next = null;
                ActualNode.Previous = null;
                count--;
            }
        }
        public void PrintAllNodes()
        {
            Node tmp = Head;
            while (tmp.Next != Head)
            {
                Debug.Log(tmp.Value + " ");
                tmp = tmp.Next;
            }
            Debug.Log(tmp.Value + " ");
        }
        public void PrintAllNodesReverse()
        {
            Node tmp = GetLastNode();
            while (tmp.Previous != GetLastNode())
            {
                Debug.Log(tmp.Value + " ");
                tmp = tmp.Previous;
            }
            Debug.Log(tmp.Value + " ");
        }
    }

