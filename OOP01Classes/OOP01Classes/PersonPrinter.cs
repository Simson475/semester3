using System;

namespace OOP01Classes
{
    public static class PersonPrinter
    {
        public static void Person(Person PersonToPrint, string ascendancy = "")
        {
            if (ascendancy != "")
            {
                Console.Write($"{ascendancy}: ");
            }
            Console.WriteLine($"{PersonToPrint.Fornavn} {PersonToPrint.Efternavn}, {PersonToPrint.Alder}, ID:{PersonToPrint.PersonID}");
        }
        public static void FamilyTree(Person PersonToPrint, string ascendancy = "")
        {
            if (PersonToPrint.Mor != null)
            {
                FamilyTree(PersonToPrint.Mor, ascendancy + "mor");
            }

            if (PersonToPrint.Far != null)
            {
                FamilyTree(PersonToPrint.Far, ascendancy + "far");
            }

            Person(PersonToPrint, ascendancy);
        }
    }
}
