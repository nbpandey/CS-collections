using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApplication1.Collections
{
    class MixedTypeList1
    {
        public static void Main()
        {
            ArrayList list = new ArrayList();
            /*
            The ArrayList class is designed to hold heterogeneous collections of objects. However, it does not always offer the best performance. Instead, we recommend the following:
            For a heterogeneous collection of objects, use the List<Object> (in C#) or List(Of Object) (in Visual Basic) type.
            For a homogeneous collection of objects, use the List<T> class.
             */
            //List<object> list = new List<object>();

            int height = 20;
            int length = 40;
            int width = 200;
            int weight = 3;
            double coordX = 0.0;
            double coordY = 2.5;
            string name = "John";

            //adding null is allowed
            list.Add(null);
            //adding boolean
            list.Add(false);
            list.Add(true);
            //adding int
            list.Add(height);
            list.Add(length);
            list.Add(width);
            list.Add(weight);
            //adding double
            list.Add(coordX);
            list.Add(coordY);
            //adding string
            list.Add(name);
            //adding duplicates is allowed
            list.Add(name);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Item # {0} in list : {1}", i, list[i]);
            }


            Console.ReadLine();
        }
    }
}
