using System;

namespace CodeWars_Test
{
    internal class Digitizer
    {

        public static long[] Digitize(long n)
        {
            char[] test = n.ToString().ToCharArray();
            long[] result = new long[test.Length];
            Array.Reverse(test);
            for (int i = 0; i < test.Length; i++)
            {
                Int64.TryParse(test[i].ToString(), out result[i]);
            }

            return result;
        }
    }
}
