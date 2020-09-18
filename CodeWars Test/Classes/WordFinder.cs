using System.Linq;

namespace CodeWars_Test
{
    public static class WordFinder
    {
        public static int FindShort(string s) => s.Split(" ").Min(s => s.Length);


        public static int FindShortOld(string s)
        {
            int Length = int.MaxValue;
            string[] Words = s.Split(" ");
            foreach (string item in Words)
            {
                if (item.Length < Length) Length = item.Length;
            }
            return Length;
        }
    }
}
