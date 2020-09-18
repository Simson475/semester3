using System;
using System.Text.RegularExpressions;

namespace CodeWars_Test
{
    public class Printer
    {
        public static string PrinterError(String s)
        {

            return $"{Regex.Matches(s, "[nopqrstuvwxyz]").Count}/{s.Length}";
        }
    }
}
