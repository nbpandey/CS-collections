using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Collections
{
    class MixedTypeList2
    {
        static void Main()
        {
            var name = new MyClass<string>() { Value = "John" };
            var age = new MyClass<int>() { Value = 24 };
            var exempt = new MyClass<bool>() { Value = true };

            // How do I define the collection so that it can hold a list of generic types? 
            // The trick is to create a list of IMyClass and then add items which are of MyClass<T>
            var attrList = new List<IMyClass>();
            attrList.Add(name);
            attrList.Add(age);
            attrList.Add(exempt);

            foreach (var item in attrList)
            {
                Console.WriteLine("{0} is of {1} type.", item.GetValue, item.GetType());
            }

            Console.ReadKey();
        }

    }


    interface IMyClass
    {
        object GetValue { get; }
    }

    class MyClass<T>: IMyClass
    {
        public T Value;

        public object GetValue
        {
            get { return Value; }
        }
    }
}
