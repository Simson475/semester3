using System;

namespace CodeWars_Test
{
    public class Summing
    {
        public static int[] TwoSum(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int SecondNumber = Array.IndexOf(numbers, target - numbers[i], i + 1);
                if (SecondNumber >= i) return new int[] { i, SecondNumber };
            }
            throw new Exception($"No two integers sum to {target}");
        }
    }
}
