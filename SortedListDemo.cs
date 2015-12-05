using System;
using System.Collections.Generic;


namespace ConsoleApplication1.Collections
{
    class SortedListDemo
    {
        public static void Main()
        {
            // Create a new sorted list of string, with string keys.
            SortedList<string, string> openWith = new SortedList<string, string>();

            // No duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.ext");
            openWith.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is already in the list.
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ERROR: An element with Key = \"txt\" already exists.");
            }

            // The Item property is another name for the indexer, so you can omit its name when accessing elements.
            Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

            // If a key does not exist, setting the indexer for the key adds a new key/value pair.
            openWith["doc"] = "winword.exe";

            // The indexer thows an exception if the requested key is not in the list.
            try
            {
                Console.WriteLine("For key= \"tif\", value = {0}.", openWith["tif"]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("ERROR: Key = \"tif\" is not found");
            }

            // If you are not sure if key exists in the list, TryGetValue can be more efficient way to retrive values
            string itemValue = "";
            if (openWith.TryGetValue("img", out itemValue))
            {
                Console.WriteLine("For key = \"img\", value = {0}.", itemValue);
            }
            else
            {
                Console.WriteLine("Key = \"img\" is not found.");
            }

            // ContainsKey can be used to  test keys before inserting them.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("Value added for key = \"ht\": {0}", openWith["ht"]);
            }

            // When you use foreach to enumerate list elements, the elements are retrieved as KeyValuePair objects.
            Console.WriteLine("\nBelow are items in the SortedList:");
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value - {1}", kvp.Key, kvp.Value);
            }

            // To get the values alone, use the Values property. The Values are strongly typed based on SortedList values.
            IList<string> iListValues = openWith.Values;
            Console.WriteLine("\nBelow are the Values in the SortedList:");
            foreach(string s in iListValues)
            {
                Console.WriteLine("Value = {0}", s);
            }
            
            // The Values property is an efficient way to retrive values by index.
            Console.WriteLine("\nIndexed retrieval using the Values property: Values[2] = {0}", openWith.Values[2]);

            // To get the keys alone use the Keys property
            IList<string> iListKeys = openWith.Keys;
            Console.WriteLine("\nBelow are the Keys in the SortedList:");
            foreach (string s in iListKeys)
            {
                Console.WriteLine("Key = {0}", s);
            }

            // The Keys property is an efficient way to retrive keys by index.
            Console.WriteLine("\nIndexed retrieval using the Keys property: Keys[2] = {0}", openWith.Keys[2]);

            //  Use the Remove method to remove a key/value pair
            Console.WriteLine("\nRemove(\"doc\")");
            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found");
            }

            Console.ReadLine();
        }
    }
}
