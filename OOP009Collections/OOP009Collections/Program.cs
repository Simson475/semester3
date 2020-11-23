using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP009Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //RandomNNumbers randomNumbers = new RandomNNumbers(new Random().Next(0, 50), 5, 0, 10);
            //SortedList<int> sortedList = new SortedList<int>();

            //foreach (int item in randomNumbers.GetNumbers())
            //{
            //    Console.WriteLine(item);
            //    sortedList.Add(item);
            //}

            //Console.WriteLine("\n\n Now sorted:");

            //foreach (int item in sortedList)
            //{
            //    Console.WriteLine(item);
            //}


            //Console.WriteLine("\n\n Now reversed:");

            //foreach (int item in sortedList.GetElementsReversed())
            //{
            //    Console.WriteLine(item);
            //}


            //Console.WriteLine("\n\n less than 5");

            //foreach (var item in sortedList.GetElements(x => x < 5))
            //{
            //    Console.WriteLine(item);
            //}



            //Console.WriteLine("\n\n\n\n");

            //List<int> numbers = new List<int>();
            //Random r = new Random();
            //int randomNum = 0;
            //for (int i = 1; i < 20; i++)
            //{
            //    randomNum = r.Next(0, 100); //random number between 0 and 100
            //    numbers.Add(randomNum);
            //}


            //Console.WriteLine("\n\n divisible by 5");

            //foreach (var item in numbers.FindAll(x => x % 5 == 0))
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("\n\n between 20 and 40");
            //foreach (var item in numbers.FindAll(x => x <= 40 && x >= 20))
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("\n\n highest between 20 and 40");

            //Console.WriteLine(numbers.FindAll(x => x <= 40 && x >= 20).Max());

            //Console.WriteLine("\n\n Multiply by 5");

            //foreach (var item in numbers.Select(x => x *= 5))
            //{
            //    Console.WriteLine(item);
            //}


            //Console.WriteLine("\n\n Decending");

            //foreach (var item in numbers.OrderByDescending(x => x))
            //{
            //    Console.WriteLine(item);
            //}


            //Console.WriteLine("\n\ntest");
            //Random random = new Random();
            //IEnumerable<int> test = Enumerable.Range(1, 10).Select(x => random.Next());

            //foreach (var item in test)
            //{
            //    Console.WriteLine(item);
            //}



            //List<Person> people = new List<Person>(){
            //    new Person() { Name = "Ib", Weight = 89.6, Age = 27 },
            //    new Person() { Name = "Kaj", Weight = 65.7, Age = 17 },
            //    new Person() { Name = "Ole", Weight = 77, Age = 7 },
            //    new Person() { Name = "Anders", Weight = 72, Age = 40 },
            //    new Person() { Name = "Børge", Weight = 88.8, Age = 13 }};


            //foreach (var item in people.OrderBy(x => x.Weight)) Console.WriteLine(item);
            //foreach (var item in people.OrderByDescending(x => x.Name)) Console.WriteLine(item);
            //foreach (var item in people.FindAll(x => x.Age > 10).Select(x => x.Name).Where(x => x.ToLower().Contains("a"))) Console.WriteLine(item);
            //Console.WriteLine(people.FindAll(x => x.Age > 12 && x.Age < 20).Select(x => x.Name).OrderBy(x => x.Length).Last());
            //Console.WriteLine(people.FindAll(x => x.Age > 12 && x.Age < 20).OrderBy(x => x.Name.Length).Last().Weight);




        }
    }
    abstract class MotorVehicle
    {
        protected Fuel _fuel;
        public string Make { get; set; } //VW, Audi, Skoda...
        public string Model { get; set; } //Golf, Polo, A3, Fabia, etc.
        public int Year { get; set; }
        public decimal Price { get; set; }
        public virtual Fuel Fuel
        {
            get { return _fuel; }
            set { _fuel = value; }
        }
    }

}

