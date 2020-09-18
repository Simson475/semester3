using System;
using System.ComponentModel.DataAnnotations;

namespace CodeWars_Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] arr = DirReduction.dirReduc(new string[] { "NORTH", "SOUTH", "WEST", "EAST", "NORTH" });
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
