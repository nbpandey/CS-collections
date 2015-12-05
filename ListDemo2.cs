using System;
using System.Collections.Generic;


namespace ConsoleApplication1.Collections
{
    // https://msdn.microsoft.com/en-us/library/6sh2ey19(v=vs.110).aspx
    // A simple business object. PartId is used to identify the type of part but the PartName can change.
    class Part : IEquatable<Part>
    {
        public int PartId {get; set;}
        public string PartName { get; set; }

        public override string ToString()
        {
            return "ID: " + PartId + " Name: " + PartName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Part objAsPart = obj as Part;
            if (objAsPart == null)
                return false;
            else
                return Equals(objAsPart);
        }

        public override int GetHashCode()
        {
            return PartId;
        }
        
        bool IEquatable<Part>.Equals(Part other)
        {
            if (other == null)
                return false;
            return (this.PartId.Equals(other.PartId));
        }

        // Should also override == and != operators.
    }

    class ListDemo2
    {
        public static void Main()
        {
            // Create a list of parts
            List<Part> parts = new List<Part>();

            // Add parts to the list.
            parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
            parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
            parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
            parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
            parts.Add(new Part() { PartName = "shift lever", PartId = 1634 });

            // Write out the parts in the list. This will call the overridden ToString method in the Part class.
            Console.WriteLine();
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }

            // Check the list for part # 1734. This calls the IEquitable.Equals method of the Part class, which checks the PartId for equality.
            Console.WriteLine("\nContains(\"1734\"): {0}", parts.Contains(new Part { PartId = 1734, PartName = "" }));

            // Insert a new item at position 2.
            Console.WriteLine("\nInsert(2, \"1834\")");
            parts.Insert(2, new Part() { PartName = "brake lever", PartId = 1834 });

            foreach (Part apart in parts)
                Console.WriteLine(apart);

            Console.WriteLine("\nParts[3]: {0}", parts[3]);

            Console.WriteLine("\nRemove(\"1534\")");
            // This will remove part 1534 even though the PartName is different, becuase the Equals method only checks PartId for equality.
            parts.Remove(new Part() { PartId = 1534, PartName = "cogs" });

            foreach (Part apart in parts)
                Console.WriteLine(apart);

            Console.WriteLine("\nRemoveAt(3)");
            // This will remove the part at index 3
            parts.RemoveAt(3);

            foreach (Part apart in parts)
                Console.WriteLine(apart);

            Console.ReadLine();
        }
    }

}
