using System;
using System.IO;

namespace OOP01Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Mig = new Person("Simon", "Nielsen");
            Mig.Mor = new Person("Laila", "Rosenberg");
            Mig.Far = new Person("Jens", "Frimor");
            Mig.Far.Mor = new Person("Else", "Frimor");
            Mig.Far.Far = new Person("Knud", "Frimor");
            Mig.Mor.Mor = new Person("Grethe", "Andersen");
            Mig.Mor.Far = new Person("Erik", "Andersen");
            PersonPrinter.FamilyTree(Mig);


            DirectoryInfo di = new DirectoryInfo(@"C:\Programs\semester3\");
            DirectoryLookup.Search(di, ".sln");


            Vector2D v1 = new Vector2D(1, 2);
            Vector2D v2 = new Vector2D(3, 4);
            Console.WriteLine((v1 - v2).x);
            Console.WriteLine((v1 - v2).y);
            Console.WriteLine((v1 * 5.2).y);

            ReferenceTester test1 = new ReferenceTester(1);
            ReferenceTester test2 = new ReferenceTester(1);

            if (test1.Equals(test2))
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not equal");
            }

        }
    }
}
