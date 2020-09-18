using System;

namespace CodeWars_Test
{
    public static class Calculator
    {
        public static int Factorial(int n)
        {
            int Value = 1;
            if (n < 0 || n > 12) throw new ArgumentOutOfRangeException();
            for (int i = 1; i <= n; i++)
            {
                Value *= i;
            }
            return Value;
        }
        public static int RecursiveFactorial(int n)
        {
            if (n < 0 || n > 12) throw new ArgumentOutOfRangeException();
            return n > 0 ? n * Factorial(n - 1) : 1;
        }
    }
}


