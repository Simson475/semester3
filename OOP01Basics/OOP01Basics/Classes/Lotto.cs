using System;

namespace OOP01
{
    public class Lotto
    {
        private static int[] DrawNumbers()
        {
            Random rnd = new Random();
            return new int[] { rnd.Next(99), rnd.Next(99), rnd.Next(99), rnd.Next(99), rnd.Next(99), rnd.Next(99), rnd.Next(99) };
        }
        public static void PrintWinners()
        {
            int[] LottoWinner = DrawNumbers();
            foreach (int Item in LottoWinner)
            {
                Console.Write($"{Item} ");
            }
            Console.WriteLine("");
        }
    };
}
