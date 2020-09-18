using System;

namespace OOP01
{
    class StarPrinter
    {
        public static void Stair(int steps)
        {
            string PrintString = "";
            for (int i = 0; i < steps; i++)
            {
                PrintString += "*";
                Console.WriteLine(PrintString);
            }
            return;
        }
        public static void ReverseStair(int steps)
        {
            string PrintString = new string('*', steps);
            for (int i = steps; i > 0; i--)
            {
                Console.WriteLine(PrintString.Substring(0, i));
            }
        }
    }
}
