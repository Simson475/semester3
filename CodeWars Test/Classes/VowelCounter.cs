using System.Text.RegularExpressions;

namespace CodeWars_Test
{
    public static class VowelCounter
    {
        public static int GetVowelCount(string str)
        {
            return Regex.Matches(str, "[aeiouAEIOU]").Count;
        }
    }

}
