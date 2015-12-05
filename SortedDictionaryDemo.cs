using System;
using System.Collections.Generic;


namespace ConsoleApplication1.Collections
{
    /* The SortedDictionary<TKey, TValue> generic class is a binary search tree with O(log n) retrieval, 
       where n is the number of elements in the dictionary. In this respect, it is similar to the SortedList<TKey, TValue> generic class. 
       The two classes have similar object models, and both have O(log n) retrieval. Where the two classes differ is in memory use and 
       speed of insertion and removal:
     * SortedList<TKey, TValue> uses less memory than SortedDictionary<TKey, TValue>.
     * SortedDictionary<TKey, TValue> has faster insertion and removal operations for unsorted data: O(log n) as opposed to O(n) for SortedList<TKey, TValue>.
     * If the list is populated all at once from sorted data, SortedList<TKey, TValue> is faster than SortedDictionary<TKey, TValue>.
    */
    class SortedDictionaryDemo
    {
        public static void Main()
        {
            // Create a new sorted dictionary of string , with string keys
            SortedDictionary<string, string> openWith = new SortedDictionary<string, string>();

            // Add some elements to the dictionary. There are no duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is already in the dictionary
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                // Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            // The Item property is another name for the indexer, so you can omit its name when accessing elements.
            Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

            // The indexer can be used to change the value associated with a key
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

            // If a key does not exist, setting the indexer for that key adds a new key/value pair.
            openWith["doc"] = "winword.exe";

            // The indexer throws an excepetion if the requested key is not in the dictionary.
            try
            {
                Console.WriteLine("For key = \"tif\", value = {0}", openWith["tif"]);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            // When a program often has to try keys that turn out not to be in the dictionary, 
            // TryGetValue can be a more efficient way to retrieve values.
            string value = "";
            if (openWith.TryGetValue("tif", out value))
            {
                Console.WriteLine("For key = \"tif\", value = {0}", value);
            }
            else
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // ContainKey can be used to test keys before inserting them.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("Value added for key = \"ht\" : {0}", openWith["ht"]);
            }

            // When you use foreach to enumerate dictionary elements, the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            // To get the values alone, use the Values property.
            SortedDictionary<string, string>.ValueCollection valueCols = openWith.Values;

            // The elements of the ValueCollection are strongly typed with type that was specified for dictionary values
            Console.WriteLine();
            foreach (string s in valueCols)
            {
                Console.WriteLine("Value = {0}", s);
            }

            SortedDictionary<string, string>.KeyCollection keyCols = openWith.Keys;
            foreach (string s in keyCols)
            {
                Console.WriteLine("Key = {0}", s);
            }

            // Use the Remove method to remove a key/value pair
            Console.WriteLine("\nRemove(\"doc\")");
            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
                Console.WriteLine("Key \"doc\" is not found.");

            Console.ReadLine();
        }
    }
}
