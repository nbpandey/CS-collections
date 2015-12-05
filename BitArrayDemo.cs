using System;
using System.Collections;

namespace ConsoleApplication1.Collections
{
    // https://msdn.microsoft.com/en-us/library/system.collections.bitarray(v=vs.110).aspx
    class BitArrayDemo
    {
        static void Main()
        {
            // Create and intializes several BitArrays.
            BitArray myBA1 = new BitArray(5);
            BitArray myBA2 = new BitArray(5, true);

            byte[] myBytes = new byte[5] { 1, 2, 3, 4, 5 };
            // BitArray that contains bit values copied from the specified array of bytes (8-bit).
            BitArray myBA3 = new BitArray(myBytes);

            bool[] myBools = new bool[5] { true, false, true, true, false };
            // BitArray class that contains bit values copied from the specified array of Booleans (1 bit)
            BitArray myBA4 = new BitArray(myBools);

            int[] myInts = new int[5] { 1, 2, 3, 4 ,5 };
            // BitArray that contains bit values copied from the specified array of 32-bit integers.
            BitArray myBA5 = new BitArray(myInts);

            // Displays the properties and values of the BitArrays.
            Console.WriteLine("myBA1");
            Console.WriteLine(" Count:  {0}", myBA1.Count);
            Console.WriteLine(" Length: {0}", myBA1.Length);
            Console.WriteLine(" Values:");
            PrintValues(myBA1, 8);

            Console.WriteLine("myBA2");
            Console.WriteLine(" Count:  {0}", myBA2.Count);
            Console.WriteLine(" Length: {0}", myBA2.Length);
            Console.WriteLine(" Values:");
            PrintValues(myBA2, 8);

            Console.WriteLine("myBA3");
            Console.WriteLine(" Count:  {0}", myBA3.Count);
            Console.WriteLine(" Length: {0}", myBA3.Length);
            Console.WriteLine(" Values:");
            PrintValues(myBA3, 8);

            Console.WriteLine("myBA4");
            Console.WriteLine(" Count:  {0}", myBA4.Count);
            Console.WriteLine(" Length: {0}", myBA4.Length);
            Console.WriteLine(" Values:");
            PrintValues(myBA4, 8);

            Console.WriteLine("myBA5");
            Console.WriteLine(" Count:  {0}", myBA5.Count);
            Console.WriteLine(" Length: {0}", myBA5.Length);
            Console.WriteLine(" Values:");
            PrintValues(myBA5, 8);


            Console.WriteLine("hello".GetType());
            Console.ReadLine();
        }

        public static void PrintValues (IEnumerable myList, int myWidth)
        {
            int i = myWidth;
            foreach (Object obj in myList)
            {
                // {0,6} is for 6-character field to hold the string. The characters are right-aligned.
                Console.Write("{0, 6}", obj);
            }
            Console.WriteLine();
            Console.WriteLine("--------------------");
        }
    }
}
