using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleLinkList<T>
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
        private int count;

        public void AddNodeAtStart(T value)
        {
            if (Head == null)
            {
                Node newNode = new Node(value);
                Head = newNode;
                count = count + 1;
            }
            else
            {
                Node newNode = new Node(value);
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
                count = count + 1;
            }
        }
    public void NexNode(T value)
    {
        Node tmp = Head;
        if (tmp != null)
        {
            tmp=tmp.Next;
        }
        else
        {
            Debug.Log("No hay otra habilidad");
        }
    }
        private Node GetLastNode()
        {
            Node LastNode = Head;
            while (LastNode.Next != null)
            {
                LastNode = LastNode.Next;
            }
            return LastNode;
        }
        public void AddNodeAtEnd(T value)
        {
            if (Head == null)
            {
                AddNodeAtStart(value);
            }
            else
            {
                Node lastnode = GetLastNode();
                Node newNode = new Node(value);

                lastnode.Next = newNode;
                newNode.Previous = lastnode;
                count = count + 1;
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

        public void PrintAllNodeReverse()
        {
            Node tmp = GetLastNode();
            while (tmp != null)
            {
                Debug.Log(tmp.Value + " ");
                tmp = tmp.Previous;
            }
        }

        public void AddNoteAtPosition(T value, int position)
        {
            if (position == 0)
            {
                AddNodeAtStart(value);
            }
            else if (position == count - 1)
            {
                AddNodeAtEnd(value);
            }
            else if (position >= count)
            {
                Debug.Log("Acceso denegado");
            }
            else
            {
                int iterator = 0;
                Node previous = Head;
                while (iterator < position - 1)
                {
                    previous = previous.Next;
                    iterator = iterator + 1;
                }

                Node next = previous.Next;
                Node newNode = new Node(value);
                // Previous = 7
                // Next = 4
                // NewNode = 8
                previous.Next = newNode; // 7 --> 8
                newNode.Previous = previous; // 8 <-- 7
                newNode.Next = next; // 8 --> 4
                next.Previous = newNode; // 4 <-- 8
                count = count + 1;
            }
        }
        /*public void ModifyAtStart(T value)
        {
            if (Head == null)
            {
                Debug.Log("No se puede papu");
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
                Debug.Log("No se puede papu");
            }
            else
            {
                Node lastNode = GetLastNode();
                lastNode.Value = value;
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
            else if (position >= count)
            {
                Debug.Log("No se puede papu");
            }
            else
            {
                int iterator = 0;
                Node tmp = Head;
                while (iterator < position)
                {
                    iterator = iterator + 1;
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }*/
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
        public void DeleteNodeAtStart()
        {
            if (Head == null)
            {
                Debug.Log("No se puede papu");
            }
            else
            {
                Node newHead = Head.Next;
                Head.Next = null;
                newHead.Previous = null;
                Head = newHead;
                count = count - 1;

            }
        }
        public void DeleteNodeAtEnd()
        {
            if (Head == null)
            {
                Debug.Log("No se puede papu");
            }
            else
            {
                Node lastNode = GetLastNode(); // 5
                Node newLastNode = lastNode.Previous; // 4

                newLastNode.Next = null; // 4 --> null
                lastNode.Previous = null; // 5 <-- null
                count = count - 1;
            }
        }
        public void DeleteNodeAtPosition(int position)
        {
            if (position == 0)
            {
                DeleteNodeAtStart();
            }
            else if (position == count - 1)
            {
                DeleteNodeAtEnd();
            }
            else if (position >= count || position < 0)
            {
                Debug.Log("No se puede papu");
            }
            else
            {
                int iterator = 0;
                Node NodePosition = Head;
                while (iterator < position)
                {
                    iterator = iterator + 1;
                    NodePosition = NodePosition.Next;
                }
                Node previousNode = NodePosition.Previous; // 9
                Node nextNode = NodePosition.Next; // 4

                NodePosition.Previous = null; // 3 <-- Null
                previousNode.Next = nextNode; // 9 --> 4

                NodePosition.Next = null; // 3 --> Null
                nextNode.Previous = previousNode; // 4 <- 9
                count = count - 1;

            }
        }
}
