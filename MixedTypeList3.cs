using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Collections
{
    class MixedTypeList3
    {
        static void Main()
        {
            var name = new MyItemClass<string> { Value = "Neal" };
            var age = new MyItemClass<int> { Value = 28 };
            var exempt = new MyItemClass<bool> { Value = true };
            
            var col = new MyItemCollection();
            col.Put(name);
            col.Put(age);
            col.Put(exempt);

            var dictionary = col.Dict;

            foreach (var item in dictionary)
            {
                Console.WriteLine("{0} is of {1} - {2} type.", item.ToString(),  item.Key, item.Value);
            }

            Console.ReadKey();

        }
    }

    abstract class MyClass
    {
        public abstract Type MyType { get; }
    }

    class MyItemClass<T> : MyClass
    {
        public T Value { get; set; }

        public override Type MyType
        {
            get { return typeof(T); }
        }
    }

    class MyItemCollection
    {
        public Dictionary<Type, MyClass> Dict { get; set; }

        public MyItemCollection()
        {
            Dict = new Dictionary<Type, MyClass>();
        }

        public void Put<T>(MyItemClass<T> item)
        {
            Dict[typeof(T)] = item;
        }

        public MyItemClass<T> Get<T>()
        {
            return Dict[typeof(T)] as MyItemClass<T>;
        }
    }

 
}
