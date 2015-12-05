using System;
using System.Collections.Generic;


namespace ConsoleApplication1.Collections
{
    class LinkedListNodeDemo
    {
        public static void Main()
        {
            // Create a new LinkedListNode of type String and display its properties.
            LinkedListNode<String> lln = new LinkedListNode<String>(" Orange ");
            Console.WriteLine(" After creating the node...");
            DisplayProperties(lln);

            // Creating a new LinkedList.
            LinkedList<String> ll = new LinkedList<string>();
            
            // Add the "orange" node and display its properties
            ll.AddLast(lln);
            Console.WriteLine(" After adding the node to the empty LinkedList...");
            DisplayProperties(lln);

            // Add nodes before and after the "orange" node and display the "orange" node properties.
            ll.AddFirst("Red");
            ll.AddLast("Yellow");
            Console.WriteLine(" After adding Red and Yellow...");
            DisplayProperties(lln);

            Console.ReadLine();
        }
        

        public static void DisplayProperties (LinkedListNode<String> lln)
        {
            if (lln.List == null)
                Console.WriteLine(" Node is not linked.");
            else
                Console.WriteLine(" Node belongs to a linked list with {0} elements.", lln.List.Count);

            if (lln.Previous == null)
                Console.WriteLine(" Previous node is null.");
            else
                Console.WriteLine(" Value of previous node: {0}", lln.Previous.Value);

            Console.WriteLine(" Value of current node: {0}", lln.Value);

            if (lln.Next == null)
                Console.WriteLine(" Next node is null.");
            else
                Console.WriteLine(" Value of next node: {0}", lln.Next.Value);

            Console.WriteLine();
        }


    }
}
