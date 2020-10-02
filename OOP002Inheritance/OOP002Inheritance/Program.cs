using System;
using System.Collections.Generic;

namespace OOP002Inheritance
{
    partial class Program
    {
        static void Main(string[] args)
        {
            List<Person> plist = new List<Person>();
            plist.Add(new Person("Thomas", 47));
            plist.Add(new Person("Erik", 15));
            plist.Add(new Person("Erik", 12));
            plist.Add(new Person("Jesper", 83));
            plist.Add(new Employee("Bo", "Grunt", 0));
            plist.Add(new Employee("Hans", 21, "Second Rank Grunt", 100));
            plist.Add(new Person("Kurt", 52));

            PersonFilter pfilter = new XorFilter(new NameFilter("Erik"), new AgeFilter(14, 50));
            List<Person> filteredList = pfilter.Filter(plist);
            foreach (Person person in filteredList)
            {
                Console.WriteLine(person.Name);
            }


            ParkingMeter pm = new ParkingMeter(40);
            pm.Pay(20);
        }
    }
}

