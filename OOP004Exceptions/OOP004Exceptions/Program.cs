using System;

namespace OOP004Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    HellPrinter.Print();

                }
                catch (OutOfTonerException)
                {
                    Console.WriteLine("Printer is out of toner, please change it and press any button to continue");
                    Console.ReadKey();
                }
                catch (OutOfPaperException)
                {
                    Console.WriteLine("Printer is out of Paper, please add more and press any button to continue");
                    Console.ReadKey();
                }
                catch (PaperJamException)
                {
                    Console.WriteLine("Printer is having a paper jam, when fixed, press any button to continue");
                    Console.ReadKey();
                }

            }
        }
    }
    static class HellPrinter
    {
        public static void Print()
        {
            Random Random = new Random();

            int Number = Random.Next(1, 4);
            switch (Number)
            {
                case 1:
                    throw new OutOfPaperException();
                case 2:
                    throw new OutOfTonerException();
                case 3:
                    throw new PaperJamException();
                default:
                    break;
            }
        }
    }
}

