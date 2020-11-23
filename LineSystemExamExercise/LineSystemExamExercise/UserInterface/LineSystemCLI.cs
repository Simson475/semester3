using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface
{
    public class LineSystemCLI
    {
        public LineSystemCLI(LineSystem linesystem)
        {
            InternalLineSystem = linesystem;
        }
        public ILineSystem InternalLineSystem { get; set; }
        public void Start()
        {
            string input;
            do
            {
                PrintToScreen();

                input = Console.ReadLine();

            } while (input != "q");

        }
        private void PrintToScreen()//TODO format nice?
        {
            Console.WriteLine("Press q to quit");
            List<Product> products = InternalLineSystem.ActiveProducts;
            foreach (Product item in products)
            {
                Console.WriteLine(item);
            }
        }
    }
}
