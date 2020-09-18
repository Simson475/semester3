using System;

namespace CodeWars_Test
{
    public class IQ
    {
        public static int Test(string numbers)
        {
            int even = 0;
            int odd = 0;
            string[] NumberArray = numbers.Split(" ");
            int[] IntArray = new int[(numbers.Split(" ")).Length];
            for (int i = 0; i < NumberArray.Length; i++)
            {
                IntArray[i] = int.Parse(NumberArray[i]);
                if (IntArray[i] % 2 == 0) even++;
                else odd++;
            }
            return Array.IndexOf(IntArray, odd == 1 ? Array.Find(IntArray, ele => ele % 2 == 1) : Array.Find(IntArray, ele => ele % 2 == 0)) + 1;
        }
    }
}
