using System;
using System.Linq;

namespace CodeWars_Test
{
    public class DuplicateCounter
    {
        public static int DuplicateCount(string str)
        {
            char[] CountFrom = str.ToLower().ToCharArray();
            char[] UniqueElements = CountFrom.Distinct().ToArray();
            Console.WriteLine(UniqueElements);
            Console.WriteLine(CountFrom);
            int MaxDuplicates = 0;

            foreach (char Item in UniqueElements)
            {
                if (CountFrom.Count(s => s == Item) > 1) MaxDuplicates++;
                Console.WriteLine(MaxDuplicates);
            }
            return MaxDuplicates;
        }
    }
}
