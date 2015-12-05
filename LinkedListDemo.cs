using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication1.Collections
{
    class LinkedListDemo
    {
        public static void Main()
        {
            // Create the link list.
            string[] words = { "the", "fox", "jumped", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);
            
            // Find a value in LL
            Display(sentence, "The linked list values:");
            Console.WriteLine("sentence.Contains(\"jumped\") = {0}", sentence.Contains("jumped"));

            // Add a value to the beginning of the list
            sentence.AddFirst("today");
            Display(sentence, "Test 1: Add 'today' to the LL");

            // Move the first node to be the last noe.
            LinkedListNode<string> mark1 = sentence.First;
            sentence.RemoveFirst();
            sentence.AddLast(mark1);
            Display(sentence, "Test 2: Move first node to be last node");

            // Change the last node to 'yesterday'
            sentence.RemoveLast();
            sentence.AddLast("yesterday");
            Display(sentence, "Test 3: Change the last node to 'yesterday'");

            // Move the last node to first.
            mark1 = sentence.Last;
            sentence.RemoveLast();
            sentence.AddFirst(mark1);
            Display(sentence, "Test 4: Move last node to first");

            // Indicate, by using parentheisis, the last occurence of 'the'
            LinkedListNode<string> current = sentence.FindLast("the");
            IndicateNode(current, "Test 5: Indicate last occurence of 'the'");

            // Add 'lazy' and 'old' after 'the'
            sentence.AddAfter(current, "old");
            sentence.AddAfter(current, "lazy");
            IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

            // Indicate 'fox' node
            current = sentence.FindLast("fox");
            IndicateNode(current, "Test 7: Indicate the 'fox' node:");

            // Add 'quick' and 'brown' before 'fox'
            sentence.AddBefore(current, "quick");
            sentence.AddBefore(current, "brown");
            IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox:");

            // Keep a reference to the current node, 'fox', and to the previous node. Indicate the 'dog' node.
            mark1 = current;
            LinkedListNode<string> mark2 = current.Previous;
            current = sentence.Find("dog");
            IndicateNode(current, "Test 9: Indicate the 'dog' node:");

            //The AddBefore method throws an InvalidOperationException if you try to add a node that already belongs to a list.
            Console.WriteLine("Test 10: Throw exception by adding node (fox) aready in the list");
            try
            {
                
                sentence.AddBefore(current, mark1);
                // using string "fox" instead of mark1 will add a new LinkedListNode with value "fox".
                // LL allows duplicate values and null. You can't just add the same LinkedListNode (which is a reference) twice.
                // sentence.AddBefore(current, "fox");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Exception message: {0} ", ex.Message);
            }
            Console.WriteLine();
            // LinkedListNodeDemo.DisplayProperties(mark1);

            // Remove the node referred to by mark1, and the add it before the node referred to by current.
            // Indicate the node referred to by current.
            sentence.Remove(mark1);
            sentence.AddBefore(current, mark1);
            IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

            // Remove the node referred to by current.
            sentence.Remove(current);
            IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

            // Add the node after the node referred to by mark2.
            sentence.AddAfter(mark2, current);
            IndicateNode(current, "Test 13: Add removed node after a referenced node (brown):");

            // The Remove method finds and removes the first node that has the specified value.
            sentence.Remove("old");
            Display(sentence, "Test 14: Remove node that the value 'old':");

            // When the linked list is cast to ICollection(Of String), the add methods adds a node to the end of the list.
            sentence.RemoveLast();
            ICollection<string> iCol1 = sentence;
            iCol1.Add("rhinocerous");
            Display(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros");

            Console.WriteLine("Test 16: Copy the list to an array:");
            // Create an array with the same number of elements as the linkedlist.
            string[] sArray = new string[sentence.Count];
            sentence.CopyTo(sArray, 0);
            foreach (string s in sArray)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            // Release all the nodes;
            sentence.Clear();
            Console.WriteLine("Test 17: Clear Linked List. Count is {0}, Contains 'jumped' = {1}", sentence.Count, 
                sentence.Contains("jumped"));

            Console.ReadLine();
        }


        private static void Display(LinkedList<String> words, string test)
        {
            Console.WriteLine(test);
            foreach(string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void IndicateNode(LinkedListNode<string> node, string test)
        {
            Console.WriteLine(test);
            if (node.List == null)
            {
                Console.WriteLine("Node: '{0}' is not in the list.\n", node.Value);
                return;
            }

            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            LinkedListNode<string> nodeP = node.Previous;

            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }

    }
}
