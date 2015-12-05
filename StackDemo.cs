using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Collections
{
    // https://msdn.microsoft.com/en-us/library/3278tedw(v=vs.110).aspx
    class StackDemo
    {
        public static void Main()
        {
            // Creates and initializes a new Stack.
            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push(1);
            myStack.Push("!");

            // Display the properties and values of the Stack.
            Console.WriteLine("myStack");
            Console.WriteLine("\tCount: {0}", myStack.Count);
            Console.Write("\tValues:");
            PrintValues(myStack);

            // Creates a instance of generic Stack -- a variable size last-in-first-out (LIFO) collection of instances of the same specified type.
            Stack<string> numbers = new Stack<string>();
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");
            numbers.Push("four");
            numbers.Push("five");
            // A stack can be enumerated without disturbing its contents.
            Console.WriteLine("\n\n'numbers' stack:");
            foreach(string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nPopping '{0}'", numbers.Pop());
            Console.WriteLine("Peek at the next item to destack: {0}", numbers.Peek());
            Console.WriteLine("Popping '{0}'", numbers.Pop());

            // Create a copy of the stack using ToArray method and the constructor that accepts an IEnumerable<T>.
            Stack<string> stack2 = new Stack<string>(numbers.ToArray());

            Console.WriteLine("\nContents of the first copy:");
            foreach(string number in stack2)
            {
                Console.WriteLine(number);
            }

            // Creat an array twice the size of the stack and copy the elements of the stack, starting at the middle of the array.
            string[] array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // Create a second stack, using teh contructor that accepts an IEnumerable(Of T).
            Stack<string> stack3 = new Stack<string>(array2);

            Console.WriteLine("\nContents of the second copy, with duplicates and nulls");
            foreach (string number in stack3)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nstack2.Contains(\"four\") = {0}", stack2.Contains("four"));

            Console.WriteLine("\nstack2.Clear()");
            stack2.Clear();
            Console.WriteLine("\nstack2.Count = {0}", stack2.Count);

            Console.ReadLine();
        }

        public static void PrintValues(IEnumerable myCollection)
        {
            /* Enumerating through a collection is intrinsically not a thread-safe procedure. 
             * Even when a collection is synchronized, other threads can still modify the collection, which causes the enumerator to throw an exception. 
             * To guarantee thread safety during enumeration, you can either lock the collection during the entire enumeration or 
             * catch the exceptions resulting from changes made by other threads.
             */
            lock (myCollection)
            {
                foreach (Object obj in myCollection)
                {
                    Console.Write(" {0}", obj);
                }                   
            }

        }
    }
}
