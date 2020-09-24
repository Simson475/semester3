using System;
using System.Collections;

namespace OOP003interfaces
{
    class Car : IComparable
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        public void Print() => Console.WriteLine($"{Make} {Model} Price:{Price}");
        public int CompareTo(object obj) => Price.CompareTo((obj as Car).Price);
    }
}