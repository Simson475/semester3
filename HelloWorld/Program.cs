using System;

namespace HelloWorld
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //My hello world program
            string HelloWorld = "Hello World", FirstName, LastName;
            Console.WriteLine(HelloWorld);
            Console.Write("First Name: ");
            FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            LastName = Console.ReadLine();
            Console.WriteLine($"Your full name is {FirstName} {LastName}");
        }
    }
}