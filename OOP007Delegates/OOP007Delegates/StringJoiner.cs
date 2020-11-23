using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP007Delegates
{
    public static class StringJoiner
    {
        public static string Join3(string a, string b, string c, StringJoin stringJoiner)
        {
            return stringJoiner(stringJoiner(a, b), c);
        }
        public static string JoinAllString(List<string> stringList, Func<string, string, string> functionToUse)
        {
            return stringList.Aggregate(functionToUse);
        }
    }
}
