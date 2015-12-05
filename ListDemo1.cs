using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Collections
{
    class ListDemo1
    {
        static void Main()
        {
           /* list of int, sorting and gethashcode */
            var list = new List<int> { 1, 4, -33, 34, 35, 128, 259, 0 };
            foreach (int i in list)
                Console.WriteLine("{0} : {1}", i.GetHashCode(), i);
            Console.WriteLine();
            
            list.Sort();
            for (int i = 0; i < list.Count; i++ )
                Console.WriteLine("{0} : {1}", i.GetHashCode(), i);
            Console.WriteLine();

            /* list of cars, sorting */
            var listOfCar = new List<Car>
            {        
                new Car {Model="Ford", Make="Focus", Doors = 5},
                new Car {Model="Ford", Make="Fiesta", Doors = 3},
                new Car {Model="Audi", Make="A4", Doors=4},
                new Car {Model="TVR", Make="Chimera", Doors=2},
                new Car {Model="Honda", Make="Civic", Doors=5},
                new Car {Model="Volvo", Make="S60", Doors=4}
            };

            // sorting with an extension method and Lambda expression instead of listOfCar.Sort
            var sortedListOfCar = listOfCar.OrderBy(item => item.Doors);
            foreach (Car c in sortedListOfCar)
                Console.WriteLine("{0} - {1} has {2} doors.", c.Make, c.Model, c.Doors);
            Console.WriteLine();

            // sorting using LINQ to Objects
            var anothersortedListofCar = from c in listOfCar
                                         orderby c.Model
                                         select c;
            foreach (Car c in anothersortedListofCar)
                Console.WriteLine("{0} - {1} has {2} doors.", c.Make, c.Model, c.Doors);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
