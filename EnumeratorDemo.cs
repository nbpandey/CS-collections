using System;
using System.Collections;

namespace ConsoleApplication1.Collections
{
    // https://msdn.microsoft.com/en-us/library/system.collections.ienumerable.getenumerator(v=vs.110).aspx
    class EnumeratorDemo
    {
        static void Main()
        {
            Person[] peopleArray = new Person[3]
            {
                new Person("John", "Smith"),
                new Person("Jim", "Johnson"),
                new Person("Sue", "Rabon")
            };

            People peopleList = new People(peopleArray);
            foreach (Person p in peopleList)
                Console.WriteLine(p.firstName + " " + p.lastName);

            Console.ReadLine();
        }
    }


    // Simple business object
    public class Person
    {
        public string firstName;
        public string lastName;
        public Person (string fName, string lName)
        {
            this.firstName = fName;
            this.lastName = lName;
        }
    }


    // Collection of Person objects. This class implements IEnumerable so that it can be used with ForEach syntax.
    public class People : IEnumerable
    {
        private Person[] _people;
        public People(Person[] pArray)
        {
            _people = new Person[pArray.Length];

            for (int i=0; i<pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }

        // Implementation for the GetEnumerator method. You must follow the iterator pattern 
        // by providing a GetEnumerator method that returns an interface, class or struct.
        // You must provide a class that contains a Current property, and MoveNext and Reset methods as described by IEnumerator, 
        // but the class does not have to implement IEnumerator.
        IEnumerator IEnumerable.GetEnumerator()
        {
            PeopleEnum pEnum = new PeopleEnum(_people);
            return (IEnumerator) pEnum;
        }
    }


    // When you implement IEnumerable, you must also implement IEnumerator.
    // IEnumerator provides the ability to iterate through the collection by exposing a Current property and MoveNext and Reset methods.
    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;
        // Constructor
        public PeopleEnum(Person[] list)
        {
            _people = list;
        }

        // Enumerators are positioned before the first element until the first MoveNext() call.
        int position = -1;

        public Person Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }  
             }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        bool IEnumerator.MoveNext()
        {
            position++;
            return(position < _people.Length);
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }
    }


}
