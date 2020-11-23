using System;

namespace OOP008Test
{
    public class BadList
    {
        private class Node
        {
            public Node(int data)
            {
                Data = data;
            }
            public int Data { get; }
            public Node Next { get; set; }
        }
        public BadList()
        {
            Head = null;
            Length = 0;
        }

        public int Length { get; private set; }
        private Node Head { get; set; }

        /// <summary>
        /// Count elements that contains [number]
        /// </summary>
        /// <param name="number">Number to count</param>
        /// <returns></returns>
        public int CountNumbers(int number)
        {
            int count = 0;
            Node current = Head;
            while (current != null)
            {
                if (current.Data == number) count++;
                current = current.Next;
            }
            return count;
        }

        public void Add(int i)
        {
            if (Head == null) Head = new Node(i);
            else GetNodeBefore(Length).Next = new Node(i);
            Length++;
        }

        public int Get(int index)
        {
            return GetNodeAt(index).Data;
        }

        //TODO why -2? WTF
        public void Remove(int index)
        {
            if (index == 0)
            {
                Head = Head.Next;
            }
            else
            {
                Node n = GetNodeBefore(index);
                n.Next = n.Next.Next;
            }
            Length--;
        }

        public bool IsEmpty
        {
            get { return Head == null; }
        }

        public void InsertAt(int index, int value)
        {
            if (index == 0) Head = new Node(value) { Next = Head };
            else GetNodeBefore(index).Next = new Node(value) { Next = GetNodeAt(index) };
            Length++;
        }

        private Node GetNodeBefore(int index)
        {
            Node result = GetNodeAt(index - 1);
            return result;
        }
        private Node GetNodeAt(int index)
        {
            try
            {
                Node current = Head;
                while (index-- > 0)
                {
                    current = current.Next;
                }
                return current;
            }
            catch (NullReferenceException)
            {
                throw new IndexOutOfRangeException(index.ToString());
            }
        }
    }
}
