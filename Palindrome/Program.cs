using System.Collections.Generic;

namespace Palindrome;
public class Program
{
    static void Main(string[] args)
    {
        LinkedList<string> linkedList = new LinkedList<string>();

        linkedList.AddLast("xbx");
        linkedList.AddLast("pka");
        linkedList.AddLast("pka");
        linkedList.AddLast("xbx");

        Console.WriteLine(IsPalindrome(linkedList) );
    }

    public static bool IsPalindrome<T>(LinkedList<T> linkedList)
    {
        // are the first and last items the same?

        // if so, move toward the middle

        var currentHead = linkedList.First;
        var currentTail = linkedList.Last;
        var count = linkedList.Count;
        count = count / 2;
        while(currentHead != null)
        {
            if (currentHead == currentTail)
            {
                return true;
            }
       
            if (currentTail == currentHead.Next)
            {
                return currentHead.Value.Equals(currentTail.Value);
            }

            if (currentHead.Value.Equals(currentTail.Value))
            {
                currentHead = currentHead.Next;
                currentTail = currentTail.Previous;
                //linkedList.First = currentHead;
                //linkedList.Last = currentTail;
            }
            else
            {
                return false;
            }
        }


        return true;
    }
}

//for (var i=0; i<count; i++)

//if (count == 0 || count == 1)
//{
//    return true;
//} else
//{
//    Console.WriteLine($"head: {currentHead.Value} ; tail: {currentTail.Value}");
//    if (!currentHead.Equals(currentTail))
//    {
//        return false;
//    }

//}

//if (count != 0)
//{
//    Console.WriteLine($"head: {currentHead.Value} ; tail: {currentTail.Value}");
//    if (!currentHead.Equals(currentTail))
//    {
//        return false;
//    }
//    currentHead = currentHead.Next;
//    currentTail = currentTail.Previous;
//}