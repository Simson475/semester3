using System.Collections.Generic;
using System.Linq;

namespace OOP007Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class LinqPlays
    {
        public static List<int> LinqWhere(List<int> list)
        {
            return list.Where(a => a % 2 == 0).ToList();
        }
    }
    public delegate string StringJoin(string l, string r);
}
