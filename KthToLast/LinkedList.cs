using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace KthToLast
{
    public class LinkedListNode<T>
    {


        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data = default(T), LinkedListNode<T> next = null)
        {
            Data = data;
            Next = next;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }

    public class LinkedList<T> : IList<T>
    {
        public LinkedListNode<T> Head { get; set; }
        public LinkedListNode<T> Tail { get; set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
        }

        public T? First { get => IsEmpty ? default(T) : this.Head.Data; }

        public T? Last { get => IsEmpty ? default(T) : this.Tail.Data; }

        public bool IsEmpty { get => length == 0; }


        private int length = 0;
        public int Length => length;

        public void Append(T value)
        {

            var newNode = new LinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            length++;


        }

        public void Clear()
        {
            Head = null;
            Tail = null;

            length = 0;
        }

        public bool Contains(T value)
        {

            if (FirstIndexOf(value) != -1)
            {
                return true;
            }

            return false;
        }

        public int FirstIndexOf(T value)
        {
            int index = 0;

            var currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(value))
                {
                    return index;
                }
                index++;
                currentNode = currentNode.Next;

            }

            return -1;
        }

        public T Get(int index)
        {
            var currentNode = Head;
            int currentIndex = 0;

            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }

            while (currentNode.Next != null)
            {
                if (currentIndex == index)
                {
                    return currentNode.Data;
                }

                currentNode = currentNode.Next;
                currentIndex++;
            }

            return default(T);
        }

        public void InsertAfter(T newValue, T existingValue)
        {
            var currentNode = Head;
            int count = 0;

            if (IsEmpty || Contains(existingValue) == false)
            {
                Append(newValue);
            }

            else
            {
                while (currentNode != null && !(currentNode.Data.Equals(existingValue)))
                {
                    currentNode = currentNode.Next;
                    count++;
                }

                InsertAt(newValue, count + 1);
            }
        }

        public void InsertAt(T value, int index)
        {
            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                Prepend(value);
            }



            var currentNode = Head;
            int currentIndex = 0;



            while (currentNode != null)
            {
                if (currentIndex == index - 1)
                {
                    var newNode = new LinkedListNode<T>(value);
                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;

                    if (currentNode == Tail)
                    {
                        Tail = newNode;
                    }

                    length++;
                }

                currentNode = currentNode.Next;
                currentIndex++;
            }
        }



        public void Prepend(T value)
        {

            var newHead = new LinkedListNode<T>(value);

            if (IsEmpty)
            {

                Head = newHead;
                Tail = newHead;
            }

            else
            {
                newHead.Next = Head;
                Head = newHead;

            }

            length++;


        }

        public void Remove(T value)
        {
            //If list is empty, we're done son
            if (IsEmpty)
            {
                return;
            }

            //Remove Head
            if (Head.Data.Equals(value))
            {
                Head = Head.Next;

                //1-element list
                if (Head == Tail)
                {
                    Tail = null;
                    Head = null;
                }

                length--;
                return;
            }

            //Remove non-head node
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Next != null && currentNode.Next.Data.Equals(value))
                {
                    var nodeToDelete = currentNode.Next;
                    length--;
                    if (nodeToDelete == Tail)
                    {
                        currentNode.Next = null;
                        Tail = currentNode;
                    }
                    else
                    {
                        currentNode.Next = currentNode.Next.Next;
                        nodeToDelete.Next = null;
                    }
                    return;


                }

                currentNode = currentNode.Next;
            }

        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }


            if (index < length && index >= 0)
            {

                var currentNode = Head;
                int currentIndex = 0;


                if (index == 0)
                {
                    var deleteHead = currentNode.Next;

                    Head = currentNode.Next;

                    length--;
                    return;
                }



                while (currentNode != null && currentIndex <= index)
                {


                    if (currentIndex == (index - 1))
                    {
                        var prevNode = currentNode;
                        var nodeToDelete = currentNode.Next;
                        if (nodeToDelete == Tail)
                        {
                            currentNode.Next = null;
                            Tail = currentNode;
                        }
                        else
                        {
                            nodeToDelete = currentNode.Next;
                            prevNode = nodeToDelete.Next;
                        }

                        length--;
                        return;
                    }



                    currentNode = currentNode.Next;
                    currentIndex++;


                }
            }
        }

        public IList<T> Reverse()
        {
            var reversedList = new LinkedList<T>();

            var currentNode = Head;

            while( currentNode != null)
            {
                reversedList.Prepend(currentNode.Data);
                currentNode = currentNode.Next;
            }

            return reversedList;

        }

        public override string ToString()
        {
            string result = "[";

            for (var currentNode = Head; currentNode != null; currentNode = currentNode.Next)
            {
                result += currentNode.ToString();
                if (currentNode != Tail)
                {
                    result += ", ";
                }
            }
            result += "]";
            return result;
        }
        // TODO 
        public T KthToLast(int k)
        {
            var reversedList = Reverse();

            return reversedList.Get(k);
        }
    }
}

