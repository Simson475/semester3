using System;
using System.Linq;

namespace CodeWars_Test
{
    public static class FindStrayNumber
    {
        public static int Stray(int[] numbers)
        {
            Array.Sort(numbers);
            return numbers[0] == numbers[1] ? numbers.Last() : numbers.First();
        }

        public static int StrayOld(int[] numbers)
        {
            int Previous = numbers[0];
            if (Previous != numbers[1])
            {
                return Previous == numbers[2] ? numbers[1] : Previous;
            }
            foreach (int item in numbers)
            {
                if (item != Previous) return item;
            }
            throw new Exception("invalid input");
        }
    }
}
