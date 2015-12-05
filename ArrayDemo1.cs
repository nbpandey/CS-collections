using System;


namespace ConsoleApplication1.Collections
{
    // https://msdn.microsoft.com/en-us/library/system.array(v=vs.110).aspx
    class ArrayDemo1
    {
        public static void Main()
        {
            // Create and initializes a new integer array and a new Object array.
            int[] myIntArray = new int[5] { 1, 2, 3, 4, 5 };
            object[] myObjArray = new object[5] { 26, 27, 28, 29, 30 };
            
            // Printe the initial values of both arrays
            Console.Write("Initially, integer array: ");
            PrintValues(myIntArray);
            Console.Write("Object array: ");
            PrintValues(myObjArray);

            // Copies the first tow elements from the integer array to the Object array.
            System.Array.Copy(myIntArray, myObjArray, 2);

            // Print the values of the modified arrays.
            Console.Write("\nAfter copying the first two elements of the Integer array to the Object array, the Integer array: ");
            PrintValues(myIntArray);
            Console.Write("Object array: ");
            PrintValues(myObjArray);

            // Copies the last two elements from the Object array to the Integer array.
            System.Array.Copy(myObjArray, myObjArray.GetUpperBound(0) - 1, myIntArray, myIntArray.GetUpperBound(0) - 1, 2);

            // Print the values of the modified arrays.
            Console.Write("\nAfter copying the last two elements of the Object array to the Integer array, the Integer array: ");
            PrintValues(myIntArray);
            Console.Write("Object array: ");
            PrintValues(myObjArray);

            Console.ReadLine();
        }

        private static void PrintValues(object[] myObjArray)
        {
            foreach (Object i in myObjArray)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }

        private static void PrintValues(int[] myIntArray)
        {
            foreach( int i in myIntArray)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }


    }
}
